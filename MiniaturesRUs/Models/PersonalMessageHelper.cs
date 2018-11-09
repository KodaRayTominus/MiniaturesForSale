using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public static class PersonalMessageHelper
    {
        public static void ProcessSender(InboxViewModel myModel, PersonalMessage messageToSend, string userId)
        {
            myModel.User = ApplicationUserDB.GetApplicationUserById(userId);
            myModel.NewMessage.SenderID = myModel.User.Id;
            myModel.NewMessage.Sender = myModel.User;
            messageToSend.SenderID = myModel.User.Id;
        }
        
        public static void ProcessRecipient(InboxViewModel myModel, PersonalMessage messageToSend)
        {
            ApplicationUser Recipient = ApplicationUserDB.GetApplicationUserByUserName(myModel.RecipientName);
            myModel.NewMessage.RecipientID = Recipient.Id;
            myModel.NewMessage.Recipient = Recipient;
            messageToSend.RecipientID = Recipient.Id;
        }
        
        public static void ProcessBody(InboxViewModel myModel, PersonalMessage messageToSend)
        {
            messageToSend.Message = myModel.NewMessage.Message;
            messageToSend.Title = myModel.NewMessage.Title;
            messageToSend.Read = false;
        }
    }
}