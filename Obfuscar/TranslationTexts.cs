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
    /// Translations.
    /// </summary>
    public static partial class Translations
    {
        private static Dictionary<string, Dictionary<string, string>> translationsByLanguage = new Dictionary<string, Dictionary<string, string>>()
        { { "DUMMY", new Dictionary<string, string>(){ } }, { Languages.ar, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** وحدة تحكم DotBlur ({0}) في {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "عرض رقم إصدار هذا التطبيق." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** أداة DotBlur العالمية ({0}) في {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "اطبع معلومات المساعدة هذه." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "جاري تحميل المشروع '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.cs, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Zobrazení čísla verze této aplikace." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Vytiskněte tuto nápovědu." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Načítání projektu '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.da, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Vis versionsnummeret for denne applikation." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Udskriv denne hjælpeinformation." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Indlæser projekt '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.de, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) am {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Versionsnummer dieser Anwendung anzeigen." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) am {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Drucken Sie diese Hilfeinformation aus." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Laden des Projekts '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.en, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Display version number of this application." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Print this help information." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Loading project '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.es, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** Consola DotBlur ({0}) el {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Muestra el número de versión de esta aplicación." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) el {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprime esta información de ayuda." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Cargando proyecto '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.fi, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Näyttää tämän sovelluksen versionumeron." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Tulosta tämä ohje." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Lataa projekti '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.fr, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Affiche le numéro de version de cette application." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprimer ces informations d'aide." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Chargement du projet '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.it, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) il {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Visualizza il numero di versione di questa applicazione." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** Strumento globale DotBlur ({0}) il {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Stampare queste informazioni di aiuto." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Caricamento del progetto '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.ja, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** ドットブラーコンソール ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "このアプリケーションのバージョン番号を表示します。" }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** ドットブラーグローバルツール ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "このヘルプ情報を印刷する。" }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "プロジェクト '{0}' をロードしています。" }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.ko, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur 콘솔({0}) {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "이 애플리케이션의 버전 번호를 표시합니다." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur 글로벌 도구({0}) {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "이 도움말 정보를 인쇄하세요." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "프로젝트 '{0}'을 로드하는 중입니다." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.nb, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur-konsoll ({0}) på {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Vis versjonsnummeret til denne applikasjonen." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) på {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Skriv ut denne hjelpeinformasjonen." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Laster prosjektet '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.nl, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) op {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Versienummer van deze applicatie weergeven." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) op {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Druk deze helpinformatie af." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Project '{0}' wordt geladen." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.pl, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** Konsola DotBlur ({0}) w dniu {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Wyświetla numer wersji tej aplikacji." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Wydrukuj te informacje pomocy." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Ładowanie projektu '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.pt, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** Consola DotBlur ({0}) em {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Mostra o número da versão desta aplicação." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** Ferramenta DotBlur Global ({0}) em {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprimir esta informação de ajuda." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "A carregar o projeto '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        , { Languages.sv, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_display_version, "Visar versionsnummer för denna applikation." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Skriv ut denna hjälpinformation." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Laddar projekt '{0}'." }
          , { TranslationKeys.db_options_colon, "Options:" }
          }
        }
        };
    }
}
