using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class MiniatureDB
    {
        public static Miniature GetMiniatureById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Miniatures.Find(id);
        }

        public static void AddMiniatureToDB(Miniature mini)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Miniatures.Add(mini);
            db.SaveChanges();
        }

        public static void UpdateMiniature(Miniature miniature)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Entry(miniature).State = EntityState.Modified;
            db.SaveChanges();
        }

        internal static int GetTotalProducts()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            return context.Miniatures.Count();
        }

        internal static List<Miniature> GetProductsByPage(int page, byte pageSize)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Miniature> prodList = context
                                        .Miniatures
                                        .Take(pageSize) //grabs one page worth of products, equivilent to sql offset or fetch
                                        .OrderBy(p => p.Name)
                                        .Skip((page - 1) * pageSize)
                                        .ToList();

            return prodList;
        }

        public static void DeleteMiniature(Miniature miniature)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Miniatures.Remove(miniature);
            db.SaveChanges();
        }



    }
}