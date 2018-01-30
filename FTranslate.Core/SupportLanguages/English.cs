using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.Attributes;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class English : LanguageString
    {
        protected English() : base()
        {
            ISO631_1_LanguageCode = "en";
            ISO631_2_LanguageCode = "eng";
            ISO631_3_LanguageCode = "eng";
            GOST_7_75_97_LanguageCode = "анг";
        }

        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_mlteast_en;
            base.InitializationCode();
        }
    }
}