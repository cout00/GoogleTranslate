using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("GoogleTranslate.Tests")]
namespace GoogleTranslate.Core
{
    public static class Pool
    {
        static public ObjectPool<IShowTypeForm> ResultFormPool { get;}

        static Pool()
        {
            ResultFormPool = new ObjectPool<IShowTypeForm>();
            GetDerivativeTypes().ForEach(instanse =>
            {
                ResultFormPool.Add((IShowTypeForm)Activator.CreateInstance(instanse));
            });     
                
        }

        internal static List<Type> GetDerivativeTypes()
        {            
            return Assembly.GetAssembly(typeof(IShowTypeForm)).GetTypes().Where(type =>
            {
                return type.GetInterfaces().Contains(typeof(IShowTypeForm)) ? true : false;
            }).ToList();
        }

    }
}
