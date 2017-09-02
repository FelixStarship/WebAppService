using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{   
    /// <summary>
    /// 创建型设计模式：关注类型的实例化
    /// 结构型设计模式：关注类与类之间的关系
    /// 行为型设计模式：关注行为和对象的分离
    /// 
    /// 饿汉式：
    /// 懒汉式：
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                taskList.Add(taskFactory.StartNew(()=> 
                {
                    Singleton singleton = Singleton.CreateInstance();
                    singleton.Show();
                }));
            }
            //Task.WaitAll(taskList.ToArray());
            //Console.WriteLine("第一轮全部完成!");
            //for (int i = 0; i < 5; i++)
            //{
            //    taskFactory.StartNew(() =>
            //    {
            //        Singleton singleton = Singleton.CreateInstance();
            //        singleton.Show();
            //    });
            //}
            Console.ReadLine();
        }
    }
}
