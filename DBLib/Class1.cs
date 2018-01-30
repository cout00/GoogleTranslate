using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib
{
    public static class BDInvoker
    {
        public static void InvokeBd()
        {
            bdWordsEntities bd = new bdWordsEntities();
            bd.Word.Load();
        }
    }
}
