using Role_based_auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Role_based_auth;

namespace Role_based_auth.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public new ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User user) // user.Username, user.Password
        {
            RoleBasedMVCEntities usersEntities = new RoleBasedMVCEntities();
            Validate_User_Result roleUser = usersEntities.Validate_User(user.Username, user.Password).FirstOrDefault();

            string message = string.Empty;
            switch (roleUser.UserId.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated.";
                    break;
                default:
                    //public FormsAuthenticationTicket (int version, string name, DateTime issueDate, DateTime expiration, bool isPersistent, string userData);
                    //FormsAuthentication.FormsCookiePath - Usually the path is set to /, which means the cookie is valid throughout the entire domain.
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(30), false, roleUser.Roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    // We can create a cookie manually or gets applied with the default name .ASPXAUTH
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    // How are cookie expiration and ticket expiration related?
                    // In case of non-persistent cookie, if the ticket is expired, cookie
                    // will also expire, and the user will be redirected to the logon page.
                    // On the other side, if the ticket is marked as persistent, where the
                    // cookie is stored on the client box, browsers can use the same authentication
                    // cookie to log on to the Web site any time. However, we can use the
                    // FormsAuthentication.SignOut method to delete persistent or
                    // non - persistent cookies explicitly
                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Profile");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UserDetails()
        {
            RoleBasedMVCEntities usersEntities = new RoleBasedMVCEntities();
            List<User> users = usersEntities.Users.ToList();
            return View(users);
        }

        //[HttpPost]
        //[Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
