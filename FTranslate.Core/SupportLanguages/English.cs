using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.Attributes;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class English : Language
    {
        protected English()
        {
            Iso6311LanguageCode = "en";
            Iso6312LanguageCode = "eng";
            Iso6313LanguageCode = "eng";
            Gost77597LanguageCode = "анг";
        }

        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_mlteast_en;
            base.InitializationCode();
        }

        public override string ToString()
        {
            return "English";
        }
    }
}