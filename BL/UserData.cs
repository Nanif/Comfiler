using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class UserData
    {
        //האם לעשות פה מופע 
        //או לעשות לכל גישה ל
        //database
        //עם 
        // using
        public static  User GetUserByID(int id)
        {
        DBcomfilerEntities1  context = new DBcomfilerEntities1();
            try
            {

              //return context.Users.FirstOrDefault(x=>
            }
            catch (Exception e)
            {

                throw e;
            }
                return null;
        }
    }
}
