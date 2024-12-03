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
using System.Globalization;

namespace Obfuscar
{
    /// <summary>
    /// Languages.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">ISO code.</param>
        /// <param name="resourceCode">Resource code.</param>
        /// <param name="cultureInfo">Culture info.</param>
        public Language(string code, string resourceCode, CultureInfo cultureInfo)
        {
            this.Code = code;
            this.ResourceCode = resourceCode;
            this.CultureInfo = cultureInfo;
        }

        /// <summary>
        /// ISO code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Resource code.
        /// </summary>
        public string ResourceCode { get; set; }

        /// <summary>
        /// Culture info.
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        /// <summary>
        /// Arabic.
        /// </summary>
        public static readonly Language ar = new Language(Languages.ar, "itgen_arabic", CultureInfo.GetCultureInfo("ar"));

        /// <summary>
        /// Czech.
        /// </summary>
        public static readonly Language cs = new Language(Languages.cs, "itgen_czech", CultureInfo.GetCultureInfo("cs"));

        /// <summary>
        /// Danish.
        /// </summary>
        public static readonly Language da = new Language(Languages.da, "itgen_danish", CultureInfo.GetCultureInfo("da"));

        /// <summary>
        /// German.
        /// </summary>
        public static readonly Language de = new Language(Languages.de, "itgen_german", CultureInfo.GetCultureInfo("de"));

        /// <summary>
        /// English.
        /// </summary>
        public static readonly Language en = new Language(Languages.en, "itgen_english", CultureInfo.GetCultureInfo("en"));

        /// <summary>
        /// Spanish.
        /// </summary>
        public static readonly Language es = new Language(Languages.es, "itgen_spanish", CultureInfo.GetCultureInfo("es"));

        /// <summary>
        /// Finnish.
        /// </summary>
        public static readonly Language fi = new Language(Languages.fi, "itgen_finnish", CultureInfo.GetCultureInfo("fi"));

        /// <summary>
        /// French.
        /// </summary>
        public static readonly Language fr = new Language(Languages.fr, "itgen_french", CultureInfo.GetCultureInfo("fr"));

        /// <summary>
        /// Italian.
        /// </summary>
        public static readonly Language it = new Language(Languages.it, "itgen_italian", CultureInfo.GetCultureInfo("it"));

        /// <summary>
        /// Japanese.
        /// </summary>
        public static readonly Language ja = new Language(Languages.ja, "itgen_japanese", CultureInfo.GetCultureInfo("ja"));

        /// <summary>
        /// Korean.
        /// </summary>
        public static readonly Language ko = new Language(Languages.ko, "itgen_korean", CultureInfo.GetCultureInfo("ko"));

        /// <summary>
        /// Bokmal.
        /// </summary>
        public static readonly Language nb = new Language(Languages.nb, "itgen_bokmal", CultureInfo.GetCultureInfo("nb"));

        /// <summary>
        /// Dutch.
        /// </summary>
        public static readonly Language nl = new Language(Languages.nl, "itgen_dutch", CultureInfo.GetCultureInfo("nl-NL"));

        /// <summary>
        /// Polish.
        /// </summary>
        public static readonly Language pl = new Language(Languages.pl, "itgen_polish", CultureInfo.GetCultureInfo("pl"));

        /// <summary>
        /// Portuguese.
        /// </summary>
        public static readonly Language pt = new Language(Languages.pt, "itgen_portuguese", CultureInfo.GetCultureInfo("pt"));

        /// <summary>
        /// Swedish.
        /// </summary>
        public static readonly Language sv = new Language(Languages.sv, "itgen_swedish", CultureInfo.GetCultureInfo("sv"));
    }
}
