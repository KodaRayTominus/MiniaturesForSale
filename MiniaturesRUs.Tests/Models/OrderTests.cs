using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniaturesRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniaturesRUs.Models.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void Order_CreateOrder_CreatesOrderWithAllParameters()
        {
            //arrange
            string salesPersonId = "1";
            string salesPersonIdToTest = "1";

            string buyerPersonId = "15";
            string buyerPersonIdToTest = "15";

            //act
            Order testOrder = new Order(buyerPersonId, salesPersonId);

            //assert
            Assert.AreEqual(salesPersonIdToTest, testOrder.SellerId);
            Assert.AreEqual(buyerPersonIdToTest, testOrder.BuyerId);
        }

        [TestMethod()]
        public void Order_CreateOrder_CreatesNullOrder()
        {

            //act
            Order tester = new Order();

            //assert
            Assert.AreEqual(null, tester.SellerId);
            Assert.AreEqual(null, tester.BuyerId);
        }

    }
}