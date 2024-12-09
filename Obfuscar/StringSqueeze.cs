using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Obfuscar.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obfuscar
{
    internal class StringSqueeze
    {
        /// <summary>
        /// Store the class to generate so we can generate it later on.
        /// </summary>
        private class StringSqueezeData
        {
            public StringSqueezeData
                ( TypeDefinition newType
                , FieldDefinition dataConstantField
                , FieldDefinition dataField
                , FieldDefinition stringArrayField
                , MethodDefinition stringGetterMethodDefinition
                , TypeDefinition structType
                )
            {
                this.NewType = newType;
                this.DataConstantField = dataConstantField;
                this.DataField = dataField;
                this.StringArrayField = stringArrayField;
                this.StringGetterMethodDefinition = stringGetterMethodDefinition;
                this.StructType = structType;
            }

            public TypeDefinition NewType { get; set; }

            public TypeDefinition StructType { get; set; }

            public FieldDefinition DataConstantField { get; set; }

            public FieldDefinition DataField { get; set; }

            public FieldDefinition StringArrayField { get; set; }

            public MethodDefinition StringGetterMethodDefinition { get; set; }

            public int NameIndex { get; set; }

            public int StringIndex { get; set; }

            // Array of bytes receiving the obfuscated strings in UTF8 format.
            public List<byte> DataBytes { get; } = new List<byte>();
        }

        private TypeReference? SystemStringTypeReference { get; set; }

        private TypeReference? SystemVoidTypeReference { get; set; }

        private TypeReference? SystemByteTypeReference { get; set; }

        private TypeReference? SystemIntTypeReference { get; set; }

        private TypeReference? SystemObjectTypeReference { get; set; }

        private TypeReference? SystemValueTypeTypeReference { get; set; }

        private MethodReference? InitializeArrayMethod { get; set; }

        private TypeDefinition? EncodingTypeDefinition { get; set; }

        private readonly List<StringSqueezeData> newDatas = new List<StringSqueezeData>();

        private StringSqueezeData? mostRecentData;

        private readonly Dictionary<string, MethodDefinition> _methodByString = new Dictionary<string, MethodDefinition>();

        private readonly AssemblyDefinition library;
        private bool isInitialized;
        private bool isDisabled;

        public StringSqueeze(AssemblyDefinition library)
        {
            this.library = library;
        }

        private void Initialize()
        {
            if (this.isInitialized)
            {
                return;
            }

            this.isInitialized = true;
            AssemblyDefinition library = this.library;

            //
            // We get the most used type references.
            //
            this.SystemVoidTypeReference = library.MainModule.TypeSystem.Void;
            this.SystemStringTypeReference = library.MainModule.TypeSystem.String;
            this.SystemByteTypeReference = library.MainModule.TypeSystem.Byte;
            this.SystemIntTypeReference = library.MainModule.TypeSystem.Int32;
            this.SystemObjectTypeReference = library.MainModule.TypeSystem.Object;
            this.SystemValueTypeTypeReference = new TypeReference("System", "ValueType", library.MainModule, library.MainModule.TypeSystem.CoreLibrary);

            this.EncodingTypeDefinition = new TypeReference
                                            ( "System.Text"
                                            , "Encoding"
                                            , library.MainModule
                                            , library.MainModule.TypeSystem.CoreLibrary
                                            )
                                            .Resolve()
                                            ;

            if (this.EncodingTypeDefinition == null)
            {
                this.isDisabled = true;
                return;
            }

            //
            // IMPORTANT: this runtime helpers resolution must be after encoding resolution.
            //
            TypeDefinition runtimeHelpers = new TypeReference("System.Runtime.CompilerServices", "RuntimeHelpers",library.MainModule, library.MainModule.TypeSystem.CoreLibrary).Resolve();

            this.InitializeArrayMethod = library.MainModule.ImportReference(runtimeHelpers.Methods.FirstOrDefault(method => method.Name == "InitializeArray"));
        }

        private StringSqueezeData GetNewType()
        {
            StringSqueezeData data;

            if (this.mostRecentData != null && this.mostRecentData.StringIndex < 65_000 /* maximum number of methods per class allowed by the CLR */)
            {
                data = this.mostRecentData;
            }
            else
            {
                if (this.EncodingTypeDefinition == null)
                {
                    throw new ObfuscarException(MessageCodes.dbr038, "Encoding type definition not set.");
                }

                AssemblyDefinition library = this.library;

                MethodReference? encodingGetUtf8Method = library.MainModule.ImportReference(this.EncodingTypeDefinition.Methods.FirstOrDefault(method => method.Name == "get_UTF8"));
                MethodReference? encodingGetStringMethod = library.MainModule.ImportReference(this.EncodingTypeDefinition.Methods.FirstOrDefault(method => method.FullName == "System.String System.Text.Encoding::GetString(System.Byte[],System.Int32,System.Int32)"));

                //
                // New static class with a method for each unique string we substitute.
                //
                string guid = Guid.NewGuid().ToString().ToUpper();

                TypeDefinition newType = new TypeDefinition
                                            ( "<PrivateImplementationDetails>{" + guid + "}"
                                            , Guid.NewGuid().ToString().ToUpper()
                                            , TypeAttributes.BeforeFieldInit
                                              | TypeAttributes.AutoClass
                                              | TypeAttributes.AnsiClass
                                              | TypeAttributes.BeforeFieldInit
                                            , this.SystemObjectTypeReference
                                            );

                // Add struct for constant byte array data
                TypeDefinition structType = new TypeDefinition
                                                ( "1{" + guid + "}", "2"
                                                , TypeAttributes.ExplicitLayout
                                                  | TypeAttributes.AnsiClass
                                                  | TypeAttributes.Sealed
                                                  | TypeAttributes.NestedPrivate
                                                , this.SystemValueTypeTypeReference
                                                );
                structType.PackingSize = 1;
                newType.NestedTypes.Add(structType);

                //
                // Add field with constant string data.
                //
                FieldDefinition dataConstantField = new FieldDefinition
                                                        ( "3"
                                                        , FieldAttributes.HasFieldRVA | FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.Assembly
                                                        , structType
                                                        );
                newType.Fields.Add(dataConstantField);

                //
                // Add data field where constructor copies the data to.
                //
                FieldDefinition dataField = new FieldDefinition
                                                ( "4"
                                                , FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.Assembly
                                                , new ArrayType(this.SystemByteTypeReference)
                                                );

                newType.Fields.Add(dataField);

                //
                // Add string array of deobfuscated strings.
                //
                FieldDefinition stringArrayField = new FieldDefinition
                                                    ( "5"
                                                    , FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.Assembly
                                                    , new ArrayType(this.SystemStringTypeReference)
                                                    );

                newType.Fields.Add(stringArrayField);

                //
                // Add method to extract a string from the byte array. It is called by the indiviual string getter methods we add later to the class.
                //
                MethodDefinition stringGetterMethodDefinition = new MethodDefinition
                                                                    ( "6"
                                                                    , MethodAttributes.Static | MethodAttributes.Private | MethodAttributes.HideBySig
                                                                    , this.SystemStringTypeReference
                                                                    );

                stringGetterMethodDefinition.Parameters.Add(new ParameterDefinition(this.SystemIntTypeReference));
                stringGetterMethodDefinition.Parameters.Add(new ParameterDefinition(this.SystemIntTypeReference));
                stringGetterMethodDefinition.Parameters.Add(new ParameterDefinition(this.SystemIntTypeReference));

                stringGetterMethodDefinition.Body.Variables.Add(new VariableDefinition(this.SystemStringTypeReference));

                ILProcessor worker3 = stringGetterMethodDefinition.Body.GetILProcessor();

                worker3.Emit(OpCodes.Call, encodingGetUtf8Method);
                worker3.Emit(OpCodes.Ldsfld, dataField);
                worker3.Emit(OpCodes.Ldarg_1);
                worker3.Emit(OpCodes.Ldarg_2);
                worker3.Emit(OpCodes.Callvirt, encodingGetStringMethod);
                worker3.Emit(OpCodes.Stloc_0);

                worker3.Emit(OpCodes.Ldsfld, stringArrayField);
                worker3.Emit(OpCodes.Ldarg_0);
                worker3.Emit(OpCodes.Ldloc_0);
                worker3.Emit(OpCodes.Stelem_Ref);

                worker3.Emit(OpCodes.Ldloc_0);
                worker3.Emit(OpCodes.Ret);
                newType.Methods.Add(stringGetterMethodDefinition);

                data = new StringSqueezeData
                        (newType
                        , dataConstantField
                        , dataField
                        , stringArrayField
                        , stringGetterMethodDefinition
                        , structType
                        );

                this.newDatas.Add(data);

                this.mostRecentData = data;
            }

            return data;
        }

        public void Squeeze()
        {
            if (!this.isInitialized)
                return;

            if (this.isDisabled)
                return;

            foreach (StringSqueezeData data in this.newDatas)
            {
                //
                // Now that we know the total size of the byte array, we can update the struct size and store it in the constant field.
                //
                data.StructType.ClassSize = data.DataBytes.Count;

                for (int i = 0; i < data.DataBytes.Count; i++)
                {
                    data.DataBytes[i] = (byte)(data.DataBytes[i] ^ (byte)i ^ 0xAA);
                }

                data.DataConstantField.InitialValue = data.DataBytes.ToArray();

                //
                // Add static constructor which initializes the dataField from the constant data field.
                //
                MethodDefinition ctorMethodDefinition = new MethodDefinition
                                                            ( ".cctor"
                                                            , MethodAttributes.Static
                                                              | MethodAttributes.Private
                                                              | MethodAttributes.HideBySig
                                                              | MethodAttributes.SpecialName
                                                              | MethodAttributes.RTSpecialName
                                                            , this.SystemVoidTypeReference
                                                            );

                data.NewType.Methods.Add(ctorMethodDefinition);
                ctorMethodDefinition.Body = new MethodBody(ctorMethodDefinition);
                ctorMethodDefinition.Body.Variables.Add(new VariableDefinition(this.SystemIntTypeReference));

                ILProcessor worker2 = ctorMethodDefinition.Body.GetILProcessor();
                worker2.Emit(OpCodes.Ldc_I4, data.StringIndex);
                worker2.Emit(OpCodes.Newarr, this.SystemStringTypeReference);
                worker2.Emit(OpCodes.Stsfld, data.StringArrayField);


                worker2.Emit(OpCodes.Ldc_I4, data.DataBytes.Count);
                worker2.Emit(OpCodes.Newarr, this.SystemByteTypeReference);
                worker2.Emit(OpCodes.Dup);
                worker2.Emit(OpCodes.Ldtoken, data.DataConstantField);
                worker2.Emit(OpCodes.Call, this.InitializeArrayMethod);
                worker2.Emit(OpCodes.Stsfld, data.DataField);

                worker2.Emit(OpCodes.Ldc_I4_0);
                worker2.Emit(OpCodes.Stloc_0);

                Instruction backlabel1 = worker2.Create(OpCodes.Br_S, ctorMethodDefinition.Body.Instructions[0]);
                worker2.Append(backlabel1);
                Instruction label2 = worker2.Create(OpCodes.Ldsfld, data.DataField);
                worker2.Append(label2);
                worker2.Emit(OpCodes.Ldloc_0);
                worker2.Emit(OpCodes.Ldsfld, data.DataField);
                worker2.Emit(OpCodes.Ldloc_0);
                worker2.Emit(OpCodes.Ldelem_U1);
                worker2.Emit(OpCodes.Ldloc_0);
                worker2.Emit(OpCodes.Xor);
                worker2.Emit(OpCodes.Ldc_I4, 0xAA);
                worker2.Emit(OpCodes.Xor);
                worker2.Emit(OpCodes.Conv_U1);
                worker2.Emit(OpCodes.Stelem_I1);
                worker2.Emit(OpCodes.Ldloc_0);
                worker2.Emit(OpCodes.Ldc_I4_1);
                worker2.Emit(OpCodes.Add);
                worker2.Emit(OpCodes.Stloc_0);
                backlabel1.Operand = worker2.Create(OpCodes.Ldloc_0);
                worker2.Append((Instruction)backlabel1.Operand);
                worker2.Emit(OpCodes.Ldsfld, data.DataField);
                worker2.Emit(OpCodes.Ldlen);
                worker2.Emit(OpCodes.Conv_I4);
                worker2.Emit(OpCodes.Clt);
                worker2.Emit(OpCodes.Brtrue, label2);
                worker2.Emit(OpCodes.Ret);

                this.library.MainModule.Types.Add(data.NewType);
            }
        }

        public void ProcessStrings
            ( MethodDefinition method
            , AssemblyInfo info
            , Project project
            )
        {
            if (info.ShouldSkipStringHiding
                    ( new MethodKey(method)
                    , project.InheritMap
                    , project.Settings.HideStrings
                    )
                || method.Body == null
               )
            {
                return;
            }

            this.Initialize();

            if (this.isDisabled)
            {
                return;
            }

            //
            // Unroll short form instructions so they can be auto-fixed by Cecil
            // automatically when instructions are inserted/replaced.
            //
            method.Body.SimplifyMacros();
            ILProcessor worker = method.Body.GetILProcessor();

            //
            // Make a dictionary of all instructions to replace and their replacement.
            //
            Dictionary<Instruction, LdStrInstructionReplacement> oldToNewStringInstructions = new Dictionary<Instruction, LdStrInstructionReplacement>();

            for (int index = 0; index < method.Body.Instructions.Count; index++)
            {
                Instruction instruction = method.Body.Instructions[index];

                if (instruction.OpCode == OpCodes.Ldstr && instruction.Operand is string operand)
                {
                    if (!this._methodByString.TryGetValue(operand, out MethodDefinition? individualStringMethodDefinition))
                    {
                        StringSqueezeData data = this.GetNewType();

                        string methodName = NameMaker.UniqueName(data.NameIndex++);

                        //
                        // Add the string to the data array.
                        //
                        byte[] stringBytes = Encoding.UTF8.GetBytes(operand);
                        int start = data.DataBytes.Count;
                        data.DataBytes.AddRange(stringBytes);
                        int count = data.DataBytes.Count - start;

                        //
                        // Add a method for this string to our new class.
                        //
                        individualStringMethodDefinition = new MethodDefinition
                                                            ( methodName
                                                            , MethodAttributes.Static | MethodAttributes.Public | MethodAttributes.HideBySig
                                                            , this.SystemStringTypeReference
                                                            );

                        individualStringMethodDefinition.Body = new MethodBody(individualStringMethodDefinition);
                        ILProcessor worker4 = individualStringMethodDefinition.Body.GetILProcessor();

                        worker4.Emit(OpCodes.Ldsfld, data.StringArrayField);
                        worker4.Emit(OpCodes.Ldc_I4, data.StringIndex);
                        worker4.Emit(OpCodes.Ldelem_Ref);
                        worker4.Emit(OpCodes.Dup);

                        Instruction label20 = worker4.Create
                                                ( OpCodes.Brtrue_S
                                                , data.StringGetterMethodDefinition.Body.Instructions[0]
                                                );
                        worker4.Append(label20);

                        worker4.Emit(OpCodes.Pop);
                        worker4.Emit(OpCodes.Ldc_I4, data.StringIndex);
                        worker4.Emit(OpCodes.Ldc_I4, start);
                        worker4.Emit(OpCodes.Ldc_I4, count);
                        worker4.Emit(OpCodes.Call, data.StringGetterMethodDefinition);

                        label20.Operand = worker4.Create(OpCodes.Ret);
                        worker4.Append((Instruction)label20.Operand);

                        data.NewType.Methods.Add(individualStringMethodDefinition);
                        this._methodByString.Add(operand, individualStringMethodDefinition);

                        if (this.mostRecentData == null)
                        {
                            throw new ObfuscarException(MessageCodes.dbr039, "Most recent data not set.");
                        }

                        this.mostRecentData.StringIndex++;
                    }

                    //
                    // Replace Ldstr with Call.
                    //
                    Instruction newinstruction = worker.Create(OpCodes.Call, individualStringMethodDefinition);

                    oldToNewStringInstructions.Add(instruction, new LdStrInstructionReplacement(index, newinstruction));
                }
            }

            worker.ReplaceAndFixReferences(method.Body, oldToNewStringInstructions);

            //
            // Optimize method back.
            //
            if (project.Settings.OptimizeMethods)
            {
                method.Body.Optimize();
            }
        }
    }
}
