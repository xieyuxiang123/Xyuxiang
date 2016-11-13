using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XyuxiangObject.XyuxiangService;

namespace XyuxiangObject.Controllers
{
    public class XyuxiangTestController : Controller
    {
        private readonly XyuxiangServiceClient _xyuxiangServiceClient = new XyuxiangServiceClient();

        //
        // GET: /XyuxiangTest/

        public ActionResult Index()
        {
            var sum = _xyuxiangServiceClient.GetSum(12, 13);
            ViewBag.Sum = sum;
            return View();
        }

    }
}
