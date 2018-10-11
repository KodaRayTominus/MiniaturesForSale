using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Person
    {
        public int Personid { get; set; }

        private string Name { get; set; }

        private string Address { get; set; }

        private string UserName { get; set; }

        private int AccountId { get; set; }

        public Person()
        {
        }

        public Person(int personid)
            : this(personid, "", "", "", 0)
        {
        }

        public Person(int personid, string name)
            : this(personid, name, "", "", 0)
        {
        }

        public Person(int personid, string name, string address)
            : this(personid, name, address, "", 0)
        {
        }

        public Person(int personid, string name, string address, string userName)
            : this(personid, name, address, userName, 0)
        {
        }

        public Person(int personid, string name, string address, string userName, int accountId)
        {
            Personid = personid;
            Name = name;
            Address = address;
            UserName = userName;
            AccountId = accountId;
        }
    }
}