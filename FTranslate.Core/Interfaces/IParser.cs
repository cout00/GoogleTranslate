using System;
using System.Collections.Generic;

namespace FTranslate.Core.Interfaces
{
    public interface IParser
    {
        void GetMistakes(ref Dictionary<int, string> Mistakes);
        Tuple<NotTranslatedException, string> GetTranslate();

    }
}
