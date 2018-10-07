using System;
using System.Collections.Generic;
using System.IO;
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
            string sendEmail = Session["userEmail"].ToString();
            BL.Logic.SendLinkInEmail(subject, emailAddress, sendEmail);
            return PartialView("_sendEmailForm");
        }
        public ActionResult Template()
        {
            //   Logic.AddTamplate();
            return RedirectToAction("Index");
        }
        public ActionResult Try(string name)
        {

            return null;
        }
   /// <summary>
   /// create a new file and download it
   /// </summary>
   /// <returns></returns>
        public FileResult CreateFile()
        {
            string fileName = "";
            FileStream file = BL.FileManager.CreatFile(out fileName,Session["userEmail"].ToString(),Session["TZ"].ToString());
            //Shoud not return a file but add it to the table in the UI
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public FileResult OpenFile(string fileName)
        {
            FileStream file = BL.FileManager.OpenFile(fileName);
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}