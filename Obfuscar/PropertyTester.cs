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

using System.Text.RegularExpressions;

namespace Obfuscar
{
    internal class PropertyTester : IPredicate<PropertyKey>
    {
        private readonly string? name;
        private readonly Regex? nameRx;
        private readonly string type;
        private readonly string attrib;
        private readonly string? typeAttrib;

        public PropertyTester(string name, string type, string attrib, string? typeAttrib)
        {
            this.name = name;
            this.type = type;
            this.attrib = attrib;
            this.typeAttrib = typeAttrib;
        }

        public PropertyTester(Regex nameRx, string type, string attrib, string? typeAttrib)
        {
            this.nameRx = nameRx;
            this.type = type;
            this.attrib = attrib;
            this.typeAttrib = typeAttrib;
        }

        public bool Test(PropertyKey prop, InheritMap? map)
        {
            if (Helper.CompareOptionalRegex(prop.TypeKey.Fullname, this.type) && !MethodTester.CheckMemberVisibility(this.attrib, this.typeAttrib, prop.GetterMethodAttributes, prop.DeclaringType))
            {
                if (this.name != null)
                {
                    return Helper.CompareOptionalRegex(prop.Name, this.name);
                }
                else if (this.nameRx != null)
                {
                    return this.nameRx.IsMatch(prop.Name);
                }
                else
                {
                    throw new ObfuscarException(MessageCodes.dbr036, Translations.GetTranslationOfKey(TranslationKeys.db_dbr036_msg));
                }
            }

            return false;
        }
    }
}
