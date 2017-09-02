using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    class Program
    {
        static void Main(string[] args)
        {
            ICache cache = new MemoryCacheCache();
            for (int i = 0; i < 5; i++)
            {
                if (!cache.Contains("DBHelper"))
                    cache.Add("DBHelper", DBHelper.Query<Program>());
                else
                {
                   List<Program> programList = cache.Get<List<Program>>("DBHelper");
                }
            }
            for (int i = 0; i < 5; i++)
            {
                List<Program> programList = CacheManage.Get<List<Program>>("FileHelper", () => FileHelper.Query<Program>(), 30);
            }
        }
    }
}
