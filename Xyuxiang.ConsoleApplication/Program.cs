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
    class Program
    {
        static void Main(string[] args)
        {
            var b=LambdaHelper.TestExpressionReturnBool().Compile()("www.aabb22.com",11);
            Console.WriteLine(b + "");
            var pint = LambdaHelper.TestExpressionMath().Compile()(30, 60);
            Console.WriteLine(pint.X + "");
            Console.ReadKey();
        }
    }
}
