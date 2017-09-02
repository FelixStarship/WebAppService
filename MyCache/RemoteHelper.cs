using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
   public class RemoteHelper
    {   
        /// <summary>
        /// 读取远程接口数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is {0} Query",typeof(RemoteHelper));
            long lResult = 0;
            for (int i = 0; i < 1000; i++)
            {
                lResult += i;
            }
            return new List<T>
            {
                default(T),default(T),default(T)
            };
        }
    }
}
