using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleTranslate.Core
{
    public class YandexParser :Parser
    {

        public YandexParser(IHttpRequest RequestObj, string NotTranslatedText):base(RequestObj,NotTranslatedText)
        {
            
        }


        //{"code":200,"lang":"en-ru","text":["привет мир"]}
        
        protected override void GetParsMistakes(ref Dictionary<int, string> Mistakes)
        {
            Mistakes.Add(401, "Неправильный API-ключ");
            Mistakes.Add(402, "API-ключ заблокирован");
            Mistakes.Add(404, "Превышено суточное ограничение на объем переведенного текста");
            Mistakes.Add(413, "Превышен максимально допустимый размер текста");
            Mistakes.Add(422, "Текст не может быть переведен");
            Mistakes.Add(501, "Заданное направление перевода не поддерживается");
        }

        protected override Tuple<NotTranslatedException, string> Parse(string UnParsedString)
        {
            try
            {

                dynamic stuff = JsonConvert.DeserializeObject(UnParsedString);
                var code = Convert.ToInt32((string)stuff.code.ToString());
                var tes2t = (string)stuff.text.ToString();
                var newStr = "";
                if (code != 200)
                {
                    return new Tuple<NotTranslatedException, string>(new NotTranslatedException(this, code), "");
                }
                for (int i = 0; i < tes2t.Length; i++)
                {
                    if (!((int)tes2t[i]).In(new int[] { 93, 91, 13, 10, 34 }))
                    {
                        if (((int)tes2t[i]).In(new int[] { 32 }) && (((int)tes2t[i - 1]).In(new int[] { 32 }) || ((int)tes2t[i + 1]).In(new int[] { 32 })))
                        {
                            continue;
                        }
                        newStr += tes2t[i];
                    }
                }
                if (newStr.Length < 1)
                {
                    return new Tuple<NotTranslatedException, string>(new NotTranslatedException(this, 42), "");
                }
                newStr.Trim().Trim();
                return new Tuple<NotTranslatedException, string>(null, newStr);
            }
            catch (NotTranslatedException)
            {
                return new Tuple<NotTranslatedException, string>(new NotTranslatedException(this, 42), "");
            }
        }
    }
}
