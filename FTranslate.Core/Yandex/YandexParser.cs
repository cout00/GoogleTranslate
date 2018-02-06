using System;
using System.Collections.Generic;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.Interfaces;
using Newtonsoft.Json;

namespace FTranslate.Core.Yandex
{
    public class YandexParser :Parser
    {

        public YandexParser(IHttpRequest requestObj, Language inputLanguageObj, Language outPutLanguageObj) :base(requestObj,inputLanguageObj, outPutLanguageObj)
        {
            
        }
        
        protected override void GetParsMistakes(ref Dictionary<int, string> mistakes)
        {
            mistakes.Add(401, "Неправильный API-ключ");
            mistakes.Add(402, "API-ключ заблокирован");
            mistakes.Add(404, "Превышено суточное ограничение на объем переведенного текста");
            mistakes.Add(413, "Превышен максимально допустимый размер текста");
            mistakes.Add(422, "Текст не может быть переведен");
            mistakes.Add(501, "Заданное направление перевода не поддерживается");
        }

        protected override NotTranslatedException Parse(string unParsedString)
        {
            try
            {
                dynamic deserializedObject = JsonConvert.DeserializeObject(unParsedString);
                var code = Convert.ToInt32((string)deserializedObject.code.ToString());
                var jsonString = (string)deserializedObject.text.ToString();
                var newStr = "";
                if (code != 200)
                {
                    return new NotTranslatedException(this, code);
                }
                for (int i = 0; i < jsonString.Length; i++)
                {
                    if (!((int)jsonString[i]).In(new int[] { 93, 91, 13, 10, 34 }))
                    {
                        if (((int)jsonString[i]).In(new int[] { 32 }) && (((int)jsonString[i - 1]).In(new int[] { 32 }) || ((int)jsonString[i + 1]).In(new int[] { 32 })))
                        {
                            continue;
                        }
                        newStr += jsonString[i];
                    }
                }
                if (newStr.Length < 1)
                {
                    return new NotTranslatedException(this, 42);
                }
                newStr.Trim().Trim();
                OutPutLanguageObj.Text = newStr;
                return null;
            }
            catch (NotTranslatedException)
            {
                return new NotTranslatedException(this, 42);
            }
        }
    }
}
