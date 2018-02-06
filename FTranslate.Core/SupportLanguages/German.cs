using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class German :Language
    {
        protected German(){
            Iso6311LanguageCode = "de";
            Iso6312LanguageCode = "deu";
            Iso6313LanguageCode = "deu";
            Gost77597LanguageCode = "нем";
        }

        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_multext_ge;
            base.InitializationCode();
        }

        public override string ToString()
        {
            return "German";
        }
    }
}
