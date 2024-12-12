using System;
using System.IO;

namespace Obfuscar
{
    /// <summary>
    /// Logging utility.
    /// </summary>
    public static class Log
    {
        private static bool isAtNewLine = true;

        /// <summary>
        /// Write a line of text with line-end to output.
        /// </summary>
        /// <param name="messageCode">Message code.</param>
        /// <param name="output">Text.</param>
        public static void OutputLine(string messageCode, string? output)
        {
            Output(messageCode, output, true);
        }

        /// <summary>
        /// Write a line of text to output.
        /// </summary>
        /// <param name="messageCode">Message code.</param>
        /// <param name="output">Text.</param>
        /// <param name="addNewLine">Whether to append a new line.</param>
        public static void Output(string messageCode, string? output, bool addNewLine = false)
        {
            Output(Console.Out, messageCode, output, addNewLine);
        }

        /// <summary>
        /// Write a line of text to output.
        /// </summary>
        /// <param name="writer">Text writer.</param>
        /// <param name="messageCode">Message code.</param>
        /// <param name="output">Text.</param>
        /// <param name="addNewLine">Whether to append a new line.</param>
        public static void Output(TextWriter writer, string messageCode, string? output, bool addNewLine = false)
        {
            string? line;

            if (isAtNewLine)
            {
                string dateTxt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

                line = String.Concat(dateTxt, ": ", messageCode, " ", output);
            }
            else
            {
                line = output;
            }

            if (addNewLine)
            {
                isAtNewLine = true;
                writer.WriteLine(line);
            }
            else
            {
                isAtNewLine = output?.EndsWith("\n") ?? false;
                writer.Write(line);
            }

        }
    }
}
