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

using Mono.Cecil;
using Obfuscar.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Obfuscar
{
    internal class Project
    {
        public List<AssemblyInfo> AssemblyList { get; } = new List<AssemblyInfo>();
        public List<AssemblyInfo> CopyAssemblyList { get; } = new List<AssemblyInfo>();

        private readonly Dictionary<string, AssemblyInfo> assemblyMap = new Dictionary<string, AssemblyInfo>();
        private readonly Variables vars = new Variables();
        private readonly List<string> assemblySearchPaths = new List<string>();

        private Project()
        {
        }

        public IEnumerable<string>? ExtraPaths
        {
            get
            {
                return this.Settings.ExtraFrameworkFolders?.Split([ Path.PathSeparator ], StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public IEnumerable<string> AllAssemblySearchPaths
        {
            get
            {
                return (this.ExtraPaths ?? Enumerable.Empty<string>())
                        .Concat(this.assemblySearchPaths)
                        .Concat([this.Settings.InPath])
                        ;
            }
        }

        /// <summary>
        /// Initialize project.
        /// </summary>
        private void Initialize()
        {
            string? keyFileName = this.Settings.KeyFile;
            string? keyFilePassword = this.Settings.KeyFilePassword;
            string? keyContainerName = this.Settings.KeyContainer;
            string? signingFileDigestAlgorithm = this.Settings.SigningFileDigestAlgorithm;
            string? signingTimeStampServerUrl = this.Settings.SigningTimeStampServerUrl;

            if (!string.IsNullOrEmpty(keyFileName) && !string.IsNullOrEmpty(keyContainerName))
            {
                throw new ObfuscarException(MessageCodes.dbr002, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr002_msg_par1), Settings.VariableKeyFile, Settings.VariableKeyContainer));
            }

            //
            // Initialize key pair.
            //
            {
                if (string.IsNullOrEmpty(keyFileName) && string.IsNullOrEmpty(keyContainerName))
                {
                    Log.OutputLine(MessageCodes.dbr110, Translations.GetTranslationOfKey(TranslationKeys.db_dbr110_msg));
                }
                else
                {
                    try
                    {
                        byte[]? keyPair;

                        if (Path.GetExtension(keyFileName)?.Equals(".pfx", StringComparison.InvariantCultureIgnoreCase) ?? false)
                        {
                            Log.OutputLine(MessageCodes.dbr109, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr109_msg_par1), keyFileName));

                            if (string.IsNullOrEmpty(keyFileName))
                            {
                                throw new ObfuscarException(MessageCodes.dbr024, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr024_msg_par1), Settings.VariableKeyFile));
                            }

                            keyPair = GetStrongNameKeyPairFromPfx(keyFileName, keyFilePassword);
                        }
                        else if (!string.IsNullOrEmpty(keyFileName))
                        {
                            Log.OutputLine(MessageCodes.dbr070, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr070_msg_par1), keyFileName));

                            keyPair = File.ReadAllBytes(keyFileName);
                        }
                        else
                        {
                            Log.OutputLine(MessageCodes.dbr069, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr069_msg_par1), keyFileName));

                            keyPair = null;
                        }

                        this.KeyPair = keyPair;
                    }
                    catch (Exception ex)
                    {
                        throw new ObfuscarException(MessageCodes.dbr007, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr007_msg_par1), keyFileName), innerException: ex);
                    }
                }
            }

            //
            // Initialize key value.
            // This is only supported on Windows.
            //
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Type.GetType("System.MonoType") != null)
                {
                    throw new ObfuscarException(MessageCodes.dbr008, Translations.GetTranslationOfKey(TranslationKeys.db_dbr008_msg));
                }

                if (string.IsNullOrEmpty(keyFileName) && string.IsNullOrEmpty(keyContainerName))
                {
                    Log.OutputLine(MessageCodes.dbr111, Translations.GetTranslationOfKey(TranslationKeys.db_dbr111_msg));
                }
                else
                {
                    if (!string.IsNullOrEmpty(keyContainerName))
                    {
                        Log.OutputLine(MessageCodes.dbr079, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr079_msg_par1), keyContainerName));

                        CspParameters cp = new CspParameters();
                        cp.KeyContainerName = keyContainerName;

                        this.KeyValue = new RSACryptoServiceProvider(cp);
                    }
                    else
                    {
                        Log.OutputLine(MessageCodes.dbr112, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr112_msg_par1), keyContainerName));
                    }
                }
            }
        }

        /// <summary>
        /// Key pair.
        /// </summary>
        public byte[]? KeyPair { get; private set; }

        /// <summary>
        /// RSA key value.
        /// </summary>
        [SupportedOSPlatform("windows")]
        public RSA? KeyValue { get; private set; }

        private AssemblyCache? m_cache;

        internal AssemblyCache Cache
        {
            get
            {
                if (this.m_cache == null)
                {
                    this.m_cache = new AssemblyCache(this);
                }

                return this.m_cache;
            }
            set => this.m_cache = value;
        }

        /// <summary>
        /// Load and initialize project from XML.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="projectFileNameDirectory">Project file name and directory.</param>
        /// <returns>Project.</returns>
        public static Project FromXml(XDocument reader, string? projectFileNameDirectory)
        {
            Log.OutputLine(MessageCodes.dbr156, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr156_msg_par1), projectFileNameDirectory));

            Project project = new Project();

            string? projectDirectory = Path.GetDirectoryName(projectFileNameDirectory);
                
            project.vars.Add(Settings.SpecialVariableProjectFileDirectory, string.IsNullOrEmpty(projectDirectory) ? "." : projectDirectory);

            const string ROOT_TAG = "DotBlur";

            if (reader.Root?.Name != ROOT_TAG)
            {
                throw new ObfuscarException
                ( MessageCodes.dbr004
                , string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr004_msg_par1), ROOT_TAG)
                , string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr004_2_msg_par1), projectFileNameDirectory)
                );
            }

            FromXmlReadNode(reader.Root, project);

            //
            // Set up for use.
            //
            project.Initialize();

            return project;
        }

        private static void FromXmlReadNode(XElement reader, Project project)
        {
            ReadVariables(reader, project);

            //
            // Initialize settings as soons as possible.
            //
            project.Settings = new Settings(project.vars);

            ReadIncludeTags(reader, project);
            ReadAssemblySearchPath(reader, project);
            ReadModules(reader, project);
            ReadModuleGroups(reader, project);
        }

        /// <summary>
        /// Process variables from project definition.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="project">Project.</param>
        private static void ReadVariables(XElement reader, Project project)
        {
            IEnumerable<XElement> settings = reader.Elements("Var");

            int variableCnt = 0;

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
                    throw new ObfuscarException(MessageCodes.dbr163, Translations.GetTranslationOfKey(TranslationKeys.db_missing_setting_name));
                }

                variableCnt++;
            }

            Log.OutputLine(MessageCodes.dbr157, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr157_msg_par1), variableCnt));
        }

        /// <summary>
        /// Process Include tags from project definition.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="project">Project.</param>
        private static void ReadIncludeTags(XElement reader, Project project)
        {
            IEnumerable<XElement> includes = reader.Elements("Include");

            int includeTagCnt = 0;

            foreach (XElement include in includes)
            {
                ReadIncludeTag(include, project, FromXmlReadNode);

                includeTagCnt++;
            }

            Log.OutputLine(MessageCodes.dbr158, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr158_msg_par1), includeTagCnt));
        }

        internal static void ReadIncludeTag(XElement parentReader, Project project,
            Action<XElement, Project> readAction)
        {
            if (parentReader == null)
            {
                throw new ObfuscarException(MessageCodes.dbr164, Translations.GetTranslationOfKey(TranslationKeys.db_missing_parent_reader));
            }

            if (readAction == null)
            {
                throw new ObfuscarException(MessageCodes.dbr165, Translations.GetTranslationOfKey(TranslationKeys.db_missing_read_action));
            }

            string path = Environment.ExpandEnvironmentVariables(Helper.GetAttribute(parentReader, "path", project.vars));

            XDocument includeReader = XDocument.Load(path);

            if (includeReader.Root?.Name == "Include")
            {
                readAction(includeReader.Root, project);
            }
        }

        /// <summary>
        /// Process AssemblySearchPath in project definition.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="project">Project.</param>
        private static void ReadAssemblySearchPath(XElement reader, Project project)
        {
            IEnumerable<XElement> searchPaths = reader.Elements("AssemblySearchPath");

            int assemblySearchPathCnt = 0;

            foreach (XElement searchPath in searchPaths)
            {
                string path = Environment.ExpandEnvironmentVariables(Helper.GetAttribute(searchPath, "path", project.vars));
                project.assemblySearchPaths.Add(path);

                assemblySearchPathCnt++;
            }

            Log.OutputLine(MessageCodes.dbr159, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr159_msg_par1), assemblySearchPathCnt));
        }

        /// <summary>
        /// Process Module in project definition.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="project">Project</param>
        private static void ReadModules(XElement reader, Project project)
        {
            IEnumerable<XElement> modules = reader.Elements("Module");

            int moduleCnt = 0;

            foreach (XElement module in modules)
            {
                string file = Helper.GetAttribute(module, "file", project.vars);

                if (string.IsNullOrWhiteSpace(file))
                {
                    throw new ObfuscarException(MessageCodes.dbr034, Translations.GetTranslationOfKey(TranslationKeys.db_dbr034_msg));
                }

                ReadModule(file, module, project);

                moduleCnt++;
            }

            Log.OutputLine(MessageCodes.dbr160, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr160_msg_par1), moduleCnt));
        }

        /// <summary>
        /// Process Modules in project definition.
        /// </summary>
        /// <param name="reader">XML reader.</param>
        /// <param name="project">Project</param>
        private static void ReadModuleGroups(XElement reader, Project project)
        {
            IEnumerable<XElement> modules = reader.Elements("Modules");

            int moduleGroupCnt = 0;

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

                moduleGroupCnt++;
            }

            Log.OutputLine(MessageCodes.dbr161, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr161_msg_par1), moduleGroupCnt));
        }

        private static List<string> ReadModuleGroupPattern(string name, XElement module, Project project)
        {
            return module.Elements(name)
                         .Select(e => project.vars.Replace(e.Value))
                         .Where(s => !string.IsNullOrWhiteSpace(s))
                         .ToList()
                         ;
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
                Log.OutputLine(MessageCodes.dbr108, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr108_msg_par1), info.Definition.Name.FullName));
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
                    this.Root.Add(new Node<AssemblyInfo> { Item = item });
                }

                AddParents(this.Root);
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
                this.CleanPool(this.Root, result);
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
            Graph graph = new Graph(this.AssemblyList);
            this.AssemblyList.Clear();
            this.AssemblyList.AddRange(graph.GetOrderedList());
        }

        /// <summary>
        /// Looks through the settings, trys to make sure everything looks ok.
        /// </summary>
        public void CheckSettings()
        {
            Log.OutputLine(MessageCodes.dbr168, Translations.GetTranslationOfKey(TranslationKeys.db_check_project_settings));

            for (int i = 0; i < this.assemblySearchPaths.Count; i++)
            {
                string assemblySearchPath = this.assemblySearchPaths[i];
                if (!Directory.Exists(assemblySearchPath))
                {
                    //throw new ObfuscarException($"Path specified by AssemblySearchPath must exist:{assemblySearchPath}");
                    this.assemblySearchPaths.Remove(assemblySearchPath);
                }
            }

            if (!Directory.Exists(this.Settings.InPath))
            {
                throw new ObfuscarException(MessageCodes.dbr006, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr006_msg_par1), this.Settings.InPath));
            }

            if (!Directory.Exists(this.Settings.OutPath))
            {
                try
                {
                    Directory.CreateDirectory(this.Settings.OutPath);
                }
                catch (IOException e)
                {
                    throw new ObfuscarException(MessageCodes.dbr005, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr005_msg_par1), this.Settings.OutPath), innerException: e);
                }
            }
        }

        internal InheritMap? InheritMap { get; private set; }

        private Settings? settings;

        internal Settings Settings
        {
            get
            {
                if (this.settings == null)
                {
                    throw new ObfuscarException(MessageCodes.dbr046, Translations.GetTranslationOfKey(TranslationKeys.db_settings_not_initialized));
                }

                return this.settings;
            }
            private set => this.settings = value;
        }

        public void LoadAssemblies()
        {
            //
            // Build reference tree.
            //
            foreach (AssemblyInfo info in this.AssemblyList)
            {
                //
                // Add self reference...makes things easier later, when
                // we need to go through the member references.
                //
                info.ReferencedBy.Add(info);

                //
                // Try to get each assembly referenced by this one.  if it's in
                // the map (and therefore in the project), set up the mappings.
                //
                foreach (AssemblyNameReference nameRef in info.Definition.MainModule.AssemblyReferences)
                {
                    if (this.assemblyMap.TryGetValue(nameRef.Name, out AssemblyInfo? reference))
                    {
                        info.References.Add(reference);
                        reference.ReferencedBy.Add(info);
                    }
                }
            }

            //
            // Make each assembly's list of member refs.
            //
            foreach (AssemblyInfo info in this.AssemblyList)
            {
                info.Init();
            }

            //
            // Build inheritance map.
            //
            this.InheritMap = new InheritMap(this);

            this.ReorderAssemblies();
        }

        /// <summary>
        /// Returns whether the project contains a given type.
        /// </summary>
        public bool Contains(TypeReference type)
        {
            string name = type.GetScopeName();

            return this.assemblyMap.ContainsKey(name);
        }

        /// <summary>
        /// Returns whether the project contains a given type.
        /// </summary>
        internal bool Contains(TypeKey type)
        {
            return this.assemblyMap.ContainsKey(type.Scope);
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

                if (this.assemblyMap.TryGetValue(name, out AssemblyInfo? info))
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
                throw new ObfuscarException(MessageCodes.dbr166, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr166_msg_par1), pfxFile));
            }

            //
            // Not clear, but we may need to have only one key and that should be the provider https://msdn.microsoft.com/en-us/library/aa730868(vs.80).aspx
            //
            foreach (X509Certificate2 cert in certs)
            {
#pragma warning disable SYSLIB0028
                if (cert.PrivateKey is RSACryptoServiceProvider provider)
                {
                    return provider.ExportCspBlob(true);
                }
            }

            throw new ObfuscarException(MessageCodes.dbr167, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr167_msg_par1), pfxFile));
        }
    }
}
