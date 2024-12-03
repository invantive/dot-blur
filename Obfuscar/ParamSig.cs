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
using System;
using System.Collections.Generic;
using System.Text;

namespace Obfuscar
{
    /// <summary>
    /// Used to identify the signature of a method by its parameters.
    /// </summary>
    class ParamSig : IComparable<ParamSig>
    {
        readonly int hashCode;

        public ParamSig(ParamSig sig): this((string[]) sig.ParamTypes.Clone())
        {
        }

        public ParamSig(string[] paramTypes)
        {
            this.ParamTypes = paramTypes;
            this.hashCode = this.CalcHashCode();
        }

        public ParamSig(MethodReference method)
        {
            this.ParamTypes = new string[method.Parameters.Count];

            int i = 0;
            foreach (ParameterDefinition param in method.Parameters)
            {
                this.ParamTypes[i++] = Helper.GetParameterTypeName(param);
            }

            this.hashCode = this.CalcHashCode();
        }

        public ParamSig(MethodDefinition method)
        {
            this.ParamTypes = new string[method.Parameters.Count];

            int i = 0;
            foreach (ParameterDefinition param in method.Parameters)
            {
                this.ParamTypes[i++] = Helper.GetParameterTypeName(param);
            }

            this.hashCode = this.CalcHashCode();
        }

        private int CalcHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.ParamTypes.Length; i++)
            {
                hashCode ^= this.ParamTypes[i].GetHashCode();
            }
            return hashCode;
        }

        public int Count
        {
            get 
            { 
                return this.ParamTypes.Length; 
            }
        }

        public string this[int index]
        {
            get 
            { 
                return this.ParamTypes[index]; 
            }
        }

        public string[] ParamTypes { get; }

        public bool Equals(ParamSig other)
        {
            return other != null &&ParamsEqual(this.ParamTypes, other.ParamTypes);
        }

        private static bool ParamsEqual(IList<string> a, IList<string> b)
        {
            if (a == null)
            {
                return b == null;
            }
            else if (b == null)
            {
                return false;
            }
            else if (a.Count != b.Count)
            {
                return false;
            }
            else
            {
                // kludge...too simplistic...param types match anything

                for (int i = 0; i < a.Count; i++)
                {
                    if (!a[i].StartsWith("!") && !b[i].StartsWith("!") && !a[i].Equals(b[i]))
                    {
                        return false;
                    }
                }

                // they aren't not equal
                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is ParamSig ? this.Equals((ParamSig)obj) : false;
        }

        public static bool operator ==(ParamSig? a, ParamSig? b)
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

        public static bool operator !=(ParamSig? a, ParamSig? b)
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

        public override string? ToString()
        {
            if (this.ParamTypes.Length == 0)
            {
                return "";
            }
            else if (this.ParamTypes.Length == 1)
            {
                return this.ParamTypes[0].ToString();
            }
            else if (this.ParamTypes.Length == 2)
            {
                return this.ParamTypes[0].ToString() + " " + this.ParamTypes[1].ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(this.ParamTypes[0]);
                for (int i = 1; i < this.ParamTypes.Length; i++)
                {
                    sb.Append(" ");
                    sb.Append(this.ParamTypes[i]);
                }
                return sb.ToString();
            }
        }

        public int CompareTo(ParamSig? other)
        {
            if (other == null)
            {
                return -1;
            }

            if (this.ParamTypes.Length < other.ParamTypes.Length)
            {
                return -1;
            }
            else if (this.ParamTypes.Length > other.ParamTypes.Length)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < this.ParamTypes.Length; i++)
                {
                    int cmp = string.Compare(this.ParamTypes[i], other.ParamTypes[i]);
                    if (cmp != 0)
                    {
                        return cmp;
                    }
                }

                return 0;
            }
        }
    }
}
