using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GoogleTranslateApi
{
    /// <summary>
    /// By: Muhammad Rostami
    /// </summary>
    public class GoogleApi
    {
        Dictionary<LanguagesType, string> types;
        public GoogleApi()
        {
            types = new Dictionary<LanguagesType, string>()
            {
                {LanguagesType.Albanian , "af" },
                {LanguagesType.Afrikaans , "sq" },
                {LanguagesType.Arabic , "ar" },
                {LanguagesType.Armenian , "hy" },
                {LanguagesType.Azerbaijani , "az" },
                {LanguagesType.Basque , "eu" },
                {LanguagesType.Belarusian , "be" },
                {LanguagesType.Bulgarian , "bg" },
                {LanguagesType.Catalan , "ca" },
                {LanguagesType.Chinese_Simplified , "zh-CN" },
                {LanguagesType.Chinese_Traditional , "zh-TW" },
                {LanguagesType.Croatian , "hr" },
                {LanguagesType.Czech , "cs" },
                {LanguagesType.Danish , "da" },
                {LanguagesType.Dutch , "nl" },
                {LanguagesType.English , "en" },
                {LanguagesType.Estonian , "et" },
                {LanguagesType.Filipino , "tl" },
                {LanguagesType.Finnish , "fi" },
                {LanguagesType.French , "fr" },
                {LanguagesType.Galician , "gl" },
                {LanguagesType.Georgian , "ka" },
                {LanguagesType.German , "de" },
                {LanguagesType.Greek , "el" },
                {LanguagesType.HaitianCreole , "ht" },
                {LanguagesType.Hebrew , "iw" },
                {LanguagesType.Hindi , "hi" },
                {LanguagesType.Hungarian , "hu" },
                {LanguagesType.Icelandic , "is" },
                {LanguagesType.Indonesian , "id" },
                {LanguagesType.Irish , "ga" },
                {LanguagesType.Italian , "it" },
                {LanguagesType.Japanese , "ja" },
                {LanguagesType.Korean , "ko" },
                {LanguagesType.Latvian , "lv" },
                {LanguagesType.Lithuanian , "lt" },
                {LanguagesType.Macedonian , "mk" },
                {LanguagesType.Malay , "ms" },
                {LanguagesType.Maltese , "mt" },
                {LanguagesType.Norwegian , "no" },
                {LanguagesType.Persian , "fa" },
                {LanguagesType.Polish , "pl" },
                {LanguagesType.Portuguese , "pt" },
                {LanguagesType.Romanian , "ro" },
                {LanguagesType.Russian , "ru" },
                {LanguagesType.Serbian , "sr" },
                {LanguagesType.Slovak , "sk" },
                {LanguagesType.Slovenian , "sl" },
                {LanguagesType.Spanish , "es" },
                {LanguagesType.Swahili , "sw" },
                {LanguagesType.Swedish , "sv" },
                {LanguagesType.Thai , "th" },
                {LanguagesType.Turkish , "tr" },
                {LanguagesType.Ukrainian , "uk" },
                {LanguagesType.Urdu , "ur" },
                {LanguagesType.Vietnamese , "vi" },
                {LanguagesType.Welsh , "cy" },
                {LanguagesType.Yiddish , "yi" },

            };
        }


        /// <summary>
        /// Using this method, you can send your request as Async
        /// </summary>
        /// <param name="setting">Your translator settings such as text and language should be used in this section</param>
        /// <returns>Returns a string containing the translated content. If the From and To entries in the settings are the same, your string will be returned as it was sent from the server side.</returns>
        public Task<String> TranslateAsync(TranslatSetting setting)
        {
            return Task<string>.Factory.StartNew(()=> Translate(setting));
        }

        // <summary>
        /// Using this method, you can send your request as Normal(NOT Async)
        /// </summary>
        /// <param name="setting">Your translator settings such as text and language should be used in this section</param>
        /// <returns>Returns a string containing the translated content. If the From and To entries in the settings are the same, your string will be returned as it was sent from the server side.</returns>
        public String Translate(TranslatSetting setting)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={GetLanguageCode(setting.FromLanguage)}&tl={GetLanguageCode(setting.ToLanguage)}&dt=t&q={setting.Content}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error to Translating";
                throw new Exception("Error to Running Translating Prosses");
            }
        }



        #region Private Methods
        private string GetLanguageCode(LanguagesType type) => types[type];
        #endregion

    }
    public enum LanguagesType
    {
        Afrikaans,
        Albanian,
        Arabic,
        Armenian,
        Azerbaijani,
        Basque,
        Belarusian,
        Bulgarian,
        Catalan,
        Chinese_Simplified,
        Chinese_Traditional,
        Croatian,
        Czech,
        Danish,
        Dutch,
        English,
        Estonian,
        Filipino,
        Finnish,
        French,
        Galician,
        Georgian,
        German,
        Greek,
        HaitianCreole,
        Hebrew,
        Hindi,
        Hungarian,
        Icelandic,
        Indonesian,
        Irish,
        Italian,
        Japanese,
        Korean,
        Latvian,
        Lithuanian,
        Macedonian,
        Malay,
        Maltese,
        Norwegian,
        Persian,
        Polish,
        Portuguese,
        Romanian,
        Russian,
        Serbian,
        Slovak,
        Slovenian,
        Spanish,
        Swahili,
        Swedish,
        Thai,
        Turkish,
        Ukrainian,
        Urdu,
        Vietnamese,
        Welsh,
        Yiddish,

    }


    /// <summary>
    /// This class is used to store and send the translator settings parameter, where Content is the string to be translated
    ///FromLanguage is for source language and ToLanguage is for destination language
    /// </summary>
    public class TranslatSetting
    {
        public string Content { get; set; }
        public LanguagesType FromLanguage { get; set; }
        public LanguagesType ToLanguage { get; set; }
    }
}
