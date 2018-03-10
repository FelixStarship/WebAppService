using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleThread
{
    class Program
    {

        static int tickets = 100;
        static object gloalObj = new object();
        static void Main(string[] args)
        {

#if RELEASE
            {
                //线程也分前后台
                Thread backThread = new Thread(Worker);
                backThread.IsBackground = true;
                backThread.Start();
                backThread.Join();
                Console.WriteLine("从主线程中退出!");
            }


            Console.WriteLine("主线程ID={0}", Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(CallBackWorkItem);
            ThreadPool.QueueUserWorkItem(CallBackWorkItem,"work");
            Thread.Sleep(2000);
            Console.WriteLine("主线程退出");


            Console.WriteLine("主线程运行");
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(callback, cts.Token);
            Console.Read();
            cts.Cancel();   //协作式取消线程
            Console.ReadKey();



            Thread parmThread = new Thread(new ParameterizedThreadStart(Worker));
            parmThread.Name = "线程1";
            parmThread.Start("线程参数");
            Console.WriteLine("从主线程返回");
     
            
            //线程同步
            Thread thread1 = new Thread(SaleTickeThread1);
            Thread thread2 = new Thread(SaleTicketThread2);
            thread1.Start();
            thread2.Start();
            Thread.Sleep(4000);
#endif

            int x = 0;
            const int iterationNumber = 5000000;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterationNumber; i++)
            {
                x++;
            }
            Console.WriteLine("不使用锁的情况下花费的时间：{0} ms",sw.ElapsedMilliseconds);
            sw.Restart();

            for (int i = 0; i < iterationNumber; i++)
            {
                Interlocked.Increment(ref x);
            }
            Console.WriteLine("使用锁的情况下花费的时间：{0} ms",sw.ElapsedMilliseconds);
            Console.Read();
        }


        private static void SaleTickeThread1()
        {
            while (true) {
                try
                {
                    Monitor.Enter(gloalObj);   //在object对象上获取排他锁
                    Thread.Sleep(1);
                    if (tickets > 0)
                        Console.WriteLine("线程1出票：" + tickets--);
                    else
                        break;

                Monitor.Exit(gloalObj);
            }
            finally
            {
                Monitor.Exit(gloalObj);    //释放指定对象上的排他锁
            }
        }
        }
        private static void SaleTicketThread2()
        {
            while (true) {
                try
                {
                    Monitor.Enter(gloalObj);
                    Thread.Sleep(1);
                    if (tickets > 0)
                        Console.WriteLine("线程2出票：" + tickets--);
                    else
                        break;
                }
                finally
                {
                    Monitor.Exit(gloalObj);
                }
            }
        }

        public static void Worker(object data)
        {   
            Thread.Sleep(1000);
            Console.WriteLine("传入的参数为：" + data.ToString());
            Console.WriteLine("从线程1返回");
            Console.Read();
        }

        private static void CallBackWorkItem(object state) {
            Console.WriteLine("线程池线程开始执行");
            if (state != null)
            {
                Console.WriteLine("线程池线程ID {0} 传入的参数为 {1}", Thread.CurrentThread.ManagedThreadId, state.ToString());
            }
            else
            {
                Console.WriteLine("线程池线程ID {0}",Thread.CurrentThread.ManagedThreadId);
            }
        }


        private static void callback(object state) {
            CancellationToken token = (CancellationToken)state;
            Console.WriteLine("开始计数");
            Count(token,1000);
        }

        private static void Count(CancellationToken token, int count) {
            for (int i = 0; i < count; i++)
            {
                if (token.IsCancellationRequested) {
                    Console.WriteLine("计数取消");
                    return;
                }
                Console.WriteLine("计数为："+i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("计数完成");
        }
    }
}
