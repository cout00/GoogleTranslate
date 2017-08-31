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
        public NotTranslatedException(int ExCode)
        {
            ExceptionCode = ExCode;
            InitDictionary();
            TranslationMistakeInfo = MistakeDistionary[ExCode];
        }

        void InitDictionary()
        {
            MistakeDistionary.Add(42, "Нет данных");
            MistakeDistionary.Add(300, "Сервер недоступен");
            MistakeDistionary.Add(401, "Неправильный API-ключ");
            MistakeDistionary.Add(402, "API-ключ заблокирован");
            MistakeDistionary.Add(404, "Превышено суточное ограничение на объем переведенного текста");
            MistakeDistionary.Add(413, "Превышен максимально допустимый размер текста");
            MistakeDistionary.Add(422, "Текст не может быть переведен");
            MistakeDistionary.Add(501, "Заданное направление перевода не поддерживается");
        }

        protected NotTranslatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
