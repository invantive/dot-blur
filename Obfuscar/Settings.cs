#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

/// <copyright>
/// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </copyright>

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
            this.Optimize = XmlConvert.ToBoolean(vars.GetValue(VariableOptimizeMethods, "true"));
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

        public string InPath { get; }

        public string OutPath { get; }

        public bool MarkedOnly { get; }

        public string LogFilePath { get; }

        public bool RenameFields { get; }

        public bool RenameProperties { get; }

        public bool RenameEvents { get; }

        public bool KeepPublicApi { get; }

        public bool HidePrivateApi { get; }

        public bool ReuseNames { get; }

        public bool HideStrings { get; }

        public bool Optimize { get; }

        public bool SuppressIldasm { get; }

        public bool XmlMapping { get; }

        public bool UseUnicodeNames { get; }

        public bool UseKoreanNames { get; }

        public bool AnalyzeXaml { get; }

        public string CustomChars { get; }

        public string? ExtraFrameworkFolders { get; }

        public string? KeyContainer { get; }

        public string? KeyFile { get; }

        public string? KeyFilePassword { get; }

        public string? SignToolExe { get; }

        public bool SignAssembly { get; }

        public string? SigningFileDigestAlgorithm { get; }

        public string? SigningTimeStampServerUrl { get; }
    }
}
