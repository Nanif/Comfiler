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
        public static User GetUserByTZ(string tz)
        {
            using(DBcomfilerEntities1 context=new DBcomfilerEntities1())
            {
                //todo לחבר את הדטבייס 
              var user = context.Users.FirstOrDefault(x => x.TZ == tz);
              if (user != null)
                    return user;
            }
            return null;
        }
    }
}
