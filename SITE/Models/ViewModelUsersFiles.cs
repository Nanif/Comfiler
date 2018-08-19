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
        public ViewModelUsersFiles()
        {
            Users = Logic.GetAllUsers();
            Files = Logic.GetAllFiles();
        }
    }
}