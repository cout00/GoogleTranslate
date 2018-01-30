using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class German :LanguageString
    {
        protected German() : base()
        {
            ISO631_1_LanguageCode = "de";
            ISO631_2_LanguageCode = "deu";
            ISO631_3_LanguageCode = "deu";
            GOST_7_75_97_LanguageCode = "нем";
        }

        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_multext_ge;
            base.InitializationCode();
        }
    }
}
