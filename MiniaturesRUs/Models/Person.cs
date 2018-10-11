using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Person
    {

        [Key]
        public int Personid { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string UserName { get; set; }

        public int? AccountId { get; set; }

        public Person()
        {
        }

        public Person(string name, string userName, int accountId)
            : this(name, "", userName,accountId)
        {
        }

        public Person(string name, string address, string userName, int accountId)
        {
            Name = name;
            Address = address;
            UserName = userName;
            AccountId = accountId;
        }
    }
}