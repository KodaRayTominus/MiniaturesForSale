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
    }
}