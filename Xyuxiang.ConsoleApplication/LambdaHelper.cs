using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Expression = System.Linq.Expressions.Expression;

namespace Xyuxiang.ConsoleApplication
{
    /// <summary>
    /// 
    /// </summary>
    public class LambdaHelper
    {
        /// <summary>
        /// 创建lambda表达式：(string s,int len) => s.Length > len && len >=10;
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<string, int, bool>> TestExpressionReturnBool()
        {
            //(string s,int len) => s.Length > len && len >=10;
            ParameterExpression s = Expression.Parameter(typeof(string), "s");
            ParameterExpression len = Expression.Parameter(typeof(int), "len");
            var constant = Expression.Constant(10);
            MemberExpression member = Expression.PropertyOrField(s, "Length");
            var query1 = Expression.GreaterThan(member, len);
            var query2 = Expression.GreaterThan(len, constant);
            var query = Expression.And(query1, query2);
            return Expression.Lambda<Func<string, int, bool>>(query, s, len);
        }

        /// <summary>
        /// 创建lambda表达式：(double x,double y) => new System.Windows.Point() { X = Math.Sin(x), Y = Math.Cos(y) }
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<double, double, Point>> TestExpressionMath()
        {
            //(double x,double y) => new System.Windows.Point() { X = Math.Sin(x), Y = Math.Cos(y) }
            var pointType = typeof(Point);
            var memeberX = pointType.GetProperty("X");
            var memeberY = pointType.GetProperty("Y");
            var creatPoint = Expression.New(pointType);
            var paramX = Expression.Parameter(typeof(double), "x");
            var paramY = Expression.Parameter(typeof(double), "y");
            var mathSin = typeof(Math).GetMethod("Sin");
            var callMathSin = Expression.Call(null, mathSin, paramX);
            var mathCos = typeof(Math).GetMethod("Cos");
            var callMathCos = Expression.Call(null, mathCos, paramY);
            var xBind = Expression.Bind(memeberX, callMathSin);
            var yBind = Expression.Bind(memeberY, callMathCos);
            var inits = Expression.MemberInit(creatPoint, xBind, yBind);
            //Expression<Func<double, double, Point>> labExpression = Expression.Lambda<Func<double, double, Point>>(inits, paramX, paramY);
            return Expression.Lambda<Func<double, double, Point>>(inits, paramX, paramY);
        }
    }
}
