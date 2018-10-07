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
    public class MiniatureTests
    {
        /*string name, double price, string description, DateTime year, string gameName, string faction, char? size, int? speed, 
                        int? attack, int? strength, int? hitPoints, int? defense*/

        [TestMethod()]
        public void Miniature_CreateMiniature_CreatesMiniatureWithDefaultValuesWhereApplicable()
        {

            //Arrange 
            string name = "testMini";

            double price = 10.00;

            string description = "This is a description";

            int year = 1992;

            string gameName = "testGame";

            string faction = "testFaction";

            char? defaultSize = 'x';

            int? defaultSpeed = 0;

            int? defaultAttack = 0;

            int? defaultStrength = 0;

            int? DefaultHitPoints = 0;

            int? defaultDefense = 0;

            //Act
            Miniature miniToTest = new Miniature(name, price, description, year, gameName, faction);

            //Assert
            Assert.AreEqual(defaultSize, miniToTest.Size);
            Assert.AreEqual(defaultSpeed, miniToTest.Speed);
            Assert.AreEqual(defaultAttack, miniToTest.Attack);
            Assert.AreEqual(defaultStrength, miniToTest.Strength);
            Assert.AreEqual(DefaultHitPoints, miniToTest.HitPoints);
            Assert.AreEqual(defaultDefense, miniToTest.Defense);
        }
    }
}