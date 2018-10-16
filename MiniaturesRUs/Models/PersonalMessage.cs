using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class PersonalMessage
    {
        [Key]
        public int MessageID { get; set; }

        [Required]
        [ForeignKey("Sender")]
        [Column(Order = 2)]
        public int SenderID { get; set; }

        [ForeignKey("Recipient")]
        [Required]
        [Column(Order = 3)]
        public int RecipientID { get; set; }

        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public Person Sender { get; set; }
        
        public Person Recipient { get; set; }

        public PersonalMessage(int senderID, int recipientID, string message)
            :this(senderID, recipientID, "", message)
        {
        }

        public PersonalMessage(int senderID, int recipientID, string title, string message)
        {
            SenderID = senderID;
            RecipientID = recipientID;
            Title = title;
            Message = message;
        }
    }
}