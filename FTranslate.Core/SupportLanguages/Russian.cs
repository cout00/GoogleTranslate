using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.SupportLanguages
{

    public class Russian :Language
    {
        public override LanguageDBCode Code
        {
            get {
                return LanguageDBCode.Russian;
            }

            set {
                Code = LanguageDBCode.Russian;
            }
        }
        protected Russian()
        {
            Iso6311LanguageCode = "ru";
            Iso6312LanguageCode = "rus";
            Iso6313LanguageCode = "rus";
            Gost77597LanguageCode = "рус";
        }
        protected override void InitializationCode()
        {
            Lematizer = Resource.full7z_mlteast_ru;
            base.InitializationCode();
        }

        public override string ToString()
        {
            return "Russian";
        }
    }
}
