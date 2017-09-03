using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{

    [Serializable]
    public class NotTranslatedException :Exception
    {
        Dictionary<int, string> MistakeDistionary = new Dictionary<int, string>();

        public int ExceptionCode { get; }
        public string TranslationMistakeInfo { get; set; }
        public NotTranslatedException() { }
        public NotTranslatedException(IParser InitData, int ExCode)
        {
            ExceptionCode = ExCode;
            InitDictionary();
            InitData.GetMistakes(ref MistakeDistionary);
            TranslationMistakeInfo = MistakeDistionary[ExCode];
        }

        virtual protected void InitDictionary()
        {
            MistakeDistionary.Add(42, "Нет данных");
            MistakeDistionary.Add(300, "Сервер недоступен");
        }

        protected NotTranslatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    





}
