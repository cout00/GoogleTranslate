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
        ISO_639_1,
        ISO_639_2,
        ISO_639_3,
        GOST_7_75_97
    }

    [SingletonPool(typeof(LanguageString))]
    public abstract class LanguageString
    {
        protected static LanguageString InstanseLanguageString;
        public string Text { get; set; }
        public LanguageCodeSystem CodeSystem { get; set; }

        private static object syncobject;

        protected LanguageString()
        {
            InstanseLanguageString = this;
        }

        public string LemmantizedString
        {
            get
            {
                if (Text.Trim().Split(' ').Length==1)
                {
                    return lemmatizer.Lemmatize(Text);
                }
                return "";
            }
        }

        protected string ISO631_1_LanguageCode;
        protected string ISO631_2_LanguageCode;
        protected string ISO631_3_LanguageCode;
        protected string GOST_7_75_97_LanguageCode;
        protected byte[] Lematizer;
        private Lemmatizer lemmatizer;



        public string GetLanguageCode()
        {
            switch (CodeSystem)
            {
                case LanguageCodeSystem.ISO_639_1:
                    return ISO631_1_LanguageCode;
                case LanguageCodeSystem.ISO_639_2:
                    return ISO631_2_LanguageCode;
                case LanguageCodeSystem.ISO_639_3:
                    return ISO631_3_LanguageCode;
                case LanguageCodeSystem.GOST_7_75_97:
                    return GOST_7_75_97_LanguageCode;
            }
            return null;
        }

        [PoolInitTarget]
        protected virtual void InitializationCode()
        {
            lemmatizer=new Lemmatizer(new MemoryStream(Lematizer));   
        }

        public static LanguageString GetFromPool()
        {
            lock (syncobject)
            {
                return InstanseLanguageString;
            }          
        }


    }
}
