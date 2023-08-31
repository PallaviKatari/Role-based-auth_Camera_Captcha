using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Role_based_auth.Controllers
{
    public class CameraController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult SaveCapture(string data)
        {
            string fileName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");

            //Convert Base64 Encoded string to Byte Array.
            byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);

            //Save the Byte Array as Image File.
            string filePath = Server.MapPath(string.Format("~/Captures/{0}.jpg", fileName));
            System.IO.File.WriteAllBytes(filePath, imageBytes);

            return Content("true");
        }
    }
}