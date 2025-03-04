﻿#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

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

#pragma warning disable 1591
using Mono.Cecil;
using Obfuscar;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace ObfuscarTests
{
    public class InterfacesTests
    {
        private Obfuscator BuildAndObfuscateAssemblies(string name)
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='true' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}{3}.dll' />" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar, name);

            return TestHelper.BuildAndObfuscate(name, string.Empty, xml);
        }

        private MethodDefinition FindMethodByName(TypeDefinition typeDef, string name)
        {
            foreach (MethodDefinition method in typeDef.Methods)
                if (method.Name == name)
                    return method;

            Assert.Fail(string.Format("Expected to find method: {0}", name));
            return null; // never here
        }

        private PropertyDefinition FindPropertyByName(TypeDefinition typeDef, string name)
        {
            foreach (PropertyDefinition property in typeDef.Properties)
                if (property.Name == name)
                    return property;

            Assert.Fail(string.Format("Expected to find method: {0}", name));
            return null; // never here
        }

        [Fact]
        public void CheckInterfaces()
        {
            Obfuscator item = this.BuildAndObfuscateAssemblies("AssemblyWithInterfaces");
            ObfuscationMap map = item.Mapping;

            string assmName = "AssemblyWithInterfaces.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(TestHelper.InputPath, assmName));

            if (string.IsNullOrEmpty(item.Project.Settings.OutPath))
            {
                throw new ObfuscarException(MessageCodes.dbr199, "Missing OutPath.");
            }

            AssemblyDefinition outAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(item.Project.Settings.OutPath, assmName));
            {
                TypeDefinition classCType = inAssmDef.MainModule.GetType("TestClasses.C");
                MethodDefinition method = this.FindMethodByName(classCType, "Method");
                PropertyDefinition property = this.FindPropertyByName(classCType, "Property");

                ObfuscatedThing methodEntry = map.GetMethod(new MethodKey(method));
                ObfuscatedThing propertyEntry = map.GetProperty(new PropertyKey(new TypeKey(classCType), property));

                Assert.True(methodEntry.Status == ObfuscationStatus.Skipped, "public interface method should not be obfuscated.");

                Assert.True(propertyEntry.Status == ObfuscationStatus.Skipped, "public interface property should not be obfuscated.");
            }
        }


        // TODO: have to manually skip the items now.
        // [Fact]
        private void CheckInterfaces2()
        {
            Obfuscator item = this.BuildAndObfuscateAssemblies("AssemblyWithInterfaces2");
            ObfuscationMap map = item.Mapping;

            string assmName = "AssemblyWithInterfaces2.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(TestHelper.InputPath, assmName));

            if (string.IsNullOrEmpty(item.Project.Settings.OutPath))
            {
                throw new ObfuscarException(MessageCodes.dbr198, "Missing OutPath.");
            }

            AssemblyDefinition outAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(item.Project.Settings.OutPath, assmName));
            {
                TypeDefinition classCType = inAssmDef.MainModule.GetType("TestClasses.C");
                MethodDefinition method = this.FindMethodByName(classCType, "Method");
                PropertyDefinition property1 = this.FindPropertyByName(classCType, "TestClasses.A.Property");
                PropertyDefinition property2 = this.FindPropertyByName(classCType, "TestClasses.B.Property");

                ObfuscatedThing methodEntry = map.GetMethod(new MethodKey(method));
                ObfuscatedThing property1Entry = map.GetProperty(new PropertyKey(new TypeKey(classCType), property1));
                ObfuscatedThing property2Entry = map.GetProperty(new PropertyKey(new TypeKey(classCType), property2));

                Assert.True(methodEntry.Status == ObfuscationStatus.Skipped, "public interface method should not be obfuscated.");

                Assert.True(property1Entry.Status == ObfuscationStatus.Skipped, "public interface property should not be obfuscated.");

                Assert.True(property2Entry.Status == ObfuscationStatus.Renamed, "internal interface property should be obfuscated.");
            }
        }

        private Assembly? AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), args.Name.Split(',')[0] + ".dll");
            return File.Exists(assemblyPath) ? Assembly.LoadFile(assemblyPath) : null;
        }
    }
}
#pragma warning restore 1591
