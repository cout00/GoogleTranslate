﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    public interface IParser
    {
        void GetMistakes(ref Dictionary<int, string> Mistakes);
        Tuple<NotTranslatedException, string> GetTranslate();

    }
}
