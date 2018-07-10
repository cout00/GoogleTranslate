using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{
    public class French :Language
    {

        public override LanguageDBCode Code
        {
            get {
                return LanguageDBCode.French;
            }

            set {
                Code = LanguageDBCode.French;

            }
        }



        private French()
        {            
            Iso6311LanguageCode = "fr";
            Iso6312LanguageCode = "fra";
            Iso6313LanguageCode = "fra";
            Gost77597LanguageCode = "фра";
        }
        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_multext_fr;
            base.InitializationCode();
        }

        public override string ToString()
        {
            return "French";
        }
    }
}
