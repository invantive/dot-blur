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
    /// Global tool.
    /// </summary>
    internal static class Program
    {
        private static void ShowHelp(OptionSet optionSet)
        {
            Console.WriteLine(Translations.GetTranslationOfKey(TranslationKeys.db_fork_obfuscar));
            Console.WriteLine(string.Format("(C) 2007-{0}, Ryan Williams and other contributors.", DateTime.UtcNow.Year));
            Console.WriteLine();
            Console.WriteLine("dotblur [Options] [project_file] [project_file]");
            Console.WriteLine();
            Console.WriteLine(Translations.GetTranslationOfKey(TranslationKeys.db_options_colon));
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

            Console.WriteLine();
            Console.WriteLine(String.Format(Translations.GetTranslationOfKey(TranslationKeys.db_gt_title_par2), fullVersion, DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss")));
            Console.WriteLine();

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
                Console.WriteLine(ex.Message);
                return 1;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return 0;
            }

            if (showVersion)
            {
                Console.WriteLine(fullVersion);
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
                    Log.OutputLine(string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_loading_pjt_par1), project));
                    Obfuscator obfuscator = new Obfuscator(project);

                    obfuscator.RunRules();

                    Log.OutputLine($"Completed, {(Environment.TickCount - start) / 1000.0:f2} secs.");
                }
                catch (ObfuscarException e)
                {
                    Console.WriteLine();
                    Console.Error.WriteLine(Translations.GetTranslationOfKey(TranslationKeys.db_error_processing_colon));

                    Console.Error.Write(e.MessageCode);
                    Console.Error.Write(": ");

                    Console.Error.WriteLine(e.Message);

                    if (!string.IsNullOrEmpty(e.Hint))
                    {
                        Console.Error.WriteLine(string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_hint_colon_par1), e.Hint));
                    }

                    if (e.InnerException != null)
                    {
                        Console.Error.WriteLine(string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_inner_exception_par1), e.InnerException.Message));
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.Error.WriteLine(Translations.GetTranslationOfKey(TranslationKeys.db_error_processing_colon));

                    Console.Error.WriteLine(e.Message);

                    if (e.InnerException != null)
                    {
                        Console.Error.WriteLine(string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_inner_exception_par1), e.InnerException.Message));
                    }

                    return 1;
                }
            }

            return 0;
        }
    }
}
