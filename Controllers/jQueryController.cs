using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Role_based_auth.Controllers
{
    public class jQueryController : Controller
    {
        // GET: jQuery
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Export()
        {
            //https://github.com/posabsolute/jQuery-Validation-Engine
            return RedirectToAction("Index");
        }
    }
}