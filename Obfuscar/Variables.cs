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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;

namespace Obfuscar
{
    internal class Variables
    {
        readonly Dictionary<string, string> vars = new Dictionary<string, string>();

        readonly System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"\$\(([^)]+)\)");

        public void Add(string name, string value)
        {
            this.vars[name] = value;
        }

        public void Remove(string name)
        {
            this.vars.Remove(name);
        }

        /// <summary>
        /// Gets value of a variable as a list of strings.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>String (nullable) value.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public List<string>? GetListOfStringValue(string name, string? defaultValue)
        {
            List<string>? listOfString = this.vars.Where(x => x.Key == name).Select(x => this.Replace(x.Value)).ToList();

            if (!string.IsNullOrEmpty(defaultValue))
            {
                if (!listOfString.Any())
                {
                    listOfString = new List<string>() { defaultValue };
                }
            }

            return listOfString;
        }

        /// <summary>
        /// Gets value of a variable as a string.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>String (nullable) value.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public string? GetStringValue(string name, string? defaultValue)
        {
            bool found = this.vars.TryGetValue(name, out string? stringValue);

            if (!found)
            {
                stringValue = defaultValue;
            }

            return this.Replace(stringValue);
        }

        /// <summary>
        /// Gets value of a variable as a boolean.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Boolean (nullable) value.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public bool? GetBoolValue(string name, bool? defaultValue)
        {
            bool found = this.vars.TryGetValue(name, out string? stringValue);

            bool? value;
            if (!found)
            {
                value = defaultValue;
            }
            else if (string.IsNullOrEmpty(stringValue))
            {
                value = null;
            }
            else
            {
                value = XmlConvert.ToBoolean(stringValue);
            }

            return value;
        }

        [return: NotNullIfNotNull(nameof(str))]
        public string? Replace(string? str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            System.Text.StringBuilder formatted = new System.Text.StringBuilder();

            int lastMatch = 0;

            string variable;
            string? replacement;
            foreach (System.Text.RegularExpressions.Match m in this.re.Matches(str))
            {
                formatted.Append(str.Substring(lastMatch, m.Index - lastMatch));

                variable = m.Groups[1].Value;
                if (this.vars.TryGetValue(variable, out replacement))
                {
                    formatted.Append(this.Replace(replacement));
                }
                else
                {
                    throw new ObfuscarException(MessageCodes.dbr012, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr012_msg_par1), variable));
                }

                lastMatch = m.Index + m.Length;
            }

            formatted.Append(str.Substring(lastMatch));

            return formatted.ToString();
        }

        /// <summary>
        /// Gets the expanded string value of a variable by name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value of variable, after expansion for environment variables.</returns>
        public string? EvaluateStringVariable(string name, string? defaultValue)
        {
            string? value = this.GetStringValue(name, defaultValue);

            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                return Environment.ExpandEnvironmentVariables(value);
            }
        }

        /// <summary>
        /// Gets a list with expanded string value of a variable by name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value of variable, after expansion for environment variables.</returns>
        public List<string>? EvaluateListOfStringVariable(string name, string? defaultValue)
        {
            List<string>? value = this.GetListOfStringValue(name, defaultValue);

            if (!(value?.Any() ?? false))
            {
                return value;
            }
            else
            {
                return value.Select(x => Environment.ExpandEnvironmentVariables(x)).ToList();
            }
        }

        /// <summary>
        /// Gets the expanded value of a variable by name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value of variable, after expansion for environment variables.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public bool? EvaluateBoolVariable(string name, bool? defaultValue)
        {
            return GetBoolValue(name, defaultValue);
        }
    }
}
