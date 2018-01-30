using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class French :LanguageString
    {        
        private French():base()
        {            
            ISO631_1_LanguageCode = "fr";
            ISO631_2_LanguageCode = "fra";
            ISO631_3_LanguageCode = "fra";
            GOST_7_75_97_LanguageCode = "фра";
        }
        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_multext_fr;
            base.InitializationCode();
        }
    }
}
