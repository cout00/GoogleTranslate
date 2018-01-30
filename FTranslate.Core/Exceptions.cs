using System;
using System.Collections.Generic;
using FTranslate.Core.Interfaces;

namespace FTranslate.Core
{

    [Serializable]
    public sealed class NotTranslatedException :Exception
    {
        private readonly Dictionary<int, string> _mistakeDistionary = new Dictionary<int, string>();

        public int ExceptionCode { get; }
        public string TranslationMistakeInfo { get; set; }
        public NotTranslatedException() { }
        public NotTranslatedException(IParser initData, int exCode)
        {
            ExceptionCode = exCode;
            InitDictionary();
            initData.GetMistakes(ref _mistakeDistionary);
            TranslationMistakeInfo = _mistakeDistionary[exCode];
        }

        private void InitDictionary()
        {
            _mistakeDistionary.Add(42, "Нет данных");
            _mistakeDistionary.Add(300, "Сервер недоступен");
        }

        private NotTranslatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    





}
