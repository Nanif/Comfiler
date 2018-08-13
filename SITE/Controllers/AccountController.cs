using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using DAL;

namespace SITE.Controllers
{
    public class AccountController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TZ,string password)
        {
            User user = Logic.GetUserByTZ(TZ);
            if (user!=null)
            {
                Session["userEmail"]= user.Email;
                var x = Session["userEmail"];
                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}