using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{

    public class Russian :LanguageString
    {
        protected Russian() : base()
        {
            ISO631_1_LanguageCode = "ru";
            ISO631_2_LanguageCode = "rus";
            ISO631_3_LanguageCode = "rus";
            GOST_7_75_97_LanguageCode = "рус";
        }
        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_mlteast_ru;
            base.InitializationCode();
        }
    }
}
