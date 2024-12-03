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

using System.Collections.Generic;

namespace Obfuscar
{
    /// <summary>
    /// Languages.
    /// </summary>
    public static class Languages
    {
        /// <summary>
        /// Display languages and their properties.
        /// </summary>
        public static readonly Dictionary<string, Language> DisplayLanguages = new Dictionary<string, Language>()
            { { Languages.ar, Language.ar }
            , { Languages.cs, Language.cs }
            , { Languages.da, Language.da }
            , { Languages.de, Language.de }
            , { Languages.en, Language.en }
            , { Languages.es, Language.es }
            , { Languages.fi, Language.fi }
            , { Languages.fr, Language.fr }
            , { Languages.it, Language.it }
            , { Languages.ja, Language.ja }
            , { Languages.ko, Language.ko }
            , { Languages.nb, Language.nb }
            , { Languages.nl, Language.nl }
            , { Languages.pl, Language.pl }
            , { Languages.pt, Language.pt }
            , { Languages.sv, Language.sv }
            };

        /// <summary>
        /// Arabic.
        /// </summary>
        public const string ar = nameof(ar);

        /// <summary>
        /// Czech.
        /// </summary>
        public const string cs = nameof(cs);

        /// <summary>
        /// German.
        /// </summary>
        public const string de = nameof(de);

        /// <summary>
        /// French.
        /// </summary>
        public const string fr = nameof(fr);

        /// <summary>
        /// Italian.
        /// </summary>
        public const string it = nameof(it);

        /// <summary>
        /// Danish.
        /// </summary>
        public const string da = nameof(da);

        /// <summary>
        /// Swedish.
        /// </summary>
        public const string sv = nameof(sv);

        /// <summary>
        /// Bokmal.
        /// </summary>
        public const string nb = nameof(nb);

        /// <summary>
        /// Japanese.
        /// </summary>
        public const string ja = nameof(ja);

        /// <summary>
        /// Korean.
        /// </summary>
        public const string ko = nameof(ko);

        /// <summary>
        /// Polish.
        /// </summary>
        public const string pl = nameof(pl);

        /// <summary>
        /// Dutch.
        /// </summary>
        public const string nl = nameof(nl);

        /// <summary>
        /// English.
        /// </summary>
        public const string en = nameof(en);

        /// <summary>
        /// Spanish.
        /// </summary>
        public const string es = nameof(es);

        /// <summary>
        /// Finnish.
        /// </summary>
        public const string fi = nameof(fi);

        /// <summary>
        /// Portuguese.
        /// </summary>
        public const string pt = nameof(pt);

        /// <summary>
        /// Default language code.
        /// </summary>
        public const string DefaultLanguageCode = Languages.en;
    }
}
