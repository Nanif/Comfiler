using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.IO;

namespace BL
{
    public class Logic
    {
        #region Users
        public static List<User> GetAllUsers()
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                var users = context.Users.ToList();
                if (users != null)
                    return users;
            }
            return null;
        }

        public static List<Category> GetAllCategories()
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                var categories = context.Categories.ToList();
                if (categories != null)
                    return categories;
            }
            return null;
        }

           public static User GetUserByUserName(string userName)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == userName);
                if (user != null)
                    return user;
            }
            return null;
        }

        private static string GetUserNameByEmail(string sendEmail)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Email == sendEmail);
                if (user != null)
                    return user.UserName;
            }
            return null;
        }


        #endregion

        #region Files
        public static List<FilesDetail> GetAllFilesDetail()
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                List<DAL.FilesDetail> files = context.FilesDetails.ToList();
                if (files != null)
                    return files;
            }
            return null;
        }
        public static List<DAL.File> GetAllFiles()
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                List<DAL.File> files = context.Files.ToList();
                if (files != null)
                    return files;
            }
            return null;
        }

        public static List<DAL.Extension> GetAllExtentions()
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                List<Extension> extentions= context.Extensions.ToList();
                if (extentions != null)
                {
                    return extentions;
                }
                return null;
            }
        }
        #endregion

        #region others
        public static void SendLinkInEmail(string subject, string emailAddress, string sendEmail)
        {
            string sendName = GetUserNameByEmail(sendEmail);
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress("neomi2152@gmail.com", sendName);
                m.To.Add(new MailAddress(emailAddress));

                //to do add option to send multiple emails in one click
                //to do how to send the file? or the link to file?

                string linkToFile = "https://mail.google.com/mail/u/0/#search/langbracha%40gmail.com/16531d134e3deb76?projector=1&messagePartId=0.1";
                m.Subject = subject; m.IsBodyHtml = true; m.Body = "  לצפייה בקובץ לחץ על הקישור המצורף" + linkToFile;

                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new NetworkCredential("comfiler.site@gmail.com", "comfiler123");

                sc.EnableSsl = true;
                sc.Send(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        #endregion

    }
}
