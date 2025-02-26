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
    public class FunctionOverridingTests
    {
        private string? output;

        private Obfuscator BuildAndObfuscateAssemblies()
        {
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithOverrides.dll' />" +
                @"</Obfuscator>", TestHelper.InputPath, TestHelper.OutputPath, Path.DirectorySeparatorChar);

            return TestHelper.BuildAndObfuscate("AssemblyWithOverrides", string.Empty, xml);
        }

        private MethodDefinition FindByName(TypeDefinition typeDef, string name)
        {
            foreach (MethodDefinition method in typeDef.Methods)
                if (method.Name == name)
                    return method;

            Assert.Fail(string.Format("Expected to find method: {0}", name));
            return null; // never here
        }

        [Fact]
        public void CheckClassHasAttribute()
        {
            Obfuscator item = this.BuildAndObfuscateAssemblies();
            ObfuscationMap map = item.Mapping;

            string assmName = "AssemblyWithOverrides.dll";

            AssemblyDefinition inAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(TestHelper.InputPath, assmName));

            if (string.IsNullOrEmpty(item.Project.Settings.OutPath))
            {
                throw new ObfuscarException(MessageCodes.dbr200, "Missing OutPath.");
            }

            AssemblyDefinition outAssmDef = AssemblyDefinition.ReadAssembly(Path.Combine(item.Project.Settings.OutPath, assmName));
            {
                TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses.ClassA");
                MethodDefinition classAmethod2 = this.FindByName(classAType, "Method2");
                MethodDefinition classAcompare = this.FindByName(classAType, "CompareTo");

                TypeDefinition classBType = inAssmDef.MainModule.GetType("TestClasses.ClassB");
                MethodDefinition classBmethod2 = this.FindByName(classBType, "Method2");
                MethodDefinition classBcompare = this.FindByName(classBType, "CompareTo");

                TypeDefinition classCType = inAssmDef.MainModule.GetType("TestClasses.ClassC");
                MethodDefinition classCmethod1 = this.FindByName(classCType, "Method1");

                TypeDefinition classDType = inAssmDef.MainModule.GetType("TestClasses.ClassD");
                MethodDefinition classDmethod1 = this.FindByName(classDType, "Method1");

                ObfuscatedThing classAEntry = map.GetMethod(new MethodKey(classAmethod2));
                ObfuscatedThing classACompareEntry = map.GetMethod(new MethodKey(classAcompare));
                ObfuscatedThing classBEntry = map.GetMethod(new MethodKey(classBmethod2));
                ObfuscatedThing classBCompareEntry = map.GetMethod(new MethodKey(classBcompare));
                ObfuscatedThing classCEntry = map.GetMethod(new MethodKey(classCmethod1));
                ObfuscatedThing classDEntry = map.GetMethod(new MethodKey(classDmethod1));

                TypeDefinition classFType = inAssmDef.MainModule.GetType("TestClasses.ClassF");
                MethodDefinition classFmethod = this.FindByName(classFType, "Test");

                TypeDefinition classGType = inAssmDef.MainModule.GetType("TestClasses.ClassG");
                MethodDefinition classGmethod = this.FindByName(classGType, "Test");

                ObfuscatedThing classFEntry = map.GetMethod(new MethodKey(classFmethod));
                ObfuscatedThing classGEntry = map.GetMethod(new MethodKey(classGmethod));

                Assert.True(
                    classAEntry.Status == ObfuscationStatus.Renamed &&
                    classBEntry.Status == ObfuscationStatus.Renamed,
                    "Both methods should have been renamed.");

                Assert.True(
                    classAEntry.StatusText == classBEntry.StatusText,
                    "Both methods should have been renamed to the same thing.");

                Assert.True(classACompareEntry.Status == ObfuscationStatus.Skipped);

                Assert.True(classBCompareEntry.Status == ObfuscationStatus.Skipped);

                Assert.True(classCEntry.Status == ObfuscationStatus.Renamed);

                Assert.True(classDEntry.Status == ObfuscationStatus.Renamed);

                Assert.True(
                    classFEntry.Status == ObfuscationStatus.Renamed && classGEntry.Status == ObfuscationStatus.Renamed,
                    "Both methods should have been renamed.");

                Assert.True(classFEntry.StatusText == classGEntry.StatusText,
                    "Both methods should have been renamed to the same thing.");
            }

            {
                TypeDefinition classAType = inAssmDef.MainModule.GetType("TestClasses.CA");
                MethodDefinition classAmethod2 = this.FindByName(classAType, "get_PropA");

                TypeDefinition classBType = inAssmDef.MainModule.GetType("TestClasses.CB");
                MethodDefinition classBmethod2 = this.FindByName(classBType, "get_PropB");

                TypeDefinition classCType = inAssmDef.MainModule.GetType("TestClasses.IA");
                MethodDefinition classCmethod1 = this.FindByName(classCType, "get_PropA");

                TypeDefinition classDType = inAssmDef.MainModule.GetType("TestClasses.IB");
                MethodDefinition classDmethod1 = this.FindByName(classDType, "get_PropB");

                ObfuscatedThing classAEntry = map.GetMethod(new MethodKey(classAmethod2));
                ObfuscatedThing classBEntry = map.GetMethod(new MethodKey(classBmethod2));
                ObfuscatedThing classCEntry = map.GetMethod(new MethodKey(classCmethod1));
                ObfuscatedThing classDEntry = map.GetMethod(new MethodKey(classDmethod1));

                Assert.True(
                    classAEntry.Status == ObfuscationStatus.Renamed &&
                    classCEntry.Status == ObfuscationStatus.Renamed,
                    "Both methods should have been renamed.");

                Assert.True(
                    classAEntry.StatusText == classCEntry.StatusText,
                    "Both methods should have been renamed to the same thing.");

                Assert.True(
                    classBEntry.Status == ObfuscationStatus.Renamed && classDEntry.Status == ObfuscationStatus.Renamed,
                    "Both methods should have been renamed.");

                Assert.True(classBEntry.StatusText == classDEntry.StatusText,
                    "Both methods should have been renamed to the same thing.");

                Assert.True(classAEntry.StatusText != classBEntry.StatusText,
                    "Both methods shouldn't have been renamed to the same thing.");
            }

            {
                TypeDefinition classType = inAssmDef.MainModule.GetType("TestClasses.ClassH");
                MethodDefinition classMethod = this.FindByName(classType, "GetObjectData");

                ObfuscatedThing classEntry = map.GetMethod(new MethodKey(classMethod));

                Assert.True(
                    classEntry.Status == ObfuscationStatus.Skipped,
                    "GetObjectData method should have been skipped.");

                Assert.Equal("external base class or interface", classEntry.StatusText);
            }
        }

        [Fact]
        public void CheckGenericMethodRenaming()
        {
            string outputPath = TestHelper.OutputPath;
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithGenericOverrides.dll' />" +
                @"<Module file='$(InPath){2}AssemblyWithGenericOverrides2.dll'>" +
                @"<SkipNamespace name='*' />" +
                @"</Module>" +
                @"</Obfuscator>", TestHelper.InputPath, outputPath, Path.DirectorySeparatorChar);

            Obfuscator obfuscator =
                TestHelper.BuildAndObfuscate([ "AssemblyWithGenericOverrides", "AssemblyWithGenericOverrides2" ],
                    xml);

            string assembly2Path = Path.Combine(Directory.GetCurrentDirectory(), outputPath,
                "AssemblyWithGenericOverrides2.dll");
            Assembly? assembly2 = Assembly.LoadFile(assembly2Path);
            Type? type = assembly2.GetType("TestClasses.Test");

            Assert.NotNull(type);

            ConstructorInfo? ctor = type.GetConstructor([]);

            Assert.NotNull(ctor);

            object instance = ctor.Invoke([]);
            try
            {
                this.output = outputPath;
                AppDomain.CurrentDomain.AssemblyResolve += this.AssemblyResolve;
                Assert.True(instance.ToString() == "Empty<string, string>=A<B<String, String>>",
                    "Generic override should have been updated");
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= this.AssemblyResolve;
            }
        }

        private Assembly? AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            Assert.NotNull(this.output);

            string assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), this.output, args.Name.Split(',')[0] + ".dll");
            return File.Exists(assemblyPath) ? Assembly.LoadFile(assemblyPath) : null;
        }

        [Fact]
        public void CheckClosedMethodOverrideGenericMethod()
        {
            string outputPath = TestHelper.OutputPath;
            string xml = string.Format(
                @"<?xml version='1.0'?>" +
                @"<Obfuscator>" +
                @"<Var name='InPath' value='{0}' />" +
                @"<Var name='OutPath' value='{1}' />" +
                @"<Var name='KeepPublicApi' value='false' />" +
                @"<Var name='HidePrivateApi' value='true' />" +
                @"<Module file='$(InPath){2}AssemblyWithClosedOverrideGeneric.dll' />" +
                @"</Obfuscator>", TestHelper.InputPath, outputPath, Path.DirectorySeparatorChar);

            TestHelper.BuildAndObfuscate("AssemblyWithClosedOverrideGeneric", string.Empty, xml);

            string assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), outputPath,
                "AssemblyWithClosedOverrideGeneric.dll");
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Assert.Equal(5, assembly.GetTypes().Length);
        }
    }
}
#pragma warning restore 1591
