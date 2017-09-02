using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    class Program
    {
        static void Main(string[] args)
        {   
            MyDelegate myDelegate = new MyDelegate();
            myDelegate.Show();
            {
                Cat cat = new Cat();
                //cat.Miao();
            }
            {
                Cat cat = new Cat();

                //注册委托
                cat.MiaoAction += new Mouse().Run;
                cat.MiaoAction += new Dog().Wang;
                cat.MiaoAction += new Baby().Cry;
                cat.MiaoAction += new Brother().Turn;
                cat.MiaoAction += new Mother().Wispher;
                cat.MiaoAction += new Father().Rora;
                cat.MiaoAction += new Neighbor().Awake;


                cat.MiaoAction += new Stealer().Hide;
                cat.MiaoAction -= new Stealer().Hide;   //是二个不同的实例

                //cat.MiaoActionMethod();
                cat.MiaoAction.Invoke();

                //注册事件
                cat.MiaoEvent += new Mouse().Run;
                cat.MiaoEvent += new Dog().Wang;
                cat.MiaoEvent += new Baby().Cry;
                cat.MiaoEvent += new Brother().Turn;
                cat.MiaoEvent += new Mother().Wispher;
                cat.MiaoEvent += new Father().Rora;
                cat.MiaoEvent += new Neighbor().Awake;


                cat.MiaoEvent += new Stealer().Hide;
                cat.MiaoEvent -= new Stealer().Hide;

                
                //cat.MiaoEventMethod();
            }
        }
        
        /// <summary>
        /// 对源数据根据条件进行过滤
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ExtendWhere<TSource>(IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            List<TSource> Extendlist = new List<TSource>();
            foreach (TSource item in source)
            {
                bool bResult = func.Invoke(item);
                if (bResult)
                {
                    Extendlist.Add(item);
                }
            }
            return Extendlist;
        }
    }
}
