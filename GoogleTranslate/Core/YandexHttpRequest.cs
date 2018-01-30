using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    public class YandexHttpRequest :IHttpRequest
    {
        private const string Key = "trnsl.1.1.20170830T095657Z.cebe39bf87ebd94c.0b9492d1930a6c88ff7b712891d7e8c46910f402";
        public string GetRequestData(string inputText)
        {            
                var conString = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key= {Key} &lang=en-ru&text={inputText}";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(conString);
                req.Method = "POST";
                req.Accept = "*/*";
                req.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse rest = (HttpWebResponse)req.GetResponse();
                using (StreamReader stream = new StreamReader(rest.GetResponseStream(), Encoding.UTF8))
                {
                    return stream.ReadToEnd();
                }
            
        }
    }
}
