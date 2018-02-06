using System.IO;
using System.Net;
using System.Text;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.Interfaces;

namespace FTranslate.Core.Yandex
{
    public class YandexHttpRequest :IHttpRequest
    {
        public Language inplang { get; set; }
        public Language inplang2 { get; set; }

        private const string Key = "trnsl.1.1.20170830T095657Z.cebe39bf87ebd94c.0b9492d1930a6c88ff7b712891d7e8c46910f402";
        public string GetRequestData(string langCode, string inpText)
        {
            var test = inplang;            
                var conString = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key= {Key} &lang={langCode}&text={inpText}";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(conString);
                req.Method = "POST";
                req.Accept = "*/*";req.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse rest = (HttpWebResponse)req.GetResponse();
                using (StreamReader stream = new StreamReader(rest.GetResponseStream(), Encoding.UTF8))
                {
                    return stream.ReadToEnd();
                }         
        }
    }
}
