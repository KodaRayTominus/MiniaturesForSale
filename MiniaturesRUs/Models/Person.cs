using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    /// <summary>
    /// A class representation of a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Primary Key ID
        /// </summary>
        [Key]
        public int PersonId { get; set; }

        /// <summary>
        /// Persons First and LastName
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A Persons Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// UserName to be used for display and login purposes
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 7)]
        public string UserName { get; set; }

        /// <summary>
        /// Foreign Key Linking Person to sensitive account details
        /// </summary>
        public int? AccountId { get; set; }

        /// <summary>
        /// Biography of the person
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The persons favorite game to be displayed
        /// </summary>
        public string FavoriteGame { get; set; }

        /// <summary>
        /// The persons nickname to be displayed
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Persons contact phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// A persons personal fan fiction for their fan faction
        /// </summary>
        public string FactionFanFiction { get; set; }

        /// <summary>
        /// details on a persons past experience with miniatures and gaming
        /// </summary>
        public string PastExperience { get; set; }

        /// <summary>
        /// List of different expertise
        /// </summary>
        public List<string> Expertise { get; set; }

        /// <summary>
        /// Miniatures that the person is interested in buying
        /// </summary>
        public List<int> WishList { get; set; }

        /// <summary>
        /// Miniatures the person wants to keep tabs on
        /// </summary>
        public List<int> WatchList { get; set; }

        /// <summary>
        /// miniatures the person owns
        /// </summary>
        public List<int> Owned { get; set; }

        /// <summary>
        /// No arg constructor
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Constructor with default values
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <param name="userName">UserName of the person</param>
        /// <param name="accountId">AccountID to be attached to the person</param>
        public Person(string name, string userName, int accountId)
            : this(name, "", userName,accountId)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <param name="address">Address of the person</param>
        /// <param name="userName">UserName of the person</param>
        /// <param name="accountId">AccountID to be attached to the person</param>
        public Person(string name, string address, string userName, int accountId)
        {
            Name = name;
            Address = address;
            UserName = userName;
            AccountId = accountId;
        }
    }
}