using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xyuxiang.IBLL;

namespace Xyuxiang.BLL
{
    public class PracessBll:IPracessBll
    {
        public int GetSum(int a,int b)
        {
            return a + b;
        }
    }
}
