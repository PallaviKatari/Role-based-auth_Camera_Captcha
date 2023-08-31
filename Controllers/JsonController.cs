using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;
using Role_based_auth.Models;

namespace Role_based_auth.Controllers
{
    public class JsonController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Files/Customers.json")))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<CustomerModel> customers = serializer.Deserialize<List<CustomerModel>>(reader.ReadToEnd());
                return View(customers);
            }
        }
    }
}