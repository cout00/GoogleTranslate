using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    public abstract class Parser :IParser
    {
        protected IHttpRequest Request;
        protected string Text;

        protected abstract Tuple<NotTranslatedException, string> Parse(string unParsedString);

        protected Parser(IHttpRequest requestObj, string notTranslatedText)
        {
            Request = requestObj;
            Text = notTranslatedText;
        }

        protected abstract void GetParsMistakes(ref Dictionary<int, string> mistakes);
        

        public void GetMistakes(ref Dictionary<int, string> mistakes)
        {
            GetParsMistakes(ref mistakes);
        }

        public Tuple<NotTranslatedException, string> GetTranslate()
        {
            string parseStr = "";
            try
            {
                parseStr = Request.GetRequestData(Text);
            }
            catch (Exception)
            {
                return new Tuple<NotTranslatedException, string>(new NotTranslatedException(this, 42), "");
            }
            return Parse(parseStr);
        }
    }
}
