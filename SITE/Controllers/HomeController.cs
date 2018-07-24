using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SITE.Filters;
using BL;
namespace SITE.Controllers
{
   // [AoutoFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult SendEmail(string userName, string password)
        {
            //יש לשנות את התנאי לתנאי אמיתי
            if (true)
            {
               //אם תהנתונים תקינים יש לשלוח את המייל לנמען
            }
            return RedirectToAction("Index");
        }
        public ActionResult SendEmail() {
            return PartialView("_sendEmailForm");
        }
        public ActionResult Template() {
            Logic.AddTamplate();
            
            return RedirectToAction("Index");

        }
    }
}