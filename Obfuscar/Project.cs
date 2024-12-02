#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

/// <copyright>
/// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </copyright>

#endregion

using Mono.Cecil;
using Obfuscar.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Obfuscar
{
    class Project
    {
        public List<AssemblyInfo> AssemblyList { get; } = new List<AssemblyInfo>();
        public List<AssemblyInfo> CopyAssemblyList { get; } = new List<AssemblyInfo>();

        private readonly Dictionary<string, AssemblyInfo> assemblyMap = new Dictionary<string, AssemblyInfo>();
        private readonly Variables vars = new Variables();
        private readonly List<string> assemblySearchPaths = new List<string>();

        Settings? settings;

        // FIXME: Figure out why this exists if it is never used.
        //private RSA keyvalue;
        // don't create.  call FromXml.
        private Project()
        {
        }

        public IEnumerable<string>? ExtraPaths
        {
            get
            {
                return vars.GetValue(Settings.VariableExtraFrameworkFolders, "")?.Split([ Path.PathSeparator ], StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public IEnumerable<string> AllAssemblySearchPaths
        {
            get
            {
                return (ExtraPaths ?? Enumerable.Empty<string>())
                        .Concat(assemblySearchPaths)
                        .Concat([Settings.InPath])
                        ;
            }
        }

        public string? KeyContainerName = null;
        private byte[]? keyPair;
        private RSA? keyValue;
        private object keyPairLocker = new object();

        public byte[]? KeyPair
        {
            get
            {
                if (this.keyPair == null)
                {
                    lock (this.keyPairLocker)
                    {
                        if (this.keyPair == null)
                        {
                            string? lKeyFileName = vars.GetValue(Settings.VariableKeyFile, null);
                            string? lKeyContainerName = vars.GetValue(Settings.VariableKeyContainer, null);

                            if (string.IsNullOrEmpty(lKeyFileName) && string.IsNullOrEmpty(lKeyContainerName))
                            {
                                Log.OutputLine("No key file and no key container configured. Use no key pair.");
                                return null;
                            }

                            if (!string.IsNullOrEmpty(lKeyFileName) && !string.IsNullOrEmpty(lKeyContainerName))
                            {
                                throw new ObfuscarException(MessageCodes.ofr002, $"'{Settings.VariableKeyFile}' and '{Settings.VariableKeyContainer}' variables can't be set together.");
                            }

                            try
                            {
                                if (Path.GetExtension(lKeyFileName)?.Equals(".pfx", StringComparison.InvariantCultureIgnoreCase) ?? false)
                                {
                                    if (string.IsNullOrEmpty(lKeyFileName))
                                    {
                                        throw new ObfuscarException(MessageCodes.ofr024, $"'{Settings.VariableKeyFile}' is not set.");
                                    }

                                    string? lKeyFilePassword = vars.GetValue(Settings.VariableKeyFilePassword, null);

                                    this.keyPair = GetStrongNameKeyPairFromPfx(lKeyFileName, lKeyFilePassword);

                                    Log.OutputLine($"Created key pair from '{lKeyFileName}' with password.");
                                }
                                else if (!string.IsNullOrEmpty(lKeyFileName))
                                {
                                    Log.OutputLine($"Created key pair from '{lKeyFileName}' with no password.");
                                    this.keyPair = File.ReadAllBytes(lKeyFileName);
                                }
                                else
                                {
                                    Log.OutputLine($"Created no key pair from '{lKeyFileName}'.");
                                    this.keyPair = null;
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new ObfuscarException(MessageCodes.ofr007, String.Format("Failure loading key file \"{0}\"", lKeyFileName), ex);
                            }
                        }
                    }
                }

                return this.keyPair;
            }
        }

        [SupportedOSPlatform("windows")]
        public RSA? KeyValue
        {
            get
            {
                if (keyValue != null)
                {
                    return keyValue;
                }

                if (Type.GetType("System.MonoType") != null)
                {
                    throw new ObfuscarException(MessageCodes.ofr008, "Key containers are not supported for Mono.");
                }

                string? lKeyFileName = vars.GetValue(Settings.VariableKeyFile, null);
                string? lKeyContainerName = vars.GetValue(Settings.VariableKeyContainer, null);

                if (string.IsNullOrEmpty(lKeyFileName) && string.IsNullOrEmpty(lKeyContainerName))
                {
                    return null;
                }
                if (!string.IsNullOrEmpty(lKeyFileName) && !string.IsNullOrEmpty(lKeyContainerName))
                {
                    throw new ObfuscarException(MessageCodes.ofr003, $"'{Settings.VariableKeyFile}' and '{Settings.VariableKeyContainer}' variables cann't be setted together.");
                }

                KeyContainerName = lKeyContainerName;

                if (KeyContainerName != null)
                {
                    CspParameters cp = new CspParameters();
                    cp.KeyContainerName = KeyContainerName;

                    keyValue = new RSACryptoServiceProvider(cp);
                    return keyValue;
                }
                else
                {
                    return null;
                }
            }
        }

        AssemblyCache? m_cache;

        internal AssemblyCache Cache
        {
            get
            {
                if (m_cache == null)
                {
                    m_cache = new AssemblyCache(this);
                }

                return m_cache;
            }
            set { m_cache = value; }
        }

        public static Project FromXml(XDocument reader, string? projectFileDirectory)
        {
            Project project = new Project();

            project.vars.Add(Settings.SpecialVariableProjectFileDirectory, string.IsNullOrEmpty(projectFileDirectory) ? "." : projectFileDirectory);

            if (reader.Root?.Name != "Obfuscator")
            {
                throw new ObfuscarException(MessageCodes.ofr004, "XML configuration file should have <Obfuscator> root tag.");
            }

            FromXmlReadNode(reader.Root, project);

            return project;
        }

        private static void FromXmlReadNode(XElement reader, Project project)
        {
            ReadVariables(reader, project);
            ReadIncludeTags(reader, project);
            ReadAssemblySearchPath(reader, project);
            ReadModules(reader, project);
            ReadModuleGroups(reader, project);
        }

        private static void ReadVariables(XElement reader, Project project)
        {
            IEnumerable<XElement> settings = reader.Elements("Var");
            foreach (XElement setting in settings)
            {
                string? name = setting.Attribute("name")?.Value;
                if (!string.IsNullOrEmpty(name))
                {
                    string? value = setting.Attribute("value")?.Value;
                    if (!string.IsNullOrEmpty(value))
                    {
                        project.vars.Add(name, value);
                    }
                    else
                    {
                        project.vars.Remove(name);
                    }
                }
                else
                {
                    throw new ArgumentNullException("name");
                }
            }
        }

        private static void ReadIncludeTags(XElement reader, Project project)
        {
            IEnumerable<XElement> includes = reader.Elements("Include");
            foreach (XElement include in includes)
            {
                ReadIncludeTag(include, project, FromXmlReadNode);
            }
        }

        internal static void ReadIncludeTag(XElement parentReader, Project project,
            Action<XElement, Project> readAction)
        {
            if (parentReader == null)
            {
                throw new ArgumentNullException("parentReader");
            }

            if (readAction == null)
            {
                throw new ArgumentNullException("readAction");
            }

            string path = Environment.ExpandEnvironmentVariables(Helper.GetAttribute(parentReader, "path", project.vars));

            XDocument includeReader = XDocument.Load(path);

            if (includeReader.Root?.Name == "Include")
            {
                readAction(includeReader.Root, project);
            }
        }

        private static void ReadAssemblySearchPath(XElement reader, Project project)
        {
            IEnumerable<XElement> searchPaths = reader.Elements("AssemblySearchPath");

            foreach (XElement searchPath in searchPaths)
            {
                string path = Environment.ExpandEnvironmentVariables(Helper.GetAttribute(searchPath, "path", project.vars));
                project.assemblySearchPaths.Add(path);
            }
        }

        private static void ReadModules(XElement reader, Project project)
        {
            IEnumerable<XElement> modules = reader.Elements("Module");
            foreach (XElement module in modules)
            {
                string file = Helper.GetAttribute(module, "file", project.vars);

                if (string.IsNullOrWhiteSpace(file))
                {
                    throw new ObfuscarException(MessageCodes.ofr034, "Need valid file attribute.");
                }

                ReadModule(file, module, project);
            }
        }

        private static void ReadModuleGroups(XElement reader, Project project)
        {
            IEnumerable<XElement> modules = reader.Elements("Modules");

            foreach (XElement module in modules)
            {
                List<string> includes = ReadModuleGroupPattern("IncludeFiles", module, project);

                if (!includes.Any())
                {
                    continue;
                }

                List<string> excludes = ReadModuleGroupPattern("ExcludeFiles", module, project);

                Filter filter = new Filter(project.Settings.InPath, includes, excludes);

                foreach (string file in filter)
                {
                    ReadModule(file, module, project);
                }
            }
        }

        private static List<string> ReadModuleGroupPattern(string name, XElement module, Project project)
        {
            return (from i in module.Elements(name)
                    let value = project.vars.Replace(i.Value)
                    where !string.IsNullOrWhiteSpace(value)
                    select value).ToList();
        }

        private static void ReadModule(string file, XElement module, Project project)
        {
            AssemblyInfo info = AssemblyInfo.FromXml(project, module, file, project.vars);

            if (info.Exclude)
            {
                project.CopyAssemblyList.Add(info);
            }
            else
            {
                Console.WriteLine("Processing assembly: " + info.Definition.Name.FullName);
                project.AssemblyList.Add(info);
                project.assemblyMap[info.Name] = info;
            }
        }

        private class Graph
        {
            public List<Node<AssemblyInfo>> Root = new List<Node<AssemblyInfo>>();

            public Graph(List<AssemblyInfo> items)
            {
                foreach (AssemblyInfo item in items)
                {
                    Root.Add(new Node<AssemblyInfo> { Item = item });
                }

                AddParents(Root);
            }

            private static void AddParents(List<Node<AssemblyInfo>> nodes)
            {
                foreach (Node<AssemblyInfo> node in nodes)
                {
                    List<AssemblyInfo>? references = node.Item?.References;

                    if (references != null)
                    {
                        foreach (AssemblyInfo reference in references)
                        {
                            Node<AssemblyInfo>? parent = SearchNode(reference, nodes);

                            if (parent != null)
                            {
                                node.AppendTo(parent);
                            }
                        }
                    }
                }
            }

            private static Node<AssemblyInfo>? SearchNode(AssemblyInfo baseType, List<Node<AssemblyInfo>> nodes)
            {
                return nodes.FirstOrDefault(node => node.Item == baseType);
            }

            internal IEnumerable<AssemblyInfo> GetOrderedList()
            {
                List<AssemblyInfo> result = new List<AssemblyInfo>();
                CleanPool(Root, result);
                return result;
            }

            private void CleanPool(List<Node<AssemblyInfo>> pool, List<AssemblyInfo> result)
            {
                while (pool.Count > 0)
                {
                    List<Node<AssemblyInfo>> toRemoved = new List<Node<AssemblyInfo>>();
                    foreach (Node<AssemblyInfo> node in pool)
                    {
                        if (node.Parents.Count == 0)
                        {
                            toRemoved.Add(node);
                            if (node.Item == null || result.Contains(node.Item))
                            {
                                continue;
                            }

                            result.Add(node.Item);
                        }
                    }

                    foreach (Node<AssemblyInfo> remove in toRemoved)
                    {
                        pool.Remove(remove);
                        foreach (Node<AssemblyInfo> child in remove.Children)
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

        private void ReorderAssemblies()
        {
            Graph graph = new Graph(AssemblyList);
            AssemblyList.Clear();
            AssemblyList.AddRange(graph.GetOrderedList());
        }

        /// <summary>
        /// Looks through the settings, trys to make sure everything looks ok.
        /// </summary>
        public void CheckSettings()
        {
            for (int i = 0; i < assemblySearchPaths.Count; i++)
            {
                string assemblySearchPath = assemblySearchPaths[i];
                if (!Directory.Exists(assemblySearchPath))
                {
                    //throw new ObfuscarException($"Path specified by AssemblySearchPath must exist:{assemblySearchPath}");
                    assemblySearchPaths.Remove(assemblySearchPath);
                }
            }

            if (!Directory.Exists(Settings.InPath))
            {
                throw new ObfuscarException(MessageCodes.ofr006, "Path specified by InPath variable must exist:" + Settings.InPath);
            }

            if (!Directory.Exists(Settings.OutPath))
            {
                try
                {
                    Directory.CreateDirectory(Settings.OutPath);
                }
                catch (IOException e)
                {
                    throw new ObfuscarException(MessageCodes.ofr005, "Could not create path specified by OutPath:  " + Settings.OutPath, e);
                }
            }
        }

        internal InheritMap? InheritMap { get; private set; }

        internal Settings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new Settings(vars);
                }

                return settings;
            }
        }

        public void LoadAssemblies()
        {
            // build reference tree
            foreach (AssemblyInfo info in AssemblyList)
            {
                // add self reference...makes things easier later, when
                // we need to go through the member references
                info.ReferencedBy.Add(info);

                // try to get each assembly referenced by this one.  if it's in
                // the map (and therefore in the project), set up the mappings
                foreach (AssemblyNameReference nameRef in info.Definition.MainModule.AssemblyReferences)
                {
                    if (assemblyMap.TryGetValue(nameRef.Name, out AssemblyInfo? reference))
                    {
                        info.References.Add(reference);
                        reference.ReferencedBy.Add(info);
                    }
                }
            }

            // make each assembly's list of member refs
            foreach (AssemblyInfo info in AssemblyList)
            {
                info.Init();
            }

            // build inheritance map
            InheritMap = new InheritMap(this);
            ReorderAssemblies();
        }

        /// <summary>
        /// Returns whether the project contains a given type.
        /// </summary>
        public bool Contains(TypeReference type)
        {
            string name = type.GetScopeName();

            return assemblyMap.ContainsKey(name);
        }

        /// <summary>
        /// Returns whether the project contains a given type.
        /// </summary>
        internal bool Contains(TypeKey type)
        {
            return assemblyMap.ContainsKey(type.Scope);
        }

        public TypeDefinition? GetTypeDefinition(TypeReference type)
        {
            if (type == null)
            {
                return null;
            }

            TypeDefinition? typeDef = type as TypeDefinition;
            if (typeDef == null)
            {
                string name = type.GetScopeName();

                if (assemblyMap.TryGetValue(name, out AssemblyInfo? info))
                {
                    string fullName = type.Namespace + "." + type.Name;
                    typeDef = info.Definition.MainModule.GetType(fullName);
                }
            }

            return typeDef;
        }

        private static byte[] GetStrongNameKeyPairFromPfx(string pfxFile, string? password)
        {
            X509Certificate2Collection certs = new X509Certificate2Collection();

            certs.Import(pfxFile, password, X509KeyStorageFlags.Exportable);

            if (certs.Count == 0)
            {
                throw new ArgumentException("Invalid certificate", nameof(pfxFile));
            }

            //not clear, but we may need to have only one key and that should be the provider https://msdn.microsoft.com/en-us/library/aa730868(vs.80).aspx

            foreach (X509Certificate2 cert in certs)
            {
                if (cert.PrivateKey is RSACryptoServiceProvider provider)
                {
                    return provider.ExportCspBlob(true);
                }
            }

            throw new ArgumentException("Invalid private key certificate", nameof(pfxFile));
        }
    }
}
