﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    public interface IHttpRequest
    {
        string GetRequestData(string inputText);
    }
}
