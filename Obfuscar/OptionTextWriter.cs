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
using System.IO;
using System.Text;

namespace Obfuscar
{
    /// <summary>
    /// Text writer which starts each new line with a predefined text.
    /// </summary>
    public class OptionTextWriter : TextWriter
    {
        private readonly TextWriter originalWriter;
        private string messageCode;

        /// <inheritdoc/>
        public OptionTextWriter(TextWriter originalWriter, string? messageCode)
        {
            this.originalWriter = originalWriter ?? throw new ArgumentNullException(nameof(originalWriter));
            this.messageCode = string.IsNullOrEmpty(messageCode) ? MessageCodes.dbr172 : messageCode;
        }

        /// <inheritdoc/>
        public override Encoding Encoding => this.originalWriter.Encoding;

        /// <inheritdoc/>
        public override void Write(char value)
        {
            Log.Output(this.originalWriter, this.messageCode, value.ToString(), false);
        }

        /// <inheritdoc/>
        public override void WriteLine(string? value)
        {
            Log.Output(this.originalWriter, this.messageCode, value, true);
        }

        /// <inheritdoc/>
        public override void WriteLine()
        {
            Log.Output(this.originalWriter, this.messageCode, null, true);
        }
    }
}
