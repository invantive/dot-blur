using Mono.Cecil;

namespace Obfuscar.Helpers
{
    internal static class MemberDefinitionExtensions
    {
        public static bool? MarkedToRename(this IMemberDefinition type, bool fromMember = false)
        {
#pragma warning disable 618
            string? obfuscarObfuscate = typeof(ObfuscateAttribute).FullName;
#pragma warning restore 618
            string? reflectionObfuscate = typeof(System.Reflection.ObfuscationAttribute).FullName;

            foreach (CustomAttribute customAttribute in type.CustomAttributes)
            {
                string attrFullName = customAttribute.Constructor.DeclaringType.FullName;

                if (attrFullName == obfuscarObfuscate)
                {
                    return (bool)(Helper.GetAttributePropertyByName(customAttribute, "ShouldObfuscate") ?? true);
                }

                if (attrFullName == reflectionObfuscate)
                {
                    bool applyToMembers = (bool)(Helper.GetAttributePropertyByName(customAttribute, "ApplyToMembers") ?? true);
                    bool rename = !(bool)(Helper.GetAttributePropertyByName(customAttribute, "Exclude") ?? true);

                    if (fromMember && !applyToMembers)
                    {
                        return !rename;
                    }
                    else
                    {
                        return rename;
                    }
                }
            }

            return type.DeclaringType == null ? null : MarkedToRename(type.DeclaringType, true);
        }

        public static void CleanAttributes(this IMemberDefinition type)
        {
            string? reflectionObfuscate = typeof(System.Reflection.ObfuscationAttribute).FullName;

            for (int i = 0; i < type.CustomAttributes.Count; i++)
            {
                CustomAttribute attr = type.CustomAttributes[i];
                string attrFullName = attr.Constructor.DeclaringType.FullName;

                if (attrFullName == reflectionObfuscate)
                {
                    if ((Helper.GetAttributePropertyByName(attr, "StripAfterObfuscation") as bool?) ?? true)
                    {
                        type.CustomAttributes.Remove(attr);
                    }
                }
            }
        }
    }
}
