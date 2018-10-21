using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class InboxViewModel
    {
        public ApplicationUser User { get; set; }

        public PersonalMessage NewMessage { get; set; }

        public List<PersonalMessage> Messages { get; set; }
    }
}