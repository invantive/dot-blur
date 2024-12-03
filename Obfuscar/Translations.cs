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
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Obfuscar
{
    /// <summary>
    /// Translations.
    /// </summary>
    public static partial class Translations
    {
        [SupportedOSPlatform("windows")]
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetUserPreferredUILanguages(uint dwFlags, out uint pulNumLanguages, char[]? pwszLanguagesBuffer, ref uint pcchLanguagesBuffer);

        /// <summary>
        /// Gets a list of user preferred ISO language codes, with the first one representing
        /// the user UI language.
        /// </summary>
        /// <returns>List of language codes.</returns>
        [SupportedOSPlatform("windows")]
        private static List<string>? GetUserPreferredUITwoIsoLetterLanguageCodes()
        {
            //
            // ISO language (culture) name convention.
            //
            const uint MUI_LANGUAGE_NAME = 0x8;

            uint languagesCount, languagesBufferSize = 0;

            //
            // On Windows Vista and later, the user UI language is the first language in the user preferred UI languages list
            // Source: https://github.com/MicrosoftDocs/win32/blob/docs/desktop-src/Intl/user-interface-language-management.md)
            //
            if (GetUserPreferredUILanguages(MUI_LANGUAGE_NAME, out languagesCount, null, ref languagesBufferSize))
            {
                char[] languagesBuffer = new char[languagesBufferSize];
                if (GetUserPreferredUILanguages(MUI_LANGUAGE_NAME, out languagesCount, languagesBuffer, ref languagesBufferSize))
                {
                    List<string> result = new List<string>((int)languagesCount);
                    string[] languages = new string(languagesBuffer, 0, (int)languagesBufferSize - 2).Split('\0');

                    int cnt = 0;
                    foreach (string language in languages)
                    {
                        cnt++;

                        //
                        // Register as ISO two letter language when format is xx-xx.
                        //
                        if (language.Length == 5 && language[2] == '-')
                        {
                            result.Add(language.Substring(0, 2));
                        }
                    }

                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private static string? defaultLanguageCode;
        private static object defaultLanguageCodeLocker = new object();

        /// <summary>
        /// Gets the default language code for the user from the Operating System.
        /// </summary>
        /// <returns>Default language code.</returns>
        public static string GetOSUserPreferredLanguageCode()
        {
            if (string.IsNullOrEmpty(defaultLanguageCode))
            {
                lock (defaultLanguageCodeLocker)
                {
                    if (string.IsNullOrEmpty(defaultLanguageCode))
                    {
                        string? languageToUse = null;

                        bool useFallback;

                        //
                        // First try to determine the preferred UI language of the user, which
                        // is returned in the first position from GetUserPreferredUITwoIsoLetterLanguageCodes.
                        //
                        try
                        {
                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                            {
                                List<string>? preferredUiLanguages = GetUserPreferredUITwoIsoLetterLanguageCodes();

                                if (preferredUiLanguages?.Any() ?? false)
                                {
                                    languageToUse = preferredUiLanguages.First();
                                    useFallback = false;
                                }
                                else
                                {
                                    useFallback = true;
                                }
                            }
                            else
                            {
                                useFallback = true;
                            }
                        }
                        catch (Exception)
                        {
                            useFallback = true;
                        }

                        //
                        // Second try is to fallback to the user interface language, which may be wrong
                        // The user can later select his desired language during installation.
                        //
                        if (useFallback)
                        {
                            languageToUse = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                        }

                        if (string.IsNullOrEmpty(languageToUse))
                        {
                            languageToUse = Languages.DefaultLanguageCode;
                        }

                        //
                        // Only choose supported languages, and English otherwise.
                        //
                        string[] allowedUserInterfaceLanguages = Languages.DisplayLanguages.Keys.ToArray();

                        if (allowedUserInterfaceLanguages != null && allowedUserInterfaceLanguages.Any())
                        {
                            if (!allowedUserInterfaceLanguages.Contains(languageToUse))
                            {
                                languageToUse = Languages.DefaultLanguageCode;
                            }
                        }

                        defaultLanguageCode = languageToUse;
                    }
                }
            }

            return defaultLanguageCode ?? Languages.DefaultLanguageCode;
        }

        /// <summary>
        /// Gets the current language.
        /// </summary>
        public static string CurrentLanguage { get; set; } = Languages.DefaultLanguageCode;

        /// <summary>
        /// Gets the allowed UI languages.
        /// </summary>
        public static IEnumerable<string> AllowedUiLanguages => Languages.DisplayLanguages.Keys;

        /// <summary>
        /// Get a translation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The translation.</returns>
        public static string GetTranslationOfKey(string key)
        {
            return GetTranslationOfKey(key, CurrentLanguage);
        }

        /// <summary>
        /// Get a translation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns>The translation.</returns>
        public static string GetTranslationOfKey(string key, string languageCode)
        {
            //
            // Search for Support Assistant-specific translation.
            //
            string? value;

            if (translationsByLanguage.TryGetValue(languageCode, out Dictionary<string, string>? translations))
            {
                if (translations.TryGetValue(key, out value))
                {
                    return value;
                }
            }

            return key;
        }

        /// <summary>
        /// Configure translations.
        /// </summary>
        public static void Configure()
        {
            CurrentLanguage = GetOSUserPreferredLanguageCode();
        }
    }
}
