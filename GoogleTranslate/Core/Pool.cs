using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslate.Core
{
    public static class Pool
    {
        static public ObjectPool<IShowTypeForm> ResultFormPool { get;}

        static Pool()
        {
            ResultFormPool = new ObjectPool<IShowTypeForm>();
            Assembly.GetAssembly(typeof(IShowTypeForm)).GetTypes().Where(type =>
            {
                return type.GetInterfaces().Contains(typeof(IShowTypeForm)) ? true : false;
            }).ToList().ForEach(instanse =>
            {
                ResultFormPool.Add((IShowTypeForm)Activator.CreateInstance(instanse));
            });           
        }
    }
}
