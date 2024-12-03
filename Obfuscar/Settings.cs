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

using System;
using System.Xml;

namespace Obfuscar
{
    class Settings
    {
        private const string VariableAnalyzeXaml = "AnalyzeXaml";
        private const string VariableCustomChars = "CustomChars";
        private const string VariableExtraFrameworkFolders = "ExtraFrameworkFolders";
        private const string VariableHidePrivateApi = "HidePrivateApi";
        private const string VariableHideStrings = "HideStrings";
        private const string VariableInPath = "InPath";
        private const string VariableKeepPublicApi = "KeepPublicApi";
        internal const string VariableKeyContainer = "KeyContainer";
        internal const string VariableKeyFile = "KeyFile";
        private const string VariableKeyFilePassword = "KeyFilePassword";
        private const string VariableLogFile = "LogFile";
        private const string VariableMarkedOnly = "MarkedOnly";
        private const string VariableOptimizeMethods = "OptimizeMethods";
        private const string VariableOutPath = "OutPath";
        private const string VariableRegenerateDebugInfo = "RegenerateDebugInfo";
        private const string VariableRenameEvents = "RenameEvents";
        private const string VariableRenameFields = "RenameFields";
        private const string VariableRenameProperties = "RenameProperties";
        private const string VariableReuseNames = "ReuseNames";
        private const string VariableSuppressIldasm = "SuppressIldasm";
        private const string VariableUseKoreanNames = "UseKoreanNames";
        private const string VariableUseUnicodeNames = "UseUnicodeNames";
        private const string VariableXmlMapping = "XmlMapping";
        private const string VariableSignToolExe = "SignToolExe";
        private const string VariableSignAssembly = "SignAssembly";
        private const string VariableSigningFileDigestAlgorithm = "SigningFileDigestAlgorithm";
        private const string VariableSigningTimeStampServerUrl = "SigningTimeStampServerUrl";

        internal const string SpecialVariableProjectFileDirectory = "ProjectFileDirectory";

        public Settings(Variables vars)
        {
            this.InPath = Environment.ExpandEnvironmentVariables(vars.GetValue(VariableInPath, "."));
            this.OutPath = Environment.ExpandEnvironmentVariables(vars.GetValue(VariableOutPath, "."));
            this.LogFilePath = Environment.ExpandEnvironmentVariables(vars.GetValue(VariableLogFile, ""));
            this.MarkedOnly = XmlConvert.ToBoolean(vars.GetValue(VariableMarkedOnly, "false"));

            this.RenameFields = XmlConvert.ToBoolean(vars.GetValue(VariableRenameFields, "true"));
            this.RenameProperties = XmlConvert.ToBoolean(vars.GetValue(VariableRenameProperties, "true"));
            this.RenameEvents = XmlConvert.ToBoolean(vars.GetValue(VariableRenameEvents, "true"));
            this.KeepPublicApi = XmlConvert.ToBoolean(vars.GetValue(VariableKeepPublicApi, "true"));
            this.HidePrivateApi = XmlConvert.ToBoolean(vars.GetValue(VariableHidePrivateApi, "true"));
            this.ReuseNames = XmlConvert.ToBoolean(vars.GetValue(VariableReuseNames, "true"));
            this.UseUnicodeNames = XmlConvert.ToBoolean(vars.GetValue(VariableUseUnicodeNames, "false"));
            this.UseKoreanNames = XmlConvert.ToBoolean(vars.GetValue(VariableUseKoreanNames, "false"));
            this.HideStrings = XmlConvert.ToBoolean(vars.GetValue(VariableHideStrings, "true"));
            this.OptimizeMethods = XmlConvert.ToBoolean(vars.GetValue(VariableOptimizeMethods, "true"));
            this.SuppressIldasm = XmlConvert.ToBoolean(vars.GetValue(VariableSuppressIldasm, "true"));

            this.XmlMapping = XmlConvert.ToBoolean(vars.GetValue(VariableXmlMapping, "false"));
            this.RegenerateDebugInfo = XmlConvert.ToBoolean(vars.GetValue(VariableRegenerateDebugInfo, "false"));
            this.AnalyzeXaml = XmlConvert.ToBoolean(vars.GetValue(VariableAnalyzeXaml, "false"));
            this.CustomChars = vars.GetValue(VariableCustomChars, "");
            this.ExtraFrameworkFolders = vars.GetValue(VariableExtraFrameworkFolders, null);
            this.KeyContainer = vars.GetValue(VariableKeyContainer, null);
            this.KeyFile = vars.GetValue(VariableKeyFile, null);
            this.KeyFilePassword = vars.GetValue(VariableKeyFilePassword, null);
            this.SignToolExe = vars.GetValue(VariableSignToolExe, null);
            this.SignAssembly = XmlConvert.ToBoolean(vars.GetValue(VariableSignAssembly, "false"));
            this.SigningFileDigestAlgorithm = vars.GetValue(VariableSigningFileDigestAlgorithm, null);
            this.SigningTimeStampServerUrl = vars.GetValue(VariableSigningTimeStampServerUrl, null);
        }

