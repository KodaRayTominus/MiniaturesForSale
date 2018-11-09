using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class MessageDB
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        public static List<PersonalMessage> GetAllMessageForUserById(string id)
        {
            List<PersonalMessage> messages = (from m in db.PersonalMessages
                                              where m.RecipientID == id || m.SenderID == id
                                              select m).ToList();

            return messages;
        }

        public static PersonalMessage GetMessageById(int? id)
        {
            return db.PersonalMessages.Find(id);
        }

        public static void AddMessage(PersonalMessage message)
        {
            db.PersonalMessages.Add(message);
            db.SaveChanges();
        }
    }
}