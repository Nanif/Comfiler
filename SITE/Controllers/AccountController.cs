using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
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
        public ActionResult Login(int id)
        {
          //  var user = UserData.GetUserByID(id);
            return View();
        }

    }
}