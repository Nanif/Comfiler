﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL;

namespace BL
{
    public class FileManager
    {
        /// <summary>
        ///   create a new file
        /// </summary>
        public static FileStream CreatFile(out string fileName, string userEmail, string TZ)
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
            SaveNewFile(file, userEmail, TZ);
            return file;
        }

        public static FileStream OpenFile(string fileName)
        {
            fileName = fileName + ".docx";
            using (var file = System.IO.File.Open(fileName, FileMode.Open))
            {
                if (file != null)
                {
                    return file;
                }
            }
            return null;
        }


        private static void SaveNewFile(FileStream file, string userEmail, string TZ)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                // todo convert from the system.io object to my file.
                DAL.File myFile = new DAL.File();
                myFile.ID = file.Name;
                myFile.CreatorID = TZ;
                myFile.Date_Creation = DateTime.Now;
                myFile.Desctiption = "";
                myFile.ExtensionID = 123;
                myFile.Version = 1;
                SaveFileInDB(myFile);
                //    myFile.CreatorID = file. ;
                // than to check it adds to the table.
                //than check the open file if it works.

                //         context.Files.Add(file);
                //         if (file != null)
                //         {
                //             return file;
                //         }
                //     }
                //     return null;
            }
        }

        private static void SaveFileInDB(DAL.File myFile)
        {
            using (DBcomfilerEntities context = new DBcomfilerEntities())
            {
                try
                {
                    context.Files.Add(myFile);
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
    }
}
