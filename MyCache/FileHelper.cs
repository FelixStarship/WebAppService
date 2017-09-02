using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
   public class FileHelper
    {  

        /// <summary>
        /// 执行一个耗时的读文件的操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Query<T>()
        {
            Console.WriteLine("This is {0} Query",typeof(FileHelper));
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
