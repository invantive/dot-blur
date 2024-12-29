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
          , { TranslationKeys.db_callstack, "مجموعة نداءات" }
          , { TranslationKeys.db_check_project_settings, "التحقق من إعدادات المشروع." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console هو فرع من Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [خيارات] [ملف المشروع] [ملف المشروع]" }
          , { TranslationKeys.db_con_title_par2, "*** وحدة تحكم DotBlur ({0}) في {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(ج) 2007-{0}، ريان ويليامز ومساهمون آخرون." }
          , { TranslationKeys.db_dbr002_msg_par1, "لا يمكن تعيين المتغيرين \"{0}\" و\"{1}\" معًا." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "يرجى تصحيح محتويات الملف '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "يجب أن يحتوي ملف تكوين XML على علامة الجذر <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "تعذر إنشاء المسار '{0}' المحدد بواسطة OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "يجب أن يكون المسار '{0}' المحدد بواسطة متغير InPath موجودًا،" }
          , { TranslationKeys.db_dbr007_msg_par1, "فشل تحميل ملف المفتاح '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "لا يتم دعم حاويات المفاتيح لـ Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "غير قادر على حل التبعية '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "استخدم 'العام'." }
          , { TranslationKeys.db_dbr010_msg_par1, "\"{0}\" غير صالح لقيمة 'typeattrib' لعناصر التخطي." }
          , { TranslationKeys.db_dbr011_msg, "استخدم 'العام'." }
          , { TranslationKeys.db_dbr011_msg_par1, "\"{0}\" غير صالح لقيمة \"attrib\" لعنصر SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "غير قادر على استبدال المتغير '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "استخدم \"عام\" أو \"محمي\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "\"{0}\" غير صالح لقيمة \"attrib\" لعناصر التخطي." }
          , { TranslationKeys.db_dbr014_msg_par1, "غير قادر على قراءة ملف المشروع المحدد '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "استخدم خاصية KeyFile أو KeyContainer لتعيين المفتاح الذي تريد استخدامه." }
          , { TranslationKeys.db_dbr015_msg_par1, "سيؤدي إخفاء التجميع الموقع '{0}' إلى إنشاء تجميع غير صالح." }
          , { TranslationKeys.db_dbr017_msg_par1, "غير قادر على توقيع التجميع باستخدام المفتاح من حاوية المفتاح '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} ليس ملف XML صالحًا." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "غير قادر على العثور على التجميع '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "فشل الحصول على تعريفات النوع لـ {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "إنشاء زوج مفاتيح من '{0}' بدون كلمة مرور." }
          , { TranslationKeys.db_dbr027_msg, "الاسم يجب أن يكون له قيمة." }
          , { TranslationKeys.db_dbr028_msg, "يجب تعيين الاسم وتعبير الاسم العادي." }
          , { TranslationKeys.db_dbr029_msg, "يجب استدعاء AssemblyInfo.LoadAssembly قبل الاستخدام." }
          , { TranslationKeys.db_dbr031_msg, "يجب استدعاء AssemblyInfo.Init قبل الاستخدام." }
          , { TranslationKeys.db_dbr034_msg, "بحاجة إلى سمة ملف صالحة." }
          , { TranslationKeys.db_dbr035_msg_par1, "يجب أن تكون أسماء النوع '{0}' و'{1}' متساوية." }
          , { TranslationKeys.db_dbr036_msg, "لم يتم تعيين الاسم وتعبير الاسم العادي." }
          , { TranslationKeys.db_dbr038_msg, "لم يتم تعيين تعريف نوع الترميز." }
          , { TranslationKeys.db_dbr039_msg, "لم يتم تعيين أحدث البيانات." }
          , { TranslationKeys.db_dbr040_msg, "تعذر توقيع التجميع نظرًا لعدم إمكانية تحديد موقع signtool.exe." }
          , { TranslationKeys.db_dbr041_msg_par1, "تعذر توقيع التجميع نظرًا لعدم العثور على signtool.exe في الموقع المحدد '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "لم أتمكن من بدء عملية التوقيع باستخدام signtool.exe. لا توجد عملية." }
          , { TranslationKeys.db_dbr043_msg_par1, "لم تنتهي عملية تجميع التوقيع في الوقت المخصص وهو {0:N0} مللي ثانية." }
          , { TranslationKeys.db_dbr044_msg, "تعذر توقيع التجميع لأن اسم ملف المفتاح غير محدد." }
          , { TranslationKeys.db_dbr045_msg_par1, "تعذر توقيع التجميع لأن اسم ملف المفتاح '{0}' ليس ملف شهادة PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "إعادة تسمية الأنواع في تجميعات {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "معالجة لاحقة لتجميعات {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "حفظ التجميعات في '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "حفظ التخطيط في الملف '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "مجلدات الإطار الإضافية:" }
          , { TranslationKeys.db_dbr061_msg_par1, "فشل في حفظ '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "قد يكون {0} واحدًا من:" }
          , { TranslationKeys.db_dbr069_msg_par1, "لا تقم بإنشاء زوج مفاتيح من '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "تم الانتهاء بنجاح في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr079_msg_par1, "إنشاء قيمة مفتاح RSA من '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "تم الانتهاء بنجاح في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr108_msg_par1, "عملية التجميع '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "إنشاء زوج مفاتيح من {0} باستخدام كلمة المرور." }
          , { TranslationKeys.db_dbr110_msg, "لا يوجد ملف مفتاح ولا حاوية مفتاح تم تكوينها. لا تستخدم أي زوج مفاتيح." }
          , { TranslationKeys.db_dbr111_msg, "لا يوجد ملف مفتاح ولا حاوية مفتاح تم تكوينها. لا تستخدم أي قيمة مفتاح RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "لا تنشئ قيمة مفتاح RSA من '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "ابدأ بالتوقيع '{0}' باستخدام أداة التوقيع '{1}' مع الوسائط '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "تحميل التجميعات." }
          , { TranslationKeys.db_dbr117_msg_par1, "لم يتم حفظ التجميع '{0}' باستخدام زوج مفاتيح المشروع إلى '{1}' بسبب {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "تم التوقيع على '{0}' كـ '{1}' باستخدام الحاوية '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "تم حفظ '{0}' كما هو في '{1}'؛ لم يكن في الأصل يحمل توقيعًا قويًا." }
          , { TranslationKeys.db_dbr120_msg_par1, "احفظ '{0}' باستخدام زوج مفاتيح المشروع إلى '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "هناك {0:N0} تجميعات في المشروع لحفظها." }
          , { TranslationKeys.db_dbr123_msg_par1, "تم التوقيع '{0}'." }
          , { TranslationKeys.db_dbr124_msg_par1, "لا يوجد مفتاح عام للتجميع '{0}'؛ احفظه كما هو." }
          , { TranslationKeys.db_dbr125_msg_par1, "قناة ستدير: {0}" }
          , { TranslationKeys.db_dbr130_par1, "تم الانتهاء من ذلك مع وجود خطأ في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr131_par1, "تم الانتهاء من ذلك مع وجود خطأ في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr132_par1, "تم الانتهاء من ذلك مع وجود خطأ في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr133_par1, "تم الانتهاء من ذلك مع وجود خطأ في {0:N0} ثانية." }
          , { TranslationKeys.db_dbr135_msg, "من المتوقع أن تكون الحالة إما \"تمت إعادة تسميتها\" أو \"تم تخطيها\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "من المتوقع أن تكون الحالة إما \"تمت إعادة تسميتها\" أو \"تم تخطيها\" بدلاً من {0} من '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "اسم الملف مفقود." }
          , { TranslationKeys.db_dbr143_msg, "كان من المفترض أن يتم التعامل مع العلم الخارجي للمجموعة عند إنشاء المجموعة ويجب أن يتم بالفعل وضع علامة \"تخطي\" على جميع الأساليب في المجموعة." }
          , { TranslationKeys.db_dbr144_msg, "يجب أن يكون للطريقة اسم عندما لا يتم تخطي الطريقة ويكون للمجموعة اسم." }
          , { TranslationKeys.db_dbr145_msg_par1, "لم يتم توقيع \"{0}\" بسبب رمز الخطأ {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "يجب أن تكون الحالة \"تمت إعادة تسميتها\" أو \"تخطيها\" بدلاً من \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "القناة القياسية: {0}" }
          , { TranslationKeys.db_dbr154_msg, "لا توجد مجلدات إطارية إضافية:" }
          , { TranslationKeys.db_dbr155_msg, "لا يمكن استخراج اسم النوع." }
          , { TranslationKeys.db_dbr156_msg_par1, "قم بتحميل تعريف مشروع XML من '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "تمت معالجة {0} متغير." }
          , { TranslationKeys.db_dbr158_msg_par1, "تمت معالجة {0} تتضمن العلامات." }
          , { TranslationKeys.db_dbr159_msg_par1, "تمت معالجة {0} مسارات بحث التجميع." }
          , { TranslationKeys.db_dbr160_msg_par1, "تمت معالجة {0} وحدة." }
          , { TranslationKeys.db_dbr161_msg_par1, "تمت معالجة {0} مجموعات وحدات." }
          , { TranslationKeys.db_dbr162_msg, "تهيئة الإعدادات من المتغيرات." }
          , { TranslationKeys.db_dbr166_msg_par1, "يجب أن يحتوي ملف الشهادة '{0}' على شهادة واحدة على الأقل." }
          , { TranslationKeys.db_dbr167_msg_par1, "ملف الشهادة '{0}' له تنسيق غير صالح." }
          , { TranslationKeys.db_dbr169_msg, "تحديد الأحرف لتوليد الاسم." }
          , { TranslationKeys.db_dbr173_msg_par1, "تم العثور على تثبيت {0} في '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "لم يتم العثور على تثبيت {0} في '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "يمكن استخدام واحد على الأكثر من اختيار الشهادة حسب اسم ملف المفتاح وبصمة SHA1." }
          , { TranslationKeys.db_dbr176_msg, "يجب استخدام اختيار الشهادة عن طريق اسم ملف المفتاح أو بصمة SHA1." }
          , { TranslationKeys.db_dbr177_msg, "لا يمكن توفير كلمة مرور ملف المفتاح إلا عند تحديد الشهادة حسب اسم ملف المفتاح." }
          , { TranslationKeys.db_definition_missing, "التعريف مفقود." }
          , { TranslationKeys.db_display_version, "عرض رقم إصدار هذا التطبيق." }
          , { TranslationKeys.db_duplicate_character, "شخصية مكررة." }
          , { TranslationKeys.db_error_processing_colon, "حدث خطأ أثناء المعالجة:" }
          , { TranslationKeys.db_filename_missing, "اسم الملف مفقود." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur هو شوكة من Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "الاسم الكامل مفقود." }
          , { TranslationKeys.db_gt_title_par2, "*** أداة DotBlur العالمية ({0}) في {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "اطبع معلومات المساعدة هذه." }
          , { TranslationKeys.db_hide_strings, "إخفاء السلاسل." }
          , { TranslationKeys.db_hint_colon_par1, "تلميح: {0}" }
          , { TranslationKeys.db_hint_skiptype, "تلميح: قد تحتاج إلى إضافة SkipType لعنصر التعداد أعلاه." }
          , { TranslationKeys.db_inner_exception_par1, "الاستثناء الداخلي: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "جاري تحميل المشروع '{0}'." }
          , { TranslationKeys.db_missing_group, "مجموعة مفقودة." }
          , { TranslationKeys.db_missing_parent_reader, "قارئ الوالدين مفقود." }
          , { TranslationKeys.db_missing_parts, "أجزاء مفقودة." }
          , { TranslationKeys.db_missing_path_value, "قيمة مفقودة للمسار." }
          , { TranslationKeys.db_missing_read_action, "إجراء القراءة مفقود." }
          , { TranslationKeys.db_missing_setting_name, "اسم الإعداد مفقود." }
          , { TranslationKeys.db_not_hide_strings, "لا تخفي الخيوط." }
          , { TranslationKeys.db_not_rename_events, "لا تقم بإعادة تسمية الأحداث." }
          , { TranslationKeys.db_not_rename_fields, "لا تقم بإعادة تسمية الحقول." }
          , { TranslationKeys.db_not_rename_properties, "لا تقم بإعادة تسمية الخصائص." }
          , { TranslationKeys.db_options_colon, "خيارات:" }
          , { TranslationKeys.db_pool_clean, "لا يمكن تنظيف المسبح." }
          , { TranslationKeys.db_pool_still, "لا يزال في حمام السباحة:" }
          , { TranslationKeys.db_rename_events, "إعادة تسمية الأحداث." }
          , { TranslationKeys.db_rename_fields, "إعادة تسمية الحقول." }
          , { TranslationKeys.db_rename_methods, "إعادة تسمية الأساليب." }
          , { TranslationKeys.db_rename_parameters, "إعادة تسمية المعلمات." }
          , { TranslationKeys.db_rename_properties, "إعادة تسمية الخصائص." }
          , { TranslationKeys.db_settings_not_initialized, "لم يتم تهيئة الإعدادات بعد." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [خيارات] [ملف المشروع] [ملف المشروع]" }
          }
        }
        , { Languages.cs, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Zkontrolujte nastavení projektu." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console je rozvětvení aplikace Obfuscar (https://www.obfuscar.com)." }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [project_file] [project_file]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams a další přispěvatelé." }
          , { TranslationKeys.db_dbr002_msg_par1, "Proměnné '{0}' a '{1}' nelze nastavit společně." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Opravte prosím obsah souboru '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "Konfigurační soubor XML by měl mít kořenovou značku <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "Nepodařilo se vytvořit cestu '{0}' zadanou pomocí OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Cesta '{0}' zadaná proměnnou InPath musí existovat," }
          , { TranslationKeys.db_dbr007_msg_par1, "Selhání při načítání souboru s klíčem '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Klíčové kontejnery nejsou pro Mono podporovány." }
          , { TranslationKeys.db_dbr009_msg_par1, "Nelze vyřešit závislost '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Použijte \"public\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" není platná pro hodnotu \"typeattrib\" prvků skip." }
          , { TranslationKeys.db_dbr011_msg, "Použijte \"public\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" není platná pro hodnotu \"attrib\" elementu SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "Nelze nahradit proměnnou '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Použijte \"public\" nebo \"protected\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" není platná pro hodnotu \"attrib\" prvků skip." }
          , { TranslationKeys.db_dbr014_msg_par1, "Nelze načíst zadaný soubor projektu '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Pomocí vlastnosti KeyFile nebo KeyContainer nastavte klíč, který chcete použít." }
          , { TranslationKeys.db_dbr015_msg_par1, "Obfuskace podepsané sestavy '{0}' by vedla k neplatné sestavě." }
          , { TranslationKeys.db_dbr017_msg_par1, "Nelze podepsat sestavu pomocí klíče z kontejneru klíčů '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} není platný soubor XML." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Nelze najít sestavu '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Nepodařilo se získat definice typu pro {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Vytvoření páru klíčů z '{0}' bez hesla." }
          , { TranslationKeys.db_dbr027_msg, "Název musí mít hodnotu." }
          , { TranslationKeys.db_dbr028_msg, "Musí být nastaven regulární výraz pro název a jméno." }
          , { TranslationKeys.db_dbr029_msg, "Před použitím je třeba zavolat AssemblyInfo.LoadAssembly." }
          , { TranslationKeys.db_dbr031_msg, "Před použitím je třeba zavolat AssemblyInfo.Init." }
          , { TranslationKeys.db_dbr034_msg, "Potřebujete platný atribut souboru." }
          , { TranslationKeys.db_dbr035_msg_par1, "Názvy typů \"{0}\" a \"{1}\" se musí rovnat." }
          , { TranslationKeys.db_dbr036_msg, "Regulární výraz pro název a jméno není nastaven." }
          , { TranslationKeys.db_dbr038_msg, "Definice typu kódování není nastavena." }
          , { TranslationKeys.db_dbr039_msg, "Nejnovější údaje nejsou nastaveny." }
          , { TranslationKeys.db_dbr040_msg, "Nelze podepsat sestavu, protože soubor signtool.exe se nepodařilo najít." }
          , { TranslationKeys.db_dbr041_msg_par1, "Nelze podepsat sestavu, protože soubor signtool.exe nebyl nalezen v zadaném umístění '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Nepodařilo se spustit proces podepisování pomocí since signtool.exe. Žádný proces." }
          , { TranslationKeys.db_dbr043_msg_par1, "Podpisová sestava nebyla ukončena ve stanoveném čase {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Nelze podepsat sestavu, protože není nastaven název souboru s klíčem." }
          , { TranslationKeys.db_dbr045_msg_par1, "Sestavu nelze podepsat, protože název souboru klíče '{0}' není soubor certifikátu PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Přejmenování typů v sestavách {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "Následné zpracování sestav {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Uložte sestavy do '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Uložte mapování do souboru '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Rámcové složky navíc:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Nepodařilo se uložit '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} může být jedním z:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Nevytvořte žádný pár klíčů z '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Úspěšně dokončeno za {0:N0} sekund." }
          , { TranslationKeys.db_dbr079_msg_par1, "Vytvoření hodnoty klíče RSA z '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Úspěšně dokončeno za {0:N0} sekund." }
          , { TranslationKeys.db_dbr108_msg_par1, "Zpracování sestavy '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Vytvoření páru klíčů z {0} s heslem." }
          , { TranslationKeys.db_dbr110_msg, "Není nakonfigurován žádný soubor klíčů ani kontejner klíčů. Nepoužívejte žádný pár klíčů." }
          , { TranslationKeys.db_dbr111_msg, "Není nakonfigurován žádný soubor s klíčem ani kontejner s klíčem. Nepoužívejte žádnou hodnotu klíče RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Nevytvořte žádnou hodnotu klíče RSA z '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Spusťte podepisování '{0}' pomocí podepisovacího nástroje '{1}' s argumenty '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Nakládání sestav." }
          , { TranslationKeys.db_dbr117_msg_par1, "Sestava '{0}' nebyla uložena pomocí páru klíčů projektu do '{1}' kvůli {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Podepsáno '{0}' jako '{1}' pomocí kontejneru '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Uloženo '{0}' tak, jak je, v '{1}'; původně nebylo podepsáno silným jménem." }
          , { TranslationKeys.db_dbr120_msg_par1, "Uložte '{0}' pomocí dvojice klíčů projektu do '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "V projektu je {0:N0} sestav, které je třeba uložit." }
          , { TranslationKeys.db_dbr123_msg_par1, "Podepsáno \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "Sestava '{0}' nemá veřejný klíč; uložte ji tak, jak je." }
          , { TranslationKeys.db_dbr125_msg_par1, "Kanál Stderr: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Dokončeno s chybou za {0:N0} sekund." }
          , { TranslationKeys.db_dbr131_par1, "Dokončeno s chybou za {0:N0} sekund." }
          , { TranslationKeys.db_dbr132_par1, "Dokončeno s chybou za {0:N0} sekund." }
          , { TranslationKeys.db_dbr133_par1, "Dokončeno s chybou za {0:N0} sekund." }
          , { TranslationKeys.db_dbr135_msg, "Očekává se, že stav bude buď \"Přejmenováno\", nebo \"Přeskočeno\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Očekává se, že stav bude buď \"Přejmenováno\", nebo \"Přeskočeno\" místo {0} nebo \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Chybějící název souboru." }
          , { TranslationKeys.db_dbr143_msg, "Externí příznak skupiny by měl být zpracován již při jejím vytvoření a všechny metody ve skupině by měly být označeny jako přeskočené." }
          , { TranslationKeys.db_dbr144_msg, "Metoda musí mít název, pokud není přeskočena a skupina má název." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}\" nebyl podepsán kvůli chybovému kódu {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Stav musí být \"Přejmenováno\" nebo \"Přeskočeno\" místo \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Kanál Stdout: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Žádné další rámcové složky:" }
          , { TranslationKeys.db_dbr155_msg, "Nelze extrahovat název typu." }
          , { TranslationKeys.db_dbr156_msg_par1, "Načtení definice projektu XML z '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Zpracované proměnné {0}." }
          , { TranslationKeys.db_dbr158_msg_par1, "Zpracované {0} zahrnují značky." }
          , { TranslationKeys.db_dbr159_msg_par1, "Zpracováno {0} cest hledání sestavy." }
          , { TranslationKeys.db_dbr160_msg_par1, "Zpracováno {0} modulů." }
          , { TranslationKeys.db_dbr161_msg_par1, "Zpracováno {0} skupin modulů." }
          , { TranslationKeys.db_dbr162_msg, "Inicializace nastavení z proměnných." }
          , { TranslationKeys.db_dbr166_msg_par1, "Soubor certifikátu \"{0}\" musí obsahovat alespoň jeden certifikát." }
          , { TranslationKeys.db_dbr167_msg_par1, "Soubor certifikátu '{0}' má nesprávný formát." }
          , { TranslationKeys.db_dbr169_msg, "Určete znaky pro generování názvu." }
          , { TranslationKeys.db_dbr173_msg_par1, "Nalezena instalace {0} na adrese '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "V '{1}' nebyla nalezena žádná instalace {0}." }
          , { TranslationKeys.db_dbr175_msg, "Lze použít nejvýše jeden z certifikátů vybraných podle názvu souboru klíče a otisku SHA1." }
          , { TranslationKeys.db_dbr176_msg, "Je třeba použít buď výběr certifikátu podle názvu souboru s klíčem, nebo otisk SHA1." }
          , { TranslationKeys.db_dbr177_msg, "Heslo souboru s klíčem lze zadat pouze v případě, že je certifikát vybrán podle názvu souboru s klíčem." }
          , { TranslationKeys.db_definition_missing, "Definice chybí." }
          , { TranslationKeys.db_display_version, "Zobrazení čísla verze této aplikace." }
          , { TranslationKeys.db_duplicate_character, "Duplicitní znak." }
          , { TranslationKeys.db_error_processing_colon, "Při zpracování došlo k chybě:" }
          , { TranslationKeys.db_filename_missing, "Chybějící název souboru." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur je rozvětvení produktu Obfuscar (https://www.obfuscar.com)." }
          , { TranslationKeys.db_full_name_missing, "Chybí celé jméno." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Vytiskněte tuto nápovědu." }
          , { TranslationKeys.db_hide_strings, "Skrýt řetězce." }
          , { TranslationKeys.db_hint_colon_par1, "Nápověda: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Tip: možná budete muset přidat SkipType pro výše uvedený výčet." }
          , { TranslationKeys.db_inner_exception_par1, "Vnitřní výjimka: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Načítání projektu '{0}'." }
          , { TranslationKeys.db_missing_group, "Chybějící skupina." }
          , { TranslationKeys.db_missing_parent_reader, "Chybějící rodičovský čtenář." }
          , { TranslationKeys.db_missing_parts, "Chybějící díly." }
          , { TranslationKeys.db_missing_path_value, "Chybějící hodnota pro cestu." }
          , { TranslationKeys.db_missing_read_action, "Chybějící čtení." }
          , { TranslationKeys.db_missing_setting_name, "Chybějící název nastavení." }
          , { TranslationKeys.db_not_hide_strings, "Neskrývání řetězců." }
          , { TranslationKeys.db_not_rename_events, "Nepřejmenovávejte události." }
          , { TranslationKeys.db_not_rename_fields, "Nepřejmenovávejte pole." }
          , { TranslationKeys.db_not_rename_properties, "Nepřejmenovávejte vlastnosti." }
          , { TranslationKeys.db_options_colon, "Možnosti:" }
          , { TranslationKeys.db_pool_clean, "Nelze vyčistit bazén." }
          , { TranslationKeys.db_pool_still, "Stále v bazénu:" }
          , { TranslationKeys.db_rename_events, "Přejmenování událostí." }
          , { TranslationKeys.db_rename_fields, "Přejmenování polí." }
          , { TranslationKeys.db_rename_methods, "Přejmenování metod." }
          , { TranslationKeys.db_rename_parameters, "Přejmenování parametrů." }
          , { TranslationKeys.db_rename_properties, "Přejmenování vlastností." }
          , { TranslationKeys.db_settings_not_initialized, "Nastavení ještě nebylo inicializováno." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Options] [project_file] [project_file]" }
          }
        }
        , { Languages.da, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Tjek projektindstillingerne." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console er en forgrening af Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Indstillinger] [projekt_fil] [projekt_fil]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams og andre bidragydere." }
          , { TranslationKeys.db_dbr002_msg_par1, "Variablerne '{0}' og '{1}' kan ikke indstilles sammen." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Ret venligst indholdet af filen '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML-konfigurationsfilen skal have et <{0}> root-tag." }
          , { TranslationKeys.db_dbr005_msg_par1, "Kunne ikke oprette stien '{0}' specificeret af OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Stien '{0}', der er angivet af InPath-variablen, skal eksistere," }
          , { TranslationKeys.db_dbr007_msg_par1, "Fejl i indlæsning af nøglefilen '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Nøglecontainere understøttes ikke af Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Kan ikke løse afhængigheden '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Brug 'offentlig'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' er ikke gyldig for 'typeattrib'-værdien for skip-elementer." }
          , { TranslationKeys.db_dbr011_msg, "Brug 'offentlig'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' er ikke gyldig for 'attrib'-værdien i SkipType-elementet." }
          , { TranslationKeys.db_dbr012_msg_par1, "Kunne ikke erstatte variablen '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Brug 'offentlig' eller 'beskyttet'." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}' er ikke gyldig for 'attrib'-værdien af skip-elementer." }
          , { TranslationKeys.db_dbr014_msg_par1, "Kunne ikke læse den angivne projektfil '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Brug egenskaben KeyFile eller KeyContainer til at angive en nøgle, der skal bruges." }
          , { TranslationKeys.db_dbr015_msg_par1, "Obfuskering af den signerede samling '{0}' ville resultere i en ugyldig samling." }
          , { TranslationKeys.db_dbr017_msg_par1, "Kunne ikke signere samlingen med nøglen fra nøglebeholderen '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} er ikke en gyldig XML-fil." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Kan ikke finde samlingen '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Kunne ikke hente typedefinitioner for {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Opret nøglepar fra '{0}' uden adgangskode." }
          , { TranslationKeys.db_dbr027_msg, "Navnet skal have en værdi." }
          , { TranslationKeys.db_dbr028_msg, "Navn og regulært udtryk for navn skal være angivet." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly skal kaldes før brug." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init skal kaldes før brug." }
          , { TranslationKeys.db_dbr034_msg, "Har brug for gyldig filattribut." }
          , { TranslationKeys.db_dbr035_msg_par1, "Typenavnene '{0}' og '{1}' skal være ens." }
          , { TranslationKeys.db_dbr036_msg, "Navn og regulært udtryk for navn er ikke angivet." }
          , { TranslationKeys.db_dbr038_msg, "Definition af kodningstype ikke indstillet." }
          , { TranslationKeys.db_dbr039_msg, "Seneste data er ikke angivet." }
          , { TranslationKeys.db_dbr040_msg, "Kunne ikke signere samlingen, da signtool.exe ikke kunne findes." }
          , { TranslationKeys.db_dbr041_msg_par1, "Kunne ikke signere samlingen, da signtool.exe ikke kunne findes på den angivne placering '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Kunne ikke starte underskriftsprocessen ved hjælp af siden signtool.exe. Ingen proces." }
          , { TranslationKeys.db_dbr043_msg_par1, "Signeringssamlingen blev ikke afsluttet inden for den tildelte tid på {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Kunne ikke signere samlingen, da nøglefilnavnet ikke er angivet." }
          , { TranslationKeys.db_dbr045_msg_par1, "Kunne ikke signere samlingen, da nøglefilnavnet '{0}' ikke er en PFX-certifikatfil." }
          , { TranslationKeys.db_dbr054_msg_par1, "Omdøb typer i {0:N0}-samlinger." }
          , { TranslationKeys.db_dbr055_msg_par1, "Efterbehandling af {0:N0}-samlinger." }
          , { TranslationKeys.db_dbr056_msg_par1, "Gem samlinger i '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Gem kortlægningen i filen '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Ekstra rammemapper:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Det lykkedes ikke at gemme '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} kan være en af:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Opret ikke noget nøglepar fra '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Afsluttet med succes på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr079_msg_par1, "Opret RSA-nøgleværdi fra '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Afsluttet med succes på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr108_msg_par1, "Behandl samling '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Opret nøglepar fra {0} med adgangskode." }
          , { TranslationKeys.db_dbr110_msg, "Ingen nøglefil og ingen nøglebeholder konfigureret. Brug ikke noget nøglepar." }
          , { TranslationKeys.db_dbr111_msg, "Ingen nøglefil og ingen nøglebeholder konfigureret. Brug ingen RSA-nøgleværdi." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Opret ingen RSA-nøgleværdi fra '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Start signering af '{0}' ved hjælp af signeringsværktøjet '{1}' med argumenterne '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Indlæsning af samlinger." }
          , { TranslationKeys.db_dbr117_msg_par1, "Samling '{0}' ikke gemt med projektnøglepar til '{1}' på grund af {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signerede '{0}' som '{1}' ved hjælp af container '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Gemte '{0}' som den er i '{1}'; var oprindeligt ikke signeret med stærkt navn." }
          , { TranslationKeys.db_dbr120_msg_par1, "Gem '{0}' ved hjælp af projektets nøglepar til '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Der er {0:N0} samlinger i det projekt, der skal gemmes." }
          , { TranslationKeys.db_dbr123_msg_par1, "Underskrevet '{0}'." }
          , { TranslationKeys.db_dbr124_msg_par1, "Samling '{0}' har ingen offentlig nøgle; gem som den er." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-kanal: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Afsluttet med fejl om {0:N0} sekunder." }
          , { TranslationKeys.db_dbr131_par1, "Afsluttet med fejl om {0:N0} sekunder." }
          , { TranslationKeys.db_dbr132_par1, "Afsluttet med fejl om {0:N0} sekunder." }
          , { TranslationKeys.db_dbr133_par1, "Afsluttet med fejl om {0:N0} sekunder." }
          , { TranslationKeys.db_dbr135_msg, "Status forventes at være enten 'Renamed' eller 'Skipped'." }
          , { TranslationKeys.db_dbr139_msg_par1, "Status forventes at være enten 'Renamed' eller 'Skipped' i stedet for {0} eller '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Manglende filnavn." }
          , { TranslationKeys.db_dbr143_msg, "Gruppens eksterne flag skulle have været håndteret, da gruppen blev oprettet, og alle metoder i gruppen skulle allerede være markeret som sprunget over." }
          , { TranslationKeys.db_dbr144_msg, "Metoden skal have et navn, når metoden ikke er sprunget over, og gruppen har et navn." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' blev IKKE signeret på grund af fejlkode {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status skal være 'Renamed' eller 'Skipped' i stedet for '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-kanal: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Ingen ekstra rammemapper:" }
          , { TranslationKeys.db_dbr155_msg, "Kan ikke udtrække typenavn." }
          , { TranslationKeys.db_dbr156_msg_par1, "Indlæs XML-projektdefinition fra '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Behandlet {0} variabler." }
          , { TranslationKeys.db_dbr158_msg_par1, "Behandlet {0} inkluderer tags." }
          , { TranslationKeys.db_dbr159_msg_par1, "Behandlet {0} monteringssøgningsstier." }
          , { TranslationKeys.db_dbr160_msg_par1, "Behandlet {0} moduler." }
          , { TranslationKeys.db_dbr161_msg_par1, "Behandlet {0} modulgrupper." }
          , { TranslationKeys.db_dbr162_msg, "Initialiser indstillinger fra variabler." }
          , { TranslationKeys.db_dbr166_msg_par1, "Certifikatfilen '{0}' skal indeholde mindst ét certifikat." }
          , { TranslationKeys.db_dbr167_msg_par1, "Certifikatfilen '{0}' har et ugyldigt format." }
          , { TranslationKeys.db_dbr169_msg, "Bestem tegn til navnegenerering." }
          , { TranslationKeys.db_dbr173_msg_par1, "Fandt installation af {0} på '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Fandt ingen installation af {0} i '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Der kan højst bruges et af de certifikater, der vælges ud fra nøglefilens navn og SHA1 thumbprint." }
          , { TranslationKeys.db_dbr176_msg, "Der skal bruges enten certifikatvalg via nøglefilnavn eller SHA1 thumbprint." }
          , { TranslationKeys.db_dbr177_msg, "Adgangskoden til nøglefilen kan kun angives, når certifikatet vælges med nøglefilens navn." }
          , { TranslationKeys.db_definition_missing, "Der mangler en definition." }
          , { TranslationKeys.db_display_version, "Vis versionsnummeret for denne applikation." }
          , { TranslationKeys.db_duplicate_character, "Duplikeret tegn." }
          , { TranslationKeys.db_error_processing_colon, "Der opstod en fejl under behandlingen:" }
          , { TranslationKeys.db_filename_missing, "Manglende filnavn." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur er en forgrening af Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Det fulde navn mangler." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Udskriv denne hjælpeinformation." }
          , { TranslationKeys.db_hide_strings, "Skjul strenge." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Tip: Det kan være nødvendigt at tilføje en SkipType for en enum ovenfor." }
          , { TranslationKeys.db_inner_exception_par1, "Indre undtagelse: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Indlæser projekt '{0}'." }
          , { TranslationKeys.db_missing_group, "Mangler en gruppe." }
          , { TranslationKeys.db_missing_parent_reader, "Mangler en forælder som læser." }
          , { TranslationKeys.db_missing_parts, "Manglende dele." }
          , { TranslationKeys.db_missing_path_value, "Manglende værdi for sti." }
          , { TranslationKeys.db_missing_read_action, "Missing read action." }
          , { TranslationKeys.db_missing_setting_name, "Mangler navn på indstilling." }
          , { TranslationKeys.db_not_hide_strings, "Skjuler ikke strenge." }
          , { TranslationKeys.db_not_rename_events, "Du må ikke omdøbe begivenheder." }
          , { TranslationKeys.db_not_rename_fields, "Du må ikke omdøbe felter." }
          , { TranslationKeys.db_not_rename_properties, "Du må ikke omdøbe egenskaber." }
          , { TranslationKeys.db_options_colon, "Valgmuligheder:" }
          , { TranslationKeys.db_pool_clean, "Kan ikke gøre poolen ren." }
          , { TranslationKeys.db_pool_still, "Stadig i poolen:" }
          , { TranslationKeys.db_rename_events, "Omdøb begivenheder." }
          , { TranslationKeys.db_rename_fields, "Omdøb felter." }
          , { TranslationKeys.db_rename_methods, "Omdøb metoder." }
          , { TranslationKeys.db_rename_parameters, "Omdøb parametre." }
          , { TranslationKeys.db_rename_properties, "Omdøb egenskaber." }
          , { TranslationKeys.db_settings_not_initialized, "Indstillingerne er endnu ikke initialiseret." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Indstillinger] [projekt_fil] [projekt_fil]" }
          }
        }
        , { Languages.de, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Aufrufstapel" }
          , { TranslationKeys.db_check_project_settings, "Überprüfen der Projekteinstellungen." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console ist ein Fork von Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Optionen] [Projektdatei] [Projektdatei]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) am {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams und andere Beiträger." }
          , { TranslationKeys.db_dbr002_msg_par1, "Die Variablen '{0}' und '{1}' können nicht zusammen gesetzt werden." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Bitte korrigieren Sie den Inhalt der Datei '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML-Konfigurationsdatei sollte ein <{0}> root-Tag haben." }
          , { TranslationKeys.db_dbr005_msg_par1, "Der von OutPath angegebene Pfad '{0}' konnte nicht erstellt werden." }
          , { TranslationKeys.db_dbr006_msg_par1, "Der von der InPath-Variablen angegebene Pfad '{0}' muss vorhanden sein," }
          , { TranslationKeys.db_dbr007_msg_par1, "Fehler beim Laden der Schlüsseldatei '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Schlüsselcontainer werden für Mono nicht unterstützt." }
          , { TranslationKeys.db_dbr009_msg_par1, "Die Abhängigkeit '{0}' kann nicht aufgelöst werden." }
          , { TranslationKeys.db_dbr010_msg, "Verwenden Sie 'public'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' ist für den 'typeattrib'-Wert von Skip-Elementen nicht gültig." }
          , { TranslationKeys.db_dbr011_msg, "Verwenden Sie 'public'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" ist für den \"attrib\"-Wert des SkipType-Elements nicht gültig." }
          , { TranslationKeys.db_dbr012_msg_par1, "Die Variable '{0}' kann nicht ersetzt werden." }
          , { TranslationKeys.db_dbr013_msg, "Verwenden Sie 'public' oder 'protected'." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" ist für den \"attrib\"-Wert von \"Skip\"-Elementen nicht gültig." }
          , { TranslationKeys.db_dbr014_msg_par1, "Die angegebene Projektdatei '{0}' kann nicht gelesen werden." }
          , { TranslationKeys.db_dbr015_msg, "Verwende die Eigenschaft 'KeyFile' oder 'KeyContainer' um einen zu verwendenden Schlüssel festzulegen." }
          , { TranslationKeys.db_dbr015_msg_par1, "Das Verschleiern der signierten Assembly '{0}' würde zu einer ungültigen Assembly führen." }
          , { TranslationKeys.db_dbr017_msg_par1, "Assembly kann nicht signiert werden mit dem Schlüssel aus dem Schlüsselcontainer '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} ist keine gültige XML-Datei." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Assembly '{0}' kann nicht gefunden werden." }
          , { TranslationKeys.db_dbr020_msg_par1, "Fehler beim Abrufen von Typdefinitionen für {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Schlüsselpaar erstellen aus '{0}' ohne Passwort." }
          , { TranslationKeys.db_dbr027_msg, "Name muss einen Wert haben." }
          , { TranslationKeys.db_dbr028_msg, "Name und regulärer Ausdruck für Name müssen festgelegt worden sein." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly muss vor der Verwendung aufgerufen werden." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init muss vor der Verwendung aufgerufen werden." }
          , { TranslationKeys.db_dbr034_msg, "Gültiges Dateiattribut erforderlich." }
          , { TranslationKeys.db_dbr035_msg_par1, "Die Typnamen '{0}' und '{1}' müssen gleich sein." }
          , { TranslationKeys.db_dbr036_msg, "Name und regulärer Ausdruckname sind nicht festgelegt." }
          , { TranslationKeys.db_dbr038_msg, "Definition des Codierungstyps nicht festgelegt." }
          , { TranslationKeys.db_dbr039_msg, "Neuste Daten nicht festgelegt." }
          , { TranslationKeys.db_dbr040_msg, "Assembly konnte nicht signiert werden da signtool.exe nicht gefunden werden konnte." }
          , { TranslationKeys.db_dbr041_msg_par1, "Assembly konnte nicht signiert werden da signtool.exe am angegebenen Speicherort '{0}' nicht gefunden werden konnte." }
          , { TranslationKeys.db_dbr042_msg, "Signiervorgang mit signtool.exe konnte nicht gestartet werden. Kein Prozess." }
          , { TranslationKeys.db_dbr043_msg_par1, "Signieren der Assembly wurde nicht innerhalb der zugewiesenen Zeit von {0:N0} ms beendet." }
          , { TranslationKeys.db_dbr044_msg, "Assembly konnte nicht signiert werden da der Name der Schlüsseldatei nicht festgelegt ist." }
          , { TranslationKeys.db_dbr045_msg_par1, "Assembly konnte nicht signiert werden da es sich bei dem Schlüsseldateinamen '{0}' nicht um eine PFX-Zertifikatdatei handelt." }
          , { TranslationKeys.db_dbr054_msg_par1, "Umbenennen von Typen in {0:N0} Assemblies." }
          , { TranslationKeys.db_dbr055_msg_par1, "Nachbearbeitung von {0:N0} Assemblies." }
          , { TranslationKeys.db_dbr056_msg_par1, "Assemblys speichern in '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Zuordnung speichern in Dateil '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Zusätzliche Framework-Ordner:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Fehler beim Speichern von '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} könnte eines der folgenden sein:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Erzeugt kein Schlüsselpaar aus '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Erfolgreich abgeschlossen in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr079_msg_par1, "RSA-Schlüsselwert erstellen aus '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Erfolgreich abgeschlossen in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr108_msg_par1, "Assembly '{0}' verarbeiten." }
          , { TranslationKeys.db_dbr109_msg_par1, "Schlüsselpaar erstellen aus {0} mit Passwort." }
          , { TranslationKeys.db_dbr110_msg, "Keine Schlüsseldatei und kein Schlüsselcontainer konfiguriert. Kein Schlüsselpaar verwenden." }
          , { TranslationKeys.db_dbr111_msg, "Keine Schlüsseldatei und kein Schlüsselcontainer konfiguriert. Kein RSA-Schlüsselwert verwenden." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Keinen RSA-Schlüsselwert erstellen aus '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Starten mit Signieren von '{0}' mit dem Signierwerkzeug '{1}' mit Argument '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Assemblies laden." }
          , { TranslationKeys.db_dbr117_msg_par1, "Assembly '{0}' kann nicht mit Projektschlüsselpaar zu '{1}' gespeichert werden aufgrund von {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signiert '{0}' als '{1}' unter Verwendung des Containers '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "'{0}' wie-es-ist gespeichert in '{1}'; war ursprünglich nicht mit starkem Namen signiert." }
          , { TranslationKeys.db_dbr120_msg_par1, "'{0}' speichern mit dem Projektschlüsselpaar in '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Es gibt {0:N0} Assemblies im Projekt die gespeichert werden müssen." }
          , { TranslationKeys.db_dbr123_msg_par1, "'{0}' signiert." }
          , { TranslationKeys.db_dbr124_msg_par1, "Assembly '{0}' hat keinen öffentlichen Schlüssel; so speichern wie es ist." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-Kanal: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Abgeschlossen mit Fehler in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr131_par1, "Abgeschlossen mit Fehler in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr132_par1, "Abgeschlossen mit Fehler in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr133_par1, "Abgeschlossen mit Fehler in {0:N0} Sekunden." }
          , { TranslationKeys.db_dbr135_msg, "Der Status sollte entweder 'Renamed' oder 'Skipped' sein." }
          , { TranslationKeys.db_dbr139_msg_par1, "Der Status sollte entweder 'Renamed' oder 'Skipped' sein statt {0} von '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Fehlender Dateiname." }
          , { TranslationKeys.db_dbr143_msg, "Das externe Flag der Gruppe sollte beim Erstellen der Gruppe behandelt worden sein und alle Methoden in der Gruppe sollten bereits als übersprungen markiert sein." }
          , { TranslationKeys.db_dbr144_msg, "Die Methode muss einen Namen haben wenn die Methode nicht übersprungen wird und die Gruppe einen Namen hat." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' wurde aufgrund von Fehlercode {1} NICHT signiert." }
          , { TranslationKeys.db_dbr149_msg_par1, "Der Status sollte entweder 'Renamed' oder 'Skipped' sein statt '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-Kanal: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Keine zusätzlichen Framework-Ordner:" }
          , { TranslationKeys.db_dbr155_msg, "Der Typname kann nicht extrahiert werden." }
          , { TranslationKeys.db_dbr156_msg_par1, "XML-Projektdefinition laden von '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Verarbeitete {0} Variablen." }
          , { TranslationKeys.db_dbr158_msg_par1, "Verarbeitete {0} Include-Tags." }
          , { TranslationKeys.db_dbr159_msg_par1, "Verarbeitete {0} Assembly-Suchpfade." }
          , { TranslationKeys.db_dbr160_msg_par1, "Verarbeitete {0} Module." }
          , { TranslationKeys.db_dbr161_msg_par1, "Verarbeitete {0} Modulgruppen." }
          , { TranslationKeys.db_dbr162_msg, "Initialisieren Einstellungen aus Variablen." }
          , { TranslationKeys.db_dbr166_msg_par1, "Die Zertifikatsdatei '{0}' muss mindestens ein Zertifikat enthalten." }
          , { TranslationKeys.db_dbr167_msg_par1, "Die Zertifikatsdatei '{0}' hat ein ungültiges Format." }
          , { TranslationKeys.db_dbr169_msg, "Zeichen für die Namensgenerierung festlegen." }
          , { TranslationKeys.db_dbr173_msg_par1, "Installation von {0} gefunden bei '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Keine Installation von {0} in '{1}' gefunden." }
          , { TranslationKeys.db_dbr175_msg, "Es kann höchstens eine der Zertifikatsauswahl nach Schlüssel, Dateiname und SHA1-Fingerabdruck verwendet werden." }
          , { TranslationKeys.db_dbr176_msg, "Es muss entweder die Zertifikatsauswahl nach Schlüsseldateiname oder SHA1-Fingerabdruck verwendet werden." }
          , { TranslationKeys.db_dbr177_msg, "Das Kennwort für die Schlüsseldatei kann nur angegeben werden wenn das Zertifikat über den Namen der Schlüsseldatei ausgewählt wird." }
          , { TranslationKeys.db_definition_missing, "Definition fehlt." }
          , { TranslationKeys.db_display_version, "Versionsnummer dieser Anwendung anzeigen." }
          , { TranslationKeys.db_duplicate_character, "Doppeltes Zeichen." }
          , { TranslationKeys.db_error_processing_colon, "Während der Verarbeitung ist ein Fehler aufgetreten:" }
          , { TranslationKeys.db_filename_missing, "Fehlender Dateiname." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur ist ein Fork von Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Der vollständige Name fehlt." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) am {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Drucken Sie diese Hilfeinformationen aus." }
          , { TranslationKeys.db_hide_strings, "Zeichenfolgen ausblenden." }
          , { TranslationKeys.db_hint_colon_par1, "Hinweis: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Hinweis: Möglicherweise müssen Sie oben einen SkipType für eine Enum hinzufügen." }
          , { TranslationKeys.db_inner_exception_par1, "Innere Ausnahme: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Projekt '{0}' wird geladen." }
          , { TranslationKeys.db_missing_group, "Fehlende Gruppe." }
          , { TranslationKeys.db_missing_parent_reader, "Fehlender elterlicher Leser." }
          , { TranslationKeys.db_missing_parts, "Fehlende Teile." }
          , { TranslationKeys.db_missing_path_value, "Fehlender Wert für Pfad." }
          , { TranslationKeys.db_missing_read_action, "Fehlende Leseaktion." }
          , { TranslationKeys.db_missing_setting_name, "Fehlender Einstellungsname." }
          , { TranslationKeys.db_not_hide_strings, "Keine Strings ausblenden." }
          , { TranslationKeys.db_not_rename_events, "Ereignisse nicht umbennen." }
          , { TranslationKeys.db_not_rename_fields, "Felder nicht umbennen." }
          , { TranslationKeys.db_not_rename_properties, "Eigenschaften nicht umbennen." }
          , { TranslationKeys.db_options_colon, "Optionen:" }
          , { TranslationKeys.db_pool_clean, "Pool kann nicht geledigt werden." }
          , { TranslationKeys.db_pool_still, "Noch im Pool:" }
          , { TranslationKeys.db_rename_events, "Ereignisse umbenennen." }
          , { TranslationKeys.db_rename_fields, "Felder umbenennen." }
          , { TranslationKeys.db_rename_methods, "Methoden umbenennen." }
          , { TranslationKeys.db_rename_parameters, "Parameter umbenennen." }
          , { TranslationKeys.db_rename_properties, "Eigenschaften umbenennen." }
          , { TranslationKeys.db_settings_not_initialized, "Einstellungen noch nicht initialisiert." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Optionen] [Projektdatei] [Projektdatei]" }
          }
        }
        , { Languages.en, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Check project settings." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [project_file] [project_file]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams and other contributors." }
          , { TranslationKeys.db_dbr002_msg_par1, "{0}' and '{1}' variables can not be set together." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Please correct the contents of the file '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML configuration file should have a <{0}> root tag." }
          , { TranslationKeys.db_dbr005_msg_par1, "Could not create the path '{0}' specified by OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Path '{0}' specified by InPath variable must exist," }
          , { TranslationKeys.db_dbr007_msg_par1, "Failure loading key file '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Key containers are not supported for Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Unable to resolve dependency '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Use 'public'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' is not valid for the 'typeattrib' value of skip elements." }
          , { TranslationKeys.db_dbr011_msg, "Use 'public'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' is not valid for the 'attrib' value of the SkipType element." }
          , { TranslationKeys.db_dbr012_msg_par1, "Unable to replace variable '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Use 'public' or 'protected'." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}' is not valid for the 'attrib' value of skip elements." }
          , { TranslationKeys.db_dbr014_msg_par1, "Unable to read specified project file '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Use the KeyFile or KeyContainer property to set a key to use." }
          , { TranslationKeys.db_dbr015_msg_par1, "Obfuscating the signed assembly '{0}' would result in an invalid assembly." }
          , { TranslationKeys.db_dbr017_msg_par1, "Unable to sign assembly using key from key container '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} is not a valid XML file." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Unable to find assembly '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Failed to get type definitions for {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Create key pair from '{0}' with no password." }
          , { TranslationKeys.db_dbr027_msg, "Name must have a value." }
          , { TranslationKeys.db_dbr028_msg, "Name and name regular expression must have been set." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly must be called before use." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init must be called before use." }
          , { TranslationKeys.db_dbr034_msg, "Need valid file attribute." }
          , { TranslationKeys.db_dbr035_msg_par1, "Type names '{0}' and '{1}' must be equal." }
          , { TranslationKeys.db_dbr036_msg, "Name and name regular expression are not set." }
          , { TranslationKeys.db_dbr038_msg, "Encoding type definition not set." }
          , { TranslationKeys.db_dbr039_msg, "Most recent data not set." }
          , { TranslationKeys.db_dbr040_msg, "Could not sign assembly since signtool.exe could not be located." }
          , { TranslationKeys.db_dbr041_msg_par1, "Could not sign assembly since signtool.exe could not be found on the specified location '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Could not start sign process using since signtool.exe. No process." }
          , { TranslationKeys.db_dbr043_msg_par1, "Signing assembly did not end within the allotted time of {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Could not sign assembly since the key file name is not set." }
          , { TranslationKeys.db_dbr045_msg_par1, "Could not sign assembly since the key file name '{0}' is not a PFX certificate file." }
          , { TranslationKeys.db_dbr054_msg_par1, "Rename types in {0:N0} assemblies." }
          , { TranslationKeys.db_dbr055_msg_par1, "Post processing of {0:N0} assemblies." }
          , { TranslationKeys.db_dbr056_msg_par1, "Save assemblies to '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Save mapping to file '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Extra framework folders:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Failed to save '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} might be one of:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Create no key pair from '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Completed successfully in {0:N0} seconds." }
          , { TranslationKeys.db_dbr079_msg_par1, "Create RSA key value from '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Completed successfully in {0:N0} seconds." }
          , { TranslationKeys.db_dbr108_msg_par1, "Process assembly '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Create key pair from {0} with password." }
          , { TranslationKeys.db_dbr110_msg, "No key file and no key container configured. Use no key pair." }
          , { TranslationKeys.db_dbr111_msg, "No key file and no key container configured. Use no RSA key value." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Create no RSA key value from '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Start signing '{0}' using sign tool '{1}' with arguments '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Loading assemblies." }
          , { TranslationKeys.db_dbr117_msg_par1, "Assembly '{0}' not saved using project keypair to '{1}' due to {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signed '{0}' as '{1}' using container '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Saved '{0}' as-is in '{1}'; was originally not strong name signed." }
          , { TranslationKeys.db_dbr120_msg_par1, "Save '{0}' using project keypair to '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "There are {0:N0} assemblies in the project to save." }
          , { TranslationKeys.db_dbr123_msg_par1, "Signed '{0}'." }
          , { TranslationKeys.db_dbr124_msg_par1, "Assembly '{0}' has no public key; save as-is." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr channel: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Completed with error in {0:N0} seconds." }
          , { TranslationKeys.db_dbr131_par1, "Completed with error in {0:N0} seconds." }
          , { TranslationKeys.db_dbr132_par1, "Completed with error in {0:N0} seconds." }
          , { TranslationKeys.db_dbr133_par1, "Completed with error in {0:N0} seconds." }
          , { TranslationKeys.db_dbr135_msg, "Status is expected to be either 'Renamed' or 'Skipped'." }
          , { TranslationKeys.db_dbr139_msg_par1, "Status is expected to be either 'Renamed' or 'Skipped' instead of {0} of '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Missing file name." }
          , { TranslationKeys.db_dbr143_msg, "Group's external flag should have been handled when the group was created and all methods in the group should already be marked skipped." }
          , { TranslationKeys.db_dbr144_msg, "Method must have a name when the method is not skipped and the group has a name." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' was NOT signed due to error code {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status must be 'Renamed' or 'Skipped' instead of '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout channel: {0}" }
          , { TranslationKeys.db_dbr154_msg, "No extra framework folders:" }
          , { TranslationKeys.db_dbr155_msg, "Can not extract type name." }
          , { TranslationKeys.db_dbr156_msg_par1, "Load XML project definition from '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Processed {0} variables." }
          , { TranslationKeys.db_dbr158_msg_par1, "Processed {0} include tags." }
          , { TranslationKeys.db_dbr159_msg_par1, "Processed {0} assembly search paths." }
          , { TranslationKeys.db_dbr160_msg_par1, "Processed {0} modules." }
          , { TranslationKeys.db_dbr161_msg_par1, "Processed {0} module groups." }
          , { TranslationKeys.db_dbr162_msg, "Initialize settings from variables." }
          , { TranslationKeys.db_dbr166_msg_par1, "The certificate file '{0}' must contain at least one certificate." }
          , { TranslationKeys.db_dbr167_msg_par1, "The certificate file '{0}' has an invalid format." }
          , { TranslationKeys.db_dbr169_msg, "Determine characters for name generation." }
          , { TranslationKeys.db_dbr173_msg_par1, "Found installation of {0} at '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Found no installation of {0} in '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "At most one of certificate selection by key file name and SHA1 thumbprint can be used." }
          , { TranslationKeys.db_dbr176_msg, "Either certificate selection by key file name or SHA1 thumbprint must be used." }
          , { TranslationKeys.db_dbr177_msg, "The key file password can only be supplied when the certificate is selected by key file name." }
          , { TranslationKeys.db_definition_missing, "Definition is missing." }
          , { TranslationKeys.db_display_version, "Display version number of this application." }
          , { TranslationKeys.db_duplicate_character, "Duplicate character." }
          , { TranslationKeys.db_error_processing_colon, "An error occurred during processing:" }
          , { TranslationKeys.db_filename_missing, "Missing file name." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is a fork of Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Full name is missing." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Print this help information." }
          , { TranslationKeys.db_hide_strings, "Hide strings." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Hint: you might need to add a SkipType for an enum above." }
          , { TranslationKeys.db_inner_exception_par1, "Inner exception: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Loading project '{0}'." }
          , { TranslationKeys.db_missing_group, "Missing group." }
          , { TranslationKeys.db_missing_parent_reader, "Missing parent reader." }
          , { TranslationKeys.db_missing_parts, "Missing parts." }
          , { TranslationKeys.db_missing_path_value, "Missing value for path." }
          , { TranslationKeys.db_missing_read_action, "Missing read action." }
          , { TranslationKeys.db_missing_setting_name, "Missing setting name." }
          , { TranslationKeys.db_not_hide_strings, "Not hiding strings." }
          , { TranslationKeys.db_not_rename_events, "Do not rename events." }
          , { TranslationKeys.db_not_rename_fields, "Do not rename fields." }
          , { TranslationKeys.db_not_rename_properties, "Do not rename properties." }
          , { TranslationKeys.db_options_colon, "Options:" }
          , { TranslationKeys.db_pool_clean, "Cannot clean pool." }
          , { TranslationKeys.db_pool_still, "Still in pool:" }
          , { TranslationKeys.db_rename_events, "Rename events." }
          , { TranslationKeys.db_rename_fields, "Rename fields." }
          , { TranslationKeys.db_rename_methods, "Rename methods." }
          , { TranslationKeys.db_rename_parameters, "Rename parameters." }
          , { TranslationKeys.db_rename_properties, "Rename properties." }
          , { TranslationKeys.db_settings_not_initialized, "Settings not yet initialized." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Options] [project_file] [project_file]" }
          }
        }
        , { Languages.es, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Pila de llamadas" }
          , { TranslationKeys.db_check_project_settings, "Compruebe la configuración del proyecto." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console es una bifurcación de Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Opciones] [archivo_proyecto] [archivo_proyecto]" }
          , { TranslationKeys.db_con_title_par2, "*** Consola DotBlur ({0}) el {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams y otros colaboradores." }
          , { TranslationKeys.db_dbr002_msg_par1, "Las variables '{0}' y '{1}' no pueden establecerse juntas." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Por favor, corrija el contenido del fichero '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "El archivo de configuración XML debe tener una etiqueta raíz <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "No se ha podido crear la ruta '{0}' especificada por OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "La ruta '{0}' especificada por la variable InPath debe existir," }
          , { TranslationKeys.db_dbr007_msg_par1, "Fallo al cargar el archivo de claves '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Los contenedores de claves no son compatibles con Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "No se ha podido resolver la dependencia '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Utiliza \"público\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' no es válido para el valor 'typeattrib' de los elementos skip." }
          , { TranslationKeys.db_dbr011_msg, "Utiliza \"público\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' no es válido para el valor 'attrib' del elemento SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "No se ha podido reemplazar la variable '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Utiliza \"público\" o \"protegido\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}' no es válido para el valor 'attrib' de los elementos skip." }
          , { TranslationKeys.db_dbr014_msg_par1, "No se ha podido leer el archivo de proyecto especificado '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Utilice la propiedad KeyFile o KeyContainer para establecer una clave a utilizar." }
          , { TranslationKeys.db_dbr015_msg_par1, "La ofuscación del ensamblado firmado '{0}' daría como resultado un ensamblado inválido." }
          , { TranslationKeys.db_dbr017_msg_par1, "No se ha podido firmar el conjunto con la clave del contenedor de claves '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} no es un archivo XML válido." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "No se puede encontrar el ensamblaje '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Error al obtener las definiciones de tipo para {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Crear par de claves de '{0}' sin contraseña." }
          , { TranslationKeys.db_dbr027_msg, "El nombre debe tener un valor." }
          , { TranslationKeys.db_dbr028_msg, "El nombre y la expresión regular del nombre deben haber sido configurados." }
          , { TranslationKeys.db_dbr029_msg, "Se debe llamar a AssemblyInfo.LoadAssembly antes de utilizarlo." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init debe invocarse antes de su uso." }
          , { TranslationKeys.db_dbr034_msg, "Necesita un atributo de archivo válido." }
          , { TranslationKeys.db_dbr035_msg_par1, "Los nombres de tipo '{0}' y '{1}' deben ser iguales." }
          , { TranslationKeys.db_dbr036_msg, "El nombre y la expresión regular del nombre no están configurados." }
          , { TranslationKeys.db_dbr038_msg, "No se ha definido el tipo de codificación." }
          , { TranslationKeys.db_dbr039_msg, "No se han establecido los datos más recientes." }
          , { TranslationKeys.db_dbr040_msg, "No se ha podido firmar el ensamblado porque no se ha localizado signtool.exe." }
          , { TranslationKeys.db_dbr041_msg_par1, "No se pudo firmar el ensamblado porque no se encontró signtool.exe en la ubicación especificada '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "No se ha podido iniciar el proceso de firma desde signtool.exe. No hay proceso." }
          , { TranslationKeys.db_dbr043_msg_par1, "El montaje de la firma no finalizó en el tiempo asignado de {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "No se ha podido firmar el ensamblaje porque no se ha establecido el nombre del archivo de claves." }
          , { TranslationKeys.db_dbr045_msg_par1, "No se ha podido firmar el conjunto porque el nombre de archivo de clave '{0}' no es un archivo de certificado PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Renombrar tipos en ensamblajes {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "Postprocesado de conjuntos {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Guardar conjuntos en '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Guardar la asignación en el archivo '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Carpetas marco adicionales:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Error al guardar '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} podría ser uno de:" }
          , { TranslationKeys.db_dbr069_msg_par1, "No se ha creado ningún par de claves de '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Completado con éxito en {0:N0} segundos." }
          , { TranslationKeys.db_dbr079_msg_par1, "Crear valor de clave RSA de '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Completado con éxito en {0:N0} segundos." }
          , { TranslationKeys.db_dbr108_msg_par1, "Procesar conjunto '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Crear par de claves de {0} con contraseña." }
          , { TranslationKeys.db_dbr110_msg, "No hay archivo de claves ni contenedor de claves configurado. No utilice ningún par de claves." }
          , { TranslationKeys.db_dbr111_msg, "No hay archivo de claves ni contenedor de claves configurado. No utiliza ningún valor de clave RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "No se ha creado ningún valor de clave RSA a partir de '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Empieza a firmar '{0}' usando la herramienta de firma '{1}' con argumentos '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Carga de conjuntos." }
          , { TranslationKeys.db_dbr117_msg_par1, "El ensamblaje '{0}' no se ha guardado utilizando el par de claves del proyecto en '{1}' debido a {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Firmado '{0}' como '{1}' utilizando el contenedor '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Guardado '{0}' tal cual en '{1}'; originalmente no estaba firmado con nombre fuerte." }
          , { TranslationKeys.db_dbr120_msg_par1, "Guarda '{0}' usando el par de claves del proyecto en '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Hay {0:N0} ensamblados en el proyecto para guardar." }
          , { TranslationKeys.db_dbr123_msg_par1, "Firmado \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "El conjunto '{0}' no tiene clave pública; guárdelo tal cual." }
          , { TranslationKeys.db_dbr125_msg_par1, "Canal Stderr: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Completado con error en {0:N0} segundos." }
          , { TranslationKeys.db_dbr131_par1, "Completado con error en {0:N0} segundos." }
          , { TranslationKeys.db_dbr132_par1, "Completado con error en {0:N0} segundos." }
          , { TranslationKeys.db_dbr133_par1, "Completado con error en {0:N0} segundos." }
          , { TranslationKeys.db_dbr135_msg, "Se espera que el estado sea 'Renombrado' u 'Omitido'." }
          , { TranslationKeys.db_dbr139_msg_par1, "Se espera que el estado sea 'Renombrado' u 'Omitido' en lugar de {0} de '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Falta el nombre del archivo." }
          , { TranslationKeys.db_dbr143_msg, "La bandera externa del grupo debería haberse gestionado cuando se creó el grupo y todos los métodos del grupo deberían estar ya marcados como omitidos." }
          , { TranslationKeys.db_dbr144_msg, "El método debe tener un nombre cuando el método no se omite y el grupo tiene un nombre." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' NO ha sido firmado debido al código de error {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "El estado debe ser 'Renombrado' u 'Omitido' en lugar de '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Canal de salida: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Sin carpetas adicionales:" }
          , { TranslationKeys.db_dbr155_msg, "No se puede extraer el nombre del tipo." }
          , { TranslationKeys.db_dbr156_msg_par1, "Cargar definición de proyecto XML de '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Variables procesadas {0}." }
          , { TranslationKeys.db_dbr158_msg_par1, "Procesadas {0} etiquetas de inclusión." }
          , { TranslationKeys.db_dbr159_msg_par1, "Procesadas {0} rutas de búsqueda de montaje." }
          , { TranslationKeys.db_dbr160_msg_par1, "Procesados {0} módulos." }
          , { TranslationKeys.db_dbr161_msg_par1, "Procesados {0} grupos de módulos." }
          , { TranslationKeys.db_dbr162_msg, "Inicializar ajustes a partir de variables." }
          , { TranslationKeys.db_dbr166_msg_par1, "El archivo de certificado '{0}' debe contener al menos un certificado." }
          , { TranslationKeys.db_dbr167_msg_par1, "El archivo de certificado '{0}' tiene un formato no válido." }
          , { TranslationKeys.db_dbr169_msg, "Determinar los caracteres para la generación de nombres." }
          , { TranslationKeys.db_dbr173_msg_par1, "Encontrada instalación de {0} en '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "No se ha encontrado ninguna instalación de {0} en '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Se puede utilizar como máximo una selección de certificados por nombre de archivo de claves y huella digital SHA1." }
          , { TranslationKeys.db_dbr176_msg, "Debe utilizarse la selección de certificado por nombre de archivo de clave o la huella digital SHA1." }
          , { TranslationKeys.db_dbr177_msg, "La contraseña del archivo de claves sólo puede facilitarse cuando el certificado se selecciona por nombre de archivo de claves." }
          , { TranslationKeys.db_definition_missing, "Falta la definición." }
          , { TranslationKeys.db_display_version, "Muestra el número de versión de esta aplicación." }
          , { TranslationKeys.db_duplicate_character, "Carácter duplicado." }
          , { TranslationKeys.db_error_processing_colon, "Se ha producido un error durante el procesamiento:" }
          , { TranslationKeys.db_filename_missing, "Falta el nombre del archivo." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur es una bifurcación de Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Falta el nombre completo." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) el {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprime esta información de ayuda." }
          , { TranslationKeys.db_hide_strings, "Ocultar cadenas." }
          , { TranslationKeys.db_hint_colon_par1, "Pista: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Sugerencia: puede que necesite añadir un SkipType para un enum arriba." }
          , { TranslationKeys.db_inner_exception_par1, "Excepción interna: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Cargando proyecto '{0}'." }
          , { TranslationKeys.db_missing_group, "Falta un grupo." }
          , { TranslationKeys.db_missing_parent_reader, "Faltan padres lectores." }
          , { TranslationKeys.db_missing_parts, "Faltan piezas." }
          , { TranslationKeys.db_missing_path_value, "Falta el valor de la ruta." }
          , { TranslationKeys.db_missing_read_action, "Falta leer acción." }
          , { TranslationKeys.db_missing_setting_name, "Falta el nombre del ajuste." }
          , { TranslationKeys.db_not_hide_strings, "No esconder las cuerdas." }
          , { TranslationKeys.db_not_rename_events, "No cambie el nombre de los eventos." }
          , { TranslationKeys.db_not_rename_fields, "No cambie el nombre de los campos." }
          , { TranslationKeys.db_not_rename_properties, "No cambie el nombre de las propiedades." }
          , { TranslationKeys.db_options_colon, "Opciones:" }
          , { TranslationKeys.db_pool_clean, "No se puede limpiar la piscina." }
          , { TranslationKeys.db_pool_still, "Todavía en la piscina:" }
          , { TranslationKeys.db_rename_events, "Renombrar eventos." }
          , { TranslationKeys.db_rename_fields, "Renombrar campos." }
          , { TranslationKeys.db_rename_methods, "Cambiar el nombre de los métodos." }
          , { TranslationKeys.db_rename_parameters, "Renombrar parámetros." }
          , { TranslationKeys.db_rename_properties, "Renombrar propiedades." }
          , { TranslationKeys.db_settings_not_initialized, "Ajustes aún no inicializados." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Opciones] [archivo_proyecto] [archivo_proyecto]" }
          }
        }
        , { Languages.fi, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Tarkista projektin asetukset." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console on haarautunut Obfuscarista (https://www.obfuscar.com)." }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [project_file] [project_file] [project_file]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams ja muut avustajat." }
          , { TranslationKeys.db_dbr002_msg_par1, "{0}'- ja '{1}'-muuttujia ei voi asettaa yhdessä." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Korjaa tiedoston '{0}' sisältö." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML-konfiguraatiotiedostossa pitäisi olla <{0}>-juuritunniste." }
          , { TranslationKeys.db_dbr005_msg_par1, "OutPathin määrittämää polkua '{0}' ei voitu luoda." }
          , { TranslationKeys.db_dbr006_msg_par1, "InPath-muuttujan määrittämän polun '{0}' on oltava olemassa," }
          , { TranslationKeys.db_dbr007_msg_par1, "Avaintiedoston '{0}' lataaminen epäonnistui." }
          , { TranslationKeys.db_dbr008_msg, "Mono ei tue avainsäiliöitä." }
          , { TranslationKeys.db_dbr009_msg_par1, "Riippuvuutta '{0}' ei pystytä ratkaisemaan." }
          , { TranslationKeys.db_dbr010_msg, "Käytä ilmaisua 'julkinen'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" ei kelpaa skip-elementtien typeattrib-arvolle." }
          , { TranslationKeys.db_dbr011_msg, "Käytä ilmaisua 'julkinen'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" ei kelpaa SkipType-elementin attrib-arvolle." }
          , { TranslationKeys.db_dbr012_msg_par1, "Muuttujaa '{0}' ei pystytä korvaamaan." }
          , { TranslationKeys.db_dbr013_msg, "Käytä sanaa \"julkinen\" tai \"suojattu\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" ei kelpaa skip-elementtien attrib-arvolle." }
          , { TranslationKeys.db_dbr014_msg_par1, "Määritettyä projektitiedostoa '{0}' ei pystytä lukemaan." }
          , { TranslationKeys.db_dbr015_msg, "Käytä KeyFile- tai KeyContainer-ominaisuutta käytettävän avaimen asettamiseen." }
          , { TranslationKeys.db_dbr015_msg_par1, "Allekirjoitetun kokoonpanon '{0}' peittäminen johtaisi virheelliseen kokoonpanoon." }
          , { TranslationKeys.db_dbr017_msg_par1, "Kokoonpanon allekirjoittaminen avainsäiliön '{0}' avaimella ei onnistu." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} ei ole kelvollinen XML-tiedosto." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Kokoonpanoa '{0}' ei löydy." }
          , { TranslationKeys.db_dbr020_msg_par1, "Epäonnistuimme saamaan tyyppimäärittelyjä {0}:lle." }
          , { TranslationKeys.db_dbr024_msg_par1, "Luo avainparin '{0}' ilman salasanaa." }
          , { TranslationKeys.db_dbr027_msg, "Nimellä on oltava arvo." }
          , { TranslationKeys.db_dbr028_msg, "Nimi ja nimen säännöllinen lauseke on määritettävä." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly on kutsuttava ennen käyttöä." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init on kutsuttava ennen käyttöä." }
          , { TranslationKeys.db_dbr034_msg, "Tarvitaan kelvollinen tiedostoattribuutti." }
          , { TranslationKeys.db_dbr035_msg_par1, "Tyyppien '{0}' ja '{1}' nimien on oltava samat." }
          , { TranslationKeys.db_dbr036_msg, "Nimeä ja nimen säännöllistä lauseketta ei ole asetettu." }
          , { TranslationKeys.db_dbr038_msg, "Koodityypin määritelmää ei ole asetettu." }
          , { TranslationKeys.db_dbr039_msg, "Viimeisimpiä tietoja ei ole asetettu." }
          , { TranslationKeys.db_dbr040_msg, "Kokoonpanoa ei voitu allekirjoittaa, koska signtool.exe-tiedostoa ei löydetty." }
          , { TranslationKeys.db_dbr041_msg_par1, "Kokoonpanoa ei voitu allekirjoittaa, koska signtool.exe-tiedostoa ei löytynyt määritetystä sijainnista '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Allekirjoitusprosessia ei voitu käynnistää, koska signtool.exe. Ei prosessia." }
          , { TranslationKeys.db_dbr043_msg_par1, "Allekirjoituskokoonpano ei päättynyt {0:N0} ms:n määräajassa." }
          , { TranslationKeys.db_dbr044_msg, "Kokoonpanoa ei voitu allekirjoittaa, koska avaintiedoston nimeä ei ole asetettu." }
          , { TranslationKeys.db_dbr045_msg_par1, "Kokoonpanoa ei voitu allekirjoittaa, koska avaintiedoston nimi '{0}' ei ole PFX-varmentetiedosto." }
          , { TranslationKeys.db_dbr054_msg_par1, "Nimeä tyypit uudelleen {0:N0}-kokoonpanoissa." }
          , { TranslationKeys.db_dbr055_msg_par1, "{0:N0}-kokoonpanojen jälkikäsittely." }
          , { TranslationKeys.db_dbr056_msg_par1, "Tallenna kokoonpanot osoitteeseen '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Tallenna kartoitus tiedostoon '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Ylimääräiset puitekansiot:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Tallennus '{0}' epäonnistui." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} saattaa olla yksi seuraavista:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Luo avainparia '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Suoritettu onnistuneesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr079_msg_par1, "Luo RSA-avaimen arvo arvosta '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Suoritettu onnistuneesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr108_msg_par1, "Käsittele kokoonpano '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Luo avainparin {0} ja salasanan avulla." }
          , { TranslationKeys.db_dbr110_msg, "Ei avaintiedostoa eikä avainsäiliötä määritetty. Älä käytä avainparia." }
          , { TranslationKeys.db_dbr111_msg, "Ei avaintiedostoa eikä avainsäiliötä määritetty. Älä käytä RSA-avainarvoa." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Luo RSA-avainta arvosta '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Aloita allekirjoitus '{0}' käyttäen allekirjoitustyökalua '{1}' argumenteilla '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Kokoonpanojen lataaminen." }
          , { TranslationKeys.db_dbr117_msg_par1, "Kokoonpanoa '{0}' ei tallennettu projektin avainparin avulla kohteeseen '{1}', koska {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Allekirjoitettu '{0}' muotoon '{1}' käyttäen säiliötä '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Tallennettu '{0}' sellaisenaan '{1}'-osaan; alun perin ei ollut vahvaa nimisignausta." }
          , { TranslationKeys.db_dbr120_msg_par1, "Tallenna '{0}' projektin avainparin avulla osoitteeseen '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Tallennettavassa projektissa on {0:N0} kokoonpanoa." }
          , { TranslationKeys.db_dbr123_msg_par1, "Allekirjoitettu '{0}'." }
          , { TranslationKeys.db_dbr124_msg_par1, "Kokoonpanolla '{0}' ei ole julkista avainta; tallenna sellaisenaan." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-kanava: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Valmistui virheellisesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr131_par1, "Valmistui virheellisesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr132_par1, "Valmistui virheellisesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr133_par1, "Valmistui virheellisesti {0:N0} sekunnissa." }
          , { TranslationKeys.db_dbr135_msg, "Tilan odotetaan olevan joko \"Uudelleen nimetty\" tai \"Ohitettu\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Tilan odotetaan olevan joko \"Uudelleen nimetty\" tai \"Ohitettu\" eikä {0} tai \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Tiedoston nimi puuttuu." }
          , { TranslationKeys.db_dbr143_msg, "Ryhmän ulkoinen lippu olisi pitänyt käsitellä jo ryhmää luotaessa, ja kaikki ryhmän metodit olisi jo pitänyt merkitä ohitetuiksi." }
          , { TranslationKeys.db_dbr144_msg, "Metodilla on oltava nimi, kun metodia ei ole ohitettu ja ryhmällä on nimi." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}\" EI allekirjoitettu virhekoodin {1} vuoksi." }
          , { TranslationKeys.db_dbr149_msg_par1, "Tilan on oltava 'Renamed' tai 'Skipped' eikä '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-kanava: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Ei ylimääräisiä kehyskansioita:" }
          , { TranslationKeys.db_dbr155_msg, "Tyypin nimeä ei voida poimia." }
          , { TranslationKeys.db_dbr156_msg_par1, "Lataa XML-projektin määritelmä osoitteesta '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Käsitelty {0} muuttujaa." }
          , { TranslationKeys.db_dbr158_msg_par1, "Käsitellyt {0} sisältävät tunnisteet." }
          , { TranslationKeys.db_dbr159_msg_par1, "Käsitelty {0} kokoonpanon hakupolkua." }
          , { TranslationKeys.db_dbr160_msg_par1, "Käsitelty {0} moduulia." }
          , { TranslationKeys.db_dbr161_msg_par1, "Käsitelty {0} moduuliryhmää." }
          , { TranslationKeys.db_dbr162_msg, "Asetusten alustaminen muuttujista." }
          , { TranslationKeys.db_dbr166_msg_par1, "Varmentetiedoston '{0}' on sisällettävä vähintään yksi varmenne." }
          , { TranslationKeys.db_dbr167_msg_par1, "Varmentetiedoston '{0}' muoto on virheellinen." }
          , { TranslationKeys.db_dbr169_msg, "Määritä merkit nimen muodostamista varten." }
          , { TranslationKeys.db_dbr173_msg_par1, "Löytyi {0}:n asennus osoitteessa '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Ei löytynyt {0}:n asennusta paikassa '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Voidaan käyttää korkeintaan yhtä varmenteen valintaa avaintiedoston nimen ja SHA1-peukalonjäljen mukaan." }
          , { TranslationKeys.db_dbr176_msg, "On käytettävä joko varmenteen valintaa avaintiedoston nimen tai SHA1-peukalonjäljen perusteella." }
          , { TranslationKeys.db_dbr177_msg, "Avaintiedoston salasana voidaan antaa vain, kun varmenne valitaan avaintiedoston nimen perusteella." }
          , { TranslationKeys.db_definition_missing, "Määritelmä puuttuu." }
          , { TranslationKeys.db_display_version, "Näyttää tämän sovelluksen versionumeron." }
          , { TranslationKeys.db_duplicate_character, "Kaksoishahmo." }
          , { TranslationKeys.db_error_processing_colon, "Käsittelyssä tapahtui virhe:" }
          , { TranslationKeys.db_filename_missing, "Tiedoston nimi puuttuu." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur on haara Obfuscarista (https://www.obfuscar.com)." }
          , { TranslationKeys.db_full_name_missing, "Koko nimi puuttuu." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Tulosta tämä ohje." }
          , { TranslationKeys.db_hide_strings, "Piilota merkkijonot." }
          , { TranslationKeys.db_hint_colon_par1, "Vihje: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Vihje: saatat joutua lisäämään SkipType-tyypin edellä olevalle enumille." }
          , { TranslationKeys.db_inner_exception_par1, "Sisäinen poikkeus: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Lataa projekti '{0}'." }
          , { TranslationKeys.db_missing_group, "Puuttuva ryhmä." }
          , { TranslationKeys.db_missing_parent_reader, "Puuttuva vanhempi lukija." }
          , { TranslationKeys.db_missing_parts, "Puuttuvat osat." }
          , { TranslationKeys.db_missing_path_value, "Polun puuttuva arvo." }
          , { TranslationKeys.db_missing_read_action, "Missing read action." }
          , { TranslationKeys.db_missing_setting_name, "Asetusten nimi puuttuu." }
          , { TranslationKeys.db_not_hide_strings, "Ei piilotella jousia." }
          , { TranslationKeys.db_not_rename_events, "Älä nimeä tapahtumia uudelleen." }
          , { TranslationKeys.db_not_rename_fields, "Älä nimeä kenttiä uudelleen." }
          , { TranslationKeys.db_not_rename_properties, "Älä nimeä ominaisuuksia uudelleen." }
          , { TranslationKeys.db_options_colon, "Vaihtoehdot:" }
          , { TranslationKeys.db_pool_clean, "Altaan puhdistaminen ei onnistu." }
          , { TranslationKeys.db_pool_still, "Vielä altaassa:" }
          , { TranslationKeys.db_rename_events, "Nimeä tapahtumat uudelleen." }
          , { TranslationKeys.db_rename_fields, "Nimeä kentät uudelleen." }
          , { TranslationKeys.db_rename_methods, "Nimeä menetelmät uudelleen." }
          , { TranslationKeys.db_rename_parameters, "Nimeä parametrit uudelleen." }
          , { TranslationKeys.db_rename_properties, "Nimeä ominaisuudet uudelleen." }
          , { TranslationKeys.db_settings_not_initialized, "Asetuksia ei ole vielä alustettu." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Options] [project_file] [project_file] [project_file]" }
          }
        }
        , { Languages.fr, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Pile d'appels" }
          , { TranslationKeys.db_check_project_settings, "Vérifier les paramètres du projet." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console est un fork de Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [fichier_projet] [fichier_projet]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams et autres contributeurs." }
          , { TranslationKeys.db_dbr002_msg_par1, "Les variables '{0}' et '{1}' ne peuvent pas être définies ensemble." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Veuillez corriger le contenu du fichier '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "Le fichier de configuration XML doit avoir une balise racine <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "Impossible de créer le chemin '{0}' spécifié par OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Le chemin '{0}' spécifié par la variable InPath doit exister," }
          , { TranslationKeys.db_dbr007_msg_par1, "Échec du chargement du fichier clé '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Les conteneurs de clés ne sont pas pris en charge par Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Impossible de résoudre la dépendance '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Utiliser \"public\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" n'est pas valable pour la valeur \"typeattrib\" des éléments de saut." }
          , { TranslationKeys.db_dbr011_msg, "Utiliser \"public\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" n'est pas valide pour la valeur \"attrib\" de l'élément SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "Impossible de remplacer la variable '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Utilisez \"public\" ou \"protégé\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" n'est pas valable pour la valeur \"attrib\" des éléments de saut." }
          , { TranslationKeys.db_dbr014_msg_par1, "Impossible de lire le fichier de projet spécifié '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Utilisez la propriété KeyFile ou KeyContainer pour définir une clé à utiliser." }
          , { TranslationKeys.db_dbr015_msg_par1, "L'obscurcissement de l'assemblage signé \"{0}\" aboutirait à un assemblage non valide." }
          , { TranslationKeys.db_dbr017_msg_par1, "Impossible de signer l'assemblage à l'aide de la clé du conteneur de clés '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} n'est pas un fichier XML valide." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Impossible de trouver l'assemblage '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Échec de l'obtention des définitions de type pour {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Créer une paire de clés à partir de '{0}' sans mot de passe." }
          , { TranslationKeys.db_dbr027_msg, "Le nom doit avoir une valeur." }
          , { TranslationKeys.db_dbr028_msg, "Le nom et l'expression régulière du nom doivent avoir été définis." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly doit être appelé avant d'être utilisé." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init doit être appelé avant d'être utilisé." }
          , { TranslationKeys.db_dbr034_msg, "Besoin d'un attribut de fichier valide." }
          , { TranslationKeys.db_dbr035_msg_par1, "Les noms de type \"{0}\" et \"{1}\" doivent être identiques." }
          , { TranslationKeys.db_dbr036_msg, "Le nom et l'expression régulière du nom ne sont pas définis." }
          , { TranslationKeys.db_dbr038_msg, "La définition du type d'encodage n'est pas définie." }
          , { TranslationKeys.db_dbr039_msg, "Les données les plus récentes ne sont pas définies." }
          , { TranslationKeys.db_dbr040_msg, "Impossible de signer l'assemblage car signtool.exe n'a pas pu être localisé." }
          , { TranslationKeys.db_dbr041_msg_par1, "Impossible de signer l'assemblage car signtool.exe n'a pu être trouvé à l'emplacement spécifié '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Impossible de lancer le processus de signature à l'aide de signtool.exe. Pas de processus." }
          , { TranslationKeys.db_dbr043_msg_par1, "L'assemblage de la signature ne s'est pas terminé dans le temps imparti de {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Impossible de signer l'assemblage car le nom du fichier clé n'est pas défini." }
          , { TranslationKeys.db_dbr045_msg_par1, "Impossible de signer l'assemblage car le nom du fichier clé '{0}' n'est pas un fichier de certificat PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Renommer les types dans les assemblages {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "Post-traitement des assemblages {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Sauvegarder les assemblages dans '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Enregistrer la correspondance dans le fichier '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Dossiers supplémentaires du cadre :" }
          , { TranslationKeys.db_dbr061_msg_par1, "Échec de l'enregistrement de '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} peut être l'un d'entre eux :" }
          , { TranslationKeys.db_dbr069_msg_par1, "Aucune paire de clés n'a été créée à partir de '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Terminé avec succès en {0:N0} secondes." }
          , { TranslationKeys.db_dbr079_msg_par1, "Créer une valeur de clé RSA à partir de \"{0}\"." }
          , { TranslationKeys.db_dbr082_par1, "Terminé avec succès en {0:N0} secondes." }
          , { TranslationKeys.db_dbr108_msg_par1, "Traiter l'assemblage '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Créer une paire de clés à partir de {0} avec le mot de passe." }
          , { TranslationKeys.db_dbr110_msg, "Aucun fichier de clés ni conteneur de clés n'est configuré. Utiliser aucune paire de clés." }
          , { TranslationKeys.db_dbr111_msg, "Aucun fichier de clés et aucun conteneur de clés n'est configuré. Ne pas utiliser de valeur de clé RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Ne crée pas de valeur de clé RSA à partir de \"{0}\"." }
          , { TranslationKeys.db_dbr113_msg_par1, "Commencez à signer '{0}' en utilisant l'outil de signature '{1}' avec les arguments '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Chargement des assemblages." }
          , { TranslationKeys.db_dbr117_msg_par1, "L'assemblage '{0}' n'a pas été sauvegardé en utilisant la paire de clés du projet vers '{1}' en raison de {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signé '{0}' comme '{1}' en utilisant le conteneur '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Sauvegardé \"{0}\" tel quel dans \"{1}\" ; à l'origine, il n'était pas signé par un nom fort." }
          , { TranslationKeys.db_dbr120_msg_par1, "Enregistrer '{0}' en utilisant la paire de clés du projet dans '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Il y a {0:N0} assemblages dans le projet à sauvegarder." }
          , { TranslationKeys.db_dbr123_msg_par1, "Signé \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "L'assemblée \"{0}\" n'a pas de clé publique ; enregistrer telle quelle." }
          , { TranslationKeys.db_dbr125_msg_par1, "Canal Stderr : {0}" }
          , { TranslationKeys.db_dbr130_par1, "Terminé avec une erreur dans {0:N0} secondes." }
          , { TranslationKeys.db_dbr131_par1, "Terminé avec une erreur dans {0:N0} secondes." }
          , { TranslationKeys.db_dbr132_par1, "Terminé avec une erreur dans {0:N0} secondes." }
          , { TranslationKeys.db_dbr133_par1, "Terminé avec une erreur dans {0:N0} secondes." }
          , { TranslationKeys.db_dbr135_msg, "Le statut devrait être \"Renommé\" ou \"Ignoré\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Le statut devrait être \"Renommé\" ou \"Ignoré\" au lieu de {0} ou \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Nom de fichier manquant." }
          , { TranslationKeys.db_dbr143_msg, "L'indicateur externe du groupe aurait dû être traité lors de la création du groupe et toutes les méthodes du groupe devraient déjà être marquées comme étant ignorées." }
          , { TranslationKeys.db_dbr144_msg, "La méthode doit avoir un nom lorsque la méthode n'est pas ignorée et que le groupe a un nom." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' n'a pas été signé en raison du code d'erreur {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Le statut doit être \"Renommé\" ou \"Ignoré\" au lieu de \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Canal de sortie : {0}" }
          , { TranslationKeys.db_dbr154_msg, "Pas de dossiers supplémentaires :" }
          , { TranslationKeys.db_dbr155_msg, "Impossible d'extraire le nom du type." }
          , { TranslationKeys.db_dbr156_msg_par1, "Charger la définition du projet XML de '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Traitement de {0} variables." }
          , { TranslationKeys.db_dbr158_msg_par1, "Les balises {0} traitées sont incluses." }
          , { TranslationKeys.db_dbr159_msg_par1, "Traitement de {0} chemins de recherche d'assemblage." }
          , { TranslationKeys.db_dbr160_msg_par1, "Traitement de {0} modules." }
          , { TranslationKeys.db_dbr161_msg_par1, "Traitement de {0} groupes de modules." }
          , { TranslationKeys.db_dbr162_msg, "Initialiser les paramètres à partir des variables." }
          , { TranslationKeys.db_dbr166_msg_par1, "Le fichier de certificats \"{0}\" doit contenir au moins un certificat." }
          , { TranslationKeys.db_dbr167_msg_par1, "Le format du fichier de certificat \"{0}\" n'est pas valide." }
          , { TranslationKeys.db_dbr169_msg, "Déterminer les caractères pour la génération des noms." }
          , { TranslationKeys.db_dbr173_msg_par1, "Installation trouvée de {0} à '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Aucune installation de {0} n'a été trouvée dans '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Il est possible d'utiliser au maximum un certificat sélectionné par le nom du fichier de clés et l'empreinte SHA1." }
          , { TranslationKeys.db_dbr176_msg, "Il faut utiliser soit la sélection du certificat par le nom du fichier de clé, soit l'empreinte SHA1." }
          , { TranslationKeys.db_dbr177_msg, "Le mot de passe du fichier clé ne peut être fourni que lorsque le certificat est sélectionné par le nom du fichier clé." }
          , { TranslationKeys.db_definition_missing, "La définition est manquante." }
          , { TranslationKeys.db_display_version, "Affiche le numéro de version de cette application." }
          , { TranslationKeys.db_duplicate_character, "Caractère dupliqué." }
          , { TranslationKeys.db_error_processing_colon, "Une erreur s'est produite pendant le traitement :" }
          , { TranslationKeys.db_filename_missing, "Nom de fichier manquant." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur est un fork de Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Le nom complet est manquant." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprimer ces informations d'aide." }
          , { TranslationKeys.db_hide_strings, "Cacher les chaînes." }
          , { TranslationKeys.db_hint_colon_par1, "Indice : {0}" }
          , { TranslationKeys.db_hint_skiptype, "Conseil : vous pourriez avoir besoin d'ajouter un SkipType pour un enum ci-dessus." }
          , { TranslationKeys.db_inner_exception_par1, "Exception interne : {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Chargement du projet '{0}'." }
          , { TranslationKeys.db_missing_group, "Groupe manquant." }
          , { TranslationKeys.db_missing_parent_reader, "Parent lecteur manquant." }
          , { TranslationKeys.db_missing_parts, "Pièces manquantes." }
          , { TranslationKeys.db_missing_path_value, "Valeur manquante pour le chemin." }
          , { TranslationKeys.db_missing_read_action, "Action de lecture manquante." }
          , { TranslationKeys.db_missing_setting_name, "Nom du paramètre manquant." }
          , { TranslationKeys.db_not_hide_strings, "Ne pas cacher les ficelles." }
          , { TranslationKeys.db_not_rename_events, "Ne pas renommer les événements." }
          , { TranslationKeys.db_not_rename_fields, "Ne pas renommer les champs." }
          , { TranslationKeys.db_not_rename_properties, "Ne pas renommer les propriétés." }
          , { TranslationKeys.db_options_colon, "Options :" }
          , { TranslationKeys.db_pool_clean, "Impossible de nettoyer la piscine." }
          , { TranslationKeys.db_pool_still, "Toujours en piscine :" }
          , { TranslationKeys.db_rename_events, "Renommer les événements." }
          , { TranslationKeys.db_rename_fields, "Renommer les champs." }
          , { TranslationKeys.db_rename_methods, "Renommer les méthodes." }
          , { TranslationKeys.db_rename_parameters, "Renommer les paramètres." }
          , { TranslationKeys.db_rename_properties, "Renommer les propriétés." }
          , { TranslationKeys.db_settings_not_initialized, "Les paramètres n'ont pas encore été initialisés." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Options] [fichier_projet] [fichier_projet]" }
          }
        }
        , { Languages.it, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Controllare le impostazioni del progetto." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console è un fork di Obfuscar (https://www.obfuscar.com)." }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [project_file] [project_file]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) il {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams e altri collaboratori." }
          , { TranslationKeys.db_dbr002_msg_par1, "Le variabili \"{0}\" e \"{1}\" non possono essere impostate insieme." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Correggere il contenuto del file \"{0}\"." }
          , { TranslationKeys.db_dbr004_msg_par1, "Il file di configurazione XML deve avere un tag principale <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "Impossibile creare il percorso '{0}' specificato da OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Il percorso '{0}' specificato dalla variabile InPath deve esistere," }
          , { TranslationKeys.db_dbr007_msg_par1, "Errore nel caricamento del file chiave '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "I contenitori di chiavi non sono supportati da Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Impossibile risolvere la dipendenza '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Utilizzare \"pubblico\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" non è valido per il valore \"typeattrib\" degli elementi di salto." }
          , { TranslationKeys.db_dbr011_msg, "Utilizzare \"pubblico\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" non è valido per il valore \"attrib\" dell'elemento SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "Impossibile sostituire la variabile '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Utilizzare \"pubblico\" o \"protetto\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" non è valido per il valore \"attrib\" degli elementi di salto." }
          , { TranslationKeys.db_dbr014_msg_par1, "Impossibile leggere il file di progetto specificato '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Utilizzare la proprietà KeyFile o KeyContainer per impostare una chiave da utilizzare." }
          , { TranslationKeys.db_dbr015_msg_par1, "L'offuscamento dell'assembly firmato '{0}' risulterebbe in un assembly non valido." }
          , { TranslationKeys.db_dbr017_msg_par1, "Impossibile firmare l'assieme usando la chiave del contenitore di chiavi '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} non è un file XML valido." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Impossibile trovare l'assieme '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Impossibile ottenere le definizioni dei tipi per {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Crea una coppia di chiavi da '{0}' senza password." }
          , { TranslationKeys.db_dbr027_msg, "Il nome deve avere un valore." }
          , { TranslationKeys.db_dbr028_msg, "Il nome e l'espressione regolare del nome devono essere stati impostati." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly deve essere richiamato prima dell'uso." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init deve essere richiamato prima dell'uso." }
          , { TranslationKeys.db_dbr034_msg, "Serve un attributo di file valido." }
          , { TranslationKeys.db_dbr035_msg_par1, "I nomi dei tipi \"{0}\" e \"{1}\" devono essere uguali." }
          , { TranslationKeys.db_dbr036_msg, "Il nome e l'espressione regolare del nome non sono impostati." }
          , { TranslationKeys.db_dbr038_msg, "Definizione del tipo di codifica non impostata." }
          , { TranslationKeys.db_dbr039_msg, "I dati più recenti non sono stati impostati." }
          , { TranslationKeys.db_dbr040_msg, "Impossibile firmare l'assieme poiché signtool.exe non è stato individuato." }
          , { TranslationKeys.db_dbr041_msg_par1, "Impossibile firmare l'assembly poiché signtool.exe non è stato trovato nel percorso specificato '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Impossibile avviare il processo di firma utilizzando signtool.exe. Nessun processo." }
          , { TranslationKeys.db_dbr043_msg_par1, "L'assemblaggio della firma non si è concluso entro il tempo assegnato di {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Impossibile firmare l'assieme poiché il nome del file chiave non è impostato." }
          , { TranslationKeys.db_dbr045_msg_par1, "Impossibile firmare l'assieme poiché il nome del file chiave '{0}' non è un file di certificato PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Rinomina i tipi negli assiemi {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "Postelaborazione degli assiemi {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Salvare gli assiemi in '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Salva la mappatura nel file '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Cartelle extra del framework:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Impossibile salvare '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} potrebbe essere uno dei seguenti:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Non è stata creata una coppia di chiavi da '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Completato con successo in {0:N0} secondi." }
          , { TranslationKeys.db_dbr079_msg_par1, "Creare il valore della chiave RSA da '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Completato con successo in {0:N0} secondi." }
          , { TranslationKeys.db_dbr108_msg_par1, "Elaborare l'assieme '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Crea una coppia di chiavi da {0} con password." }
          , { TranslationKeys.db_dbr110_msg, "Nessun file di chiavi e nessun contenitore di chiavi configurato. Utilizzare nessuna coppia di chiavi." }
          , { TranslationKeys.db_dbr111_msg, "Nessun file di chiavi e nessun contenitore di chiavi configurato. Non utilizzare il valore della chiave RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Non è stato creato alcun valore di chiave RSA da '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Iniziare a firmare '{0}' usando lo strumento di firma '{1}' con argomenti '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Caricamento degli assiemi." }
          , { TranslationKeys.db_dbr117_msg_par1, "L'assieme '{0}' non è stato salvato usando la coppia di chiavi del progetto in '{1}' a causa di {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Firmato '{0}' come '{1}' usando il contenitore '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Salvato '{0}' così com'è in '{1}'; originariamente non era un nome forte firmato." }
          , { TranslationKeys.db_dbr120_msg_par1, "Salvare '{0}' utilizzando la coppia di chiavi del progetto in '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Nel progetto ci sono {0:N0} assiemi da salvare." }
          , { TranslationKeys.db_dbr123_msg_par1, "Firmato \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "L'assembly '{0}' non ha una chiave pubblica; salvare così com'è." }
          , { TranslationKeys.db_dbr125_msg_par1, "Canale Stderr: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Completato con errore in {0:N0} secondi." }
          , { TranslationKeys.db_dbr131_par1, "Completato con errore in {0:N0} secondi." }
          , { TranslationKeys.db_dbr132_par1, "Completato con errore in {0:N0} secondi." }
          , { TranslationKeys.db_dbr133_par1, "Completato con errore in {0:N0} secondi." }
          , { TranslationKeys.db_dbr135_msg, "Lo stato dovrebbe essere \"Rinominato\" o \"Saltato\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Lo stato dovrebbe essere \"Rinominato\" o \"Saltato\" invece di {0} o \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Nome del file mancante." }
          , { TranslationKeys.db_dbr143_msg, "Il flag esterno del gruppo dovrebbe essere stato gestito quando il gruppo è stato creato e tutti i metodi del gruppo dovrebbero essere già contrassegnati come saltati." }
          , { TranslationKeys.db_dbr144_msg, "Il metodo deve avere un nome quando il metodo non viene saltato e il gruppo ha un nome." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' NON è stato firmato a causa del codice di errore {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Lo stato deve essere \"Rinominato\" o \"Saltato\" invece di \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Canale stdout: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Nessuna cartella extra del framework:" }
          , { TranslationKeys.db_dbr155_msg, "Impossibile estrarre il nome del tipo." }
          , { TranslationKeys.db_dbr156_msg_par1, "Carica la definizione di progetto XML da '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Elaborate {0} variabili." }
          , { TranslationKeys.db_dbr158_msg_par1, "Elaborato {0} include tag." }
          , { TranslationKeys.db_dbr159_msg_par1, "Elaborati {0} percorsi di ricerca degli assiemi." }
          , { TranslationKeys.db_dbr160_msg_par1, "Elaborati {0} moduli." }
          , { TranslationKeys.db_dbr161_msg_par1, "Elaborati {0} gruppi di moduli." }
          , { TranslationKeys.db_dbr162_msg, "Inizializza le impostazioni dalle variabili." }
          , { TranslationKeys.db_dbr166_msg_par1, "Il file di certificato \"{0}\" deve contenere almeno un certificato." }
          , { TranslationKeys.db_dbr167_msg_par1, "Il file di certificato \"{0}\" ha un formato non valido." }
          , { TranslationKeys.db_dbr169_msg, "Determinare i caratteri per la generazione dei nomi." }
          , { TranslationKeys.db_dbr173_msg_par1, "Trovata installazione di {0} in '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Non è stata trovata alcuna installazione di {0} in '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "È possibile utilizzare al massimo uno dei certificati selezionati in base al nome del file chiave e all'impronta SHA1." }
          , { TranslationKeys.db_dbr176_msg, "È necessario utilizzare la selezione del certificato tramite il nome del file chiave o l'impronta SHA1." }
          , { TranslationKeys.db_dbr177_msg, "La password del file chiave può essere fornita solo quando il certificato è selezionato per nome del file chiave." }
          , { TranslationKeys.db_definition_missing, "Manca la definizione." }
          , { TranslationKeys.db_display_version, "Visualizza il numero di versione di questa applicazione." }
          , { TranslationKeys.db_duplicate_character, "Carattere duplicato." }
          , { TranslationKeys.db_error_processing_colon, "Si è verificato un errore durante l'elaborazione:" }
          , { TranslationKeys.db_filename_missing, "Nome del file mancante." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur è un fork di Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Manca il nome completo." }
          , { TranslationKeys.db_gt_title_par2, "*** Strumento globale DotBlur ({0}) il {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Stampare queste informazioni di aiuto." }
          , { TranslationKeys.db_hide_strings, "Nascondere le stringhe." }
          , { TranslationKeys.db_hint_colon_par1, "Suggerimento: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Suggerimento: potrebbe essere necessario aggiungere un SkipType per un enum sopra." }
          , { TranslationKeys.db_inner_exception_par1, "Eccezione interna: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Caricamento del progetto '{0}'." }
          , { TranslationKeys.db_missing_group, "Gruppo mancante." }
          , { TranslationKeys.db_missing_parent_reader, "Manca il lettore genitore." }
          , { TranslationKeys.db_missing_parts, "Parti mancanti." }
          , { TranslationKeys.db_missing_path_value, "Valore mancante per il percorso." }
          , { TranslationKeys.db_missing_read_action, "Manca l'azione di lettura." }
          , { TranslationKeys.db_missing_setting_name, "Nome dell'impostazione mancante." }
          , { TranslationKeys.db_not_hide_strings, "Non nasconde le corde." }
          , { TranslationKeys.db_not_rename_events, "Non rinominare gli eventi." }
          , { TranslationKeys.db_not_rename_fields, "Non rinominare i campi." }
          , { TranslationKeys.db_not_rename_properties, "Non rinominare le proprietà." }
          , { TranslationKeys.db_options_colon, "Opzioni:" }
          , { TranslationKeys.db_pool_clean, "Non è possibile pulire la piscina." }
          , { TranslationKeys.db_pool_still, "Ancora in piscina:" }
          , { TranslationKeys.db_rename_events, "Rinominare gli eventi." }
          , { TranslationKeys.db_rename_fields, "Rinominare i campi." }
          , { TranslationKeys.db_rename_methods, "Rinominare i metodi." }
          , { TranslationKeys.db_rename_parameters, "Rinominare i parametri." }
          , { TranslationKeys.db_rename_properties, "Rinominare le proprietà." }
          , { TranslationKeys.db_settings_not_initialized, "Impostazioni non ancora inizializzate." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Opzioni] [file_progetto] [file_progetto]" }
          }
        }
        , { Languages.ja, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "コールスタック" }
          , { TranslationKeys.db_check_project_settings, "プロジェクトの設定を確認する。" }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console は Obfuscar (https://www.obfuscar.com) のフォークです。" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [オプション] [プロジェクトファイル] [プロジェクトファイル］" }
          , { TranslationKeys.db_con_title_par2, "*** ドットブラーコンソール ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}、ライアン・ウィリアムズ、その他の寄稿者。" }
          , { TranslationKeys.db_dbr002_msg_par1, "{0}' と '{1}' 変数を一緒に設定することはできません。" }
          , { TranslationKeys.db_dbr004_2_msg_par1, "ファイル'{0}'の内容を修正してください。" }
          , { TranslationKeys.db_dbr004_msg_par1, "XMLコンフィギュレーション・ファイルは<{0}>ルート・タグを持つべきである。" }
          , { TranslationKeys.db_dbr005_msg_par1, "OutPath で指定されたパス '{0}' を作成できませんでした。" }
          , { TranslationKeys.db_dbr006_msg_par1, "InPath 変数で指定されたパス '{0}' が存在しなければならない、" }
          , { TranslationKeys.db_dbr007_msg_par1, "キーファイル '{0}' の読み込みに失敗しました。" }
          , { TranslationKeys.db_dbr008_msg, "キーコンテナはMonoではサポートされていません。" }
          , { TranslationKeys.db_dbr009_msg_par1, "依存関係 '{0}' を解決できません。" }
          , { TranslationKeys.db_dbr010_msg, "パブリック」を使う。" }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}'はスキップ要素の'typeattrib'値としては無効である。" }
          , { TranslationKeys.db_dbr011_msg, "パブリック」を使う。" }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' は SkipType 要素の 'attrib' 値としては無効です。" }
          , { TranslationKeys.db_dbr012_msg_par1, "変数 '{0}' を置換できません。" }
          , { TranslationKeys.db_dbr013_msg, "パブリック」または「プロテクト」を使用する。" }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}'はスキップ要素の'attribute'値としては無効である。" }
          , { TranslationKeys.db_dbr014_msg_par1, "指定されたプロジェクト・ファイル '{0}' を読み取れません。" }
          , { TranslationKeys.db_dbr015_msg, "使用するキーを設定するには、KeyFile または KeyContainer プロパティを使用します。" }
          , { TranslationKeys.db_dbr015_msg_par1, "署名されたアセンブリ '{0}' を難読化すると、無効なアセンブリになります。" }
          , { TranslationKeys.db_dbr017_msg_par1, "キーコンテナ '{0}' のキーを使用してアセンブリに署名できません。" }
          , { TranslationKeys.db_dbr018_msg_par1, "{0}は有効なXMLファイルではありません。" }
          , { TranslationKeys.db_dbr020_2_msg_par1, "アセンブリ '{0}' が見つかりません。" }
          , { TranslationKeys.db_dbr020_msg_par1, "0}の型定義の取得に失敗しました。" }
          , { TranslationKeys.db_dbr024_msg_par1, "0}」からパスワードなしでキー・ペアを作成する。" }
          , { TranslationKeys.db_dbr027_msg, "名前には必ず値が必要。" }
          , { TranslationKeys.db_dbr028_msg, "名前と名前の正規表現が設定されていなければならない。" }
          , { TranslationKeys.db_dbr029_msg, "使用する前にAssemblyInfo.LoadAssemblyを呼び出す必要があります。" }
          , { TranslationKeys.db_dbr031_msg, "使用する前にAssemblyInfo.Initを呼び出す必要があります。" }
          , { TranslationKeys.db_dbr034_msg, "有効なファイル属性が必要です。" }
          , { TranslationKeys.db_dbr035_msg_par1, "型名'{0}'と'{1}'は等しくなければならない。" }
          , { TranslationKeys.db_dbr036_msg, "名前と名前の正規表現が設定されていない。" }
          , { TranslationKeys.db_dbr038_msg, "エンコード・タイプの定義が設定されていない。" }
          , { TranslationKeys.db_dbr039_msg, "直近のデータが設定されていない。" }
          , { TranslationKeys.db_dbr040_msg, "signtool.exeが見つからないため、アセンブリに署名できませんでした。" }
          , { TranslationKeys.db_dbr041_msg_par1, "signtool.exeが指定された場所'{0}'に見つからなかったので、アセンブリに署名できませんでした。" }
          , { TranslationKeys.db_dbr042_msg, "signtool.exeを使用して署名プロセスを開始できませんでした。 プロセスがありません。" }
          , { TranslationKeys.db_dbr043_msg_par1, "署名アセンブリが{0:N0}msの割り当て時間内に終了しなかった。" }
          , { TranslationKeys.db_dbr044_msg, "キー・ファイル名が設定されていないため、アセンブリに署名できませんでした。" }
          , { TranslationKeys.db_dbr045_msg_par1, "鍵ファイル名 '{0}' が PFX 証明書ファイルではないため、アセンブリに署名できませんでした。" }
          , { TranslationKeys.db_dbr054_msg_par1, "0:N0}アセンブリの型の名前を変更します。" }
          , { TranslationKeys.db_dbr055_msg_par1, "0:N0}アセンブリの後処理。" }
          , { TranslationKeys.db_dbr056_msg_par1, "アセンブリを '{0}' に保存します。" }
          , { TranslationKeys.db_dbr057_msg_par1, "マッピングをファイル '{0}' に保存する。" }
          , { TranslationKeys.db_dbr059_msg, "余分なフレームワークフォルダ：" }
          , { TranslationKeys.db_dbr061_msg_par1, "0}'の保存に失敗しました。" }
          , { TranslationKeys.db_dbr063_msg_par1, "{0}のいずれかかもしれない：" }
          , { TranslationKeys.db_dbr069_msg_par1, "0}」からキー・ペアを作成しません。" }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "0:N0}秒で正常に完了しました。" }
          , { TranslationKeys.db_dbr079_msg_par1, "0}」からRSAキー値を作成する。" }
          , { TranslationKeys.db_dbr082_par1, "0:N0}秒で正常に完了しました。" }
          , { TranslationKeys.db_dbr108_msg_par1, "プロセスアセンブリ '{0}'。" }
          , { TranslationKeys.db_dbr109_msg_par1, "0}とパスワードからキー・ペアを作成する。" }
          , { TranslationKeys.db_dbr110_msg, "鍵ファイルと鍵コンテナが設定されていない。 鍵ペアを使用しない。" }
          , { TranslationKeys.db_dbr111_msg, "鍵ファイルおよび鍵コンテナが設定されていない。 RSA 鍵が設定されていない。" }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "0}」からRSAキー値を作成しません。" }
          , { TranslationKeys.db_dbr113_msg_par1, "引数 '{2}' を持つ署名ツール '{1}' を使って '{0}' の署名を開始する。" }
          , { TranslationKeys.db_dbr116_msg, "アセンブリをロードする。" }
          , { TranslationKeys.db_dbr117_msg_par1, "2} が原因で、プロジェクトのキーペアを使用してアセンブリ '{0}' が '{1}' に保存されませんでした。" }
          , { TranslationKeys.db_dbr118_msg_par1, "コンテナ '{2}' を使用して '{0}' を '{1}' として署名。" }
          , { TranslationKeys.db_dbr119_msg_par1, "0}'をそのまま'{1}'に保存した。" }
          , { TranslationKeys.db_dbr120_msg_par1, "プロジェクトのキーペアを使用して '{0}' を '{1}' に保存します。" }
          , { TranslationKeys.db_dbr122_msg_par1, "保存するプロジェクトに {0:N0} 個のアセンブリがあります。" }
          , { TranslationKeys.db_dbr123_msg_par1, "署名は『{0}』。" }
          , { TranslationKeys.db_dbr124_msg_par1, "アセンブリ '{0}' には公開鍵がありません。" }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr チャンネル： {0｝" }
          , { TranslationKeys.db_dbr130_par1, "エラーで{0:N0}秒で完了。" }
          , { TranslationKeys.db_dbr131_par1, "エラーで{0:N0}秒で完了。" }
          , { TranslationKeys.db_dbr132_par1, "エラーで{0:N0}秒で完了。" }
          , { TranslationKeys.db_dbr133_par1, "エラーで{0:N0}秒で完了。" }
          , { TranslationKeys.db_dbr135_msg, "ステータスは「Renamed」か「Skipped」のどちらかになると予想される。" }
          , { TranslationKeys.db_dbr139_msg_par1, "ステータスは「{1}」の{0}ではなく、「Renamed」か「Skipped」のいずれかになると予想される。" }
          , { TranslationKeys.db_dbr141_msg, "ファイル名がありません。" }
          , { TranslationKeys.db_dbr143_msg, "グループの外部フラグはグループ作成時に処理されているはずであり、グループ内のすべてのメソッドはすでにスキップされているはずである。" }
          , { TranslationKeys.db_dbr144_msg, "メソッドがスキップされず、グループに名前がある場合は、メソッドに名前がなければならない。" }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}'はエラーコード{1}により署名されなかった。" }
          , { TranslationKeys.db_dbr149_msg_par1, "ステータスは'{0}'ではなく、'Renamed'または'Skipped'でなければならない。" }
          , { TranslationKeys.db_dbr153_msg_par1, "標準出力チャンネル：{0｝" }
          , { TranslationKeys.db_dbr154_msg, "余分なフレームワークフォルダはない：" }
          , { TranslationKeys.db_dbr155_msg, "型名を抽出できません。" }
          , { TranslationKeys.db_dbr156_msg_par1, "XMLプロジェクト定義を'{0}'から読み込みます。" }
          , { TranslationKeys.db_dbr157_msg_par1, "0}個の変数を処理した。" }
          , { TranslationKeys.db_dbr158_msg_par1, "処理済み{0} インクルード・タグ。" }
          , { TranslationKeys.db_dbr159_msg_par1, "0}個のアセンブリ検索パスを処理しました。" }
          , { TranslationKeys.db_dbr160_msg_par1, "0}個のモジュールを処理しました。" }
          , { TranslationKeys.db_dbr161_msg_par1, "0}個のモジュールグループを処理しました。" }
          , { TranslationKeys.db_dbr162_msg, "変数から設定を初期化する。" }
          , { TranslationKeys.db_dbr166_msg_par1, "証明書ファイル「{0}」には、少なくとも1つの証明書が含まれていなければならない。" }
          , { TranslationKeys.db_dbr167_msg_par1, "証明書ファイル '{0}' の形式が無効です。" }
          , { TranslationKeys.db_dbr169_msg, "名前生成のための文字を決定する。" }
          , { TranslationKeys.db_dbr173_msg_par1, "1}'で{0}のインストールが見つかりました。" }
          , { TranslationKeys.db_dbr174_msg_par1, "1}' に {0} のインストールが見つかりませんでした。" }
          , { TranslationKeys.db_dbr175_msg, "鍵ファイル名による証明書選択とSHA1サムプリントのうち、使用できるのは1つまでである。" }
          , { TranslationKeys.db_dbr176_msg, "鍵ファイル名で証明書を選択するか、SHA1サムプリントを使用しなければならない。" }
          , { TranslationKeys.db_dbr177_msg, "鍵ファイルのパスワードは、鍵ファイル名で証明書を選択した場合にのみ入力できる。" }
          , { TranslationKeys.db_definition_missing, "定義が欠けている。" }
          , { TranslationKeys.db_display_version, "このアプリケーションのバージョン番号を表示します。" }
          , { TranslationKeys.db_duplicate_character, "文字が重複している。" }
          , { TranslationKeys.db_error_processing_colon, "処理中にエラーが発生しました：" }
          , { TranslationKeys.db_filename_missing, "ファイル名がありません。" }
          , { TranslationKeys.db_fork_obfuscar, "DotBlurはObfuscar (https://www.obfuscar.com) のフォークである。" }
          , { TranslationKeys.db_full_name_missing, "フルネームがない。" }
          , { TranslationKeys.db_gt_title_par2, "*** ドットブラーグローバルツール ({0}) on {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "このヘルプ情報を印刷する。" }
          , { TranslationKeys.db_hide_strings, "弦を隠す。" }
          , { TranslationKeys.db_hint_colon_par1, "ヒント：{0}。" }
          , { TranslationKeys.db_hint_skiptype, "ヒント: 上記の列挙型に SkipType を追加する必要があるかもしれません。" }
          , { TranslationKeys.db_inner_exception_par1, "内部例外：{0}。" }
          , { TranslationKeys.db_loading_pjt_par1, "プロジェクト '{0}' をロードしています。" }
          , { TranslationKeys.db_missing_group, "欠場組。" }
          , { TranslationKeys.db_missing_parent_reader, "親の読者がいない。" }
          , { TranslationKeys.db_missing_parts, "部品が足りない。" }
          , { TranslationKeys.db_missing_path_value, "パスの値がない。" }
          , { TranslationKeys.db_missing_read_action, "ミッシング・リード・アクション" }
          , { TranslationKeys.db_missing_setting_name, "設定名がありません。" }
          , { TranslationKeys.db_not_hide_strings, "糸を隠しているわけではない。" }
          , { TranslationKeys.db_not_rename_events, "イベント名を変更しないでください。" }
          , { TranslationKeys.db_not_rename_fields, "フィールド名は変更しないでください。" }
          , { TranslationKeys.db_not_rename_properties, "プロパティの名前は変更しないでください。" }
          , { TranslationKeys.db_options_colon, "オプション" }
          , { TranslationKeys.db_pool_clean, "プールの掃除ができない。" }
          , { TranslationKeys.db_pool_still, "まだプールの中だ：" }
          , { TranslationKeys.db_rename_events, "イベント名を変更する。" }
          , { TranslationKeys.db_rename_fields, "フィールド名を変更する。" }
          , { TranslationKeys.db_rename_methods, "メソッド名を変更する。" }
          , { TranslationKeys.db_rename_parameters, "パラメータ名を変更する。" }
          , { TranslationKeys.db_rename_properties, "プロパティの名前を変更する。" }
          , { TranslationKeys.db_settings_not_initialized, "設定がまだ初期化されていない。" }
          , { TranslationKeys.db_syntax, "DotBlur.exe [オプション] [プロジェクトファイル] [プロジェクトファイル］" }
          }
        }
        , { Languages.ko, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "콜스택" }
          , { TranslationKeys.db_check_project_settings, "프로젝트 설정을 확인하세요." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console은 Obfuscar(https://www.obfuscar.com)의 포크입니다." }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [옵션] [프로젝트 파일] [프로젝트 파일]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur 콘솔({0}) {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams 및 기타 기여자." }
          , { TranslationKeys.db_dbr002_msg_par1, "{0}' 및 '{1}' 변수는 함께 설정할 수 없습니다." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "파일 '{0}'의 내용을 수정하세요." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML 구성 파일에는 <{0}> 루트 태그가 있어야 합니다." }
          , { TranslationKeys.db_dbr005_msg_par1, "OutPath에서 지정한 경로 '{0}'을(를) 만들 수 없습니다." }
          , { TranslationKeys.db_dbr006_msg_par1, "InPath 변수로 지정된 경로 '{0}'이(가) 존재해야 합니다." }
          , { TranslationKeys.db_dbr007_msg_par1, "키 파일 '{0}'을 로드하는 중 실패했습니다." }
          , { TranslationKeys.db_dbr008_msg, "Mono에서는 키 컨테이너가 지원되지 않습니다." }
          , { TranslationKeys.db_dbr009_msg_par1, "종속성 '{0}'을(를) 해결할 수 없습니다." }
          , { TranslationKeys.db_dbr010_msg, "'공개'를 사용하세요." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}'은 skip 요소의 'typeattrib' 값에 유효하지 않습니다." }
          , { TranslationKeys.db_dbr011_msg, "'공개'를 사용하세요." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}'은 SkipType 요소의 'attrib' 값에 유효하지 않습니다." }
          , { TranslationKeys.db_dbr012_msg_par1, "변수 '{0}'을(를) 바꿀 수 없습니다." }
          , { TranslationKeys.db_dbr013_msg, "'공개' 또는 '보호'를 사용하세요." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}'은 skip 요소의 'attrib' 값에 유효하지 않습니다." }
          , { TranslationKeys.db_dbr014_msg_par1, "지정된 프로젝트 파일 '{0}'을 읽을 수 없습니다." }
          , { TranslationKeys.db_dbr015_msg, "KeyFile 또는 KeyContainer 속성을 사용하여 사용할 키를 설정합니다." }
          , { TranslationKeys.db_dbr015_msg_par1, "서명된 어셈블리 '{0}'을 난독화하면 잘못된 어셈블리가 생성됩니다." }
          , { TranslationKeys.db_dbr017_msg_par1, "키 컨테이너 '{0}'의 키를 사용하여 어셈블리에 서명할 수 없습니다." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0}은 유효한 XML 파일이 아닙니다." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "어셈블리 '{0}'을 찾을 수 없습니다." }
          , { TranslationKeys.db_dbr020_msg_par1, "{0}에 대한 유형 정의를 가져오지 못했습니다." }
          , { TranslationKeys.db_dbr024_msg_par1, "비밀번호 없이 '{0}'에서 키 쌍을 생성합니다." }
          , { TranslationKeys.db_dbr027_msg, "이름에는 값이 있어야 합니다." }
          , { TranslationKeys.db_dbr028_msg, "이름과 name 정규 표현식을 설정해야 합니다." }
          , { TranslationKeys.db_dbr029_msg, "사용하기 전에 AssemblyInfo.LoadAssembly를 호출해야 합니다." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init은 사용하기 전에 호출해야 합니다." }
          , { TranslationKeys.db_dbr034_msg, "유효한 파일 속성이 필요합니다." }
          , { TranslationKeys.db_dbr035_msg_par1, "형식 이름 '{0}' 및 '{1}'은 동일해야 합니다." }
          , { TranslationKeys.db_dbr036_msg, "이름과 name 정규 표현식이 설정되지 않았습니다." }
          , { TranslationKeys.db_dbr038_msg, "인코딩 유형 정의가 설정되지 않았습니다." }
          , { TranslationKeys.db_dbr039_msg, "최신 데이터가 설정되지 않았습니다." }
          , { TranslationKeys.db_dbr040_msg, "signtool.exe를 찾을 수 없으므로 어셈블리에 서명할 수 없습니다." }
          , { TranslationKeys.db_dbr041_msg_par1, "지정된 위치 '{0}'에서 signtool.exe를 찾을 수 없으므로 어셈블리에 서명할 수 없습니다." }
          , { TranslationKeys.db_dbr042_msg, "signtool.exe 이후부터 sign 프로세스를 시작할 수 없습니다. 프로세스 없음." }
          , { TranslationKeys.db_dbr043_msg_par1, "할당된 시간 {0:N0}ms 내에 서명 어셈블리가 종료되지 않았습니다." }
          , { TranslationKeys.db_dbr044_msg, "키 파일 이름이 설정되지 않았기 때문에 어셈블리에 서명할 수 없습니다." }
          , { TranslationKeys.db_dbr045_msg_par1, "키 파일 이름 '{0}'이(가) PFX 인증서 파일이 아니기 때문에 어셈블리에 서명할 수 없습니다." }
          , { TranslationKeys.db_dbr054_msg_par1, "{0:N0} 어셈블리의 유형 이름을 바꿉니다." }
          , { TranslationKeys.db_dbr055_msg_par1, "{0:N0} 어셈블리의 사후 처리." }
          , { TranslationKeys.db_dbr056_msg_par1, "어셈블리를 '{0}'에 저장합니다." }
          , { TranslationKeys.db_dbr057_msg_par1, "매핑을 파일 '{0}'에 저장합니다." }
          , { TranslationKeys.db_dbr059_msg, "추가 프레임워크 폴더:" }
          , { TranslationKeys.db_dbr061_msg_par1, "'{0}'을(를) 저장하지 못했습니다." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0}은 다음 중 하나일 수 있습니다." }
          , { TranslationKeys.db_dbr069_msg_par1, "'{0}'에서 키 쌍을 생성하지 마십시오." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "{0:N0}초 만에 성공적으로 완료되었습니다." }
          , { TranslationKeys.db_dbr079_msg_par1, "'{0}'에서 RSA 키 값을 생성합니다." }
          , { TranslationKeys.db_dbr082_par1, "{0:N0}초 만에 성공적으로 완료되었습니다." }
          , { TranslationKeys.db_dbr108_msg_par1, "프로세스 어셈블리 '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "비밀번호로 {0}에서 키 쌍을 생성합니다." }
          , { TranslationKeys.db_dbr110_msg, "키 파일과 키 컨테이너가 구성되지 않았습니다. 키 쌍을 사용하지 마십시오." }
          , { TranslationKeys.db_dbr111_msg, "키 파일과 키 컨테이너가 구성되지 않았습니다. RSA 키 값을 사용하지 마십시오." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "'{0}'에서 RSA 키 값을 생성하지 마십시오." }
          , { TranslationKeys.db_dbr113_msg_par1, "인수 '{2}'와 함께 서명 도구 '{1}'을 사용하여 '{0}' 서명을 시작합니다." }
          , { TranslationKeys.db_dbr116_msg, "조립품을 로딩합니다." }
          , { TranslationKeys.db_dbr117_msg_par1, "{2}로 인해 어셈블리 '{0}'이(가) 프로젝트 키 페어를 사용하여 '{1}'에 저장되지 않았습니다." }
          , { TranslationKeys.db_dbr118_msg_par1, "컨테이너 '{2}'을(를) 사용하여 '{0}'을(를) '{1}'(으)로 서명했습니다." }
          , { TranslationKeys.db_dbr119_msg_par1, "'{0}'을(를) 있는 그대로 '{1}'에 저장했습니다. 원래는 강력한 이름으로 서명되지 않았습니다." }
          , { TranslationKeys.db_dbr120_msg_par1, "프로젝트 키페어를 사용하여 '{0}'을(를) '{1}'에 저장합니다." }
          , { TranslationKeys.db_dbr122_msg_par1, "프로젝트에 저장할 어셈블리가 {0:N0}개 있습니다." }
          , { TranslationKeys.db_dbr123_msg_par1, "'{0}'에 서명했습니다." }
          , { TranslationKeys.db_dbr124_msg_par1, "어셈블리 '{0}'에 공개 키가 없습니다. 그대로 저장하세요." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr 채널: {0}" }
          , { TranslationKeys.db_dbr130_par1, "{0:N0}초 만에 오류가 발생하여 완료되었습니다." }
          , { TranslationKeys.db_dbr131_par1, "{0:N0}초 만에 오류가 발생하여 완료되었습니다." }
          , { TranslationKeys.db_dbr132_par1, "{0:N0}초 만에 오류가 발생하여 완료되었습니다." }
          , { TranslationKeys.db_dbr133_par1, "{0:N0}초 만에 오류가 발생하여 완료되었습니다." }
          , { TranslationKeys.db_dbr135_msg, "상태는 '이름 변경됨' 또는 '건너뜀' 중 하나여야 합니다." }
          , { TranslationKeys.db_dbr139_msg_par1, "상태는 '{1}'의 {0} 대신 '이름 변경됨' 또는 '건너뜀'이어야 합니다." }
          , { TranslationKeys.db_dbr141_msg, "파일 이름이 없습니다." }
          , { TranslationKeys.db_dbr143_msg, "그룹의 외부 플래그는 그룹이 생성될 때 처리되어야 하고, 그룹의 모든 메서드는 이미 건너뜀으로 표시되어야 합니다." }
          , { TranslationKeys.db_dbr144_msg, "메서드가 건너뛰어지지 않고 그룹에 이름이 있는 경우 메서드에는 이름이 있어야 합니다." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}'은 오류 코드 {1}로 인해 서명되지 않았습니다." }
          , { TranslationKeys.db_dbr149_msg_par1, "상태는 '{0}' 대신 '이름 변경됨' 또는 '건너뜀'이어야 합니다." }
          , { TranslationKeys.db_dbr153_msg_par1, "표준 출력 채널: {0}" }
          , { TranslationKeys.db_dbr154_msg, "추가 프레임워크 폴더 없음:" }
          , { TranslationKeys.db_dbr155_msg, "형식 이름을 추출할 수 없습니다." }
          , { TranslationKeys.db_dbr156_msg_par1, "'{0}'에서 XML 프로젝트 정의를 로드합니다." }
          , { TranslationKeys.db_dbr157_msg_par1, "{0}개의 변수를 처리했습니다." }
          , { TranslationKeys.db_dbr158_msg_par1, "처리된 {0}에는 태그가 포함됩니다." }
          , { TranslationKeys.db_dbr159_msg_par1, "{0}개의 어셈블리 검색 경로를 처리했습니다." }
          , { TranslationKeys.db_dbr160_msg_par1, "{0}개의 모듈을 처리했습니다." }
          , { TranslationKeys.db_dbr161_msg_par1, "{0}개의 모듈 그룹을 처리했습니다." }
          , { TranslationKeys.db_dbr162_msg, "변수에서 설정을 초기화합니다." }
          , { TranslationKeys.db_dbr166_msg_par1, "인증서 파일 '{0}'에는 최소한 하나의 인증서가 포함되어야 합니다." }
          , { TranslationKeys.db_dbr167_msg_par1, "인증서 파일 '{0}'의 형식이 잘못되었습니다." }
          , { TranslationKeys.db_dbr169_msg, "이름 생성에 사용할 문자를 결정합니다." }
          , { TranslationKeys.db_dbr173_msg_par1, "'{1}'에서 {0}의 설치를 찾았습니다." }
          , { TranslationKeys.db_dbr174_msg_par1, "'{1}'에서 {0}의 설치를 찾을 수 없습니다." }
          , { TranslationKeys.db_dbr175_msg, "키 파일 이름과 SHA1 지문을 통한 인증서 선택 중 하나만 사용할 수 있습니다." }
          , { TranslationKeys.db_dbr176_msg, "키 파일 이름이나 SHA1 지문을 사용한 인증서 선택을 사용해야 합니다." }
          , { TranslationKeys.db_dbr177_msg, "키 파일 비밀번호는 인증서가 키 파일 이름으로 선택된 경우에만 제공될 수 있습니다." }
          , { TranslationKeys.db_definition_missing, "정의가 없습니다." }
          , { TranslationKeys.db_display_version, "이 애플리케이션의 버전 번호를 표시합니다." }
          , { TranslationKeys.db_duplicate_character, "중복된 문자입니다." }
          , { TranslationKeys.db_error_processing_colon, "처리 중 오류가 발생했습니다:" }
          , { TranslationKeys.db_filename_missing, "파일 이름이 없습니다." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur는 Obfuscar(https://www.obfuscar.com)의 포크입니다." }
          , { TranslationKeys.db_full_name_missing, "전체 이름이 누락되었습니다." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur 글로벌 도구({0}) {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "이 도움말 정보를 인쇄하세요." }
          , { TranslationKeys.db_hide_strings, "문자열을 숨깁니다." }
          , { TranslationKeys.db_hint_colon_par1, "힌트: {0}" }
          , { TranslationKeys.db_hint_skiptype, "힌트: 위의 열거형에 대해 SkipType을 추가해야 할 수도 있습니다." }
          , { TranslationKeys.db_inner_exception_par1, "내부 예외: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "프로젝트 '{0}'을 로드하는 중입니다." }
          , { TranslationKeys.db_missing_group, "그룹이 누락되었습니다." }
          , { TranslationKeys.db_missing_parent_reader, "부모님이 읽어주시지 않아요." }
          , { TranslationKeys.db_missing_parts, "부품이 누락되었습니다." }
          , { TranslationKeys.db_missing_path_value, "경로 값이 누락되었습니다." }
          , { TranslationKeys.db_missing_read_action, "읽기 작업이 누락되었습니다." }
          , { TranslationKeys.db_missing_setting_name, "설정 이름이 없습니다." }
          , { TranslationKeys.db_not_hide_strings, "끈을 숨기지 마세요." }
          , { TranslationKeys.db_not_rename_events, "이벤트 이름을 바꾸지 마세요." }
          , { TranslationKeys.db_not_rename_fields, "필드 이름을 바꾸지 마세요." }
          , { TranslationKeys.db_not_rename_properties, "속성 이름을 변경하지 마세요." }
          , { TranslationKeys.db_options_colon, "옵션:" }
          , { TranslationKeys.db_pool_clean, "수영장을 청소할 수 없습니다." }
          , { TranslationKeys.db_pool_still, "아직 수영장에 있어요:" }
          , { TranslationKeys.db_rename_events, "이벤트 이름을 변경합니다." }
          , { TranslationKeys.db_rename_fields, "필드 이름을 바꾸세요." }
          , { TranslationKeys.db_rename_methods, "메서드 이름을 변경합니다." }
          , { TranslationKeys.db_rename_parameters, "매개변수의 이름을 바꿉니다." }
          , { TranslationKeys.db_rename_properties, "속성의 이름을 바꿉니다." }
          , { TranslationKeys.db_settings_not_initialized, "설정이 아직 초기화되지 않았습니다." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [옵션] [프로젝트 파일] [프로젝트 파일]" }
          }
        }
        , { Languages.nb, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Sjekk prosjektinnstillingene." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console er en gaffel av Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Alternativer] [prosjektfil] [prosjektfil]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur-konsoll ({0}) på {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams og andre bidragsytere." }
          , { TranslationKeys.db_dbr002_msg_par1, "Variablene {0}' og '{1}' kan ikke settes sammen." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Rett innholdet i filen '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML-konfigurasjonsfilen skal ha en <{0}>-rotkode." }
          , { TranslationKeys.db_dbr005_msg_par1, "Kunne ikke opprette banen '{0}' spesifisert av OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Banen '{0}' spesifisert av InPath-variabelen må eksistere," }
          , { TranslationKeys.db_dbr007_msg_par1, "Feil ved innlasting av nøkkelfil '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Nøkkelbeholdere støttes ikke for Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Kan ikke løse avhengigheten '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Bruk 'offentlig'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' er ikke gyldig for 'typeattrib'-verdien for hopp over elementer." }
          , { TranslationKeys.db_dbr011_msg, "Bruk 'offentlig'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' er ikke gyldig for 'attrib'-verdien til SkipType-elementet." }
          , { TranslationKeys.db_dbr012_msg_par1, "Kan ikke erstatte variabelen '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Bruk \"offentlig\" eller \"beskyttet\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}' er ikke gyldig for 'attrib'-verdien for hopp over elementer." }
          , { TranslationKeys.db_dbr014_msg_par1, "Kan ikke lese den spesifiserte prosjektfilen '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Bruk egenskapen KeyFile eller KeyContainer for å angi en nøkkel som skal brukes." }
          , { TranslationKeys.db_dbr015_msg_par1, "Å skjule den signerte sammenstillingen '{0}' vil resultere i en ugyldig sammenstilling." }
          , { TranslationKeys.db_dbr017_msg_par1, "Kan ikke signere sammenstilling med nøkkel fra nøkkelbeholder '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} er ikke en gyldig XML-fil." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Kan ikke finne sammenstillingen '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Kunne ikke hente typedefinisjoner for {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Opprett nøkkelpar fra '{0}' uten passord." }
          , { TranslationKeys.db_dbr027_msg, "Navnet må ha en verdi." }
          , { TranslationKeys.db_dbr028_msg, "Det regulære uttrykket for navn og navn må ha blitt angitt." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly må tilkalles før bruk." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init må kalles opp før bruk." }
          , { TranslationKeys.db_dbr034_msg, "Trenger gyldig filattributt." }
          , { TranslationKeys.db_dbr035_msg_par1, "Typenavn '{0}' og '{1}' må være like." }
          , { TranslationKeys.db_dbr036_msg, "Det regulære uttrykket for navn og navn er ikke angitt." }
          , { TranslationKeys.db_dbr038_msg, "Kodingstypedefinisjonen er ikke angitt." }
          , { TranslationKeys.db_dbr039_msg, "De nyeste dataene er ikke angitt." }
          , { TranslationKeys.db_dbr040_msg, "Kunne ikke signere assembly siden signtool.exe ikke kunne finnes." }
          , { TranslationKeys.db_dbr041_msg_par1, "Kunne ikke signere assembly siden signtool.exe ikke ble funnet på den angitte plasseringen '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Kunne ikke starte signeringsprosessen med siden signtool.exe. Ingen prosess." }
          , { TranslationKeys.db_dbr043_msg_par1, "Signeringssamlingen ble ikke avsluttet innen den tildelte tiden på {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Kunne ikke signere sammenstilling siden nøkkelfilnavnet ikke er angitt." }
          , { TranslationKeys.db_dbr045_msg_par1, "Kunne ikke signere assembly siden nøkkelfilnavnet '{0}' ikke er en PFX-sertifikatfil." }
          , { TranslationKeys.db_dbr054_msg_par1, "Gi nytt navn til typer i {0:N0}-sammenstillinger." }
          , { TranslationKeys.db_dbr055_msg_par1, "Etterbehandling av {0:N0} sammenstillinger." }
          , { TranslationKeys.db_dbr056_msg_par1, "Lagre sammenstillinger til '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Lagre tilordningen til filen '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Ekstra rammemapper:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Kunne ikke lagre '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} kan være en av:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Opprett ingen nøkkelpar fra '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Fullført på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr079_msg_par1, "Opprett RSA-nøkkelverdi fra '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Fullført på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr108_msg_par1, "Prosesssammenstilling '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Opprett nøkkelpar fra {0} med passord." }
          , { TranslationKeys.db_dbr110_msg, "Ingen nøkkelfil og ingen nøkkelbeholder konfigurert. Bruk ikke nøkkelpar." }
          , { TranslationKeys.db_dbr111_msg, "Ingen nøkkelfil og ingen nøkkelbeholder konfigurert. Bruk ingen RSA-nøkkelverdi." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Opprett ingen RSA-nøkkelverdi fra '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Begynn å signere '{0}' ved å bruke signeringsverktøyet '{1}' med argumentene '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Laster sammenstillinger." }
          , { TranslationKeys.db_dbr117_msg_par1, "Sammenstillingen '{0}' er ikke lagret med prosjektnøkkelparet til '{1}' på grunn av {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signert '{0}' som '{1}' ved hjelp av beholderen '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Lagret '{0}' som den er i '{1}'; var opprinnelig ikke sterkt navn signert." }
          , { TranslationKeys.db_dbr120_msg_par1, "Lagre '{0}' ved hjelp av prosjektnøkkelpar til '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Det er {0:N0} sammenstillinger i prosjektet å lagre." }
          , { TranslationKeys.db_dbr123_msg_par1, "Signert '{0}'." }
          , { TranslationKeys.db_dbr124_msg_par1, "Assembly '{0}' har ingen offentlig nøkkel; lagre som den er." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-kanal: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Fullført med feil på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr131_par1, "Fullført med feil på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr132_par1, "Fullført med feil på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr133_par1, "Fullført med feil på {0:N0} sekunder." }
          , { TranslationKeys.db_dbr135_msg, "Status forventes å være enten \"Omdøpt\" eller \"Hoppet over\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Status forventes å være enten «Omdøpt» eller «Hoppet over» i stedet for {0} av «{1}»." }
          , { TranslationKeys.db_dbr141_msg, "Manglende filnavn." }
          , { TranslationKeys.db_dbr143_msg, "Gruppens eksterne flagg skal ha blitt håndtert da gruppen ble opprettet og alle metoder i gruppen skal allerede være merket som hoppet over." }
          , { TranslationKeys.db_dbr144_msg, "Metode må ha et navn når metoden ikke hoppes over og gruppen har et navn." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' ble IKKE signert på grunn av feilkode {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status må være 'Omdøpt' eller 'Hoppet over' i stedet for '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-kanal: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Ingen ekstra rammemapper:" }
          , { TranslationKeys.db_dbr155_msg, "Kan ikke trekke ut typenavn." }
          , { TranslationKeys.db_dbr156_msg_par1, "Last inn XML-prosjektdefinisjon fra '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Behandlet {0} variabler." }
          , { TranslationKeys.db_dbr158_msg_par1, "Behandlet {0} inkluderer tagger." }
          , { TranslationKeys.db_dbr159_msg_par1, "Behandlet {0} samlingssøkebaner." }
          , { TranslationKeys.db_dbr160_msg_par1, "Behandlet {0} moduler." }
          , { TranslationKeys.db_dbr161_msg_par1, "Behandlet {0} modulgrupper." }
          , { TranslationKeys.db_dbr162_msg, "Initialiser innstillinger fra variabler." }
          , { TranslationKeys.db_dbr166_msg_par1, "Sertifikatfilen '{0}' må inneholde minst ett sertifikat." }
          , { TranslationKeys.db_dbr167_msg_par1, "Sertifikatfilen '{0}' har et ugyldig format." }
          , { TranslationKeys.db_dbr169_msg, "Bestem tegn for navngenerering." }
          , { TranslationKeys.db_dbr173_msg_par1, "Fant installasjon av {0} ved '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Fant ingen installasjon av {0} i '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Høyst ett av sertifikatvalg etter nøkkelfilnavn og SHA1-tommelavtrykk kan brukes." }
          , { TranslationKeys.db_dbr176_msg, "Enten sertifikatvalg etter nøkkelfilnavn eller SHA1-tommelavtrykk må brukes." }
          , { TranslationKeys.db_dbr177_msg, "Nøkkelfilpassordet kan bare oppgis når sertifikatet er valgt med nøkkelfilnavn." }
          , { TranslationKeys.db_definition_missing, "Definisjon mangler." }
          , { TranslationKeys.db_display_version, "Vis versjonsnummeret til denne applikasjonen." }
          , { TranslationKeys.db_duplicate_character, "Duplikattegn." }
          , { TranslationKeys.db_error_processing_colon, "Det oppstod en feil under behandlingen:" }
          , { TranslationKeys.db_filename_missing, "Manglende filnavn." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur er en gaffel av Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Fullt navn mangler." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) på {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Skriv ut denne hjelpeinformasjonen." }
          , { TranslationKeys.db_hide_strings, "Skjul strenger." }
          , { TranslationKeys.db_hint_colon_par1, "Hint: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Hint: det kan hende du må legge til en SkipType for en enum ovenfor." }
          , { TranslationKeys.db_inner_exception_par1, "Indre unntak: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Laster prosjektet '{0}'." }
          , { TranslationKeys.db_missing_group, "Mangler gruppe." }
          , { TranslationKeys.db_missing_parent_reader, "Mangler foreldreleser." }
          , { TranslationKeys.db_missing_parts, "Manglende deler." }
          , { TranslationKeys.db_missing_path_value, "Manglende verdi for banen." }
          , { TranslationKeys.db_missing_read_action, "Mangler lesehandling." }
          , { TranslationKeys.db_missing_setting_name, "Mangler innstillingsnavn." }
          , { TranslationKeys.db_not_hide_strings, "Ikke skjule strenger." }
          , { TranslationKeys.db_not_rename_events, "Ikke gi nytt navn til hendelser." }
          , { TranslationKeys.db_not_rename_fields, "Ikke gi nytt navn til felt." }
          , { TranslationKeys.db_not_rename_properties, "Ikke gi nytt navn til egenskaper." }
          , { TranslationKeys.db_options_colon, "Alternativer:" }
          , { TranslationKeys.db_pool_clean, "Kan ikke rense bassenget." }
          , { TranslationKeys.db_pool_still, "Fortsatt i bassenget:" }
          , { TranslationKeys.db_rename_events, "Gi nytt navn til hendelser." }
          , { TranslationKeys.db_rename_fields, "Gi nytt navn til felt." }
          , { TranslationKeys.db_rename_methods, "Gi nytt navn til metoder." }
          , { TranslationKeys.db_rename_parameters, "Gi nytt navn til parametere." }
          , { TranslationKeys.db_rename_properties, "Gi nytt navn til egenskaper." }
          , { TranslationKeys.db_settings_not_initialized, "Innstillinger ikke initialisert ennå." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Alternativer] [prosjektfil] [prosjektfil]" }
          }
        }
        , { Languages.nl, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Controleer de projectinstellingen." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console is een fork van Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Opties] [projectbestand] [projectbestand]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) op {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams en andere bijdragers." }
          , { TranslationKeys.db_dbr002_msg_par1, "{0}' en '{1}' variabelen kunnen niet samen worden ingesteld." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Corrigeer de inhoud van het bestand '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "Het XML-configuratiebestand moet een <{0}> root-tag hebben." }
          , { TranslationKeys.db_dbr005_msg_par1, "Het door OutPath opgegeven pad '{0}' kon niet worden aangemaakt." }
          , { TranslationKeys.db_dbr006_msg_par1, "Pad '{0}' gespecificeerd door InPath variabele moet bestaan," }
          , { TranslationKeys.db_dbr007_msg_par1, "Fout bij laden van het sleutelbestand '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Sleutelcontainers worden niet ondersteund voor Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Kan afhankelijkheid '{0}' niet oplossen." }
          , { TranslationKeys.db_dbr010_msg, "Gebruik 'public'." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}' is niet geldig voor de 'typeattrib'-waarde van overgeslagen elementen." }
          , { TranslationKeys.db_dbr011_msg, "Gebruik 'public'." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}' is niet geldig voor de 'attrib' waarde van het SkipType element." }
          , { TranslationKeys.db_dbr012_msg_par1, "Kan variabele '{0}' niet vervangen." }
          , { TranslationKeys.db_dbr013_msg, "Gebruik 'public' of 'protected'." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}' is niet geldig voor de 'attrib'-waarde van overgeslagen elementen." }
          , { TranslationKeys.db_dbr014_msg_par1, "Kan het opgegeven projectbestand '{0}' niet lezen." }
          , { TranslationKeys.db_dbr015_msg, "Gebruik de eigenschap KeyFile of KeyContainer om een te gebruiken sleutel in te stellen." }
          , { TranslationKeys.db_dbr015_msg_par1, "Het versluieren van de ondertekende assembly '{0}' zou resulteren in een ongeldige assembly." }
          , { TranslationKeys.db_dbr017_msg_par1, "Kan de assembly niet ondertekenen met de sleutel uit de sleutelcontainer '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} is geen geldig XML-bestand." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Kan assembly '{0}' niet vinden." }
          , { TranslationKeys.db_dbr020_msg_par1, "Kan de typedefinities niet ophalen voor {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Maak een sleutelpaar van '{0}' zonder wachtwoord." }
          , { TranslationKeys.db_dbr027_msg, "Naam moet een waarde hebben." }
          , { TranslationKeys.db_dbr028_msg, "Naam en reguliere expressie van de naam moeten zijn ingesteld." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly moet voor gebruik worden aangeroepen." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init moet voor gebruik worden aangeroepen." }
          , { TranslationKeys.db_dbr034_msg, "Geldig bestandsattribuut nodig." }
          , { TranslationKeys.db_dbr035_msg_par1, "Typenamen '{0}' en '{1}' moeten gelijk zijn." }
          , { TranslationKeys.db_dbr036_msg, "Naam en reguliere expressie voor naam zijn niet ingesteld." }
          , { TranslationKeys.db_dbr038_msg, "Definitie van coderingstype niet ingesteld." }
          , { TranslationKeys.db_dbr039_msg, "Meest recente gegevens niet ingesteld." }
          , { TranslationKeys.db_dbr040_msg, "Kon assembly niet ondertekenen omdat signtool.exe niet kon worden gevonden." }
          , { TranslationKeys.db_dbr041_msg_par1, "Kon assembly niet ondertekenen omdat signtool.exe niet op de opgegeven locatie '{0}' kon worden gevonden." }
          , { TranslationKeys.db_dbr042_msg, "Kan ondertekeningsproces niet starten met signtool.exe. Geen proces." }
          , { TranslationKeys.db_dbr043_msg_par1, "De assembly-ondertekening is niet binnen de toegestane tijd van {0:N0} ms beëindigd." }
          , { TranslationKeys.db_dbr044_msg, "Kon assembly niet ondertekenen omdat de sleutelbestandsnaam niet is ingesteld." }
          , { TranslationKeys.db_dbr045_msg_par1, "Kon assembly niet ondertekenen omdat de sleutelbestandsnaam '{0}' geen PFX-certificaatbestand is." }
          , { TranslationKeys.db_dbr054_msg_par1, "Hernoem types in {0:N0} assemblies." }
          , { TranslationKeys.db_dbr055_msg_par1, "Nabewerking van {0:N0} assemblies." }
          , { TranslationKeys.db_dbr056_msg_par1, "Sla assemblies op in '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Sla de vertaalslag op in het bestand '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Extra framework-mappen:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Opslaan van '{0}' is mislukt." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} zou een van de volgende kunnen zijn:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Maak geen sleutelpaar aan van '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Succesvol afgerond in {0:N0} seconden." }
          , { TranslationKeys.db_dbr079_msg_par1, "Maak een RSA-sleutelwaarde op basis van '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Succesvol afgerond in {0:N0} seconden." }
          , { TranslationKeys.db_dbr108_msg_par1, "Verwerk assembly '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Maak sleutelpaar van {0} met wachtwoord." }
          , { TranslationKeys.db_dbr110_msg, "Geen sleutelbestand en geen sleutelcontainer geconfigureerd. Gebruik geen sleutelpaar." }
          , { TranslationKeys.db_dbr111_msg, "Geen sleutelbestand en geen sleutelcontainer geconfigureerd. Gebruik geen RSA-sleutelwaarde." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Maak geen RSA-sleutelwaarde van '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Begin met ondertekenen van '{0}' met ondertekentool '{1}' en argumenten '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Laden van assemblies." }
          , { TranslationKeys.db_dbr117_msg_par1, "Assembly '{0}' niet opgeslagen met projectsleutelpaar als '{1}' vanwege {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "'{0}' ondertekend als '{1}' met container '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "'{0}' bewaard as-is als '{1}; was oorspronkelijk niet ondertekend met een sterke naam." }
          , { TranslationKeys.db_dbr120_msg_par1, "Sla '{0}' op met projectsleutelpaar als '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Er zijn {0:N0} assemblies om op te slaan in het project." }
          , { TranslationKeys.db_dbr123_msg_par1, "'{0}' ondertekend." }
          , { TranslationKeys.db_dbr124_msg_par1, "Assembly '{0}' heeft geen publieke sleutel; opslaan zoals het is." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-kanaal: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Voltooid met een foutmelding in {0:N0} seconden." }
          , { TranslationKeys.db_dbr131_par1, "Voltooid met een foutmelding in {0:N0} seconden." }
          , { TranslationKeys.db_dbr132_par1, "Voltooid met een foutmelding in {0:N0} seconden." }
          , { TranslationKeys.db_dbr133_par1, "Voltooid met een foutmelding in {0:N0} seconden." }
          , { TranslationKeys.db_dbr135_msg, "De status werd verwacht als 'Renamed' of 'Skipped'." }
          , { TranslationKeys.db_dbr139_msg_par1, "De status werd verwacht als hetzij 'Renamed' of 'Skipped' in plaats van {0} van '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Bestandsnaam ontbreekt." }
          , { TranslationKeys.db_dbr143_msg, "De externe vlag van de groep had verwerkt moeten worden toen de groep werd aangemaakt en alle methoden in de groep hadden al als overgeslagen moeten zijn gemarkeerd." }
          , { TranslationKeys.db_dbr144_msg, "De methode moet een naam hebben als de methode niet wordt overgeslagen en de groep een naam heeft." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' was NIET ondertekend vanwege foutcode {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status moet 'Renamed' of 'Skipped' zijn in plaats van '{0}'." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-kanaal: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Geen extra framework-mappen:" }
          , { TranslationKeys.db_dbr155_msg, "Kan typenaam niet extraheren." }
          , { TranslationKeys.db_dbr156_msg_par1, "Laad de XML-projectdefinitie uit '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Verwerkte {0} variabelen." }
          , { TranslationKeys.db_dbr158_msg_par1, "Verwerkte {0} include-tags." }
          , { TranslationKeys.db_dbr159_msg_par1, "Verwerkte {0} assembly-zoekpaden." }
          , { TranslationKeys.db_dbr160_msg_par1, "Verwerkte {0} modules." }
          , { TranslationKeys.db_dbr161_msg_par1, "Verwerkte {0} modulegroepen." }
          , { TranslationKeys.db_dbr162_msg, "Initialiseer instellingen van variabelen." }
          , { TranslationKeys.db_dbr166_msg_par1, "Het certificaatbestand '{0}' moet ten minste één certificaat bevatten." }
          , { TranslationKeys.db_dbr167_msg_par1, "Het certificaatbestand '{0}' heeft een ongeldig formaat." }
          , { TranslationKeys.db_dbr169_msg, "Bepaal tekens voor het genereren van namen." }
          , { TranslationKeys.db_dbr173_msg_par1, "Installatie van {0} gevonden op '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Geen installatie gevonden van {0} op '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Er kan maximaal één certificaat geselecteerd op basis van sleutelbestandsnaam en SHA1-vingerafdruk worden gebruikt." }
          , { TranslationKeys.db_dbr176_msg, "Certificaatselectie op basis van de naam van het sleutelbestand of de SHA1-vingerafdruk moet worden gebruikt." }
          , { TranslationKeys.db_dbr177_msg, "Het wachtwoord van het sleutelbestand kan alleen worden opgegeven als het certificaat is geselecteerd op de naam van het sleutelbestand." }
          , { TranslationKeys.db_definition_missing, "Definitie ontbreekt." }
          , { TranslationKeys.db_display_version, "Geef versienummer van deze applicatie weer." }
          , { TranslationKeys.db_duplicate_character, "Dubbel karakter." }
          , { TranslationKeys.db_error_processing_colon, "Er is een fout opgetreden tijdens de verwerking:" }
          , { TranslationKeys.db_filename_missing, "Bestandsnaam ontbreekt." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur is een fork van Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Volledige naam ontbreekt." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) op {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Druk deze helpinformatie af." }
          , { TranslationKeys.db_hide_strings, "Verberg teksten." }
          , { TranslationKeys.db_hint_colon_par1, "Tip: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Tip: het kan nodig zijn om een SkipType toe te voegen voor een enum hierboven." }
          , { TranslationKeys.db_inner_exception_par1, "Binnengelegen uitzondering: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Project '{0}' wordt geladen." }
          , { TranslationKeys.db_missing_group, "Groep ontbreekt." }
          , { TranslationKeys.db_missing_parent_reader, "Ontbrekende bovenliggende lezer." }
          , { TranslationKeys.db_missing_parts, "Onderdelen ontbreken." }
          , { TranslationKeys.db_missing_path_value, "Waarde voor pad ontbreekt." }
          , { TranslationKeys.db_missing_read_action, "Ontbrekende leesactie." }
          , { TranslationKeys.db_missing_setting_name, "Ontbrekende instellingsnaam." }
          , { TranslationKeys.db_not_hide_strings, "Teksten niet verbergen." }
          , { TranslationKeys.db_not_rename_events, "Wijzig naam van gebeurtenissen niet." }
          , { TranslationKeys.db_not_rename_fields, "Wijzig naam van velden niet." }
          , { TranslationKeys.db_not_rename_properties, "Wijzig naam van eigenschappen niet." }
          , { TranslationKeys.db_options_colon, "Opties:" }
          , { TranslationKeys.db_pool_clean, "Kan pool niet legen." }
          , { TranslationKeys.db_pool_still, "Nog in pool:" }
          , { TranslationKeys.db_rename_events, "Wijzig naam van gebeurtenissen." }
          , { TranslationKeys.db_rename_fields, "Wijzig naam van velden." }
          , { TranslationKeys.db_rename_methods, "Wijzig naam van methodes." }
          , { TranslationKeys.db_rename_parameters, "Wijzig naam van parameters." }
          , { TranslationKeys.db_rename_properties, "Wijzig naam van eigenschappen." }
          , { TranslationKeys.db_settings_not_initialized, "Instellingen nog niet geïnitialiseerd." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Opties] [projectbestand] [projectbestand]" }
          }
        }
        , { Languages.pl, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Sprawdź ustawienia projektu." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console jest rozwidleniem Obfuscar (https://www.obfuscar.com)." }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Options] [project_file] [project_file]" }
          , { TranslationKeys.db_con_title_par2, "*** Konsola DotBlur ({0}) w dniu {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams i inni współpracownicy." }
          , { TranslationKeys.db_dbr002_msg_par1, "Zmienne \"{0}\" i \"{1}\" nie mogą być ustawione razem." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Popraw zawartość pliku '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "Plik konfiguracyjny XML powinien mieć tag główny <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "Nie można utworzyć ścieżki '{0}' określonej przez OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Ścieżka '{0}' określona przez zmienną InPath musi istnieć," }
          , { TranslationKeys.db_dbr007_msg_par1, "Błąd ładowania pliku klucza '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Kluczowe kontenery nie są obsługiwane przez Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Nie można rozwiązać zależności \"{0}\"." }
          , { TranslationKeys.db_dbr010_msg, "Użyj słowa \"publiczny\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" nie jest prawidłowa dla wartości \"typeattrib\" elementów pomijanych." }
          , { TranslationKeys.db_dbr011_msg, "Użyj słowa \"publiczny\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" nie jest prawidłowa dla wartości \"attrib\" elementu SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "Nie można zastąpić zmiennej \"{0}\"." }
          , { TranslationKeys.db_dbr013_msg, "Użyj \"publiczne\" lub \"chronione\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" nie jest prawidłowa dla wartości \"attrib\" elementów pomijanych." }
          , { TranslationKeys.db_dbr014_msg_par1, "Nie można odczytać określonego pliku projektu \"{0}\"." }
          , { TranslationKeys.db_dbr015_msg, "Użyj właściwości KeyFile lub KeyContainer, aby ustawić klucz do użycia." }
          , { TranslationKeys.db_dbr015_msg_par1, "Zaciemnienie podpisanego zespołu \"{0}\" spowodowałoby utworzenie nieprawidłowego zespołu." }
          , { TranslationKeys.db_dbr017_msg_par1, "Nie można podpisać złożenia przy użyciu klucza z kontenera kluczy \"{0}\"." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} nie jest prawidłowym plikiem XML." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Nie można znaleźć zespołu '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Nie udało się uzyskać definicji typu dla {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Utwórz parę kluczy z \"{0}\" bez hasła." }
          , { TranslationKeys.db_dbr027_msg, "Nazwa musi mieć wartość." }
          , { TranslationKeys.db_dbr028_msg, "Nazwa i wyrażenie regularne nazwy muszą być ustawione." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly musi zostać wywołany przed użyciem." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init musi zostać wywołany przed użyciem." }
          , { TranslationKeys.db_dbr034_msg, "Potrzebny prawidłowy atrybut pliku." }
          , { TranslationKeys.db_dbr035_msg_par1, "Nazwy typów \"{0}\" i \"{1}\" muszą być równe." }
          , { TranslationKeys.db_dbr036_msg, "Nazwa i wyrażenie regularne nazwy nie są ustawione." }
          , { TranslationKeys.db_dbr038_msg, "Nie ustawiono definicji typu kodowania." }
          , { TranslationKeys.db_dbr039_msg, "Nie ustawiono najnowszych danych." }
          , { TranslationKeys.db_dbr040_msg, "Nie można podpisać złożenia, ponieważ nie można zlokalizować pliku signtool.exe." }
          , { TranslationKeys.db_dbr041_msg_par1, "Nie można podpisać złożenia, ponieważ nie można znaleźć pliku signtool.exe w określonej lokalizacji \"{0}\"." }
          , { TranslationKeys.db_dbr042_msg, "Nie można uruchomić procesu podpisywania przy użyciu pliku signtool.exe. Brak procesu." }
          , { TranslationKeys.db_dbr043_msg_par1, "Podpisywanie nie zakończyło się w wyznaczonym czasie {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Nie można podpisać złożenia, ponieważ nazwa pliku klucza nie została ustawiona." }
          , { TranslationKeys.db_dbr045_msg_par1, "Nie można podpisać złożenia, ponieważ nazwa pliku klucza \"{0}\" nie jest plikiem certyfikatu PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Zmiana nazwy typów w {0:N0} zespołach." }
          , { TranslationKeys.db_dbr055_msg_par1, "Przetwarzanie końcowe złożeń {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Zapisz zespoły do '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Zapisz mapowanie do pliku '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Dodatkowe foldery ramowe:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Nie udało się zapisać '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} może być jednym z nich:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Nie utworzono pary kluczy z \"{0}\"." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Zakończono pomyślnie w ciągu {0:N0} sekund." }
          , { TranslationKeys.db_dbr079_msg_par1, "Utwórz wartość klucza RSA z \"{0}\"." }
          , { TranslationKeys.db_dbr082_par1, "Zakończono pomyślnie w ciągu {0:N0} sekund." }
          , { TranslationKeys.db_dbr108_msg_par1, "Przetwarzanie zespołu \"{0}\"." }
          , { TranslationKeys.db_dbr109_msg_par1, "Utwórz parę kluczy z {0} z hasłem." }
          , { TranslationKeys.db_dbr110_msg, "Nie skonfigurowano pliku kluczy ani kontenera kluczy. Nie użyto pary kluczy." }
          , { TranslationKeys.db_dbr111_msg, "Nie skonfigurowano pliku klucza ani kontenera klucza. Nie użyto wartości klucza RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Nie utworzono wartości klucza RSA z \"{0}\"." }
          , { TranslationKeys.db_dbr113_msg_par1, "Rozpocznij podpisywanie \"{0}\" za pomocą narzędzia do podpisywania \"{1}\" z argumentami \"{2}\"." }
          , { TranslationKeys.db_dbr116_msg, "Ładowanie zespołów." }
          , { TranslationKeys.db_dbr117_msg_par1, "Zespół '{0}' nie został zapisany przy użyciu pary kluczy projektu do '{1}' z powodu {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Podpisano \"{0}\" jako \"{1}\" przy użyciu kontenera \"{2}\"." }
          , { TranslationKeys.db_dbr119_msg_par1, "Zapisano \"{0}\" w niezmienionej postaci w \"{1}\"; pierwotnie nie była podpisana silną nazwą." }
          , { TranslationKeys.db_dbr120_msg_par1, "Zapisz \"{0}\" przy użyciu pary kluczy projektu do \"{1}\"." }
          , { TranslationKeys.db_dbr122_msg_par1, "W projekcie znajdują się {0:N0} zespołów do zapisania." }
          , { TranslationKeys.db_dbr123_msg_par1, "Podpisano \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "Zespół \"{0}\" nie ma klucza publicznego; zapisz bez zmian." }
          , { TranslationKeys.db_dbr125_msg_par1, "Kanał Stderr: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Ukończono z błędem za {0:N0} sekund." }
          , { TranslationKeys.db_dbr131_par1, "Ukończono z błędem za {0:N0} sekund." }
          , { TranslationKeys.db_dbr132_par1, "Ukończono z błędem za {0:N0} sekund." }
          , { TranslationKeys.db_dbr133_par1, "Ukończono z błędem za {0:N0} sekund." }
          , { TranslationKeys.db_dbr135_msg, "Oczekiwany status to \"Zmieniono nazwę\" lub \"Pominięto\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Oczekuje się, że status będzie wynosił \"Zmieniono nazwę\" lub \"Pominięto\" zamiast {0} lub \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Brakująca nazwa pliku." }
          , { TranslationKeys.db_dbr143_msg, "Flaga zewnętrzna grupy powinna być obsługiwana podczas tworzenia grupy, a wszystkie metody w grupie powinny być już oznaczone jako pominięte." }
          , { TranslationKeys.db_dbr144_msg, "Metoda musi mieć nazwę, gdy metoda nie jest pomijana, a grupa ma nazwę." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}\" NIE zostało podpisane z powodu kodu błędu {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status musi mieć wartość \"Zmieniono nazwę\" lub \"Pominięto\" zamiast \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Kanał stdout: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Brak dodatkowych folderów frameworka:" }
          , { TranslationKeys.db_dbr155_msg, "Nie można wyodrębnić nazwy typu." }
          , { TranslationKeys.db_dbr156_msg_par1, "Załaduj definicję projektu XML z '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Przetworzono {0} zmiennych." }
          , { TranslationKeys.db_dbr158_msg_par1, "Przetworzone {0} zawierają tagi." }
          , { TranslationKeys.db_dbr159_msg_par1, "Przetworzono {0} ścieżek wyszukiwania zespołów." }
          , { TranslationKeys.db_dbr160_msg_par1, "Przetworzono {0} modułów." }
          , { TranslationKeys.db_dbr161_msg_par1, "Przetworzono {0} grup modułów." }
          , { TranslationKeys.db_dbr162_msg, "Inicjalizacja ustawień ze zmiennych." }
          , { TranslationKeys.db_dbr166_msg_par1, "Plik certyfikatu \"{0}\" musi zawierać co najmniej jeden certyfikat." }
          , { TranslationKeys.db_dbr167_msg_par1, "Plik certyfikatu \"{0}\" ma nieprawidłowy format." }
          , { TranslationKeys.db_dbr169_msg, "Określ znaki do generowania nazw." }
          , { TranslationKeys.db_dbr173_msg_par1, "Znaleziono instalację {0} w '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Nie znaleziono instalacji {0} w '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Można użyć co najwyżej jednego z certyfikatów wybranych według nazwy pliku klucza i odcisku kciuka SHA1." }
          , { TranslationKeys.db_dbr176_msg, "Należy użyć wyboru certyfikatu według nazwy pliku klucza lub odcisku kciuka SHA1." }
          , { TranslationKeys.db_dbr177_msg, "Hasło pliku klucza można podać tylko wtedy, gdy certyfikat jest wybrany według nazwy pliku klucza." }
          , { TranslationKeys.db_definition_missing, "Brak definicji." }
          , { TranslationKeys.db_display_version, "Wyświetla numer wersji tej aplikacji." }
          , { TranslationKeys.db_duplicate_character, "Zduplikowany znak." }
          , { TranslationKeys.db_error_processing_colon, "Podczas przetwarzania wystąpił błąd:" }
          , { TranslationKeys.db_filename_missing, "Brakująca nazwa pliku." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur jest rozwidleniem Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Brakuje pełnego imienia i nazwiska." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) na {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Wydrukuj te informacje pomocy." }
          , { TranslationKeys.db_hide_strings, "Ukryj ciągi znaków." }
          , { TranslationKeys.db_hint_colon_par1, "Wskazówka: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Wskazówka: może być konieczne dodanie SkipType dla enum powyżej." }
          , { TranslationKeys.db_inner_exception_par1, "Wyjątek wewnętrzny: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Ładowanie projektu '{0}'." }
          , { TranslationKeys.db_missing_group, "Brakująca grupa." }
          , { TranslationKeys.db_missing_parent_reader, "Brakujący czytelnik-rodzic." }
          , { TranslationKeys.db_missing_parts, "Brakujące części." }
          , { TranslationKeys.db_missing_path_value, "Brakująca wartość dla ścieżki." }
          , { TranslationKeys.db_missing_read_action, "Brak akcji odczytu." }
          , { TranslationKeys.db_missing_setting_name, "Brakująca nazwa ustawienia." }
          , { TranslationKeys.db_not_hide_strings, "Nie ukrywa strun." }
          , { TranslationKeys.db_not_rename_events, "Nie należy zmieniać nazw zdarzeń." }
          , { TranslationKeys.db_not_rename_fields, "Nie należy zmieniać nazw pól." }
          , { TranslationKeys.db_not_rename_properties, "Nie należy zmieniać nazw właściwości." }
          , { TranslationKeys.db_options_colon, "Opcje:" }
          , { TranslationKeys.db_pool_clean, "Nie można wyczyścić basenu." }
          , { TranslationKeys.db_pool_still, "Wciąż w basenie:" }
          , { TranslationKeys.db_rename_events, "Zmiana nazwy zdarzeń." }
          , { TranslationKeys.db_rename_fields, "Zmiana nazwy pól." }
          , { TranslationKeys.db_rename_methods, "Zmiana nazwy metod." }
          , { TranslationKeys.db_rename_parameters, "Zmiana nazwy parametrów." }
          , { TranslationKeys.db_rename_properties, "Zmiana nazwy właściwości." }
          , { TranslationKeys.db_settings_not_initialized, "Ustawienia nie zostały jeszcze zainicjowane." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Options] [project_file] [project_file]" }
          }
        }
        , { Languages.pt, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Pilha de chamadas" }
          , { TranslationKeys.db_check_project_settings, "Verificar as definições do projeto." }
          , { TranslationKeys.db_con_fork_obfuscar, "A Consola DotBlur é uma bifurcação do Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Opções] [ficheiro_projecto] [ficheiro_projecto]" }
          , { TranslationKeys.db_con_title_par2, "*** Consola DotBlur ({0}) em {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams e outros colaboradores." }
          , { TranslationKeys.db_dbr002_msg_par1, "As variáveis '{0}' e '{1}' não podem ser definidas em conjunto." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Por favor, corrija o conteúdo do ficheiro '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "O ficheiro de configuração XML deve ter uma etiqueta de raiz <{0}>." }
          , { TranslationKeys.db_dbr005_msg_par1, "Não foi possível criar o caminho '{0}' especificado por OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "O caminho '{0}' especificado pela variável InPath tem de existir," }
          , { TranslationKeys.db_dbr007_msg_par1, "Falha ao carregar o ficheiro de chaves '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Os contentores de chaves não são suportados pelo Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Não foi possível resolver a dependência '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Utilizar \"público\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" não é válido para o valor \"typeattrib\" de elementos de salto." }
          , { TranslationKeys.db_dbr011_msg, "Utilizar \"público\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" não é válido para o valor \"attrib\" do elemento SkipType." }
          , { TranslationKeys.db_dbr012_msg_par1, "Não é possível substituir a variável '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Utilizar \"público\" ou \"protegido\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" não é válido para o valor \"attrib\" de elementos de salto." }
          , { TranslationKeys.db_dbr014_msg_par1, "Não foi possível ler o ficheiro de projeto especificado '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Utilize a propriedade KeyFile ou KeyContainer para definir uma chave a utilizar." }
          , { TranslationKeys.db_dbr015_msg_par1, "A ofuscação do conjunto assinado '{0}' resultaria num conjunto inválido." }
          , { TranslationKeys.db_dbr017_msg_par1, "Não é possível assinar o conjunto utilizando a chave do contentor de chaves '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} não é um ficheiro XML válido." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Não foi possível encontrar o conjunto '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Falha ao obter definições de tipo para {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Criar par de chaves de '{0}' sem palavra-passe." }
          , { TranslationKeys.db_dbr027_msg, "O nome deve ter um valor." }
          , { TranslationKeys.db_dbr028_msg, "O nome e a expressão regular do nome devem ter sido definidos." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly deve ser chamado antes de ser utilizado." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init deve ser chamado antes de ser utilizado." }
          , { TranslationKeys.db_dbr034_msg, "Necessita de um atributo de ficheiro válido." }
          , { TranslationKeys.db_dbr035_msg_par1, "Os nomes de tipo '{0}' e '{1}' têm de ser iguais." }
          , { TranslationKeys.db_dbr036_msg, "O nome e a expressão regular do nome não estão definidos." }
          , { TranslationKeys.db_dbr038_msg, "Definição do tipo de codificação não definida." }
          , { TranslationKeys.db_dbr039_msg, "Os dados mais recentes não estão definidos." }
          , { TranslationKeys.db_dbr040_msg, "Não foi possível assinar a montagem porque o signtool.exe não pôde ser localizado." }
          , { TranslationKeys.db_dbr041_msg_par1, "Não foi possível assinar a montagem porque o signtool.exe não pôde ser encontrado na localização especificada '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Não foi possível iniciar o processo de assinatura utilizando desde signtool.exe. Nenhum processo." }
          , { TranslationKeys.db_dbr043_msg_par1, "A montagem da assinatura não terminou no tempo previsto de {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Não foi possível assinar a montagem porque o nome do ficheiro chave não está definido." }
          , { TranslationKeys.db_dbr045_msg_par1, "Não foi possível assinar a montagem porque o nome do ficheiro chave '{0}' não é um ficheiro de certificado PFX." }
          , { TranslationKeys.db_dbr054_msg_par1, "Renomear tipos em assembleias {0:N0}." }
          , { TranslationKeys.db_dbr055_msg_par1, "Processamento posterior de conjuntos {0:N0}." }
          , { TranslationKeys.db_dbr056_msg_par1, "Guardar os conjuntos em '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Guardar o mapeamento no ficheiro '{0}'." }
          , { TranslationKeys.db_dbr059_msg, "Pastas extra da estrutura:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Falha ao guardar '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} pode ser um de:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Não criar nenhum par de chaves de '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Concluído com êxito em {0:N0} segundos." }
          , { TranslationKeys.db_dbr079_msg_par1, "Criar valor de chave RSA a partir de '{0}'." }
          , { TranslationKeys.db_dbr082_par1, "Concluído com êxito em {0:N0} segundos." }
          , { TranslationKeys.db_dbr108_msg_par1, "Processar o conjunto \"{0}\"." }
          , { TranslationKeys.db_dbr109_msg_par1, "Criar um par de chaves de {0} com a palavra-passe." }
          , { TranslationKeys.db_dbr110_msg, "Nenhum ficheiro de chaves e nenhum contentor de chaves configurado. Não utilizar nenhum par de chaves." }
          , { TranslationKeys.db_dbr111_msg, "Nenhum ficheiro de chaves e nenhum contentor de chaves configurado. Não utilizar nenhum valor de chave RSA." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Não criar nenhum valor de chave RSA a partir de '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Iniciar a assinatura de '{0}' utilizando a ferramenta de assinatura '{1}' com argumentos '{2}'." }
          , { TranslationKeys.db_dbr116_msg, "Carregamento de conjuntos." }
          , { TranslationKeys.db_dbr117_msg_par1, "O conjunto '{0}' não foi guardado utilizando o par de chaves do projeto para '{1}' devido a {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Assinado \"{0}\" como \"{1}\" utilizando o contentor \"{2}\"." }
          , { TranslationKeys.db_dbr119_msg_par1, "Guardado '{0}' tal como está em '{1}'; originalmente não tinha um nome forte assinado." }
          , { TranslationKeys.db_dbr120_msg_par1, "Guardar '{0}' utilizando o par de chaves do projeto para '{1}'." }
          , { TranslationKeys.db_dbr122_msg_par1, "Existem {0:N0} assemblies no projeto a guardar." }
          , { TranslationKeys.db_dbr123_msg_par1, "Assinado \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "O conjunto '{0}' não tem chave pública; guardar tal como está." }
          , { TranslationKeys.db_dbr125_msg_par1, "Canal Stderr: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Concluído com erro em {0:N0} segundos." }
          , { TranslationKeys.db_dbr131_par1, "Concluído com erro em {0:N0} segundos." }
          , { TranslationKeys.db_dbr132_par1, "Concluído com erro em {0:N0} segundos." }
          , { TranslationKeys.db_dbr133_par1, "Concluído com erro em {0:N0} segundos." }
          , { TranslationKeys.db_dbr135_msg, "Espera-se que o estado seja \"Renomeado\" ou \"Ignorado\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Espera-se que o estado seja \"Renomeado\" ou \"Ignorado\" em vez de {0} ou \"{1}\"." }
          , { TranslationKeys.db_dbr141_msg, "Nome de ficheiro em falta." }
          , { TranslationKeys.db_dbr143_msg, "O sinalizador externo do grupo deveria ter sido tratado quando o grupo foi criado e todos os métodos do grupo já deveriam estar marcados como ignorados." }
          , { TranslationKeys.db_dbr144_msg, "O método deve ter um nome quando o método não é ignorado e o grupo tem um nome." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' NÃO foi assinado devido ao código de erro {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "O estado deve ser \"Renomeado\" ou \"Ignorado\" em vez de \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Canal Stdout: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Sem pastas de estrutura adicionais:" }
          , { TranslationKeys.db_dbr155_msg, "Não é possível extrair o nome do tipo." }
          , { TranslationKeys.db_dbr156_msg_par1, "Carregar a definição de projeto XML de \"{0}\"." }
          , { TranslationKeys.db_dbr157_msg_par1, "Processou {0} variáveis." }
          , { TranslationKeys.db_dbr158_msg_par1, "Tags de inclusão {0} processadas." }
          , { TranslationKeys.db_dbr159_msg_par1, "Processou {0} caminhos de pesquisa de montagem." }
          , { TranslationKeys.db_dbr160_msg_par1, "Processou {0} módulos." }
          , { TranslationKeys.db_dbr161_msg_par1, "Processou {0} grupos de módulos." }
          , { TranslationKeys.db_dbr162_msg, "Inicializar definições a partir de variáveis." }
          , { TranslationKeys.db_dbr166_msg_par1, "O ficheiro de certificado \"{0}\" deve conter pelo menos um certificado." }
          , { TranslationKeys.db_dbr167_msg_par1, "O ficheiro de certificado '{0}' tem um formato inválido." }
          , { TranslationKeys.db_dbr169_msg, "Determinar caracteres para a geração de nomes." }
          , { TranslationKeys.db_dbr173_msg_par1, "Encontrada a instalação de {0} em '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Não foi encontrada nenhuma instalação de {0} em '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Pode ser utilizada, no máximo, uma das selecções de certificado por nome de ficheiro de chave e impressão digital SHA1." }
          , { TranslationKeys.db_dbr176_msg, "Deve ser utilizada a seleção de certificado por nome de ficheiro de chave ou a impressão digital SHA1." }
          , { TranslationKeys.db_dbr177_msg, "A palavra-passe do ficheiro chave só pode ser fornecida quando o certificado é selecionado pelo nome do ficheiro chave." }
          , { TranslationKeys.db_definition_missing, "Falta uma definição." }
          , { TranslationKeys.db_display_version, "Mostra o número da versão desta aplicação." }
          , { TranslationKeys.db_duplicate_character, "Carácter duplicado." }
          , { TranslationKeys.db_error_processing_colon, "Ocorreu um erro durante o processamento:" }
          , { TranslationKeys.db_filename_missing, "Nome de ficheiro em falta." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur é uma bifurcação do Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Falta o nome completo." }
          , { TranslationKeys.db_gt_title_par2, "*** Ferramenta DotBlur Global ({0}) em {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Imprimir esta informação de ajuda." }
          , { TranslationKeys.db_hide_strings, "Ocultar cadeias de caracteres." }
          , { TranslationKeys.db_hint_colon_par1, "Sugestão: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Dica: pode ser necessário adicionar um SkipType para um enum acima." }
          , { TranslationKeys.db_inner_exception_par1, "Exceção interna: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "A carregar o projeto '{0}'." }
          , { TranslationKeys.db_missing_group, "Grupo em falta." }
          , { TranslationKeys.db_missing_parent_reader, "Falta o leitor pai." }
          , { TranslationKeys.db_missing_parts, "Peças em falta." }
          , { TranslationKeys.db_missing_path_value, "Valor em falta para o caminho." }
          , { TranslationKeys.db_missing_read_action, "Ação de leitura em falta." }
          , { TranslationKeys.db_missing_setting_name, "Nome da definição em falta." }
          , { TranslationKeys.db_not_hide_strings, "Não escondendo os fios." }
          , { TranslationKeys.db_not_rename_events, "Não renomear eventos." }
          , { TranslationKeys.db_not_rename_fields, "Não mudar o nome dos campos." }
          , { TranslationKeys.db_not_rename_properties, "Não renomear propriedades." }
          , { TranslationKeys.db_options_colon, "Opções:" }
          , { TranslationKeys.db_pool_clean, "Não é possível limpar a piscina." }
          , { TranslationKeys.db_pool_still, "Ainda na piscina:" }
          , { TranslationKeys.db_rename_events, "Mudar o nome dos eventos." }
          , { TranslationKeys.db_rename_fields, "Mudar o nome dos campos." }
          , { TranslationKeys.db_rename_methods, "Renomear métodos." }
          , { TranslationKeys.db_rename_parameters, "Mudar o nome dos parâmetros." }
          , { TranslationKeys.db_rename_properties, "Mudar o nome das propriedades." }
          , { TranslationKeys.db_settings_not_initialized, "As definições ainda não foram inicializadas." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Opções] [ficheiro_projecto] [ficheiro_projecto]" }
          }
        }
        , { Languages.sv, new Dictionary<string, string>()
          { { "placeholder", "placeholder" }
          , { TranslationKeys.db_callstack, "Callstack" }
          , { TranslationKeys.db_check_project_settings, "Kontrollera projektinställningarna." }
          , { TranslationKeys.db_con_fork_obfuscar, "DotBlur Console är en förgrening av Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_con_syntax, "DotBlur.Console.exe [Alternativ] [projekt_fil] [projekt_fil]" }
          , { TranslationKeys.db_con_title_par2, "*** DotBlur Console ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_copyright_par1, "(C) 2007-{0}, Ryan Williams och andra bidragsgivare." }
          , { TranslationKeys.db_dbr002_msg_par1, "Variablerna '{0}' och '{1}' kan inte ställas in tillsammans." }
          , { TranslationKeys.db_dbr004_2_msg_par1, "Vänligen korrigera innehållet i filen '{0}'." }
          , { TranslationKeys.db_dbr004_msg_par1, "XML-konfigurationsfilen bör ha en <{0}> root-tagg." }
          , { TranslationKeys.db_dbr005_msg_par1, "Det gick inte att skapa sökvägen '{0}' som anges av OutPath." }
          , { TranslationKeys.db_dbr006_msg_par1, "Sökvägen '{0}' som anges av variabeln InPath måste finnas," }
          , { TranslationKeys.db_dbr007_msg_par1, "Fel vid laddning av nyckelfilen '{0}'." }
          , { TranslationKeys.db_dbr008_msg, "Nyckelbehållare stöds inte för Mono." }
          , { TranslationKeys.db_dbr009_msg_par1, "Det går inte att lösa beroendet '{0}'." }
          , { TranslationKeys.db_dbr010_msg, "Använd \"offentlig\"." }
          , { TranslationKeys.db_dbr010_msg_par1, "{0}\" är inte giltigt för \"typeattrib\"-värdet för skip-element." }
          , { TranslationKeys.db_dbr011_msg, "Använd \"offentlig\"." }
          , { TranslationKeys.db_dbr011_msg_par1, "{0}\" är inte giltigt för \"attrib\"-värdet i SkipType-elementet." }
          , { TranslationKeys.db_dbr012_msg_par1, "Det går inte att ersätta variabeln '{0}'." }
          , { TranslationKeys.db_dbr013_msg, "Använd \"offentlig\" eller \"skyddad\"." }
          , { TranslationKeys.db_dbr013_msg_par1, "{0}\" är inte giltigt för \"attrib\"-värdet för skip-element." }
          , { TranslationKeys.db_dbr014_msg_par1, "Det gick inte att läsa den angivna projektfilen '{0}'." }
          , { TranslationKeys.db_dbr015_msg, "Använd egenskapen KeyFile eller KeyContainer för att ange en nyckel som ska användas." }
          , { TranslationKeys.db_dbr015_msg_par1, "Att fördunkla den signerade enheten '{0}' skulle resultera i en ogiltig enhet." }
          , { TranslationKeys.db_dbr017_msg_par1, "Det gick inte att signera enheten med nyckel från nyckelbehållare '{0}'." }
          , { TranslationKeys.db_dbr018_msg_par1, "{0} är inte en giltig XML-fil." }
          , { TranslationKeys.db_dbr020_2_msg_par1, "Det går inte att hitta enheten '{0}'." }
          , { TranslationKeys.db_dbr020_msg_par1, "Misslyckades med att hämta typdefinitioner för {0}." }
          , { TranslationKeys.db_dbr024_msg_par1, "Skapa nyckelpar från '{0}' utan lösenord." }
          , { TranslationKeys.db_dbr027_msg, "Namnet måste ha ett värde." }
          , { TranslationKeys.db_dbr028_msg, "Namn och reguljärt uttryck för namn måste ha angetts." }
          , { TranslationKeys.db_dbr029_msg, "AssemblyInfo.LoadAssembly måste anropas före användning." }
          , { TranslationKeys.db_dbr031_msg, "AssemblyInfo.Init måste anropas före användning." }
          , { TranslationKeys.db_dbr034_msg, "Behöver giltigt filattribut." }
          , { TranslationKeys.db_dbr035_msg_par1, "Typnamnen '{0}' och '{1}' måste vara lika." }
          , { TranslationKeys.db_dbr036_msg, "Namn och reguljärt uttryck för namn är inte inställda." }
          , { TranslationKeys.db_dbr038_msg, "Kodningstypdefinitionen är inte fastställd." }
          , { TranslationKeys.db_dbr039_msg, "De senaste uppgifterna har inte angetts." }
          , { TranslationKeys.db_dbr040_msg, "Det gick inte att signera enheten eftersom signtool.exe inte kunde hittas." }
          , { TranslationKeys.db_dbr041_msg_par1, "Det gick inte att signera enheten eftersom signtool.exe inte kunde hittas på den angivna platsen '{0}'." }
          , { TranslationKeys.db_dbr042_msg, "Kunde inte starta signprocessen med hjälp av signtool.exe. Ingen process." }
          , { TranslationKeys.db_dbr043_msg_par1, "Signeringsenheten avslutades inte inom den tilldelade tiden på {0:N0} ms." }
          , { TranslationKeys.db_dbr044_msg, "Det gick inte att signera enheten eftersom filnamnet för nyckeln inte är angivet." }
          , { TranslationKeys.db_dbr045_msg_par1, "Det gick inte att signera enheten eftersom nyckelfilsnamnet '{0}' inte är en PFX-certifikatfil." }
          , { TranslationKeys.db_dbr054_msg_par1, "Byt namn på typer i {0:N0}-assemblies." }
          , { TranslationKeys.db_dbr055_msg_par1, "Efterbehandling av {0:N0}-sammansättningar." }
          , { TranslationKeys.db_dbr056_msg_par1, "Spara sammanställningar till '{0}'." }
          , { TranslationKeys.db_dbr057_msg_par1, "Spara mappningen i filen \"{0}\"." }
          , { TranslationKeys.db_dbr059_msg, "Extra ramverksmappar:" }
          , { TranslationKeys.db_dbr061_msg_par1, "Misslyckades med att spara '{0}'." }
          , { TranslationKeys.db_dbr063_msg_par1, "{0} kan vara en av:" }
          , { TranslationKeys.db_dbr069_msg_par1, "Skapa inget nyckelpar från '{0}'." }
          , { TranslationKeys.db_dbr070_msg_par1, "The strong signing keypair is taken from '{0}'." }
          , { TranslationKeys.db_dbr071_par1, "Avslutades framgångsrikt inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr079_msg_par1, "Skapa RSA-nyckelvärde från \"{0}\"." }
          , { TranslationKeys.db_dbr082_par1, "Avslutades framgångsrikt inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr108_msg_par1, "Bearbeta montering '{0}'." }
          , { TranslationKeys.db_dbr109_msg_par1, "Skapa nyckelpar från {0} med lösenord." }
          , { TranslationKeys.db_dbr110_msg, "Ingen nyckelfil och ingen nyckelbehållare konfigurerad. Använd inget nyckelpar." }
          , { TranslationKeys.db_dbr111_msg, "Ingen nyckelfil och ingen nyckelbehållare konfigurerad. Använd inget RSA-nyckelvärde." }
          , { TranslationKeys.db_dbr112_msg, "There is no strong naming key container name to generate a RSA-keypair from." }
          , { TranslationKeys.db_dbr112_msg_par1, "Skapa inget RSA-nyckelvärde från '{0}'." }
          , { TranslationKeys.db_dbr113_msg_par1, "Börja signera \"{0}\" med hjälp av signeringsverktyget \"{1}\" med argumenten \"{2}\"." }
          , { TranslationKeys.db_dbr116_msg, "Lastning av enheter." }
          , { TranslationKeys.db_dbr117_msg_par1, "Montering '{0}' sparades inte med projektnyckelpar till '{1}' på grund av {2}." }
          , { TranslationKeys.db_dbr118_msg_par1, "Signerade '{0}' som '{1}' med hjälp av behållare '{2}'." }
          , { TranslationKeys.db_dbr119_msg_par1, "Sparade \"{0}\" som den är i \"{1}\"; var ursprungligen inte starkt namnunderskriven." }
          , { TranslationKeys.db_dbr120_msg_par1, "Spara \"{0}\" med hjälp av projektets nyckelpar till \"{1}\"." }
          , { TranslationKeys.db_dbr122_msg_par1, "Det finns {0:N0} sammansättningar i projektet som ska sparas." }
          , { TranslationKeys.db_dbr123_msg_par1, "Undertecknad \"{0}\"." }
          , { TranslationKeys.db_dbr124_msg_par1, "Samlingen \"{0}\" har ingen offentlig nyckel; spara som den är." }
          , { TranslationKeys.db_dbr125_msg_par1, "Stderr-kanal: {0}" }
          , { TranslationKeys.db_dbr130_par1, "Avslutades med fel inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr131_par1, "Avslutades med fel inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr132_par1, "Avslutades med fel inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr133_par1, "Avslutades med fel inom {0:N0} sekunder." }
          , { TranslationKeys.db_dbr135_msg, "Status förväntas vara antingen \"Renamed\" eller \"Skipped\"." }
          , { TranslationKeys.db_dbr139_msg_par1, "Status förväntas vara antingen 'Renamed' eller 'Skipped' istället för {0} eller '{1}'." }
          , { TranslationKeys.db_dbr141_msg, "Saknar filnamn." }
          , { TranslationKeys.db_dbr143_msg, "Gruppens externa flagga borde ha hanterats när gruppen skapades och alla metoder i gruppen borde redan vara markerade som hoppade över." }
          , { TranslationKeys.db_dbr144_msg, "Metod måste ha ett namn när metoden inte hoppas över och gruppen har ett namn." }
          , { TranslationKeys.db_dbr145_msg_par1, "{0}' var INTE signerad på grund av felkod {1}." }
          , { TranslationKeys.db_dbr149_msg_par1, "Status måste vara \"Renamed\" eller \"Skipped\" i stället för \"{0}\"." }
          , { TranslationKeys.db_dbr153_msg_par1, "Stdout-kanal: {0}" }
          , { TranslationKeys.db_dbr154_msg, "Inga extra ramverksmappar:" }
          , { TranslationKeys.db_dbr155_msg, "Kan inte extrahera typnamn." }
          , { TranslationKeys.db_dbr156_msg_par1, "Ladda XML-projektdefinition från '{0}'." }
          , { TranslationKeys.db_dbr157_msg_par1, "Bearbetade {0} variabler." }
          , { TranslationKeys.db_dbr158_msg_par1, "Bearbetad {0} inkluderar taggar." }
          , { TranslationKeys.db_dbr159_msg_par1, "Bearbetade {0} sökvägar för montering." }
          , { TranslationKeys.db_dbr160_msg_par1, "Bearbetade {0} moduler." }
          , { TranslationKeys.db_dbr161_msg_par1, "Bearbetade {0} modulgrupper." }
          , { TranslationKeys.db_dbr162_msg, "Initialisera inställningar från variabler." }
          , { TranslationKeys.db_dbr166_msg_par1, "Certifikatfilen \"{0}\" måste innehålla minst ett certifikat." }
          , { TranslationKeys.db_dbr167_msg_par1, "Certifikatfilen '{0}' har ett ogiltigt format." }
          , { TranslationKeys.db_dbr169_msg, "Bestäm karaktärer för namngenerering." }
          , { TranslationKeys.db_dbr173_msg_par1, "Hittade installation av {0} på '{1}'." }
          , { TranslationKeys.db_dbr174_msg_par1, "Hittade ingen installation av {0} i '{1}'." }
          , { TranslationKeys.db_dbr175_msg, "Högst ett av certifikaturvalen genom nyckelfilens namn och SHA1-miniatyravtryck kan användas." }
          , { TranslationKeys.db_dbr176_msg, "Antingen måste certifikatval genom nyckelfilens namn eller SHA1-miniatyravtryck användas." }
          , { TranslationKeys.db_dbr177_msg, "Lösenordet för nyckelfilen kan endast anges när certifikatet väljs med nyckelfilens namn." }
          , { TranslationKeys.db_definition_missing, "Definition saknas." }
          , { TranslationKeys.db_display_version, "Visar versionsnummer för denna applikation." }
          , { TranslationKeys.db_duplicate_character, "Duplicerad karaktär." }
          , { TranslationKeys.db_error_processing_colon, "Ett fel inträffade under bearbetningen:" }
          , { TranslationKeys.db_filename_missing, "Saknar filnamn." }
          , { TranslationKeys.db_fork_obfuscar, "DotBlur är en förgrening av Obfuscar (https://www.obfuscar.com)" }
          , { TranslationKeys.db_full_name_missing, "Fullständigt namn saknas." }
          , { TranslationKeys.db_gt_title_par2, "*** DotBlur Global Tool ({0}) den {1} (UTC) ***" }
          , { TranslationKeys.db_help_info, "Skriv ut denna hjälpinformation." }
          , { TranslationKeys.db_hide_strings, "Dölj strängar." }
          , { TranslationKeys.db_hint_colon_par1, "Ledtråd: {0}" }
          , { TranslationKeys.db_hint_skiptype, "Tips: du kan behöva lägga till en SkipType för en enum ovan." }
          , { TranslationKeys.db_inner_exception_par1, "Inre undantag: {0}" }
          , { TranslationKeys.db_loading_pjt_par1, "Laddar projekt '{0}'." }
          , { TranslationKeys.db_missing_group, "Saknad grupp." }
          , { TranslationKeys.db_missing_parent_reader, "Saknad förälder läsare." }
          , { TranslationKeys.db_missing_parts, "Saknade delar." }
          , { TranslationKeys.db_missing_path_value, "Saknar värde för sökväg." }
          , { TranslationKeys.db_missing_read_action, "Missing read action." }
          , { TranslationKeys.db_missing_setting_name, "Saknar namn på inställning." }
          , { TranslationKeys.db_not_hide_strings, "Inte dölja strängar." }
          , { TranslationKeys.db_not_rename_events, "Byt inte namn på händelser." }
          , { TranslationKeys.db_not_rename_fields, "Byt inte namn på fält." }
          , { TranslationKeys.db_not_rename_properties, "Byt inte namn på egenskaper." }
          , { TranslationKeys.db_options_colon, "Alternativ:" }
          , { TranslationKeys.db_pool_clean, "Kan inte rengöra poolen." }
          , { TranslationKeys.db_pool_still, "Fortfarande i poolen:" }
          , { TranslationKeys.db_rename_events, "Byt namn på händelser." }
          , { TranslationKeys.db_rename_fields, "Byt namn på fält." }
          , { TranslationKeys.db_rename_methods, "Byt namn på metoder." }
          , { TranslationKeys.db_rename_parameters, "Byt namn på parametrar." }
          , { TranslationKeys.db_rename_properties, "Byt namn på egenskaper." }
          , { TranslationKeys.db_settings_not_initialized, "Inställningarna har ännu inte initialiserats." }
          , { TranslationKeys.db_syntax, "DotBlur.exe [Alternativ] [projekt_fil] [projekt_fil]" }
          }
        }
        };
    }
}
