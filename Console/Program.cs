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
            Log.OutputLine(MessageCodes.dbr097, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_copyright_par1), DateTime.UtcNow.Year));
            Log.OutputLine(MessageCodes.dbr098, null);
            Log.OutputLine(MessageCodes.dbr099, Translations.GetTranslationOfKey(TranslationKeys.db_con_syntax));
            Log.OutputLine(MessageCodes.dbr100, null);
            Log.OutputLine(MessageCodes.dbr101, Translations.GetTranslationOfKey(TranslationKeys.db_options_colon));

            using (OptionTextWriter writer = new OptionTextWriter(Console.Out, MessageCodes.dbr171))
            {
                optionSet.WriteOptionDescriptions(writer);
            }
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Exit code.</returns>
        private static int Main(string[] args)
        {
            Translations.Configure();

            Log.OutputLine(MessageCodes.dbr105, null);
            Log.OutputLine(MessageCodes.dbr106, String.Format(Translations.GetTranslationOfKey(TranslationKeys.db_con_title_par2), Obfuscator.FullVersion, DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")));
            Log.OutputLine(MessageCodes.dbr107, null);

            bool showHelp = false;
            bool showVersion = false;

            OptionSet p = new OptionSet()
                .Add("h|?|help", Translations.GetTranslationOfKey(TranslationKeys.db_help_info), delegate (string v) { showHelp = v != null; })
                .Add("V|version", Translations.GetTranslationOfKey(TranslationKeys.db_display_version), delegate (string v) { showVersion = v != null; })
                ;

            if (args.Length == 0)
            {
                ShowHelp(p);
                return 0;
            }

            List<string> projectParameters;

            try
            {
                projectParameters = p.Parse(args);
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
                Log.OutputLine(MessageCodes.dbr104, Obfuscator.FullVersion);
                return 0;
            }

            if (projectParameters.Count < 1)
            {
                ShowHelp(p);
                return 1;
            }

            DateTime startUtc = DateTime.UtcNow;

            foreach (string projectFileNamePath in projectParameters)
            {
                try
                {
                    Log.OutputLine(MessageCodes.dbr072, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_loading_pjt_par1), projectFileNamePath));
                    Obfuscator obfuscator = new Obfuscator(projectFileNamePath);

                    obfuscator.RunRules();

                    Log.OutputLine(MessageCodes.dbr071, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr071_par1), (DateTime.UtcNow - startUtc).TotalSeconds));
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

                    Log.OutputLine(MessageCodes.dbr130, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr130_par1), (DateTime.UtcNow - startUtc).TotalSeconds));

                    return 2;
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

                    Log.OutputLine(MessageCodes.dbr076, Translations.GetTranslationOfKey(TranslationKeys.db_callstack));
                    Log.OutputLine(MessageCodes.dbr178, e.StackTrace);

                    Log.OutputLine(MessageCodes.dbr132, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr132_par1), (DateTime.UtcNow - startUtc).TotalSeconds));

                    return 3;
                }
            }

            return 0;
        }
    }
}
