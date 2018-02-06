using System;
using System.Collections.Generic;
using System.Linq;
using FTranslate.Core.Interfaces;

namespace FTranslate.Core.ObjectPool
{
    public class ObjectPool<TSomeType> :Dictionary<Type,TSomeType> where TSomeType : class 
    {        
        public TSomeType GetPoolObject(Type nameObj)
        {            
            return (from item in this where item.Key.Name == nameObj.Name select item.Value).FirstOrDefault();
        }

        public TSomeType GetPoolObject(string key)
        {
            return this.FirstOrDefault(pair => pair.Key.Name == key).Value;
        }
    }
}
