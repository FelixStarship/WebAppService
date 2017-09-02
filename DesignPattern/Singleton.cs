using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
   public class Singleton
    {   
        private Singleton()
        {
            long lResult = 0;
            for (int i = 0; i <1000000 ; i++)
            {
                lResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}被构造一次",this.GetType().Name);
        }
        //静态字段：由CLR(通用语言运行时)保证 程序第一次使用这个类型时被创建 且进程内唯一，只创建一次
        private static Singleton _Singleton = null;
        private static object Singleton_lock = new object();
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)
            {
                lock (Singleton_lock)
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("等待锁之后，释放锁。。。。");
                    if (_Singleton == null)
                        _Singleton = new Singleton();
                }
            }
            return _Singleton;
        }
        public void Show()
        {
            Console.WriteLine("这里是{0}.Show",this.GetType().Name);
        }
    }
}
