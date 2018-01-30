using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTranslate.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    sealed class PoolInitTarget : Attribute
    {
        public PoolInitTarget()
        {
        }

    }

}
