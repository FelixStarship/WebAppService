using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsyncThreads
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"************************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            Console.WriteLine($"************************btnSync_Click End {Thread.CurrentThread.ManagedThreadId}");
        }
        /// <summary>
        /// 异步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"********************************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId}");

            {
                Action<string> act = this.DoSomethingLong;
                //act += this.DoSomethingLong;      //多播委托
                act.Invoke("btnAsync_Click");
                IAsyncResult iAsyncResult = null;
                //回调函数  
                AsyncCallback callback = t =>
                {
                    Console.WriteLine(t);
                    Console.WriteLine($"string.ReferenceEquals(t,iAsyncResult)={string.ReferenceEquals(t, iAsyncResult)}");
                    Console.WriteLine($"This is Callback {Thread.CurrentThread.ManagedThreadId}");
                };
                //iAsyncResult = act.BeginInvoke("btnAsync_Click", callback, null);

                //while (!iAsyncResult.IsCompleted)
                //{
                //    Thread.Sleep(100);
                //    Console.WriteLine("*************等待等待****************");
                //}
                //iAsyncResult.AsyncWaitHandle.WaitOne();
                //iAsyncResult.AsyncWaitHandle.WaitOne(200);
                //act.EndInvoke(iAsyncResult);
            }

            {
                Func<string, string, int> func = (t, y) =>
                 {
                     Thread.Sleep(2000);
                     return DateTime.Now.Year;
                 };

                IAsyncResult iAsyncResult = func.BeginInvoke("消逝的青春", "寻水木鱼", t =>
                {
                    int iResult = func.EndInvoke(t);
                }, null);
                int iResultOut = func.EndInvoke(iAsyncResult);
            }

            Console.WriteLine("异步执行完成才去做的事!");
            Console.WriteLine($"*************************************btnAsync_Click End {Thread.CurrentThread.ManagedThreadId}");
        }



        private void btnThread_Click(object sender, EventArgs e)
        {

            Console.WriteLine();
            Console.WriteLine();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine($"**************************btnThread_Click Start {Thread.CurrentThread.ManagedThreadId}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}**");
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnThread_Click_{i}");
                ThreadStart start = () => this.DoSomethingLong(name);
                Thread thread = new Thread(start);
                thread.Start();
                //thread.Join();  //线程等待 方式一

                threadList.Add(thread);
            }


            {
                ThreadStart threadCallback = () => { Console.WriteLine("thread回调函数!"); };
                //Thread回调函数 封装
                this.ThreadWithCallback(threadCallback, () =>
                 {
                     Console.WriteLine("thread回调函数封装!");
                 });
            }

            {
                Func<int> oldFunc = () =>
                {
                    Console.WriteLine("Start");
                    Thread.Sleep(1000);
                    Console.WriteLine("End");
                    return DateTime.Now.Millisecond;
                };
                Func<int> newFunc = this.ThreadWithReturn<int>(oldFunc);
                Console.WriteLine(newFunc.Invoke());

                ReturnType<int>();
            }

            //线程等待 方式二
            while (threadList.Count(t => t.ThreadState != System.Threading.ThreadState.Stopped) > 0)
            {
                Thread.Sleep(500);
                Console.WriteLine("waingting.........");
            }
            watch.Stop();
            Console.WriteLine($"*****************************btnThread_Click End {Thread.CurrentThread.ManagedThreadId}  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} {watch.ElapsedMilliseconds}**");
        }
        /// <summary>
        /// 回调封装
        /// </summary>
        /// <param name="start"></param>
        /// <param name="callback"></param>
        private void ThreadWithCallback(ThreadStart start, Action callback)
        {
            ThreadStart newStart = () =>
            {
                start.Invoke();
                callback.Invoke();
            };
            Thread thread = new Thread(newStart);
            thread.Start();
        }
        /// <summary>
        /// 回调函数返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart newStart = () =>
            {
                t = func.Invoke();
            };
            Thread thread = new Thread(newStart);
            thread.Start();
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }
        private Func<T> ReturnType<T>()
        {
            return () => { return default(T); };
        }
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"***************************DoSomethingLong Start {Thread.CurrentThread.ManagedThreadId}");
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult++;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"****************************DoSomethingLong End {Thread.CurrentThread.ManagedThreadId}");
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**************************btnThreadPool_Click Start {Thread.CurrentThread.ManagedThreadId}**********");

            {
                ManualResetEvent mre = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(t =>
                {
                    this.DoSomethingLong("btnThreadPool_Click");
                    mre.Set();
                });
                mre.WaitOne();
            }

            {
                ManualResetEvent mre = new ManualResetEvent(false);    //信号量
                new Action(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("委托的异步调用");
                    mre.Set();
                }).BeginInvoke(null, null);
                mre.WaitOne();

                mre.Reset();
                new Action(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("委托的异步调用2");
                    mre.Set();
                }).BeginInvoke(null, null);
                mre.WaitOne();

            }
            Console.WriteLine($"*********************************btnThreadPool_Click End {Thread.CurrentThread.ManagedThreadId}***************");
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine($"*************************************btnTask_Click Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}**************");
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnTask_Click_{i}");
                Task task = Task.Factory.StartNew(() => this.DoSomethingLong(name));
                taskList.Add(task);
            }

            //回调形式
            taskList.Add(Task.Factory.ContinueWhenAny(taskList.ToArray(), t => Console.WriteLine($"ContinueWhenAny {Thread.CurrentThread.ManagedThreadId}")));

            taskList.Add(Task.Factory.ContinueWhenAll(taskList.ToArray(), tList => Console.WriteLine($"ContinueWhenAll  {Thread.CurrentThread.ManagedThreadId}")));


            Console.WriteLine("before WaitAny");
            Task.WaitAny(taskList.ToArray());
            Console.WriteLine("after WaitAny");

            Console.WriteLine("before WaitAll");
            Task.WaitAll(taskList.ToArray());   //线程等待  主线程
            Console.WriteLine("after WaitAll");
            watch.Stop();
            Console.WriteLine($"*****************************btnTask_Click End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} {watch.ElapsedMilliseconds}******************");
        }

        private void btnParaller_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine($"***********************************btnParaller_Click Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            //Parallel.Invoke(
            //     () =>this.DoSomethingLong("btnParaller_Click_0")
            //    ,()=>this.DoSomethingLong("btnParaller_Click_1")
            //    ,()=>this.DoSomethingLong("btnParaller_Click_2")
            //    ,()=>this.DoSomethingLong("btnParaller_Click_3")
            //    ,()=>this.DoSomethingLong("btnParaller_Click_4")
            //    ,() => this.DoSomethingLong("btnParaller_Click_5")
            //);
            //Parallel.For(0, 5, t => this.DoSomethingLong($"btnParaller_Click_{t}"));

            //Parallel.ForEach(new int[] { 1, 2, 3, 4, 5, 6 }, t => this.DoSomethingLong($"btnParaller_Click_{t}"));

            ParallelOptions option = new ParallelOptions
            {
                MaxDegreeOfParallelism = 3   //线程最大并发数
            };
            //Parallel.ForEach(new int[] { 1, 2, 3, 4, 5, 6 }, option,t => this.DoSomethingLong($"btnParaller_Click_{t}"));

            new Action(() => Parallel.ForEach(new int[] { 1, 2, 3, 4, 5, 6 }, option, t =>
              {
                  this.DoSomethingLong($"btnParaller_Click_{t}");
              })).BeginInvoke(null, null);

            watch.Stop();
            Console.WriteLine($"******************************************btnParaller_Click End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} {watch.ElapsedMilliseconds}");
        }
        private static object btnThreadCore_Click_Lock = new object();
        private int TotalCount = 0;
        private List<int> IntList = new List<int>();
        private void btnThreadcore_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine($"******************************btnThreadcore_Click Start {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            try
            {
                TaskFactory taskFactory = new TaskFactory();
                List<Task> taskList = new List<Task>();
                #region            线程异常
                //for (int i = 0; i < 20; i++)
                //{
                //    string name = string.Format($"btnThreadcore_Click_{i}");
                //    Action<object> act = t =>
                //    {
                //        try
                //        {
                //            Thread.Sleep(2000);
                //            if (t.ToString().Equals("btnThreadcore_Click_11"))
                //            {
                //                throw new Exception($"{t}执行失败");
                //            }
                //            if (t.ToString().Equals("btnThreadcore_Click_12"))
                //            {
                //                throw new Exception($"{t}执行失败");
                //            }
                //            Console.WriteLine("{0}执行成功", t);
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine(ex.Message);
                //        }
                //    };
                //    taskList.Add(taskFactory.StartNew(act, name));
                //}
                #endregion

                #region  线程取消
                //CancellationTokenSource cts = new CancellationTokenSource();
                //for (int i = 0; i <40; i++)
                //{
                //    string name = string.Format($"btnThreadcore_Click_{i}");
                //    Action<object> act = t =>
                //    {
                //        try
                //        {
                //            Thread.Sleep(2000);
                //            if (t.ToString().Equals("btnThreadcore_Click_11"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败",t));
                //            }
                //            if (t.ToString().Equals("btnThreadcore_Click_12"))
                //            {
                //                throw new Exception(string.Format("{0} 执行失败",t));
                //            }
                //            if (cts.IsCancellationRequested)
                //            {
                //                Console.WriteLine($"{t}放弃执行");
                //            }
                //            else
                //            {
                //                Console.WriteLine($"{t}执行成功");
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            cts.Cancel();
                //            Console.WriteLine(ex.Message);
                //        }
                //    };
                //    taskList.Add(taskFactory.StartNew(act,name,cts.Token)); 
                //}
                #endregion

                #region 多线程临时变量
                //for (int i = 0; i < 5; i++)
                //{
                //    int k = i;
                //    new Action(() =>
                //    {
                //        Thread.Sleep(100);
                //        Console.WriteLine(k);
                //    }).BeginInvoke(null,null);
                //}
                #endregion
                #region  线程安全
                for (int i = 0; i < 1000; i++)
                {
                    int newI = i;
                    taskList.Add(taskFactory.StartNew(() =>
                    {
                        lock (btnThreadCore_Click_Lock)
                        {
                            this.TotalCount += 1;
                            IntList.Add(newI);
                        } 
                    }));
                }
                #endregion
                Task.WaitAll(taskList.ToArray());
                Console.WriteLine(this.TotalCount);
                Console.WriteLine(this.IntList.Count);
            }
            catch (AggregateException aex)
            {
                foreach (var item in aex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            watch.Stop();
            Console.WriteLine($"*********************************btnThreadcore_Click End {Thread.CurrentThread.ManagedThreadId} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}{watch.ElapsedMilliseconds}");
        }
    }
}
