using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class ProductOrderDB
    {
        public static ProductOrder GetProductOrderById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.ProductOrders.Find(id);
        }

        public static void AddProductOrderToDB(ProductOrder ProductOrder)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.ProductOrders.Add(ProductOrder);
            db.SaveChanges();
        }

        public static void UpdateProductOrder(ProductOrder ProductOrder)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Entry(ProductOrder).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteProductOrder(ProductOrder ProductOrder)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.ProductOrders.Remove(ProductOrder);
            db.SaveChanges();
        }
    }
}