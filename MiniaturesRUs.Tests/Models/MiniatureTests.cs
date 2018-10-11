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

            int? defaultHitPoints = 0;

            int? defaultDefense = 0;

            //Act
            Miniature miniToTest = new Miniature(name, price, description, year, gameName, faction);

            //Assert
            Assert.AreEqual(defaultSize, miniToTest.Size);
            Assert.AreEqual(defaultSpeed, miniToTest.Speed);
            Assert.AreEqual(defaultAttack, miniToTest.Attack);
            Assert.AreEqual(defaultStrength, miniToTest.Strength);
            Assert.AreEqual(defaultHitPoints, miniToTest.HitPoints);
            Assert.AreEqual(defaultDefense, miniToTest.Defense);
        }

        [TestMethod()]
        public void Miniature_CreateMiniature_CreatesNullMiniature()
        {
            //act
            Miniature miniToTest = new Miniature();

            //assert
            Assert.AreEqual(null, miniToTest.Size);
            Assert.AreEqual(null, miniToTest.Speed);
            Assert.AreEqual(null, miniToTest.Attack);
            Assert.AreEqual(null, miniToTest.Strength);
            Assert.AreEqual(null, miniToTest.HitPoints);
            Assert.AreEqual(null, miniToTest.Defense);
        }

        [TestMethod()]
        public void Miniature_CreateMiniature_CreatesMiniatureWithAllParametersPassed()
        {
            //arrange
            string name = "test";

            double price = 100.00;

            string description = "description";

            int year = 1992;

            string gameName = "GameOne";

            string faction = "FactionGood";

            char? sizeToTest = 's';
            char? size = 's';

            int? speedToTest = 6;
            int? speed = 6;

            int? attackToTest = 5;
            int? attack = 5;

            int? strengthToTest = 8;
            int? strength = 8;

            int? hitPointsToTest = 10;
            int? hitPoints = 10;

            int? defenseToTest = 8;
            int? defense = 8;


            //act
            Miniature miniToTest = new Miniature(name, price, description, year, gameName, faction, size, speed, attack, strength, hitPoints, defense);

            //assert
            Assert.AreEqual(sizeToTest, miniToTest.Size);
            Assert.AreEqual(speedToTest, miniToTest.Speed);
            Assert.AreEqual(attackToTest, miniToTest.Attack);
            Assert.AreEqual(strengthToTest, miniToTest.Strength);
            Assert.AreEqual(hitPointsToTest, miniToTest.HitPoints);
            Assert.AreEqual(defenseToTest, miniToTest.Defense);
        }
    }
}