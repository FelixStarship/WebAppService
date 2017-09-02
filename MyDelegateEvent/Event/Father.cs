using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
   public class Father:IObject
    {
        public void DoAction()
        {
            this.Rora();
        }
        public void Rora()
        {
            Console.WriteLine("{0} Rora",this.GetType().Name);
        }
    }
}
