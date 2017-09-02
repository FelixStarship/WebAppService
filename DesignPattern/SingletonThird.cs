using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
   public class SingletonThird
    {   

        private static SingletonThird _SingletonThird = new SingletonThird();
        public static SingletonThird CreateInstance()
        {
            return _SingletonThird;
        }
    }
}
