using System;
using System.Collections.Generic;
using FTranslate.Core.Interfaces;

namespace FTranslate.Core.BaseClasses
{
    public abstract class Parser :IParser
    {
        protected IHttpRequest Request;
        protected Language InputLanguageObj;
        protected Language OutPutLanguageObj;

        protected abstract NotTranslatedException Parse(string unParsedString);

        protected Parser(IHttpRequest requestObj, Language inputLanguageObj, Language outPutLanguageObj)
        {
            Request = requestObj;
            InputLanguageObj = inputLanguageObj;
            OutPutLanguageObj = outPutLanguageObj;
        }

        protected abstract void GetParsMistakes(ref Dictionary<int, string> mistakes);
        

        public void GetMistakes(ref Dictionary<int, string> mistakes)
        {
            GetParsMistakes(ref mistakes);
        }

        public NotTranslatedException Translate()
        {
            string parseStr = "";
            OutPutLanguageObj.Text = string.Empty;
            try
            {
                parseStr = Request.GetRequestData($"{InputLanguageObj.GetLanguageCode()}-{OutPutLanguageObj.GetLanguageCode()}", InputLanguageObj.Text);

            }
            catch (Exception)
            {
                return new NotTranslatedException(this, 42);
            }
            return Parse(parseStr);
        }
    }
}
