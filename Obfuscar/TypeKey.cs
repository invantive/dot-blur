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

using Mono.Cecil;
using Obfuscar.Helpers;
using System;

namespace Obfuscar
{
    internal class TypeKey : IComparable<TypeKey>
    {
        readonly TypeReference? typeReference;
        readonly int hashCode;

        public TypeKey(TypeReference type)
        {
            this.typeReference = type;
            this.Scope = type.GetScopeName();

            this.Name = string.IsNullOrEmpty(type.Namespace) ? type.Name : type.Namespace + "." + type.Name;
            TypeReference declaringType = type;

            //
            // Build path to nested type.
            //
            while (declaringType.DeclaringType != null)
            {
                declaringType = declaringType.DeclaringType;
                this.Name = declaringType.Name + "/" + this.Name;
            }
            this.Namespace = declaringType.Namespace;

            this.Fullname = !string.IsNullOrEmpty(this.Namespace) && this.Namespace != type.Namespace ? this.Namespace + "." + this.Name : this.Name;

            //
            // Our name should be the same as the Cecil's name. This is important to the Match method.
            //
            GenericInstanceType? gi = type as GenericInstanceType;
            type.DeclaringType = type.DeclaringType; // Hack: Update fullname of nested type

            if (this.Fullname != type.ToString() && (gi == null || this.Fullname != gi.ElementType.FullName))
            {
                throw new ObfuscarException(MessageCodes.dbr035, string.Format(Translations.GetTranslationOfKey(TranslationKeys.db_dbr035_msg_par1), this.Fullname, type));
            }

            this.hashCode = this.CalcHashCode();
        }

        public TypeKey(string scope, string ns, string name): this(scope, ns, name, ns + "." + name)
        {
        }

        public TypeKey(string scope, string ns, string name, string fullname)
        {
            this.Scope = scope;
            this.Namespace = ns;
            this.Name = name;
            this.Fullname = fullname;

            this.hashCode = this.CalcHashCode();
        }

        private int CalcHashCode()
        {
            return this.Scope.GetHashCode() ^ this.Namespace.GetHashCode() ^ this.Name.GetHashCode() ^ this.Fullname.GetHashCode();
        }

        public TypeDefinition? TypeDefinition
        {
            get 
            { 
                return this.typeReference as TypeDefinition; 
            }
        }

        public string Scope { get; }

        public string Namespace { get; }

        public string Name { get; }

        public string Fullname { get; }

        public bool Matches(TypeReference type)
        {
            //
            // Remove generic type parameters and compare full names.
            //
            GenericInstanceType? instanceType = type as GenericInstanceType;
            if (instanceType == null)
            {
                type.DeclaringType = type.DeclaringType; // Hack: Update full name
            }
            string typefullname = type.ToString();
            if (instanceType != null)
            {
                typefullname = instanceType.ElementType.ToString();
            }
            return typefullname == this.Fullname;
        }

        public bool Equals(TypeKey other)
        {
            return other != null &&
                   this.hashCode == other.hashCode &&
                   this.Scope == other.Scope &&
                   this.Namespace == other.Namespace &&
                   this.Name == other.Name &&
                   this.Fullname == other.Fullname
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is TypeKey ? this.Equals((TypeKey) obj) : false;
        }

        public static bool operator ==(TypeKey? a, TypeKey? b)
        {
            if ((object?)a == null)
            {
                return (object?)b == null;
            }
            else if ((object?)b == null)
            {
                return false;
            }
            else
            {
                return a.Equals(b);
            }
        }

        public static bool operator !=(TypeKey? a, TypeKey? b)
        {
            if ((object?)a == null)
            {
                return (object?)b != null;
            }
            else if ((object?)b == null)
            {
                return true;
            }
            else
            {
                return !a.Equals(b);
            }
        }

        public override int GetHashCode()
        {
            return this.hashCode;
        }

        public override string ToString()
        {
            return $"{this.Scope}::{this.Fullname}";
        }

        public int CompareTo(TypeKey? other)
        {
            //
            // No need to check ns and name...should be in fullname.
            //
            int cmp = string.Compare(this.Scope, other?.Scope);

            if (cmp == 0)
            {
                cmp = string.Compare(this.Fullname, other?.Fullname);
            }

            return cmp;
        }
    }
}
