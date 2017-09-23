using System.Reflection;
using System;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                Assembly assembly = Assembly.Load("MySql.DB");
                Assembly assembly1 = Assembly.LoadFile(@"D:\用户目录\我的文档\Visual Studio 2015\Projects\WebAppService\MySql.DB\bin\Debug\MySql.DB.dll");
                Assembly assembly2 = Assembly.LoadFrom("MySql.DB.dll");
                foreach (var item in assembly.GetModules())
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in assembly.GetTypes())
                {
                    Console.WriteLine(item.Name);
                }
                Type dbHelperType = assembly.GetType("MySql.DB.MySqlHelper");
                object oDBHelper = Activator.CreateInstance(dbHelperType);
            }
            

            {
                Console.WriteLine("*********反射调用实例方法、静态方法、重载方法*************");
                Assembly assembly = Assembly.Load("Sqlserver.DB");
                Type type = assembly.GetType("Sqlserver.DB.ReflectionTest");



                object oTest = Activator.CreateInstance(type);
                foreach (var item in type.GetMethods())
                {
                    Console.WriteLine(item.Name);
                }
                {
                    MethodInfo methodInfo = type.GetMethod("Show1");
                    methodInfo.Invoke(oTest,null);
                }
                {
                    MethodInfo methodInfo = type.GetMethod("Show2");
                    methodInfo.Invoke(oTest,new object[] { "っ〆星空下的拥抱" });
                }
            }

            Console.ReadKey();
        }
    }
}
