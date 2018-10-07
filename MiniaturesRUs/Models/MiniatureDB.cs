﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class MiniatureDB
    {
        public static Miniature GetMiniatureById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Minitures.Find(id);
        }

        public static void AddMiniatureToDB(Miniature mini)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Minitures.Add(mini);
            db.SaveChanges();
        }



    }
}