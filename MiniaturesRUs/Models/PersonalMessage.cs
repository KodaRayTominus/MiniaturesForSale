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
        [MaxLength(128)]
        public string SenderID { get; set; }

        [ForeignKey("Recipient")]
        [Required]
        [Column(Order = 3)]
        [MaxLength(128)]
        public string RecipientID { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }

        public ApplicationUser Sender { get; set; }
        
        public ApplicationUser Recipient { get; set; }

        public PersonalMessage(string senderID, string recipientID, string message)
            :this(senderID, recipientID, "", message)
        {
        }

        public PersonalMessage(string senderID, string recipientID, string title, string message)
        {
            SenderID = senderID;
            RecipientID = recipientID;
            Title = title;
            Message = message;
        }
    }
}