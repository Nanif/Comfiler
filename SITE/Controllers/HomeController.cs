using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SITE.Filters;
using SITE.Models;

namespace SITE.Controllers
{
    [AoutoFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ViewModelUsersFiles = new ViewModelUsersFiles();
            return View(ViewModelUsersFiles);
        }

        [HttpPost]
        public ActionResult SendEmail(string subject, string emailAddress)
        {
           string sendEmail= Session["userEmail"].ToString();
            BL.Logic.SendLinkInEmail(subject, emailAddress,sendEmail);
            return PartialView("_sendEmailForm");
        }
        public ActionResult Template()
        {
            //   Logic.AddTamplate();
            return RedirectToAction("Index");
        }
    }
}