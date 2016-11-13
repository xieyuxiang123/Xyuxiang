using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Xyuxiang.BLL;
using Xyuxiang.IBLL;

namespace ConfiguationMap
{
    public class Configuation
    {
        public static void BostrupConfig()
        {
            ObjectFactory.Configure(x => x.For<IPracessBll>().Use<PracessBll>());
        }
    }
}
