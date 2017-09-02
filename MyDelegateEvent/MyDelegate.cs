using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    
    public class MyDelegate
    {
        public delegate void NoReturnNoPara();
        
        public  void Show()
        {
            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method.Invoke();
            }
            //多播委托
            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method += () => Console.WriteLine("注册一个委托！");
                method += DoNothingStatic;

                method -= DoNothingStatic;
                method.Invoke();
            }
        }

       
        public void DoNothing()
        {
            Console.WriteLine("晚上好搬砖的小菇凉！");
        }
        private static void DoNothingStatic()
        {
            Console.WriteLine("这是一个静态方法!");
        }
    }


}