        public bool RegenerateDebugInfo { get; }

        /// <summary>
        /// Directory containing the input assemblies, such as c:\\in.
        /// </summary>
        public string InPath { get; }

        /// <summary>
        /// Directory to contain the obfuscated assemblies, such as c:\\out.
        /// </summary>
        public string OutPath { get; }

        /// <summary>
        /// Whether to only obfuscate marked items. All items are obfuscated when set to false.
        /// </summary>
        public bool MarkedOnly { get; }

        /// <summary>
        /// Obfuscation log file path (mapping.txt).
        /// </summary>
        public string LogFilePath { get; }

        /// <summary>
        /// Whether to rename fields.
        /// </summary>
        public bool RenameFields { get; }

        /// <summary>
        /// Whether to rename properties.
        /// </summary>
        public bool RenameProperties { get; }

        /// <summary>
        /// Whether to rename events.
        /// </summary>
        public bool RenameEvents { get; }

        /// <summary>
        /// Whether to exclude public types and type members from obfuscation.
        /// </summary>
        public bool KeepPublicApi { get; }

        /// <summary>
        /// Whether to include private types and type members from obfuscation.
        /// </summary>
        public bool HidePrivateApi { get; }

        /// <summary>
        /// Whether to reuse obfuscated names.
        /// </summary>
        public bool ReuseNames { get; }

        /// <summary>
        /// Whether to hide strings.
        /// </summary>
        public bool HideStrings { get; }

        /// <summary>
        /// Whether to optimize methods.
        /// </summary>
        public bool OptimizeMethods { get; }

        /// <summary>
        /// Whether to include an attribute for ILDASM to indicate that assemblies are obfuscated.
        /// </summary>
        public bool SuppressIldasm { get; }

        /// <summary>
        /// Whether the log file should be of XML format.
        /// </summary>
        public bool XmlMapping { get; }

        /// <summary>
        /// Whether to use Unicode characters as obfuscated names.
        /// </summary>
        public bool UseUnicodeNames { get; }

        /// <summary>
        /// Whether to use Korean characters as obfuscated names.
        /// </summary>
        public bool UseKoreanNames { get; }

        /// <summary>
        /// Whether to analyze XAML related metadata for obfuscation.
        /// </summary>
        public bool AnalyzeXaml { get; }

        public string CustomChars { get; }

        public string? ExtraFrameworkFolders { get; }

        /// <summary>
        /// Key container name.
        /// </summary>
        public string? KeyContainer { get; }

        /// <summary>
        /// Key file path, such as c:\folder\key.pfx.
        /// </summary>
        public string? KeyFile { get; }

        /// <summary>
        /// Key file password.
        /// </summary>
        public string? KeyFilePassword { get; }

        /// <summary>
        /// The path to signtool.exe.
        /// </summary>
        public string? SignToolExe { get; }

        /// <summary>
        /// Whether to sign assemblies.
        /// </summary>
        public bool SignAssembly { get; }

        /// <summary>
        /// Signing file digest algorithm.
        /// </summary>
        public string? SigningFileDigestAlgorithm { get; }

        /// <summary>
        /// Signing time stamp server URL.
        /// </summary>
        public string? SigningTimeStampServerUrl { get; }
    }
}
