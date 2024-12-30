#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

// <copyright>
// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>

#endregion

using ILSpy.BamlDecompiler.Baml;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Obfuscar.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace Obfuscar
{
    internal class AssemblyInfo
    {
        private const string MESAGE_FROM_FIELD_RULE_FORCE = "field rule force in configuration";
        private const string MESAGE_FROM_FIELD_RULE_SKIP = "field rule skip in configuration";
        private const string MESSAGE_FROM_ATTRIBUTE = "attribute";
        private const string MESSAGE_FROM_EVENT_RULE_FORCE = "event rule force in configuration";
        private const string MESSAGE_FROM_EVENT_RULE_SKIP = "event rule skip in configuration";
        private const string MESSAGE_FROM_FORCE_METHODS = "method rule in configuration";
        private const string MESSAGE_FROM_FORCE_PROPERTIES = "property rule force in configuration";
        private const string MESSAGE_FROM_FORCE_TYPES = "type rule in configuration";
        private const string MESSAGE_FROM_HIDE_PRIVATE_API = "HidePrivateApi option in configuration";
        private const string MESSAGE_FROM_KEEP_PUBLIC_API = "KeepPublicApi option in configuration";
        private const string MESSAGE_FROM_MARKED_ONLY = "MarkedOnly option in configuration";
        private const string MESSAGE_FROM_RUNTIME_METHOD = "runtime method";
        private const string MESSAGE_FROM_RUNTIME_SPECIAL_NAME = "runtime special name";
        private const string MESSAGE_FROM_SHOULD_FORCE = "namespace rule to force in configuration";
        private const string MESSAGE_FROM_SHOULD_SKIP = "namespace rule to skip in configuration";
        private const string MESSAGE_FROM_SKIP_ENUMERS = "enum rule in configuration";
        private const string MESSAGE_FROM_SKIP_PROPERTIES = "property rule skip in configuration";
        private const string MESSAGE_FROM_SKIPPING_EVENTS = "skipping events";
        private const string MESSAGE_FROM_SKIPPING_PROPERTIES = "skipping properties";
        private const string MESSAGE_FROM_SPECIAL_NAME = "special name";
        private const string MESSAGE_FROM_TYPE_ATTRIBUTE = "type attribute";
        private const string MESSAGE_FROM_XAML_USE = "method used in XAML";

        private readonly Project project;
        private readonly PredicateCollection<string> skipNamespaces = new PredicateCollection<string>();
        private readonly PredicateCollection<TypeKey> skipTypes = new PredicateCollection<TypeKey>();
        private readonly PredicateCollection<MethodKey> skipMethods = new PredicateCollection<MethodKey>();
        private readonly PredicateCollection<FieldKey> skipFields = new PredicateCollection<FieldKey>();
        private readonly PredicateCollection<PropertyKey> skipProperties = new PredicateCollection<PropertyKey>();
        private readonly PredicateCollection<EventKey> skipEvents = new PredicateCollection<EventKey>();
        private readonly PredicateCollection<string> forceNamespaces = new PredicateCollection<string>();
        private readonly PredicateCollection<TypeKey> forceTypes = new PredicateCollection<TypeKey>();
        private readonly PredicateCollection<MethodKey> forceMethods = new PredicateCollection<MethodKey>();
        private readonly PredicateCollection<FieldKey> forceFields = new PredicateCollection<FieldKey>();
        private readonly PredicateCollection<PropertyKey> forceProperties = new PredicateCollection<PropertyKey>();
        private readonly PredicateCollection<EventKey> forceEvents = new PredicateCollection<EventKey>();
        private readonly PredicateCollection<MethodKey> skipStringHiding = new PredicateCollection<MethodKey>();
        private readonly PredicateCollection<MethodKey> forceStringHiding = new PredicateCollection<MethodKey>();
        private List<TypeReference>? unrenamedTypeReferences;
        private List<MemberReference>? unrenamedReferences;
        private string? filename;
        private AssemblyDefinition? definition;
        private string? name;
        private bool skipEnums;

        public string? OutputFileName { get; set; }

        public bool Exclude { get; set; }

        public Dictionary<string, BamlDocument>? XamlFiles { get; private set; }

        public Dictionary<string, HashSet<string>>? XamlMethodsToExclude { get; private set; }

        private bool initialized;

        //
        // To create: use FromXml.
        //
        private AssemblyInfo(Project project)
        {
            this.project = project;
        }

        public static AssemblyInfo FromXml(Project project, XElement reader, string file, Variables vars)
        {
            AssemblyInfo info = new AssemblyInfo(project);

            //
            // Pull out the file attribute, but don't process anything empty.
            //
            info.LoadAssembly(file);

            string isExcluded = Helper.GetAttribute(reader, "Exclude", vars);
            if ((isExcluded.Length > 0) && (isExcluded.ToLowerInvariant() == "true"))
            {
                info.Exclude = true;
            }

            if (!reader.IsEmpty)
            {
                FromXmlReadNode(reader, project, vars, info);
            }

            return info;
        }

        private static void FromXmlReadNode(XElement element, Project project, Variables vars, AssemblyInfo info)
        {
            foreach (XElement reader in element.Elements())
            {
                string name = Helper.GetAttribute(reader, "name", vars);
                string rxStr = Helper.GetAttribute(reader, "rx");

                Regex? rx = null;
                if (!string.IsNullOrEmpty(rxStr))
                {
                    rx = new Regex(rxStr);
                }

                string isStaticStr = Helper.GetAttribute(reader, "static", vars);
                bool? isStatic = null;
                if (!string.IsNullOrEmpty(isStaticStr))
                {
                    isStatic = Convert.ToBoolean(isStaticStr);
                }

                string isSerializableStr = Helper.GetAttribute(reader, "serializable", vars);
                bool? isSerializable = null;
                if (!string.IsNullOrEmpty(isSerializableStr))
                {
                    isSerializable = Convert.ToBoolean(isSerializableStr);
                }

                string attrib = Helper.GetAttribute(reader, "attrib", vars);
                string inherits = Helper.GetAttribute(reader, "typeinherits", vars);
                string type = Helper.GetAttribute(reader, "type", vars);
                string typeattrib = Helper.GetAttribute(reader, "typeattrib", vars);

                string val;
                switch (reader.Name.LocalName)
                {
                    case "Include":
                        {
                            Project.ReadIncludeTag(reader, project, (includeReader, proj) => FromXmlReadNode(includeReader, proj, vars, info));
                            break;
                        }
                    case "SkipNamespace":
                        {
                            if (rx != null)
                            {
                                info.skipNamespaces.Add(new NamespaceTester(rx));
                            }
                            else
                            {
                                info.skipNamespaces.Add(new NamespaceTester(name));
                            }
                            break;
                        }
                    case "ForceNamespace":
                        {
                            if (rx != null)
                            {
                                info.forceNamespaces.Add(new NamespaceTester(rx));
                            }
                            else
                            {
                                info.forceNamespaces.Add(new NamespaceTester(name));
                            }
                            break;
                        }
                    case "SkipType":
                        {
                            TypeAffectFlags skipFlags = TypeAffectFlags.SkipNone;

                            val = Helper.GetAttribute(reader, "skipMethods", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                skipFlags |= TypeAffectFlags.AffectMethod;
                            }

                            val = Helper.GetAttribute(reader, "skipStringHiding", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                skipFlags |= TypeAffectFlags.AffectString;
                            }

                            val = Helper.GetAttribute(reader, "skipFields", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                skipFlags |= TypeAffectFlags.AffectField;
                            }

                            val = Helper.GetAttribute(reader, "skipProperties", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                skipFlags |= TypeAffectFlags.AffectProperty;
                            }

                            val = Helper.GetAttribute(reader, "skipEvents", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                skipFlags |= TypeAffectFlags.AffectEvent;
                            }

                            if (rx != null)
                            {
                                info.skipTypes.Add(new TypeTester(rx, skipFlags, attrib, inherits, isStatic, isSerializable));
                            }
                            else
                            {
                                info.skipTypes.Add(new TypeTester(name, skipFlags, attrib, inherits, isStatic, isSerializable));
                            }
                            break;
                        }
                    case "ForceType":
                        {
                            TypeAffectFlags forceFlags = TypeAffectFlags.SkipNone;

                            val = Helper.GetAttribute(reader, "forceMethods", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                forceFlags |= TypeAffectFlags.AffectMethod;
                            }

                            val = Helper.GetAttribute(reader, "forceStringHiding", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                forceFlags |= TypeAffectFlags.AffectString;
                            }

                            val = Helper.GetAttribute(reader, "forceFields", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                forceFlags |= TypeAffectFlags.AffectField;
                            }

                            val = Helper.GetAttribute(reader, "forceProperties", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                forceFlags |= TypeAffectFlags.AffectProperty;
                            }

                            val = Helper.GetAttribute(reader, "forceEvents", vars);
                            if (val.Length > 0 && Convert.ToBoolean(val))
                            {
                                forceFlags |= TypeAffectFlags.AffectEvent;
                            }

                            if (rx != null)
                            {
                                info.forceTypes.Add(new TypeTester(rx, forceFlags, attrib, inherits, isStatic, isSerializable));
                            }
                            else
                            {
                                info.forceTypes.Add(new TypeTester(name, forceFlags, attrib, inherits, isStatic, isSerializable));
                            }
                            break;
                        }
                    case "SkipMethod":
                        {
                            if (rx != null)
                            {
                                info.skipMethods.Add(new MethodTester(rx, type, attrib, typeattrib, inherits, isStatic));
                            }
                            else
                            {
                                info.skipMethods.Add(new MethodTester(name, type, attrib, typeattrib, inherits, isStatic));
                            }
                            break;
                        }
                    case "ForceMethod":
                        {
                            if (rx != null)
                            {
                                info.forceMethods.Add(new MethodTester(rx, type, attrib, typeattrib, inherits, isStatic));
                            }
                            else
                            {
                                info.forceMethods.Add(new MethodTester(name, type, attrib, typeattrib, inherits, isStatic));
                            }
                            break;
                        }
                    case "SkipStringHiding":
                        {
                            if (rx != null)
                            {
                                info.skipStringHiding.Add(new MethodTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.skipStringHiding.Add(new MethodTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "ForceStringHiding":
                        {
                            if (rx != null)
                            {
                                info.forceStringHiding.Add(new MethodTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.forceStringHiding.Add(new MethodTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "SkipField":
                        {
                            string decorator = Helper.GetAttribute(reader, "decorator", vars);

                            if (rx != null)
                            {
                                info.skipFields.Add(new FieldTester(rx, type, attrib, typeattrib, inherits, decorator, isStatic, isSerializable));
                            }
                            else
                            {
                                info.skipFields.Add(new FieldTester(name, type, attrib, typeattrib, inherits, decorator, isStatic, isSerializable));
                            }
                            break;
                        }
                    case "ForceField":
                        {
                            string decorator1 = Helper.GetAttribute(reader, "decorator", vars);

                            if (rx != null)
                            {
                                info.forceFields.Add(new FieldTester(rx, type, attrib, typeattrib, inherits, decorator1, isStatic, isSerializable));
                            }
                            else
                            {
                                info.forceFields.Add(new FieldTester(name, type, attrib, typeattrib, inherits, decorator1, isStatic, isSerializable));
                            }
                            break;
                        }
                    case "SkipProperty":
                        {
                            if (rx != null)
                            {
                                info.skipProperties.Add(new PropertyTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.skipProperties.Add(new PropertyTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "ForceProperty":
                        {
                            if (rx != null)
                            {
                                info.forceProperties.Add(new PropertyTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.forceProperties.Add(new PropertyTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "SkipEvent":
                        {
                            if (rx != null)
                            {
                                info.skipEvents.Add(new EventTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.skipEvents.Add(new EventTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "ForceEvent":
                        {
                            if (rx != null)
                            {
                                info.forceEvents.Add(new EventTester(rx, type, attrib, typeattrib));
                            }
                            else
                            {
                                info.forceEvents.Add(new EventTester(name, type, attrib, typeattrib));
                            }
                            break;
                        }
                    case "SkipEnums":
                        {
                            string skipEnumsValue = Helper.GetAttribute(reader, "value");
                            info.skipEnums = skipEnumsValue.Length > 0 && Convert.ToBoolean(skipEnumsValue);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Called by project to finish initializing the assembly.
        /// </summary>
        internal void Init()
        {
            this.unrenamedReferences = new List<MemberReference>();

            IEnumerable<MemberReference> items = this.GetMemberReferences();

            foreach (MemberReference member in items)
            {
                // FIXME: Figure out why these exist if they are never used.
                // MethodReference mr = member as MethodReference;
                // FieldReference fr = member as FieldReference;
                if (this.project.Contains(member.DeclaringType))
                {
                    this.unrenamedReferences.Add(member);
                }
            }

            HashSet<TypeReference> typerefs = new HashSet<TypeReference>();

            foreach (TypeReference type in this.Definition.MainModule.GetTypeReferences())
            {
                if (type.FullName == Obfuscator.AutoGeneratedModuleName)
                {
                    continue;
                }

                if (this.project.Contains(type))
                {
                    typerefs.Add(type);
                }
            }

            // Type references in CustomAttributes
            List<CustomAttribute> customattributes = new List<CustomAttribute>();

            customattributes.AddRange(this.Definition.CustomAttributes);

            foreach (TypeDefinition type in this.GetAllTypeDefinitions())
            {
                customattributes.AddRange(type.CustomAttributes);

                foreach (MethodDefinition methoddef in type.Methods)
                {
                    customattributes.AddRange(methoddef.CustomAttributes);
                }
                foreach (FieldDefinition fielddef in type.Fields)
                {
                    customattributes.AddRange(fielddef.CustomAttributes);
                }
                foreach (EventDefinition eventdef in type.Events)
                {
                    customattributes.AddRange(eventdef.CustomAttributes);
                }
                foreach (PropertyDefinition propertydef in type.Properties)
                {
                    customattributes.AddRange(propertydef.CustomAttributes);
                }

                foreach (CustomAttribute customattribute in customattributes)
                {
                    // Check Constructor and named parameter for argument of type "System.Type". i.e. typeof()
                    List<CustomAttributeArgument> customattributearguments = new List<CustomAttributeArgument>();
                    customattributearguments.AddRange(customattribute.ConstructorArguments);
                    foreach (CustomAttributeNamedArgument namedargument in customattribute.Properties)
                    {
                        customattributearguments.Add(namedargument.Argument);
                    }

                    foreach (CustomAttributeArgument ca in customattributearguments)
                    {
                        if (ca.Type.FullName == "System.Type" && ca.Value != null)
                        {
                            typerefs.Add((TypeReference)ca.Value);
                        }
                    }
                }

                customattributes.Clear();
            }

            this.unrenamedTypeReferences = new List<TypeReference>(typerefs);

            this.XamlFiles = this.GetXamlDocuments(this.Definition, this.project.Settings.AnalyzeXaml);

            this.XamlMethodsToExclude = this.GetXamlMethodsToExclude(this.XamlFiles);

            this.initialized = true;
        }

        private Dictionary<string, HashSet<string>> GetXamlMethodsToExclude(Dictionary<string, BamlDocument> xamlFiles)
        {
            Dictionary<string, HashSet<string>> list = new Dictionary<string, HashSet<string>>(xamlFiles.Count());

            foreach (KeyValuePair<string, BamlDocument> kvp in xamlFiles)
            {
                string typeName = kvp.Key;
                HashSet<string> methods = new HashSet<string>();

                foreach (BamlRecord bamlRecord in kvp.Value)
                {
                    switch (bamlRecord)
                    {
                        case PropertyWithConverterRecord pwcr:
                            {
                                if (!string.IsNullOrEmpty(pwcr.Value))
                                {
                                    methods.Add(pwcr.Value);
                                }

                                break;
                            }
                    }
                }

                list.Add(typeName, methods);
            }

            return list;
        }

        private Dictionary<string, BamlDocument> GetXamlDocuments(AssemblyDefinition library, bool analyzeXaml)
        {
            Dictionary<string, BamlDocument> result = new Dictionary<string, BamlDocument>();

            if (!analyzeXaml)
            {
                return result;
            }

            foreach (Resource res in library.MainModule.Resources)
            {
                if (res is not EmbeddedResource embed)
                {
                    continue;
                }

                string[] embedNameExtensionsToInclude = [ ".resources"
                                                        ];

                string? extensionOfEmbedName = Path.GetExtension(embed.Name);

                if (!embedNameExtensionsToInclude.Contains(extensionOfEmbedName))
                {
                    continue;
                }

                Stream s = embed.GetResourceStream();
                s.Position = 0;

                try
                {
                    ResourceReader reader = new ResourceReader(s);

                    foreach (DictionaryEntry entry in reader.Cast<DictionaryEntry>().OrderBy(e => e.Key.ToString()))
                    {
                        if (entry.Key.ToString()?.EndsWith(".baml", StringComparison.OrdinalIgnoreCase) ?? false)
                        {
                            Stream stream;

                            if (entry.Value is Stream st)
                            {
                                stream = st;
                            }
                            else if (entry.Value is byte[] b)
                            {
                                stream = new MemoryStream(b);
                            }
                            else
                            {
                                continue;
                            }

                            try
                            {
                                BamlDocument document = BamlReader.ReadDocument(stream, CancellationToken.None);
                                string? typeName = this.GetTypeName(document);

                                result.Add(typeName, document);
                            }
                            catch (ArgumentException)
                            {
                            }
                            catch (FileNotFoundException)
                            {
                            }
                        }
                    }
                }
                catch (NotSupportedException)
                {
                    s.Position = 0;

                    System.Resources.Extensions.DeserializingResourceReader reader = new System.Resources.Extensions.DeserializingResourceReader(s);

                    foreach (DictionaryEntry entry in reader.Cast<DictionaryEntry>().OrderBy(e => e.Key.ToString()))
                    {
                        if (entry.Key.ToString()?.EndsWith(".baml", StringComparison.OrdinalIgnoreCase) ?? false)
                        {
                            Stream stream;

                            if (entry.Value is Stream st)
                            {
                                stream = st;
                            }
                            else if (entry.Value is byte[] b)
                            {
                                stream = new MemoryStream(b);
                            }
                            else
                            {
                                continue;
                            }

                            try
                            {
                                BamlDocument document = BamlReader.ReadDocument(stream, CancellationToken.None);
                                string? typeName = this.GetTypeName(document);

                                result.Add(typeName, document);
                            }
                            catch (ArgumentException)
                            {
                            }
                            catch (FileNotFoundException)
                            {
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the first not-null full name of the type of the children that are a TypeInfoRecord.
        /// </summary>
        /// <param name="bamlDocument">BAML document.</param>
        /// <returns>Full name of the type.</returns>
        private string GetTypeName(BamlDocument bamlDocument)
        {
            int childCount = 0;

            foreach (BamlRecord child in bamlDocument)
            {
                switch (child)
                {
                    case TypeInfoRecord classAttribute:
                        {
                            //
                            // Skip when there is not type specified.
                            // Otherwise return full name of type.
                            //
                            if (string.IsNullOrEmpty(classAttribute.TypeFullName))
                            {
                                continue;
                            }
                            else
                            {
                                return classAttribute.TypeFullName;
                            }
                        }
                    default:
                        {
                            break;
                        }
                }

                childCount++;
            }

            //
            // Raise can not extract type name error.
            //
#warning I18N
            throw new ObfuscarException(MessageCodes.dbr155, $"The name of the type of the first child can not be established for the BAML document '{bamlDocument.DocumentName}' with {childCount:N0} children.");
            throw new ObfuscarException(MessageCodes.dbr155, Translations.GetTranslationOfKey(TranslationKeys.db_dbr155_msg));
        }

        private class Graph
        {
            public readonly List<Node<TypeDefinition>> Root = new List<Node<TypeDefinition>>();

            public readonly Dictionary<string, Node<TypeDefinition>> _map = new Dictionary<string, Node<TypeDefinition>>();

            public Graph(IEnumerable<TypeDefinition> typeDefinitions)
            {
                this.Root.Capacity = this.Root.Capacity + typeDefinitions.Count();

                foreach (TypeDefinition typeDefinition in typeDefinitions)
                {
                    Node<TypeDefinition> node = new Node<TypeDefinition> {Item = typeDefinition};
                    this.Root.Add(node);
                    this._map.Add(typeDefinition.FullName, node);
                }

                this.AddParents(this.Root);
            }

            private void AddParents(List<Node<TypeDefinition>> nodes)
            {
                foreach (Node<TypeDefinition> node in nodes)
                {
                    TypeReference? baseType = node.Item?.BaseType;

                    if (baseType != null)
                    {
                        if (this.TrySearchNode(baseType, out Node<TypeDefinition>? parent))
                        {
                            node.AppendTo(parent);
                        }
                    }

                    if (node.Item?.HasInterfaces ?? false)
                    {
                        foreach (InterfaceImplementation? inter in node.Item.Interfaces)
                        {
                            if (this.TrySearchNode(inter.InterfaceType, out Node<TypeDefinition>? parent))
                            {
                                node.AppendTo(parent);
                            }
                        }
                    }

                    TypeDefinition? nestedParent = node.Item?.DeclaringType;

                    if (nestedParent != null)
                    {
                        if (this.TrySearchNode(nestedParent, out Node<TypeDefinition>? parent))
                        {
                            node.AppendTo(parent);
                        }
                    }
                }
            }

            private bool TrySearchNode(TypeReference baseType, [NotNullWhen(true)] out Node<TypeDefinition>? parent)
            {
                string key = baseType.FullName;

                parent = null;

                if (this._map.ContainsKey(key))
                {
                    parent = this._map[key];

                    if (parent.Item?.Scope.Name != baseType.Scope.Name)
                    {
                        parent = null;
                    }
                }
                return parent != null;
            }

            internal IEnumerable<TypeDefinition> GetOrderedList()
            {
                List<TypeDefinition> result = new List<TypeDefinition>();
                this.CleanPool(this.Root, result);
                return result;
            }

            private void CleanPool(List<Node<TypeDefinition>> pool, List<TypeDefinition> result)
            {
                while (pool.Count > 0)
                {
                    List<Node<TypeDefinition>> toRemove = new List<Node<TypeDefinition>>();

                    foreach (Node<TypeDefinition> node in pool)
                    {
                        if (node.Parents.Count == 0)
                        {
                            toRemove.Add(node);

                            if (node.Item == null || result.Contains(node.Item))
                            {
                                continue;
                            }

                            result.Add(node.Item);
                        }
                    }

                    if (toRemove.Count == 0)
                    {
                        //
                        // Find the loop one.
                        //
                        foreach (Node<TypeDefinition> node in pool)
                        {
                            if (IsLoop(node))
                            {
                                toRemove.Add(node);

                                if (node.Item == null || result.Contains(node.Item))
                                {
                                    continue;
                                }

                                result.Add(node.Item);
                            }
                        }

                        bool IsLoop(Node<TypeDefinition> node)
                        {
                            foreach (Node<TypeDefinition> nodeParent in node.Parents)
                            {
                                if (nodeParent.Parents.Any(n => ReferenceEquals(n, node)))
                                {
                                    return true;
                                }
                            }

                            return false;
                        }
                    }

                    if (toRemove.Count == 0)
                    {
                        Log.OutputLine(MessageCodes.dbr080, Translations.GetTranslationOfKey(TranslationKeys.db_pool_still));

                        foreach (Node<TypeDefinition> node in pool)
                        {
                            string? parents = string.Join(", ", node.Parents.Select(p => p.Item?.FullName + " " + p.Item?.Scope.Name));
                            Log.OutputLine(MessageCodes.dbr068, string.Format("{0} {1} : [{2}]", node.Item?.FullName, node.Item?.Scope.Name, parents));
                        }

                        throw new ObfuscarException(MessageCodes.dbr019, Translations.GetTranslationOfKey(TranslationKeys.db_pool_clean));
                    }

                    foreach (Node<TypeDefinition> remove in toRemove)
                    {
                        pool.Remove(remove);
                        foreach (Node<TypeDefinition> child in remove.Children)
                        {
                            if (child.Item == null || result.Contains(child.Item))
                            {
                                continue;
                            }

                            child.Parents.Remove(remove);
                        }
                    }
                }
            }
        }

        private IEnumerable<TypeDefinition>? _cached;

        public IEnumerable<TypeDefinition> GetAllTypeDefinitions()
        {
            if (this._cached != null)
            {
                return this._cached;
            }

            if (!this.Definition.MarkedToRename())
            {
                return [];
            }

            try
            {
                IEnumerable<TypeDefinition> result = this.Definition.MainModule.GetAllTypes();
                Graph graph = new Graph(result);

                return this._cached = graph.GetOrderedList();
            }
            catch (Exception e)
            {
                throw new ObfuscarException(MessageCodes.dbr020, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr020_msg_par1), this.Definition.Name), innerException: e);
            }
        }

        public void InvalidateCache()
        {
            this._cached = null;
        }

        private IEnumerable<MemberReference> GetMemberReferences()
        {
            HashSet<MemberReference> memberReferences = new HashSet<MemberReference>();
            foreach (TypeDefinition type in this.GetAllTypeDefinitions())
            {
                foreach (MethodDefinition method in type.Methods)
                {
                    foreach (MethodReference memberRef in method.Overrides)
                    {
                        if (this.IsOnlyReference(memberRef))
                        {
                            memberReferences.Add(memberRef);
                        }
                    }

                    if (method.Body != null)
                    {
                        foreach (Instruction inst in method.Body.Instructions)
                        {
                            MemberReference? memberRef = inst.Operand as MemberReference;
                            if (memberRef != null)
                            {
                                if (this.IsOnlyReference(memberRef) || memberRef is FieldReference && !(memberRef is FieldDefinition))
                                {
                                    // FIXME: Figure out why this exists if it is never used.
                                    // int c = memberreferences.Count;
                                    memberReferences.Add(memberRef);
                                }
                            }
                        }
                    }
                }
            }

            return memberReferences;
        }

        private bool IsOnlyReference(MemberReference memberref)
        {
            if (memberref is MethodReference)
            {
                if (memberref is MethodDefinition)
                {
                    return false;
                }

                if (memberref is MethodSpecification)
                {
                    if (memberref is GenericInstanceMethod)
                    {
                        return true;
                    }

                    return false;
                }

                //return !(memberref is CallSite); // `memberref is CallSite` is never true
                return true;
            }

            return false;
        }

        private void LoadAssembly(string filename)
        {
            this.filename = filename;

            try
            {
                bool readSymbols = this.project.Settings.RegenerateDebugInfo && System.IO.File.Exists(System.IO.Path.ChangeExtension(filename, "pdb"));

                try
                {
                    this.Definition = AssemblyDefinition.ReadAssembly(filename, new ReaderParameters
                    {
                        ReadingMode = ReadingMode.Deferred,
                        ReadSymbols = readSymbols,
                        AssemblyResolver = this.project.Cache
                    });
                }
                catch
                {
                    //
                    // If there's a non-matching pdb next to it, this fails, else just try again.
                    //
                    if (!readSymbols)
                    {
                        throw;
                    }

                    this.Definition = AssemblyDefinition.ReadAssembly(filename, new ReaderParameters
                    {
                        ReadingMode = ReadingMode.Deferred,
                        ReadSymbols = false,
                        AssemblyResolver = this.project.Cache
                    });
                }

                this.Name = this.Definition.Name.Name;

                this.project.Cache.RegisterAssembly(this.Definition);

                // IMPORTANT: read again but with full mode.
                try
                {
                    this.Definition = AssemblyDefinition.ReadAssembly(filename, new ReaderParameters
                    {
                        ReadingMode = ReadingMode.Immediate,
                        ReadSymbols = readSymbols,
                        AssemblyResolver = this.project.Cache
                    });
                }
                catch
                {
                    //
                    // If there's a non-matching pdb next to it, this fails, else just try again.
                    //
                    if (!readSymbols)
                    {
                        throw;
                    }

                    this.Definition = AssemblyDefinition.ReadAssembly(filename, new ReaderParameters
                    {
                        ReadingMode = ReadingMode.Immediate,
                        ReadSymbols = false,
                        AssemblyResolver = this.project.Cache
                    });
                }

                this.Name = this.Definition.Name.Name;
            }
            catch (System.IO.IOException e)
            {
                throw new ObfuscarException(MessageCodes.dbr020, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr020_2_msg_par1), filename), innerException: e);
            }
        }

        public string? FileName
        {
            get
            {
                this.CheckLoaded();
                return this.filename;
            }
        }

        public AssemblyDefinition Definition
        {
            get
            {
                this.CheckLoaded();
                return this.definition;
            }
            set
            {
                this.definition = value;

                this.name = this.definition.Name.Name;
            }
        }

        public string Name
        {
            get
            {
                this.CheckLoaded();
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ObfuscarException(MessageCodes.dbr027, Translations.GetTranslationOfKey(TranslationKeys.db_dbr027_msg));
                }

                this.name = value;
            }
        }

        public List<MemberReference>? UnrenamedReferences
        {
            get
            {
                this.CheckInitialized();
                return this.unrenamedReferences;
            }
        }

        public List<TypeReference>? UnrenamedTypeReferences
        {
            get
            {
                this.CheckInitialized();
                return this.unrenamedTypeReferences;
            }
        }

        public List<AssemblyInfo> References { get; } = new List<AssemblyInfo>();

        public List<AssemblyInfo> ReferencedBy { get; } = new List<AssemblyInfo>();

        private bool ShouldSkip(string ns, InheritMap? map)
        {
            return this.skipNamespaces.IsMatch(ns, map);
        }

        private bool ShouldForce(string ns, InheritMap? map)
        {
            return this.forceNamespaces.IsMatch(ns, map);
        }

        private bool ShouldSkip(TypeKey type, TypeAffectFlags flag, InheritMap? map)
        {
            if (this.ShouldSkip(type.Namespace, map))
            {
                return true;
            }

            foreach (TypeTester typeTester in this.skipTypes)
            {
                if ((typeTester.AffectFlags & flag) > 0 && typeTester.Test(type, map))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ShouldForce(TypeKey type, TypeAffectFlags flag, InheritMap? map)
        {
            if (this.ShouldForce(type.Namespace, map))
            {
                return true;
            }

            foreach (TypeTester typeTester in this.forceTypes)
            {
                if ((typeTester.AffectFlags & flag) > 0 && typeTester.Test(type, map))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ShouldSkip(TypeKey type, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            bool? attribute = type.TypeDefinition?.MarkedToRename();
            if (attribute != null)
            {
                message = MESSAGE_FROM_ATTRIBUTE;
                return !attribute.Value;
            }

            if (markedOnly)
            {
                message = MESSAGE_FROM_MARKED_ONLY;
                return true;
            }

            if (this.forceTypes.IsMatch(type, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return false;
            }

            if (this.ShouldForce(type.Namespace, map))
            {
                message = MESSAGE_FROM_SHOULD_FORCE;
                return false;
            }

            if (this.skipTypes.IsMatch(type, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return true;
            }

            if (this.ShouldSkip(type.Namespace, map))
            {
                message = MESSAGE_FROM_SHOULD_SKIP;
                return true;
            }

            if ((type.TypeDefinition?.IsEnum ?? false) && this.skipEnums)
            {
                message = MESSAGE_FROM_SKIP_ENUMERS;
                return true;
            }

            if (type.TypeDefinition?.IsTypePublic() ?? false)
            {
                message = MESSAGE_FROM_KEEP_PUBLIC_API;
                return keepPublicApi;
            }

            message = MESSAGE_FROM_HIDE_PRIVATE_API;

            return !hidePrivateApi;
        }

        public bool ShouldSkip(MethodKey method, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            if (method.Method.IsRuntime)
            {
                message = MESSAGE_FROM_RUNTIME_METHOD;
                return true;
            }

            if (method.Method.IsSpecialName)
            {
                switch (method.Method.SemanticsAttributes)
                {
                    case MethodSemanticsAttributes.Getter:
                    case MethodSemanticsAttributes.Setter:
                        {
                            message = MESSAGE_FROM_SKIPPING_PROPERTIES;
                            return !this.project.Settings.RenameProperties;
                        }
                    case MethodSemanticsAttributes.AddOn:
                    case MethodSemanticsAttributes.RemoveOn:
                        {
                            message = MESSAGE_FROM_SKIPPING_EVENTS;
                            return !this.project.Settings.RenameEvents;
                        }
                    default:
                        {
                            message = MESSAGE_FROM_SPECIAL_NAME;
                            return true;
                        }
                }
            }

            return this.ShouldSkipParams(method, map, keepPublicApi, hidePrivateApi, markedOnly, out message);
        }

        public bool ShouldSkipParams(MethodKey method, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            bool? attribute = method.Method.MarkedToRename();

            //
            // Skip runtime methods.
            //
            if (attribute != null)
            {
                message = MESSAGE_FROM_ATTRIBUTE;
                return !attribute.Value;
            }

            bool? parent = method.DeclaringType.MarkedToRename();
            if (parent != null)
            {
                message = MESSAGE_FROM_TYPE_ATTRIBUTE;
                return !parent.Value;
            }

            if (markedOnly)
            {
                message = MESSAGE_FROM_MARKED_ONLY;
                return true;
            }

            if (this.ShouldSkipForXaml(method))
            {
                message = MESSAGE_FROM_XAML_USE;
                return true;
            }

            if (this.ShouldForce(method.TypeKey, TypeAffectFlags.AffectMethod, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return false;
            }

            if (this.forceMethods.IsMatch(method, map))
            {
                message = MESSAGE_FROM_FORCE_METHODS;
                return false;
            }

            if (this.ShouldSkip(method.TypeKey, TypeAffectFlags.AffectMethod, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return true;
            }

            if (this.skipMethods.IsMatch(method, map))
            {
                message = MESSAGE_FROM_FORCE_METHODS;
                return true;
            }

            if (method.Method.IsPublic() 
                && (method.DeclaringType.IsTypePublic() || map?.GetMethodGroup(method)?.Methods.FirstOrDefault(m => m.DeclaringType.IsTypePublic()) != null )
                )
            {
                message = MESSAGE_FROM_KEEP_PUBLIC_API;
                return keepPublicApi;
            }

            message = MESSAGE_FROM_HIDE_PRIVATE_API;

            return !hidePrivateApi;
        }

        private bool ShouldSkipForXaml(MethodKey method)
        {
            if (this.XamlMethodsToExclude != null)
            {
                string methodName = method.Name;
                string className = method.DeclaringType.FullName;

                if (this.XamlMethodsToExclude.TryGetValue(className, out HashSet<string>? methodsToExclude))
                {
                    return methodsToExclude.Contains(methodName);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ShouldSkipStringHiding(MethodKey method, InheritMap? map, bool projectHideStrings)
        {
            if (method.DeclaringType.IsResourcesType() && method.Method.ReturnType.FullName == "System.Resources.ResourceManager")
            {
                //
                // IMPORTANT: avoid hiding resource type name, as it might be renamed later.
                //
                return true; 
            }

            if (this.ShouldForce(method.TypeKey, TypeAffectFlags.AffectString, map))
            {
                return false;
            }

            if (this.forceStringHiding.IsMatch(method, map))
            {
                return false;
            }

            if (this.ShouldSkip(method.TypeKey, TypeAffectFlags.AffectString, map))
            {
                return true;
            }

            if (this.skipStringHiding.IsMatch(method, map))
            {
                return true;
            }

            return !projectHideStrings;
        }

        public bool ShouldSkip(FieldKey field, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            //
            // Skip runtime methods.
            //
            if ((field.Field.IsRuntimeSpecialName && field.Field.Name == "value__"))
            {
                message = MESSAGE_FROM_SPECIAL_NAME;
                return true;
            }

            bool? attribute = field.Field.MarkedToRename();
            if (attribute != null)
            {
                message = MESSAGE_FROM_ATTRIBUTE;
                return !attribute.Value;
            }

            bool? parent = field.DeclaringType.MarkedToRename();
            if (parent != null)
            {
                message = MESSAGE_FROM_TYPE_ATTRIBUTE;
                return !parent.Value;
            }

            if (markedOnly)
            {
                message = MESSAGE_FROM_MARKED_ONLY;
                return true;
            }

            if (this.ShouldForce(field.TypeKey, TypeAffectFlags.AffectField, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return false;
            }

            if (this.forceFields.IsMatch(field, map))
            {
                message = MESAGE_FROM_FIELD_RULE_FORCE;
                return false;
            }

            if (this.ShouldSkip(field.TypeKey, TypeAffectFlags.AffectField, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return true;
            }

            if (this.skipFields.IsMatch(field, map))
            {
                message = MESAGE_FROM_FIELD_RULE_SKIP;
                return true;
            }

            if (this.skipEnums && field.DeclaringType.IsEnum)
            {
                message = MESSAGE_FROM_SKIP_ENUMERS;
                return true;
            }

            if (field.Field.IsPublic() && field.DeclaringType.IsTypePublic())
            {
                message = MESSAGE_FROM_KEEP_PUBLIC_API;
                return keepPublicApi;
            }

            message = MESSAGE_FROM_HIDE_PRIVATE_API;

            return !hidePrivateApi;
        }

        public bool ShouldSkip(PropertyKey prop, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            if (prop.Property.IsRuntimeSpecialName)
            {
                message = MESSAGE_FROM_RUNTIME_SPECIAL_NAME;
                return true;
            }

            bool? attribute = prop.Property.MarkedToRename();
            if (attribute != null)
            {
                message = MESSAGE_FROM_ATTRIBUTE;
                return !attribute.Value;
            }

            bool? parent = prop.DeclaringType.MarkedToRename();
            if (parent != null)
            {
                message = MESSAGE_FROM_TYPE_ATTRIBUTE;
                return !parent.Value;
            }

            if (markedOnly)
            {
                message = MESSAGE_FROM_MARKED_ONLY;
                return true;
            }

            if (this.ShouldForce(prop.TypeKey, TypeAffectFlags.AffectProperty, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return false;
            }

            if (this.forceProperties.IsMatch(prop, map))
            {
                message = MESSAGE_FROM_FORCE_PROPERTIES;
                return false;
            }

            if (this.ShouldSkip(prop.TypeKey, TypeAffectFlags.AffectProperty, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return true;
            }

            if (this.skipProperties.IsMatch(prop, map))
            {
                message = MESSAGE_FROM_SKIP_PROPERTIES;
                return true;
            }

            if (prop.Property.IsPublic() 
                &&  (   prop.DeclaringType.IsTypePublic() 
                        || ( prop.Property.GetMethod != null && map?.GetMethodGroup(new MethodKey(prop.Property.GetMethod))?.Methods?.FirstOrDefault(m => m.DeclaringType.IsTypePublic()) != null )
                        || ( prop.Property.SetMethod != null && map?.GetMethodGroup(new MethodKey(prop.Property.SetMethod))?.Methods?.FirstOrDefault(m => m.DeclaringType.IsTypePublic()) != null )
                    )
                )
            {
                message = MESSAGE_FROM_KEEP_PUBLIC_API;
                return keepPublicApi;
            }

            message = MESSAGE_FROM_HIDE_PRIVATE_API;
            return !hidePrivateApi;
        }

        public bool ShouldSkip(EventKey evt, InheritMap? map, bool keepPublicApi, bool hidePrivateApi, bool markedOnly, out string message)
        {
            //
            // Skip runtime special events.
            //
            if (evt.Event.IsRuntimeSpecialName)
            {
                message = MESSAGE_FROM_RUNTIME_SPECIAL_NAME;
                return true;
            }

            bool? attribute = evt.Event.MarkedToRename();

            //
            // Skip runtime methods.
            //
            if (attribute != null)
            {
                message = MESSAGE_FROM_ATTRIBUTE;
                return !attribute.Value;
            }

            bool? parent = evt.DeclaringType.MarkedToRename();
            if (parent != null)
            {
                message = MESSAGE_FROM_TYPE_ATTRIBUTE;
                return !parent.Value;
            }

            if (markedOnly)
            {
                message = MESSAGE_FROM_MARKED_ONLY;
                return true;
            }

            if (this.ShouldForce(evt.TypeKey, TypeAffectFlags.AffectEvent, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return false;
            }

            if (this.forceEvents.IsMatch(evt, map))
            {
                message = MESSAGE_FROM_EVENT_RULE_FORCE;
                return false;
            }

            if (this.ShouldSkip(evt.TypeKey, TypeAffectFlags.AffectEvent, map))
            {
                message = MESSAGE_FROM_FORCE_TYPES;
                return true;
            }

            if (this.skipEvents.IsMatch(evt, map))
            {
                message = MESSAGE_FROM_EVENT_RULE_SKIP;
                return true;
            }

            if (evt.Event.IsPublic() 
                && (    evt.DeclaringType.IsTypePublic() 
                        || ( evt.Event.AddMethod != null && map?.GetMethodGroup(new MethodKey(evt.Event.AddMethod))?.Methods?.FirstOrDefault(m => m.DeclaringType.IsTypePublic()) != null )
                        || ( evt.Event.RemoveMethod != null && map?.GetMethodGroup(new MethodKey(evt.Event.RemoveMethod))?.Methods?.FirstOrDefault(m => m.DeclaringType.IsTypePublic()) != null )
                    )
                )
            {
                message = MESSAGE_FROM_KEEP_PUBLIC_API;
                return keepPublicApi;
            }

            message = MESSAGE_FROM_HIDE_PRIVATE_API;
            return !hidePrivateApi;
        }

        /// <summary>
        /// Makes sure that the assembly definition has been loaded (by <see cref="LoadAssembly"/>).
        /// </summary>
        [MemberNotNull(nameof(name))]
        [MemberNotNull(nameof(definition))]
        private void CheckLoaded()
        {
            if (this.definition == null)
            {
                throw new ObfuscarException(MessageCodes.dbr029, Translations.GetTranslationOfKey(TranslationKeys.db_dbr029_msg));
            }

            if (string.IsNullOrEmpty(this.name))
            {
                throw new ObfuscarException(MessageCodes.dbr030, Translations.GetTranslationOfKey(TranslationKeys.db_dbr029_msg));
            }
        }

        /// <summary>
        /// Makes sure that the assembly has been initialized (by <see cref="Init"/>).
        /// </summary>
        private void CheckInitialized()
        {
            if (!this.initialized)
            {
                throw new ObfuscarException(MessageCodes.dbr031, Translations.GetTranslationOfKey(TranslationKeys.db_dbr031_msg));
            }
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
