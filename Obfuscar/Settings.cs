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
    /// <summary>
    /// Settings.
    /// </summary>
    internal class Settings
    {
        internal const string VariableAnalyzeXaml = "AnalyzeXaml";
        internal const string VariableCustomChars = "CustomChars";
        internal const string VariableExtraFrameworkFolders = "ExtraFrameworkFolders";
        internal const string VariableHidePrivateApi = "HidePrivateApi";
        internal const string VariableHideStrings = "HideStrings";
        internal const string VariableInPath = "InPath";
        internal const string VariableKeepPublicApi = "KeepPublicApi";
        internal const string VariableKeyContainer = "KeyContainer";
        internal const string VariableKeyFile = "KeyFile";
        internal const string VariableKeyFilePassword = "KeyFilePassword";
        internal const string VariableLogFile = "LogFile";
        internal const string VariableMarkedOnly = "MarkedOnly";
        internal const string VariableOptimizeMethods = "OptimizeMethods";
        internal const string VariableOutPath = "OutPath";
        internal const string VariableRegenerateDebugInfo = "RegenerateDebugInfo";
        internal const string VariableRenameEvents = "RenameEvents";
        internal const string VariableRenameFields = "RenameFields";
        internal const string VariableRenameProperties = "RenameProperties";
        internal const string VariableReuseNames = "ReuseNames";
        internal const string VariableSignAssembly = "SignAssembly";
        internal const string VariableSigningCertificateSha1Thumbprint = "SigningCertificateSha1Thumbprint";
        internal const string VariableSigningFileDigestAlgorithm = "SigningFileDigestAlgorithm";
        internal const string VariableSigningTimeStampServerUrl = "SigningTimeStampServerUrl";
        internal const string VariableSignToolExe = "SignToolExe";
        internal const string VariableSuppressIldasm = "SuppressIldasm";
        internal const string VariableUseKoreanNames = "UseKoreanNames";
        internal const string VariableUseUnicodeNames = "UseUnicodeNames";
        internal const string VariableXmlMapping = "XmlMapping";

        internal const string SpecialVariableProjectFileDirectory = "ProjectFileDirectory";

        /// <summary>
        /// Initialize settings from variables in project definition.
        /// </summary>
        /// <param name="vars">Variables.</param>
        public Settings(Variables vars)
        {
            Log.OutputLine(MessageCodes.dbr162, "Initialize settings from variables.");

            this.AnalyzeXaml = vars.EvaluateBoolVariable(VariableAnalyzeXaml, false) ?? false;
            this.CustomChars = vars.EvaluateStringVariable(VariableCustomChars, "");
            this.ExtraFrameworkFolders = vars.EvaluateStringVariable(VariableExtraFrameworkFolders, null);
            this.HidePrivateApi = vars.EvaluateBoolVariable(VariableHidePrivateApi, true) ?? true;
            this.HideStrings = vars.EvaluateBoolVariable(VariableHideStrings, true) ?? true;
            this.InPath = vars.EvaluateStringVariable(VariableInPath, ".");
            this.KeepPublicApi = vars.EvaluateBoolVariable(VariableKeepPublicApi, true) ?? true;
            this.KeyContainer = vars.EvaluateStringVariable(VariableKeyContainer, null);
            this.KeyFile = vars.EvaluateStringVariable(VariableKeyFile, null);
            this.KeyFilePassword = vars.EvaluateStringVariable(VariableKeyFilePassword, null);
            this.LogFilePath = vars.EvaluateStringVariable(VariableLogFile, "");
            this.MarkedOnly = vars.EvaluateBoolVariable(VariableMarkedOnly, false) ?? false;
            this.OptimizeMethods = vars.EvaluateBoolVariable(VariableOptimizeMethods, true) ?? true;
            this.OutPath = vars.EvaluateStringVariable(VariableOutPath, ".");
            this.RegenerateDebugInfo = vars.EvaluateBoolVariable(VariableRegenerateDebugInfo, false) ?? false;
            this.RenameEvents = vars.EvaluateBoolVariable(VariableRenameEvents, true) ?? true;
            this.RenameFields = vars.EvaluateBoolVariable(VariableRenameFields, true) ?? true;
            this.RenameProperties = vars.EvaluateBoolVariable(VariableRenameProperties, true) ?? true;
            this.ReuseNames = vars.EvaluateBoolVariable(VariableReuseNames, true) ?? true;
            this.SignAssembly = vars.EvaluateBoolVariable(VariableSignAssembly, false) ?? false;
            this.SigningCertificateSha1Thumbprint = vars.EvaluateStringVariable(VariableSigningCertificateSha1Thumbprint, null);
            this.SigningFileDigestAlgorithm = vars.EvaluateStringVariable(VariableSigningFileDigestAlgorithm, null);
            this.SigningTimeStampServerUrl = vars.EvaluateStringVariable(VariableSigningTimeStampServerUrl, null);
            this.SignToolExe = vars.EvaluateStringVariable(VariableSignToolExe, null);
            this.SuppressIldasm = vars.EvaluateBoolVariable(VariableSuppressIldasm, true) ?? true;
            this.UseKoreanNames = vars.EvaluateBoolVariable(VariableUseKoreanNames, false) ?? false;
            this.UseUnicodeNames = vars.EvaluateBoolVariable(VariableUseUnicodeNames, false) ?? false;
            this.XmlMapping = vars.EvaluateBoolVariable(VariableXmlMapping, false) ?? false;
        }

        public bool RegenerateDebugInfo { get; }

        /// <summary>
        /// Directory containing the input assemblies, such as c:\\in.
        /// </summary>
        public string? InPath { get; }

        /// <summary>
        /// Directory to contain the obfuscated assemblies, such as c:\\out.
        /// </summary>
        public string? OutPath { get; }

        /// <summary>
        /// Whether to only obfuscate marked items. All items are obfuscated when set to false.
        /// </summary>
        public bool MarkedOnly { get; }

        /// <summary>
        /// Obfuscation log file path (mapping.txt).
        /// </summary>
        public string? LogFilePath { get; }

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

        /// <summary>
        /// Unique list of characters to use for naming.
        /// </summary>
        public string? CustomChars { get; }

        /// <summary>
        /// List of extra .net framework folders to search, separated by semicolon as path list separator.
        /// </summary>
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

        /// <summary>
        /// SHA1 thumbprint to select the certificate for signing.
        /// </summary>
        public string? SigningCertificateSha1Thumbprint { get; internal set; }
    }
}
