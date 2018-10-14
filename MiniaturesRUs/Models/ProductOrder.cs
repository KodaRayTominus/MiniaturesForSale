﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniaturesRUs.Models
{
    public class ProductOrder
    {

        [ForeignKey("OrderId")]
        [Column(Order = 1)]
        public int OrderId { get; set; }


        [ForeignKey("MiniId")]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public ProductOrder()
        {
        }

        public ProductOrder(int orderId, int productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}