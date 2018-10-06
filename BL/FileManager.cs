using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            using ( File.Create(path + fileName)) { }
            FileStream file = File.Create(path + fileName);
            return file;
        }

        public static FileStream OpenFile(out string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
