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

namespace Obfuscar
{
    /// <summary>
    /// Settings.
    /// </summary>
    internal class Settings
    {
        internal const string VariableAnalyzeXaml = "AnalyzeXaml";
        internal const string VariableCodeSignAssembly = "CodeSignAssembly";
        internal const string VariableCodeSigningCertificateSha1Thumbprint = "CodeSigningCertificateSha1Thumbprint";
        internal const string VariableCodeSigningContentDescription = "CodeSigningContentDescription";
        internal const string VariableCodeSigningContentInformationUrl = "CodeSigningContentInformationUrl";
        internal const string VariableCodeSigningFileDigestAlgorithm = "CodeSigningFileDigestAlgorithm";
        internal const string VariableCodeSigningKeyContainer = "CodeSigningKeyContainer";
        internal const string VariableCodeSigningKeyFile = "CodeSigningKeyFile";
        internal const string VariableCodeSigningKeyFilePassword = "CodeSigningKeyFilePassword";
        internal const string VariableCodeSigningTimeStampServerUrl = "CodeSigningTimeStampServerUrl";
        internal const string VariableCodeSigningToolExe = "CodeSigningToolExe";
        internal const string VariableCodeSigningValidation = "CodeSigningValidation";
        internal const string VariableCodeSignInParallel = "CodeSignInParallel";
        internal const string VariableCustomChars = "CustomChars";
        internal const string VariableExtraFrameworkFolders = "ExtraFrameworkFolders";
        internal const string VariableHidePrivateApi = "HidePrivateApi";
        internal const string VariableHideStrings = "HideStrings";
        internal const string VariableInPath = "InPath";
        internal const string VariableKeepPublicApi = "KeepPublicApi";
        internal const string VariableLogFile = "LogFile";
        internal const string VariableMarkedOnly = "MarkedOnly";
        internal const string VariableOptimizeMethods = "OptimizeMethods";
        internal const string VariableOutPath = "OutPath";
        internal const string VariableRegenerateDebugInfo = "RegenerateDebugInfo";
        internal const string VariableRenameEvents = "RenameEvents";
        internal const string VariableRenameFields = "RenameFields";
        internal const string VariableRenameProperties = "RenameProperties";
        internal const string VariableReuseNames = "ReuseNames";
        internal const string VariableStrongNameSigningKeyContainer = "StrongNameSigningKeyContainer";
        internal const string VariableStrongNameSigningKeyFile = "StrongNameSigningKeyFile";
        internal const string VariableStrongNameSigningKeyFilePassword = "StrongNameSigningKeyFilePassword";
        internal const string VariableStrongNameValidation = "StrongNameValidation";
        internal const string VariableStrongNamingToolExe = "StrongNamingToolExe";
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
            Log.OutputLine(MessageCodes.dbr162, Translations.GetTranslationOfKey(TranslationKeys.db_dbr162_msg));

