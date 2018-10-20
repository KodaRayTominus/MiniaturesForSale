using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Order
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [ForeignKey("Person")]
        [Column(Order = 2)]
        [MaxLength(128)]
        public string BuyerId { get; set; }

        [ForeignKey("Person2")]
        [Column(Order = 3)]
        [MaxLength(128)]
        public string SellerId { get; set; }

        public ApplicationUser Person { get; set; }

        public ApplicationUser Person2 { get; set; }

        public Order()
        {
        }

        public Order(string buyerId, string sellerId)
        {
            BuyerId = buyerId;
            SellerId = sellerId;
        }
    }
}