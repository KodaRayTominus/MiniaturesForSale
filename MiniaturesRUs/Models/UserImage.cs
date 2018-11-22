using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class UserImage
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}