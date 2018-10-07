using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using BL;

namespace SITE.Models
{
    public class ViewModelUsersFiles
    {
        public List<User> Users { get; set; }
        public List<File> Files { get; set; }
        public List<Category> categories { get; set; }
        
        public List<FilesDetail> FilesDetail { get; set; }
        public ViewModelUsersFiles()
        {
            FilesDetail = Logic.GetAllFilesDetail();
            Users = Logic.GetAllUsers();
            Files = Logic.GetAllFiles();
            categories = Logic.GetAllCategories();
        }
    }
}