            this.AnalyzeXaml = vars.EvaluateBoolVariable(VariableAnalyzeXaml, false) ?? false;
            this.CodeSignAssembly = vars.EvaluateBoolVariable(VariableCodeSignAssembly, false) ?? false;
            this.CodeSigningCertificateSha1Thumbprint = vars.EvaluateStringVariable(VariableCodeSigningCertificateSha1Thumbprint, null);
            this.CodeSigningContentDescription = vars.EvaluateStringVariable(VariableCodeSigningContentDescription, null);
            this.CodeSigningContentInformationUrl = vars.EvaluateStringVariable(VariableCodeSigningContentInformationUrl, null);
            this.CodeSigningFileDigestAlgorithm = vars.EvaluateStringVariable(VariableCodeSigningFileDigestAlgorithm, null);
            this.CodeSigningKeyContainer = vars.EvaluateStringVariable(VariableCodeSigningKeyContainer, null);
            this.CodeSigningKeyFile = vars.EvaluateStringVariable(VariableCodeSigningKeyFile, null);
            this.CodeSigningKeyFilePassword = vars.EvaluateStringVariable(VariableCodeSigningKeyFilePassword, null);
            this.CodeSigningTimeStampServerUrl = vars.EvaluateStringVariable(VariableCodeSigningTimeStampServerUrl, null);
            this.CodeSigningToolExe = vars.EvaluateStringVariable(VariableCodeSigningToolExe, null);
            this.CodeSigningValidation = vars.EvaluateBoolVariable(VariableCodeSigningValidation, true) ?? true;
            this.CodeSignInParallel = vars.EvaluateBoolVariable(VariableCodeSignInParallel, true) ?? true;
            this.CustomChars = vars.EvaluateStringVariable(VariableCustomChars, "");
            this.ExtraFrameworkFolders = vars.EvaluateStringVariable(VariableExtraFrameworkFolders, null);
            this.HidePrivateApi = vars.EvaluateBoolVariable(VariableHidePrivateApi, true) ?? true;
            this.HideStrings = vars.EvaluateBoolVariable(VariableHideStrings, true) ?? true;
            this.InPath = vars.EvaluateStringVariable(VariableInPath, ".");
            this.KeepPublicApi = vars.EvaluateBoolVariable(VariableKeepPublicApi, true) ?? true;
            this.LogFilePath = vars.EvaluateStringVariable(VariableLogFile, "");
            this.MarkedOnly = vars.EvaluateBoolVariable(VariableMarkedOnly, false) ?? false;
            this.OptimizeMethods = vars.EvaluateBoolVariable(VariableOptimizeMethods, true) ?? true;
            this.OutPath = vars.EvaluateStringVariable(VariableOutPath, ".");
            this.RegenerateDebugInfo = vars.EvaluateBoolVariable(VariableRegenerateDebugInfo, false) ?? false;
            this.RenameEvents = vars.EvaluateBoolVariable(VariableRenameEvents, true) ?? true;
            this.RenameFields = vars.EvaluateBoolVariable(VariableRenameFields, true) ?? true;
            this.RenameProperties = vars.EvaluateBoolVariable(VariableRenameProperties, true) ?? true;
            this.ReuseNames = vars.EvaluateBoolVariable(VariableReuseNames, true) ?? true;
            this.StrongNameSigningKeyContainer = vars.EvaluateStringVariable(VariableStrongNameSigningKeyContainer, null);
            this.StrongNameSigningKeyFile = vars.EvaluateStringVariable(VariableStrongNameSigningKeyFile, null);
            this.StrongNameSigningKeyFilePassword = vars.EvaluateStringVariable(VariableStrongNameSigningKeyFilePassword, null);
            this.StrongNameValidation = vars.EvaluateBoolVariable(VariableStrongNameValidation, true) ?? true;
            this.StrongNamingToolExe = vars.EvaluateStringVariable(VariableStrongNamingToolExe, null);
            this.SuppressIldasm = vars.EvaluateBoolVariable(VariableSuppressIldasm, true) ?? true;
            this.UseKoreanNames = vars.EvaluateBoolVariable(VariableUseKoreanNames, false) ?? false;
            this.UseUnicodeNames = vars.EvaluateBoolVariable(VariableUseUnicodeNames, false) ?? false;
            this.XmlMapping = vars.EvaluateBoolVariable(VariableXmlMapping, false) ?? false;
        }

        public bool RegenerateDebugInfo { get; private set; }

        /// <summary>
        /// Directory containing the input assemblies, such as c:\\in.
        /// </summary>
        public string? InPath { get; private set; }

        /// <summary>
        /// Directory to contain the obfuscated assemblies, such as c:\\out.
        /// </summary>
        public string? OutPath { get; private set; }

        /// <summary>
        /// Whether to only obfuscate marked items. All items are obfuscated when set to false.
        /// </summary>
        public bool MarkedOnly { get; private set; }

        /// <summary>
        /// Obfuscation log file path (mapping.txt).
        /// </summary>
        public string? LogFilePath { get; private set; }

        /// <summary>
        /// Whether to rename fields.
        /// </summary>
        public bool RenameFields { get; private set; }

        /// <summary>
        /// Whether to rename properties.
        /// </summary>
        public bool RenameProperties { get; private set; }

        /// <summary>
        /// Whether to rename events.
        /// </summary>
        public bool RenameEvents { get; private set; }

        /// <summary>
        /// Whether to exclude public types and type members from obfuscation.
        /// </summary>
        public bool KeepPublicApi { get; private set; }

        /// <summary>
        /// Whether to include private types and type members from obfuscation.
        /// </summary>
        public bool HidePrivateApi { get; private set; }

