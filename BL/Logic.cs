using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class Logic
    {
        #region Users
        public static List<User> GetAllUsers()
        {
            using (DBcomfilerEntities2 context = new DBcomfilerEntities2())
            {
                var users = context.Users.ToList();
                if (users != null)
                    return users;
            }
            return null;
        }

        public static User GetUserByTZ(string tz)
        {
            using (DBcomfilerEntities2 context = new DBcomfilerEntities2())
            {
                var user = context.Users.FirstOrDefault(x => x.TZ == tz);
                if (user != null)
                    return user;
            }
            return null;
        }

        #endregion

        #region Files
        public static List<File> GetAllFiles()
        {
            using (DBcomfilerEntities2 context = new DBcomfilerEntities2())
            {
                var files = context.Files.ToList();
                if (files != null)
                    return files;
            }
            return null;
        }
        #endregion

    }
}
