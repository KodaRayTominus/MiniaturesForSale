using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class PersonDB
    {
        public static Person GetPersonById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.People.Find(id);
        }

        public static void AddPersonToDB(Person person)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.People.Add(person);
            db.SaveChanges();
        }

        public static void UpdatePerson(Person person)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeletePerson(Person person)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.People.Remove(person);
            db.SaveChanges();
        }
    }
}