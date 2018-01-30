using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTranslate.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class SingletonPoolAttribute : Attribute
    {
        readonly Type poolType;

        public SingletonPoolAttribute(Type poolType)
        {
            this.poolType = poolType;
        }
        public Type PoolType { get; private set; }

    }
}