        /// <summary>
        /// Whether to reuse obfuscated names.
        /// </summary>
        public bool ReuseNames { get; private set; }

        /// <summary>
        /// Whether to hide strings.
        /// </summary>
        public bool HideStrings { get; private set; }

        /// <summary>
        /// Whether to optimize methods.
        /// </summary>
        public bool OptimizeMethods { get; private set; }

        /// <summary>
        /// Whether to include an attribute for ILDASM to indicate that assemblies are obfuscated.
        /// </summary>
        public bool SuppressIldasm { get; private set; }

        /// <summary>
        /// Whether the log file should be of XML format.
        /// </summary>
        public bool XmlMapping { get; private set; }

        /// <summary>
        /// Whether to use Unicode characters as obfuscated names.
        /// </summary>
        public bool UseUnicodeNames { get; private set; }

        /// <summary>
        /// Whether to use Korean characters as obfuscated names.
        /// </summary>
        public bool UseKoreanNames { get; private set; }

        /// <summary>
        /// Whether to analyze XAML related metadata for obfuscation.
        /// </summary>
        public bool AnalyzeXaml { get; private set; }

        /// <summary>
        /// Unique list of characters to use for naming.
        /// </summary>
        public string? CustomChars { get; private set; }

        /// <summary>
        /// List of extra .net framework folders to search, separated by semicolon as path list separator.
        /// </summary>
        public string? ExtraFrameworkFolders { get; private set; }

        /// <summary>
        /// Key container name for code signing.
        /// </summary>
        public string? CodeSigningKeyContainer { get; private set; }

        /// <summary>
        /// Key file path for code signing, such as c:\folder\key.pfx.
        /// </summary>
        public string? CodeSigningKeyFile { get; private set; }

        /// <summary>
        /// Key file password for code signing.
        /// </summary>
        public string? CodeSigningKeyFilePassword { get; private set; }

        /// <summary>
        /// Key container name for strong name signing.
        /// </summary>
        public string? StrongNameSigningKeyContainer { get; private set; }

        /// <summary>
        /// Key file path for strong name signing, such as c:\folder\key.pfx.
        /// </summary>
        public string? StrongNameSigningKeyFile { get; private set; }

        /// <summary>
        /// Key file password for strong name signing.
        /// </summary>
        public string? StrongNameSigningKeyFilePassword { get; private set; }

        /// <summary>
        /// The path to the code signing tool signtool.exe.
        /// </summary>
        public string? CodeSigningToolExe { get; private set; }

        /// <summary>
        /// The path to the strong naming tool sn.exe.
        /// </summary>
        public string? StrongNamingToolExe { get; private set; }

        /// <summary>
        /// Whether to code sign assemblies.
        /// </summary>
        public bool CodeSignAssembly { get; private set; }

        /// <summary>
        /// File digest algorithm for code signing.
        /// </summary>
        public string? CodeSigningFileDigestAlgorithm { get; private set; }

        /// <summary>
        /// Time stamp server URL for code signing.
        /// </summary>
        public string? CodeSigningTimeStampServerUrl { get; private set; }

        /// <summary>
        /// SHA1 thumbprint to select the certificate for code signing.
        /// </summary>
        public string? CodeSigningCertificateSha1Thumbprint { get; private set; }

        /// <summary>
        /// Description of the signed content.
        /// </summary>
        public string? CodeSigningContentDescription { get; private set; }

        /// <summary>
        /// URL with information on the signed content.
        /// </summary>
        public string? CodeSigningContentInformationUrl { get; private set; }

        /// <summary>
        /// Whether to perform code signing in parallel for the assemblies.
        /// </summary>
        /// <remarks>When using a hardware token, depending on configuration the password must be entered on first use. 
        /// Avoid multiple token password requests by falling back to serial signing on first solution being signed.</remarks>
        public bool CodeSignInParallel { get; private set; }

        /// <summary>
        /// Whether to check afterwards that the code signing signature was correctly applied.
        /// </summary>
        public bool CodeSigningValidation { get; private set; }

        /// <summary>
        /// Whether to validate strong name signature of an assembly.
        /// </summary>
        public bool StrongNameValidation { get; private set; }
    }
}
