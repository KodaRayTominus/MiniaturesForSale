﻿using System;
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

        [ForeignKey("PersonId")]
        [Column(Order = 2)]
        public int BuyerId { get; set; }

        [ForeignKey("PersonId")]
        [Column(Order = 3)]
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