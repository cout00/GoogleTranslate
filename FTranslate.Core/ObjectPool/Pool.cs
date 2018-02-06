using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FTranslate.Core.Attributes;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.Interfaces;
using FTranslate.Core.SupportLanguages;

[assembly: InternalsVisibleTo("GoogleTranslate.Tests")]
namespace FTranslate.Core.ObjectPool
{
    public static class Pool
    {
        public static ObjectPool<object> SingletonPool { get;}

        internal static IEnumerable<Type> GetDerivedTypes(Type baseType)
        {         
             return Assembly.GetAssembly(baseType)
                .GetTypes()
                .Where(type => type.IsSubclassOf(baseType))
                .ToList();
        }


        public static IEnumerable<object> GetByParentClass(Type baseType)
        {
            foreach (var type in GetDerivedTypes(baseType))
            {
                yield return SingletonPool.GetPoolObject(type);
            }
        }
         
        public static async Task ActivatePoolAsync(Type baseType)
        {
            foreach (var type in GetDerivedTypes(baseType))
            {
                foreach (var method in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (Attribute.GetCustomAttributes(method, typeof(PoolInitTarget)).Length==1)
                    {
                        await Task.Run(() => method.Invoke(SingletonPool.GetPoolObject(type), null));
                    }
                }
            }
        }

        static Pool()
        {
            SingletonPool=new ObjectPool<object>();
            SingletonPool.Clear();
            foreach (var poolType in Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(a => a.GetCustomAttributes<SingletonPoolAttribute>().Count()==1)
                .ToList())
            {
                foreach (var derivedType in GetDerivedTypes(poolType))
                {
                    SingletonPool.Add(derivedType, Activator.CreateInstance(derivedType,true));                  
                }
            }
        }        
    }
}
