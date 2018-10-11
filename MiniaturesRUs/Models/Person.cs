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
        {
            Personid = personid;
        }

        public Person(int personid, string name)
        {
            Personid = personid;
            Name = name;
        }

        public Person(int personid, string name, string address)
        {
            Personid = personid;
            Name = name;
            Address = address;
        }

        public Person(int personid, string name, string address, string userName)
        {
            Personid = personid;
            Name = name;
            Address = address;
            UserName = userName;
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