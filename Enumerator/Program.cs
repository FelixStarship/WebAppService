using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {   



            List<object> listobject = new List<object>();

            List<string> liststr = new List<string>();

            //IEnumerable<out T>  out 关键子标识
            //协变的过程 （协变指的是泛型的类型参数可以从一个派生类隐式转换成基类）
            listobject.AddRange(liststr);


            IComparer<object> objectComparer = new TestComparer();

            //逆变的过程（逆变指的是泛型类型参数可以从一个基类隐式转换成派生类）  in关键子标识
            IComparer<string> stringComparer = new TestComparer();

            liststr.Sort(objectComparer);

            //listobject.Sort(stringComparer);

        }
    }
    
    public class TestComparer : IComparer<object>
    {
        public int Compare(object obj1, object obj2)
        {
            return obj1.ToString().CompareTo(obj2.ToString());
        }
    }
}
