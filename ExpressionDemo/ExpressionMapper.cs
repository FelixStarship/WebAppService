using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace ExpressionDemo
{
    public class ExpressionMapper
    {   
        private static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("funckey_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> MemberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    MemberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    MemberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), MemberBindingList.ToArray());
                Expression<Func<TIn,TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
                {
                    parameterExpression
                });
                Func<TIn, TOut> func = lambda.Compile();
                _Dic[key] = func;
            }
            return ((Func<TIn, TOut>)_Dic[key]).Invoke(tIn);
        }
    }
}
