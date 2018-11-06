using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using SITE.Filters;
using SITE.Models;
using System.Configuration;
using System.Collections.Specialized;

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

        public PartialViewResult Table()
        {
            var ViewModelUsersFiles = new ViewModelUsersFiles();
            return PartialView("_PartialViewTable", ViewModelUsersFiles);

        }

        [HttpPost]
        public ActionResult SendEmail(string subject, string emailAddress)
        {
            string sendEmail = Session["userEmail"].ToString();
            BL.Logic.SendLinkInEmail(subject, emailAddress, sendEmail);
            return RedirectToAction("Table");
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
        public ActionResult CreateFile(string fileCategory, string filedesc, string fileKind, string remark)
        {
            string fileName = "";
            FileStream file = BL.FileManager.CreatFile(out fileName);
            BL.FileManager.SaveNewFileInDB(file, Session["TZ"].ToString(), filedesc, fileKind, remark);
            var ViewModelUsersFiles = new ViewModelUsersFiles();
            return PartialView(ViewModelUsersFiles);
        }

        public FileResult OpenFile(string fileName, string extention)
        {
            FileStream file = BL.FileManager.OpenFile(out string fileFullName, fileName, extention);
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, fileFullName);
        }
        [HttpGet]
        public ActionResult SearchFile(string category, string startDate, string endDate, string creator)
        {
            List<DAL.File> files = BL.FileManager.GetFilesByUserSearch();
            // for now
            return View();
        }


        public ActionResult Search(string content)
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("FilesPath");

               // List<File> file = BL.FileManager.Search(section["path"], @"^[0-9]*$");
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}