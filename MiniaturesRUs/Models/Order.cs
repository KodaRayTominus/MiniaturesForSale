using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [ForeignKey("Person")]
        [Column(Order = 1)]
        public int BuyerId { get; set; }

        [ForeignKey("Person")]
        [Column(Order = 2)]
        public int SellerId { get; set; }

        public Order()
        {
        }

        public Order(int buyerId, int sellerId)
        {
            BuyerId = buyerId;
            SellerId = sellerId;
        }
    }
}