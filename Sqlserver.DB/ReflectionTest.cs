using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqlserver.DB
{
  public  class ReflectionTest
    {
        public ReflectionTest()
        {
            Console.WriteLine("这里是{0}无参数构造函数",this.GetType());
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine("这里是{0}无参数构造函数",this.GetType());
        }

        public ReflectionTest(int id)
        {
            Console.WriteLine("这里是{0}无参数构造函数", this.GetType());
        }

        /// <summary>
        /// 无参方法
        /// </summary>
        public void Show1()
        {
            Console.WriteLine("这里是{0}的Show1", this.GetType());
        }

        /// <summary>
        /// 无参方法
        /// </summary>
        public void Show2(string name)
        {
            Console.WriteLine("这里是{0}的Show2_{1}", this.GetType(),name);
        }
    }
}
