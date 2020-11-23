using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManagementApi.Controllers
{
    public class StatusController : Controller
    {
        public JsonResult StatusCheck()
        {
            var status = new { IsAlive = "true"};
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
