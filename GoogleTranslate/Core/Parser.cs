using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleTranslate.Core
{
    public class Parser
    {
        IHttpRequest Request;
        public Parser(IHttpRequest RequestObj)
        {
            Request = RequestObj;
        }
        //{"code":200,"lang":"en-ru","text":["привет мир"]}
        public Tuple<NotTranslatedException, string> GetTranslate()
        {
            try
            {
                string ParseStr = Request.GetRequestData();
                dynamic stuff = JsonConvert.DeserializeObject(ParseStr);
                var code = Convert.ToInt32((string)stuff.code.ToString());
                var tes2t = (string)stuff.text.ToString();
                var newStr = "";
                if (code!=200)
                {
                    return new Tuple<NotTranslatedException, string>(new NotTranslatedException(code), "");
                }
                for (int i = 0; i < tes2t.Length; i++)
                {
                    if (!((int)tes2t[i]).In(new int[] { 93, 91, 13, 10, 34 }))
                    {
                        if (((int)tes2t[i]).In(new int[] { 32 }) && (((int)tes2t[i - 1]).In(new int[] { 32 })|| ((int)tes2t[i + 1]).In(new int[] { 32 })))
                        {
                            continue;
                        }
                        newStr += tes2t[i];
                    }
                }
                if (newStr.Length<1)
                {
                    return new Tuple<NotTranslatedException, string>(new NotTranslatedException(42), "");
                }
                newStr.Trim().Trim();
                return new Tuple<NotTranslatedException, string>(null, newStr);
            }
            catch (NotTranslatedException)
            {
                return new Tuple<NotTranslatedException, string>(new NotTranslatedException(42), ""); 
            }
            
        }



    }
}
