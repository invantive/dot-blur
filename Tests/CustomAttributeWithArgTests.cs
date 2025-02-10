#pragma warning disable 1591
using Mono.Cecil;
using System.IO;
using Xunit;

namespace ObfuscarTests
{
    public class CustomAttributeWithArgTests
    {
        public string BuildAndObfuscate()
        {
            string outputPath = TestHelper.OutputPath;
            string name = "AssemblyWithCustomAttrTypeArg";
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}{3}.dll' />" +
                @"</Obfuscator>", TestHelper.InputPath, outputPath, Path.DirectorySeparatorChar, name);

            TestHelper.BuildAndObfuscate(name, string.Empty, xml);
            return Path.Combine(outputPath, $"{name}.dll");
        }

        [Fact]
        public void Check_for_null()
        {
            string output = this.BuildAndObfuscate();
            AssemblyDefinition assmDef = AssemblyDefinition.ReadAssembly(output);

            Assert.Equal(3, assmDef.MainModule.Types.Count);
        }
    }
}
#pragma warning restore 1591
