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

using System.Reflection;

namespace Obfuscar
{
    /// <summary>
    /// Class containing all message codes for detailing exceptions exactly.
    /// </summary>
    [Obfuscation(Exclude = true, ApplyToMembers = true, Feature = "all")] /* Make call stack easier to read and improve obfuscation performance. */
    public class MessageCodes
    {
        public const string ofr001 = "ofr001";
        public const string ofr002 = "ofr002";
        public const string ofr003 = "ofr003";
        public const string ofr004 = "ofr004";
        public const string ofr005 = "ofr005";
        public const string ofr006 = "ofr006";
        public const string ofr007 = "ofr007";
        public const string ofr008 = "ofr008";
        public const string ofr009 = "ofr009";
        public const string ofr010 = "ofr010";
        public const string ofr011 = "ofr011";
        public const string ofr012 = "ofr012";
        public const string ofr013 = "ofr013";
        public const string ofr014 = "ofr014";
        public const string ofr015 = "ofr015";
        public const string ofr016 = "ofr016";
        public const string ofr017 = "ofr017";
        public const string ofr018 = "ofr018";
        public const string ofr019 = "ofr019";
        public const string ofr020 = "ofr020";
        public const string ofr021 = "ofr021";

        public const string ofrxxx = "ofrxxx";
    }
}
