using System.Collections.Generic;
using FTranslate.Core.ObjectPool;

namespace FTranslate.Core
{
    public static class Extensions
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