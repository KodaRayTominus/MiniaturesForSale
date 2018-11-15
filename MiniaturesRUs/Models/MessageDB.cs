using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class MessageDB
    {
        public static List<PersonalMessage> GetAllMessageForUserById(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            List<PersonalMessage> messages = (from m in db.PersonalMessages
                                              where m.RecipientID == id || m.SenderID == id
                                              select m).ToList();

            return messages;
        }

        public static PersonalMessage GetMessageById(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.PersonalMessages.Find(id);
        }

        public static void AddMessage(PersonalMessage message)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            db.PersonalMessages.Add(message);
            db.SaveChanges();
        }
    }
}