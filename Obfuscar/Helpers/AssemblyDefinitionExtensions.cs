using Mono.Cecil;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Obfuscar.Helpers
{
    /// <summary>
    /// Assembly definition extension methods.
    /// </summary>
    public static class AssemblyDefinitionExtensions
    {
        /// <summary>
        /// Get the portable profile directory.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The portable profile directory.</returns>
        public static string? GetPortableProfileDirectory(this AssemblyDefinition assembly)
        {
            foreach (CustomAttribute customAttribute in assembly.CustomAttributes)
            {
                if (customAttribute.AttributeType.FullName == "System.Runtime.Versioning.TargetFrameworkAttribute")
                {
                    if (!customAttribute.HasProperties)
                    {
                        continue;
                    }

                    Mono.Cecil.CustomAttributeNamedArgument framework = customAttribute.Properties.First(property => property.Name == "FrameworkDisplayName");

                    string? content = framework.Argument.Value?.ToString();

                    if (!string.Equals(content, ".NET Portable Subset"))
                    {
                        return null;
                    }

                    string[]? parts = customAttribute.ConstructorArguments[0].Value?.ToString()?.Split(',');
                    string root = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

                    if (parts == null)
                    {
                        throw new ObfuscarException(MessageCodes.dbr037, "Missing parts.");
                    }

                    string? p1 = parts[0];
                    string? p2 = parts[1].Split('=')[1];
                    string? p3 = parts[2].Split('=')[1];

                    return Environment.ExpandEnvironmentVariables
                        ( Path.Combine
                            ( root
                            , "Reference Assemblies"
                            , "Microsoft"
                            , "Framework"
                            , p1
                            , p2
                            , "Profile"
                            , p3
                            )
                        );
                }
            }

            return null;
        }

        /// <summary>
        /// Gets whether the assembly definition is marked to be renamed.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>True if the assembly definition is marked to be renamed. Otherwise false.</returns>
        public static bool MarkedToRename(this AssemblyDefinition assembly)
        {
            foreach (CustomAttribute customAttribute in assembly.CustomAttributes)
            {
                if (customAttribute.AttributeType.FullName == typeof(ObfuscateAssemblyAttribute).FullName)
                {
                    bool rename = (Helper.GetAttributePropertyByName(customAttribute, "AssemblyIsPrivate") as bool?) ?? true;

                    return rename;
                }
            }

            // IMPORTANT: assume it should be renamed.
            return true;
        }

        /// <summary>
        /// Clean attributes.
        /// </summary>
        /// <param name="assembly">The assembly to clean.</param>
        public static void CleanAttributes(this AssemblyDefinition assembly)
        {
            for (int i = 0; i < assembly.CustomAttributes.Count; i++)
            {
                CustomAttribute custom = assembly.CustomAttributes[i];

                if (custom.AttributeType.FullName == typeof(ObfuscateAssemblyAttribute).FullName)
                {
                    if ((Helper.GetAttributePropertyByName(custom, "StripAfterObfuscation") as bool?) ?? true)
                    {
                        assembly.CustomAttributes.Remove(custom);
                    }
                }
            }
        }
    }
}
