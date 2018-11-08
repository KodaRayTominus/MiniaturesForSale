using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class ApplicationUserDB
    {


        static ApplicationDbContext db = new ApplicationDbContext();


        public static ApplicationUser GetApplicationUserById(int? id)
        {
            return db.Users.Find(id);
        }

        public static void UpdateApplicationUser(ApplicationUser user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        internal static ApplicationUser GetApplicationUserByUserName(string recipientName)
        {
            List<ApplicationUser> temp = db.Users.Where(u => u.UserName == recipientName).ToList();

            return temp[0];
        }
    }
}