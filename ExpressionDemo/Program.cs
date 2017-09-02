using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                Func<int, int, int> func = (m, n) => m * n + 2;
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");

                Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(Expression.Add(Expression.Multiply(parameterExpression, parameterExpression2), Expression.Constant(2, typeof(int))), new ParameterExpression[]
                {
                   parameterExpression,
                   parameterExpression2
                });
                var num = expression.Compile().Invoke(3, 4);
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                int iResult = exp.Compile().Invoke(1, 2);
            }
            {   
                Func<int> func=()=> { return default(int); };
                Expression<Func<int>> exp = () => default(int);
                ConstantExpression ConstantExpression = Expression.Constant(1);
                ConstantExpression ConstantExpression2 = Expression.Constant(2);
                Expression<Func<int>> expression = Expression.Lambda<Func<int>>(Expression.Add(ConstantExpression, ConstantExpression2));
                var num = expression.Compile().Invoke();
            }

            {   
                //修改表达式目录树
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                ExpressionVisitorTest visitor =new ExpressionVisitorTest();
                Expression subtract = visitor.Modify(exp);
            }
            People people = new People()
            {
              Name="李阳",
              Age=23,
              Id=21022540
            };
            long cache = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000; i++)
                {
                    PeopleCopy peopleCopy = ExpressionMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                cache = watch.ElapsedMilliseconds;
                Console.WriteLine($"cache={cache} ms");
            }
            {
               long iResult= ExpressionGenericMapper<int>.Trans();
               long iResult2 = ExpressionGenericMapper<int>.Trans();
               long iResult3 = ExpressionGenericMapper<int>.Trans();
               long iResult4= ExpressionGenericMapper<double>.Trans();
            }
        }
    }
}
