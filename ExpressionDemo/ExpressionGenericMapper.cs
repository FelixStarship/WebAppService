using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    public class ExpressionGenericMapper<TOut>
    {
         private static Func<int> _Func = null;
         private static int iResult = 0;
         static ExpressionGenericMapper()
         {
            iResult++;
            Console.WriteLine($"iResult={iResult}");
            _Func += () => iResult;
         }

         public static int Trans()
         {
            return _Func();
         }
    }
}
