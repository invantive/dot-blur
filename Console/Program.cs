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

using Mono.Options;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Obfuscar
{
    /// <summary>
    /// Obfuscar.
    /// </summary>
    internal static class Program
    {
        private static void ShowHelp(OptionSet optionSet)
        {
            Log.OutputLine(MessageCodes.dbr096, Translations.GetTranslationOfKey(TranslationKeys.db_con_fork_obfuscar));
            Log.OutputLine(MessageCodes.dbr097, string.Format("(C) 2007-{0}, Ryan Williams and other contributors.", DateTime.UtcNow.Year));
            Log.OutputLine(MessageCodes.dbr098, null);
            Log.OutputLine(MessageCodes.dbr099, "DotBlur.Console.exe [Options] [project_file] [project_file]");
            Log.OutputLine(MessageCodes.dbr100, null);
            Log.OutputLine(MessageCodes.dbr101, Translations.GetTranslationOfKey(TranslationKeys.db_options_colon));
            optionSet.WriteOptionDescriptions(Console.Out);
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Exit code.</returns>
        private static int Main(string[] args)
        {
            Translations.Configure();

            string originalObfuscarBaseVersion = "2.2.40";
            string dotBlurPatchLevel = "6";

            string fullVersion = string.Concat(originalObfuscarBaseVersion, ".", dotBlurPatchLevel);

            Log.OutputLine(MessageCodes.dbr105, null);
            Log.OutputLine(MessageCodes.dbr106, String.Format(Translations.GetTranslationOfKey(TranslationKeys.db_con_title_par2), fullVersion, DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")));
            Log.OutputLine(MessageCodes.dbr107, null);

            bool showHelp = false;
            bool showVersion = false;

            OptionSet p = new OptionSet()
                .Add("h|?|help", Translations.GetTranslationOfKey(TranslationKeys.db_help_info), delegate (string v) { showHelp = v != null; })
                .Add("V|version", Translations.GetTranslationOfKey(TranslationKeys.db_display_version), delegate (string v) { showVersion = v != null; });

            if (args.Length == 0)
            {
                ShowHelp(p);
                return 0;
            }

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException ex)
            {
                Log.OutputLine(MessageCodes.dbr103, ex.Message);
                return 1;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return 0;
            }

            if (showVersion)
            {
                Log.OutputLine(MessageCodes.dbr104, fullVersion);
                return 0;
            }

            if (extra.Count < 1)
            {
                ShowHelp(p);
                return 1;
            }

            int start = Environment.TickCount;
            foreach (string project in extra)
            {
                try
                {
                    Log.OutputLine(MessageCodes.dbr072, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_loading_pjt_par1), project));
                    Obfuscator obfuscator = new Obfuscator(project);

                    obfuscator.RunRules();

                    Log.OutputLine(MessageCodes.dbr071, $"Completed, {(Environment.TickCount - start) / 1000.0:f2} secs.");
                }
                catch (ObfuscarException e)
                {
                    Log.OutputLine(MessageCodes.dbr067, null);
                    Log.OutputLine(MessageCodes.dbr066, Translations.GetTranslationOfKey(TranslationKeys.db_error_processing_colon));

                    Log.OutputLine(MessageCodes.dbr074, string.Concat(e.MessageCode, ": ", e.Message));

                    if (!string.IsNullOrEmpty(e.Hint))
                    {
                        Log.OutputLine(MessageCodes.dbr073, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_hint_colon_par1), e.Hint));
                    }

                    if (e.InnerException != null)
                    {
                        Log.OutputLine(MessageCodes.dbr075, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_inner_exception_par1), e.InnerException.Message));
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    Log.OutputLine(MessageCodes.dbr102, null);
                    Log.OutputLine(MessageCodes.dbr076, Translations.GetTranslationOfKey(TranslationKeys.db_error_processing_colon));

                    Log.OutputLine(MessageCodes.dbr077, e.Message);

                    if (e.InnerException != null)
                    {
                        Log.OutputLine(MessageCodes.dbr078, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_inner_exception_par1), e.InnerException.Message));
                    }

                    return 1;
                }
            }

            return 0;
        }
    }
}
