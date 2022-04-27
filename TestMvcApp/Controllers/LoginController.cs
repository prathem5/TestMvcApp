using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestMvcApp.Models;

namespace TestMvcApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin loginDetails)
        {
            UserContext context = new UserContext();
            var details = context.UserLoginTable.FirstOrDefault(user => user.Username == loginDetails.Username);
            if(details != null && details.Password == loginDetails.Password)
            {
                FormsAuthentication.SetAuthCookie(loginDetails.Username, false);
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}