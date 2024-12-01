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
using System.Collections.Generic;
using System.Reflection;
using Mono.Options;

namespace Obfuscar
{
    /// <summary>
    /// Obfuscar.
    /// </summary>
    internal static class Program
    {
        private static void ShowHelp(OptionSet optionSet)
        {
            Console.WriteLine("Obfuscar is available at https://www.obfuscar.com");
            Console.WriteLine("(C) 2007-2024, Ryan Williams and other contributors.");
            Console.WriteLine();
            Console.WriteLine("obfuscar [Options] [project_file] [project_file]");
            Console.WriteLine("Options:");
            optionSet.WriteOptionDescriptions(Console.Out);
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Exit code.</returns>
        private static int Main(string[] args)
        {
            string versionLabel = "2.2.40.4-INVANTIVE";

            Console.WriteLine();
            Console.WriteLine($"*** Obfuscar {versionLabel} ***");

            Console.WriteLine();
            Console.WriteLine("Improvements to 2.2.40-DEFAULT:");
            Console.WriteLine("* Correct spacing, introduce central constants for variables in project file [ER] (coding-20241119-guido, 1aa890c4fc5c71ab694b1153d1b343078c529025).");
            Console.WriteLine("* Fix System.NotSupportedException on reading resources [PR] (notsupportedexception-20241119-patrick, 51460ef56996009d56e6b0bdbaba17beaba9211d).");
            Console.WriteLine("* Sign assemblies using PFX [ER] (signpfx-20241119-patrick, 4988154ac6a6575330a6123f8327bcdaf2431ee8).");
            Console.WriteLine("* Fix ArgumentNullException on KeyPair when using KeyContainerName on signing [PR] (argumentnullexception-20241119-patrick, f389749e7d0c203435b80b0cafd3532381cf8efd).");
            Console.WriteLine("* ADD VERSION PRINTING");

            Console.WriteLine();

            bool showHelp = false;
            bool showVersion = false;

            OptionSet p = new OptionSet()
                .Add("h|?|help", "Print this help information.", delegate(string v) { showHelp = v != null; })
                .Add("V|version", "Display version number of this application.", delegate(string v) { showVersion = v != null; });

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
                Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);
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
                    Log.OutputLine($"Loading project {project}.");
                    Obfuscator obfuscator = new Obfuscator(project);

                    obfuscator.RunRules();

                    Log.OutputLine($"Completed, {(Environment.TickCount - start) / 1000.0:f2} secs.");
                }
                catch (ObfuscarException e)
                {
                    Console.WriteLine();
                    Console.Error.WriteLine("An error occurred during processing:");
                    Console.Error.WriteLine(e.Message);

                    if (e.InnerException != null)
                    {
                        Console.Error.WriteLine(e.InnerException.Message);
                    }

                    return 1;
                }
            }

            return 0;
        }
    }
}
