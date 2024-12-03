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

using Obfuscar.Helpers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Obfuscar
{
    /// <summary>
    /// Type affect flags.
    /// </summary>
    [Flags]
    public enum TypeAffectFlags
    {
        /// <summary>
        /// Skip none.
        /// </summary>
        SkipNone = 0x00,

        /// <summary>
        /// Affect event.
        /// </summary>
        AffectEvent = 0x01,

        /// <summary>
        /// Affect property.
        /// </summary>
        AffectProperty = 0x02,

        /// <summary>
        /// Affect field.
        /// </summary>
        AffectField = 0x04,

        /// <summary>
        /// Affect method.
        /// </summary>
        AffectMethod = 0x08,

        /// <summary>
        /// Affect string.
        /// </summary>
        AffectString = 0x10
    }

    class TypeTester : IPredicate<TypeKey>
    {
        private readonly string? name;
        private readonly Regex? nameRx;
        private readonly string attrib;
        private readonly string? inherits;
        private readonly bool? isStatic;

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")] private readonly bool? isSerializable;

        public TypeAffectFlags AffectFlags { get; }

        public TypeTester(string name) : this(name, TypeAffectFlags.SkipNone, string.Empty)
        {
        }

        public TypeTester(string name, TypeAffectFlags skipFlags, string attrib)
        {
            this.name = name;
            this.AffectFlags = skipFlags;
            this.attrib = attrib.ToLower();
        }

        public TypeTester(string name, TypeAffectFlags skipFlags, string attrib, string inherits, bool? isStatic, bool? isSeriablizable) : this(name, skipFlags, attrib)
        {
            this.inherits = inherits;
            this.isStatic = isStatic;
            this.isSerializable = isSeriablizable;
        }

        public TypeTester(Regex nameRx, TypeAffectFlags skipFlags, string attrib)
        {
            this.nameRx = nameRx;
            this.AffectFlags = skipFlags;
            this.attrib = attrib.ToLower();
        }

        public TypeTester(Regex nameRx, TypeAffectFlags skipFlags, string attrib, string inherits, bool? isStatic, bool? isSeriablizable) : this(nameRx, skipFlags, attrib)
        {
            this.inherits = inherits;
            this.isStatic = isStatic;
            this.isSerializable = isSeriablizable;
        }

        public bool Test(TypeKey type, InheritMap? map)
        {
            if (!string.IsNullOrEmpty(this.attrib))
            {
                if (string.Equals(this.attrib, "public", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!type.TypeDefinition?.IsTypePublic() ?? false)
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ObfuscarException(MessageCodes.ofr011, string.Format("'{0}' is not valid for the 'attrib' value of the SkipType element. Only 'public' is supported by now.",
                        this.attrib));
                }
            }

            // type's regex matches
            if (this.nameRx != null && !this.nameRx.IsMatch(type.Fullname))
            {
                return false;
            }

            // type's name matches
            if (!string.IsNullOrEmpty(this.name) && !Helper.CompareOptionalRegex(type.Fullname, this.name))
            {
                return false;
            }

            if (this.isSerializable.HasValue)
            {
                if (this.isSerializable != type.TypeDefinition?.IsSerializable)
                {
                    return false;
                }
            }

            if (this.isStatic.HasValue)
            {
                if (this.isStatic != ((type.TypeDefinition?.IsSealed ?? false) && (type.TypeDefinition?.IsAbstract ?? false)))
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(this.inherits))
            {
                if (map != null && type.TypeDefinition != null && !map.Inherits(type.TypeDefinition, this.inherits))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
