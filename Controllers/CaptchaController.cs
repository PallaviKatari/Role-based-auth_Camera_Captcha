using Role_based_auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Role_based_auth.Controllers
{
    public class CaptchaController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new RECaptcha());
        }

        [HttpPost]
        public JsonResult AjaxMethod(string response)
        {
            RECaptcha recaptcha = new RECaptcha();
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptcha.Secret + "&response=" + response;
            recaptcha.Response = (new WebClient()).DownloadString(url);
            return Json(recaptcha);
        }
    }
}