using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MistakesAttribute:Attribute
    {
        public MistakesAttribute()
        {

        }
    }
}
