using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    class ObjectPool<SomeType>:List<SomeType>, IEqualityComparer<SomeType> where SomeType : IShowTypeForm
    {

        public new void Add(SomeType newObj)
        {
            if (!this.Contains(newObj,this))
            {
                base.Add(newObj);
            }
        }


        public void InvokeObj(Type nameObj, string ctrParams)
        {
            foreach (var item in this)
            {
                if (item.GetType()==nameObj)
                {
                    item.ShowResult(ctrParams);
                }
            }
        }

        public bool Equals(SomeType x, SomeType y)
        {
            if (x.GetType().Name==y.GetType().Name)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(SomeType obj)
        {
            return obj.GetHashCode();
        }
    }
}
