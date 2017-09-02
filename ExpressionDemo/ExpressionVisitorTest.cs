using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionDemo
{
    public class ExpressionVisitorTest:ExpressionVisitor
    {   

        public Expression Modify(Expression expression)
        {
           return base.Visit(expression);
        }
         
        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.Add)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);
                return Expression.Subtract(left, right);
            }
            return base.VisitBinary(b);
        } 
    }
}
