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

        private string Name { get; set; }

        private string Address { get; set; }

        private string UserName { get; set; }

        private int AccountId { get; set; }

        public Person()
        {
        }

        public Person(string name)
            : this(name, "", "", 0)
        {
        }

        public Person(string name, string address)
            : this(name, address, "", 0)
        {
        }

        public Person(string name, string address, string userName)
            : this(name, address, userName, 0)
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