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
using System.Collections.Generic;
using System.IO;

namespace Obfuscar
{
    internal class AssemblyCache : DefaultAssemblyResolver
    {
        private readonly List<string> paths = new List<string>();

        public AssemblyCache(Project project)
        {
            foreach (string path in project.AllAssemblySearchPaths)
            {
                this.AddSearchDirectory(path);
            }

            foreach (AssemblyInfo info in project.AssemblyList)
            {
                this.AddSearchDirectory(Path.GetDirectoryName(info.FileName));
            }
        }

        public TypeDefinition? GetTypeDefinition(TypeReference type)
        {
            if (type == null)
            {
                return null;
            }

            TypeDefinition? typeDef = type as TypeDefinition;

            if (typeDef != null)
            {
                return typeDef;
            }

            AssemblyNameReference? name = type.Scope as AssemblyNameReference;

            if (name == null)
            {
                GenericInstanceType? gi = type as GenericInstanceType;
                return gi == null ? null : this.GetTypeDefinition(gi.ElementType);
            }

            AssemblyDefinition assmDef;

            try
            {
                assmDef = this.Resolve(name);
            }
            catch (FileNotFoundException)
            {
                throw new ObfuscarException(MessageCodes.dbr009, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr009_msg_par1), name.Name));
            }

            string fullName = type.GetFullName();
            typeDef = assmDef.MainModule.GetType(fullName);

            if (typeDef != null)
            {
                return typeDef;
            }

            // IMPORTANT: handle type forwarding
            if (!assmDef.MainModule.HasExportedTypes)
            {
                return null;
            }

            foreach (ExportedType exported in assmDef.MainModule.ExportedTypes)
            {
                if (exported.FullName == fullName)
                {
                    return exported.Resolve();
                }
            }

            return null;
        }

        public new void RegisterAssembly(AssemblyDefinition assembly)
        {
            string? path = assembly.GetPortableProfileDirectory();

            if (!string.IsNullOrEmpty(path) && path != null && Directory.Exists(path))
            {
                this.paths.Add(path);
            }

            base.RegisterAssembly(assembly);
        }

        public override AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            AssemblyDefinition result;

            if (name.IsRetargetable)
            {
                foreach (string? path in this.paths)
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        this.AddSearchDirectory(path);
                    }
                }

                result = base.Resolve(name, parameters);

                foreach (string? path in this.paths)
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        this.RemoveSearchDirectory(path);
                    }
                }
            }
            else
            {
                result = base.Resolve(name, parameters);
            }

            return result;
        }
    }
}
