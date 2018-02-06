using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTranslate.Core.Attributes;
using FTranslate.Core.Interfaces;
using FTranslate.Core.ObjectPool;
using LemmaSharp.Classes;

namespace FTranslate.Core.BaseClasses
{
    public enum LanguageCodeSystem
    {
        Iso6391,
        Iso6392,
        Iso6393,
        Gost77597
    }

    [SingletonPool()]
    public abstract class Language
    {
        public string Text { get; set; }
        public LanguageCodeSystem CodeSystem { get; set; }
        public string LemmantizedString { get; set; }
        
        protected string Iso6311LanguageCode;
        protected string Iso6312LanguageCode;
        protected string Iso6313LanguageCode;
        protected string Gost77597LanguageCode;
        protected byte[] Lematizer;
        private Lemmatizer _lemmatizer;
        public string GetLanguageCode()
        {
            switch (CodeSystem)
            {
                case LanguageCodeSystem.Iso6391:
                    return Iso6311LanguageCode;
                case LanguageCodeSystem.Iso6392:
                    return Iso6312LanguageCode;
                case LanguageCodeSystem.Iso6393:
                    return Iso6313LanguageCode;
                case LanguageCodeSystem.Gost77597:
                    return Gost77597LanguageCode;
            }
            return null;
        }

        public void Lemmatize()
        {
            if (Text.Trim().Split(' ').Length == 1)
            {
                LemmantizedString= _lemmatizer.Lemmatize(Text);
            }
            LemmantizedString="";
        }


        [PoolInitTarget]
        protected virtual void InitializationCode()
        {
            _lemmatizer=new Lemmatizer(new MemoryStream(Lematizer));   
        }
     

    }
}
