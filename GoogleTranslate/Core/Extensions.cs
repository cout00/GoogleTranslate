using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    static class Extensions
    {
        public static bool In<T>(this T someGeneric, IEnumerable<T> input) where T : struct
        {
            foreach (var item in input)
            {
                if (item.Equals(someGeneric))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
