using System.Collections.Generic;
using System.Globalization;
using System.IO;
using static Cirnix.Global.Globals;

namespace Cirnix.Global
{
    public static class Locale
    {
        private static readonly string LocalePath = $"{ResourcePath}\\Locales";

        private static CultureInfo _CurrentLocale = CultureInfo.CurrentCulture;

        public static string CurrentLocale {
            get => _CurrentLocale.Name;
            set {
                try
                {
                    CultureInfo info = CultureInfo.GetCultureInfo(value);
                    if (File.Exists($"{LocalePath}\\{info.Name}.json"))
                    {
                        
                    }
                }
                catch
                {

                }
            }
        }

        private static Dictionary<string, string> LangData = new Dictionary<string, string>();

        //private static string 

        /// <summary>
        /// 한국어 받침 체크
        /// </summary>
        /// <param name="name">체크할 문자열</param>
        /// <param name="firstValue">예: 을, 이, 은</param>
        /// <param name="secondValue">예: 를, 가, 는</param>
        /// <returns></returns>
        public static string IsKoreanBlock(string name, string firstValue, string secondValue, bool isNameAdd = true)
        {
            if (_CurrentLocale.LCID != 1042) return isNameAdd ? $"'{name}'" : string.Empty;
            if (name.Length <= 0) return $"{(isNameAdd ? "''" : string.Empty)}{firstValue}";
            char lastName = name[name.Length - 1];
            if (lastName < 0xAC00 || lastName > 0xD7A3) return $"{(isNameAdd ? $"'{name}'" : string.Empty)}({firstValue}){secondValue}";
            string selectedValue = (lastName - 0xAC00) % 28 > 0 ? firstValue : secondValue;
            return $"{(isNameAdd ? $"'{name}'" : string.Empty)}{selectedValue}";
        }
    }
}
