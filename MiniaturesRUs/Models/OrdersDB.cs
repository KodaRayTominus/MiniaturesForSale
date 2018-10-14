using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class OrdersDB
    {
        public static Order GetOrderById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Orders.Find(id);
        }

        public static void AddOrderToDB(Order Order)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Orders.Add(Order);
            db.SaveChanges();
        }

        public static void UpdateOrder(Order Order)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Entry(Order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteOrder(Order Order)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Orders.Remove(Order);
            db.SaveChanges();
        }
    }
}