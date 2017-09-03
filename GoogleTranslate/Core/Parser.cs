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

        protected abstract Tuple<NotTranslatedException, string> Parse(string UnParsedString);

        public Parser(IHttpRequest RequestObj, string NotTranslatedText)
        {
            Request = RequestObj;
            Text = NotTranslatedText;
        }

        protected abstract void GetParsMistakes(ref Dictionary<int, string> Mistakes);
        

        public void GetMistakes(ref Dictionary<int, string> Mistakes)
        {
            GetParsMistakes(ref Mistakes);
        }

        public Tuple<NotTranslatedException, string> GetTranslate()
        {
            string ParseStr = "";
            try
            {
                ParseStr = Request.GetRequestData(Text);
            }
            catch (Exception)
            {
                return new Tuple<NotTranslatedException, string>(new NotTranslatedException(this, 42), "");
            }
            return Parse(ParseStr);
        }
    }
}
