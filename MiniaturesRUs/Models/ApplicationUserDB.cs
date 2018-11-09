using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Security.Principal;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;

namespace MiniaturesRUs.Models
{
    public static class ApplicationUserDB
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        public static ApplicationUser GetApplicationUserById(string id)
        {
            return db.Users.Find(id);
        }

        public static void UpdateApplicationUser(ApplicationUser user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static ApplicationUser GetApplicationUserByUserName(string recipientName)
        {
            List<ApplicationUser> temp = db.Users.Where(u => u.UserName == recipientName).ToList();

            return temp[0];
        }
    }
}