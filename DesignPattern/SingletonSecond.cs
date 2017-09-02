using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
   public class SingletonSecond
    {
        private SingletonSecond()
        {
            long lResult = 0;
            for (int i = 0; i <100000 ; i++)
            {
                lResult += i;
                Console.WriteLine("{0}被构造一次",this.GetType().Name);
            }
        }
        /// <summary>
        /// 静态构造函数：由CLR（通用语言运行时）保证 在程序运行前被创建 且只创建一次
        /// </summary>
        static SingletonSecond()
        {
            _SingletonSecond = new SingletonSecond();

        }
        private static SingletonSecond _SingletonSecond = null;
        public static SingletonSecond CreateInstance()
        {
            return _SingletonSecond;
        }

    }
}
