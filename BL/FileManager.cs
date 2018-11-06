using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL;
using System.Text.RegularExpressions;
using DocxSearcher;

namespace BL
{
    public class FileManager
    {
        /// <summary>
        ///   create a new file
        /// </summary>
        public static FileStream CreatFile(out string fileName)
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            string[] dateArray = date.Split('-');
            string path = @"C:\Users\user1\Documents\GitHub\Comfiler\files\";
            foreach (string time in dateArray)
            {
                path += time + @"\";
            }
            DirectoryInfo di = Directory.CreateDirectory(path);
            Guid guid = Guid.NewGuid();
            fileName = guid + ".docx";
            using (System.IO.File.Create(path + fileName)) { }
            FileStream file = System.IO.File.Create(path + fileName);
            return file;
        }

        public static FileStream OpenFile(out string fileFullName, string fileName, string extentionId)
        {
            DateTime dateCreation = BL.FileManager.GetFileDateByName(fileName);
            string name = @"C:\Users\user1\Documents\GitHub\Comfiler\files\";
            name += dateCreation.Year.ToString();
            name += '\\';
            name += dateCreation.Month.ToString();
            name += '\\';
            name += dateCreation.Day.ToString();
            name += '\\';
            name += fileName;
            name += '.' + GetExtentionById(extentionId);

            FileStream file = System.IO.File.Open(name, FileMode.Open);
            if (file != null)
            {
                fileFullName = name;
                return file;
            }
            fileFullName = "";
            return null;
        }

        private static string GetExtentionById(string extentionId)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                int intExtentionId = int.Parse(extentionId);
                return context.Extensions.FirstOrDefault(x => x.ID == intExtentionId).Extension1;
            }
        }

        public static List<DAL.File> GetFilesByUserSearch()
        {
            throw new NotImplementedException();
        }

        public static DateTime GetFileDateByName(string fileName)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                DAL.File file = context.Files.FirstOrDefault(x => x.ID == fileName);
                {
                    return Convert.ToDateTime(file.Date_Creation);
                }
            }
        }

        public static void SaveNewFileInDB(FileStream file, string TZ, string filedesc, string extention, string remark)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                //todo convert from the system.io object to my file.
                DAL.File newFile = new DAL.File();
                string[] fileLongName = file.Name.Split('\\');
                string[] fileName = fileLongName[fileLongName.Length - 1].Split('.');
                string id = fileName[0];
                newFile.ID = id;
                newFile.CreatorID = TZ;
                newFile.Date_Creation = DateTime.Now;
                newFile.Desctiption = filedesc;
                newFile.ExtensionID = context.Extensions.FirstOrDefault(x => x.Extension1 == extention).ID;
                newFile.Version = 1;
                try
                {
                    context.Files.Add(newFile);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static DAL.File GetFileByName(string fileName)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                var file = context.Files.FirstOrDefault(x => x.ID == fileName);
                if (file != null)
                {
                    return file;
                }
            }
            return null;
        }
        public static IEnumerable<string> Search( string directory,string searchString,bool searchSubdirectories, bool caseSensitive, bool useRegex)
        {
            var isMatch = useRegex ? new Predicate<string>(x => Regex.IsMatch(x, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"))
                : new Predicate<string>(x => x.IndexOf(searchString, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0);
            // TODO rekorsive to all the directories in this directory
            foreach (var filePath in Directory.GetFiles(directory, "*.docx", searchSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                string docxText;

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (stream.Length==0)
                    {
                        continue;
                    }
                    docxText = new DocxToStringConverter(stream).Convert();
                }
                if (isMatch(docxText))
                    yield return filePath;
            }
        }
    }
}
