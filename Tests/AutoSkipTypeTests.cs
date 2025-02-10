#pragma warning disable 1591
using Mono.Cecil;
using Obfuscar;
using System.IO;
using Xunit;

namespace ObfuscarTests
{
    public class AutoSkipTypeTests
    {
        private MethodDefinition? FindByName(TypeDefinition typeDef, string name)
        {
            foreach (MethodDefinition method in typeDef.Methods)
            {
                if (method.Name == name)
                {
                    return method;
                }
            }

            Assert.Fail(string.Format("Expected to find method: {0}", name));
            return null; // never here
        }

        [Fact]
        public void CheckHidePrivateApiFalse()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='false' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition classBType = inAssmDef.MainModule.GetType("TestClasses.InternalClass");
            ObfuscatedClass classB = map.GetClass(new TypeKey(classBType));

            Assert.True(classB.Status == ObfuscationStatus.Skipped, "Internal class is obfuscated");

            TypeDefinition enumType = inAssmDef.MainModule.GetType("TestClasses.TestEnum");
            ObfuscatedClass enum1 = map.GetClass(new TypeKey(enumType));
            Assert.True(enum1.Status == ObfuscationStatus.Skipped, "Internal enum is obfuscated");

            TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses.PublicClass");
            ObfuscatedClass classA = map.GetClass(new TypeKey(classAType));
            MethodDefinition? classAmethod1 = this.FindByName(classAType, "PrivateMethod");
            MethodDefinition? classAmethod2 = this.FindByName(classAType, "PublicMethod");

            Assert.NotNull(classAmethod1);
            Assert.NotNull(classAmethod2);

            ObfuscatedThing classAMethod1 = map.GetMethod(new MethodKey(classAmethod1));
            ObfuscatedThing classAMethod2 = map.GetMethod(new MethodKey(classAmethod2));

            Assert.True(classA.Status == ObfuscationStatus.Renamed, "Public class is not obfuscated");
            Assert.True(classAMethod1.Status == ObfuscationStatus.Skipped, "private method is obfuscated.");
            Assert.True(classAMethod2.Status == ObfuscationStatus.Renamed, "pubilc method is not obfuscated.");
        }

        [Fact]
        public void CheckHidePrivateApiTrue()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";
            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition classBType = inAssmDef.MainModule.GetType("TestClasses.InternalClass");
            ObfuscatedClass classB = map.GetClass(new TypeKey(classBType));

            Assert.True(classB.Status == ObfuscationStatus.Renamed, "Internal class should have been obfuscated");

            TypeDefinition enumType = inAssmDef.MainModule.GetType("TestClasses.TestEnum");
            ObfuscatedClass enum1 = map.GetClass(new TypeKey(enumType));
            Assert.True(enum1.Status == ObfuscationStatus.Renamed, "Internal enum should have been obfuscated");
        }

        [Fact]
        public void CheckKeepPublicApiFalse()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses.PublicClass");
            MethodDefinition? classAmethod1 = this.FindByName(classAType, "PrivateMethod");
            MethodDefinition? classAmethod2 = this.FindByName(classAType, "PublicMethod");

            Assert.NotNull(classAmethod1);
            Assert.NotNull(classAmethod2);

            ObfuscatedThing classAMethod1 = map.GetMethod(new MethodKey(classAmethod1));
            ObfuscatedThing classAMethod2 = map.GetMethod(new MethodKey(classAmethod2));

            ObfuscatedClass classA = map.GetClass(new TypeKey(classAType));
            Assert.True(classA.Status == ObfuscationStatus.Renamed, "Public class should have been obfuscated");
            Assert.True(classAMethod1.Status == ObfuscationStatus.Renamed, "private method is not obfuscated.");
            Assert.True(classAMethod2.Status == ObfuscationStatus.Renamed, "pubilc method is not obfuscated.");

            MethodDefinition? protectedMethod = this.FindByName(classAType, "ProtectedMethod");

            Assert.NotNull(protectedMethod);

            ObfuscatedThing protectedAfter = map.GetMethod(new MethodKey(protectedMethod));
            Assert.True(protectedAfter.Status == ObfuscationStatus.Renamed, "protected method is not obfuscated.");
        }

        [Fact]
        public void CheckKeepPublicApiTrue()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='true' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscar.Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses.PublicClass");
            MethodDefinition? classAmethod1 = this.FindByName(classAType, "PrivateMethod");
            MethodDefinition? classAmethod2 = this.FindByName(classAType, "PublicMethod");
            MethodDefinition? classAmethod3 = this.FindByName(classAType, "InternalProtectedMethod");

            Assert.NotNull(classAmethod1);
            Assert.NotNull(classAmethod2);
            Assert.NotNull(classAmethod3);

            ObfuscatedThing classAMethod1 = map.GetMethod(new MethodKey(classAmethod1));
            ObfuscatedThing classAMethod2 = map.GetMethod(new MethodKey(classAmethod2));
            ObfuscatedThing classAMethod3 = map.GetMethod(new MethodKey(classAmethod3));
            ObfuscatedClass classA = map.GetClass(new TypeKey(classAType));
            Assert.True(classA.Status == ObfuscationStatus.Skipped, "Public class shouldn't have been obfuscated");
            Assert.True(classAMethod1.Status == ObfuscationStatus.Renamed, "private method is not obfuscated.");
            Assert.True(classAMethod2.Status == ObfuscationStatus.Skipped, "pubilc method is obfuscated.");
            Assert.True(classAMethod3.Status == ObfuscationStatus.Skipped, "internal protected method is obfuscated.");

            MethodDefinition? protectedMethod = this.FindByName(classAType, "ProtectedMethod");

            Assert.NotNull(protectedMethod);

            ObfuscatedThing protectedAfter = map.GetMethod(new MethodKey(protectedMethod));
            Assert.True(protectedAfter.Status == ObfuscationStatus.Skipped, "protected method is obfuscated.");
        }

        [Fact]
        public void CheckSkipNamespace()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"<SkipNamespace name='TestClasses1' />" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscar.Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses1.PublicClass");
            ObfuscatedClass classA = map.GetClass(new TypeKey(classAType));
            Assert.True(classA.Status == ObfuscationStatus.Skipped, "Public class shouldn't have been obfuscated");
        }

        [Fact]
        public void CheckSkipEnum()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"<SkipType name='TestClasses.TestEnum' />" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscar.Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(
                Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition enumType = inAssmDef.MainModule.GetType("TestClasses.TestEnum");
            ObfuscatedClass enum1 = map.GetClass(new TypeKey(enumType));
            Assert.True(enum1.Status == ObfuscationStatus.Skipped, "Internal enum is obfuscated");
        }

        [Fact]
        public void CheckSkipAllEnums()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithTypes.dll'>" +
                @"<SkipEnums value='true' />" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            Obfuscator obfuscator = TestHelper.BuildAndObfuscate("AssemblyWithTypes", string.Empty, xml);
            ObfuscationMap map = obfuscator.Mapping;

            string assmName = "AssemblyWithTypes.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(TestHelper.InputPath, assmName));

            TypeDefinition enumType = inAssmDef.MainModule.GetType("TestClasses.TestEnum");
            ObfuscatedClass enum1 = map.GetClass(new TypeKey(enumType));
            Assert.True(enum1.Status == ObfuscationStatus.Skipped, "Internal enum is obfuscated");
        }
    }
}
#pragma warning restore 1591
