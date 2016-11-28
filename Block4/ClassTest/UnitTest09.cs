using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise09;

namespace ClassTest
{
    [TestClass]
    public class UnitTest09
    {
        MenuItem[] menu;

        [TestInitialize]
        public void TestMenu()
        {
            menu = new MenuItem[]
            {
                new Beverage("Lizard Wine", 5.20, 7.45, 9.60),
                new Beverage("Bilk", 2.00, 3.50, 5.00),
                new Beverage("Coco Voda", 7.50, 9.00, 12.00),
                new Beverage("Manhattan", 9.00, 11.00, 14.00),
                new Snack("Plasmon", 2.66),
                new Snack("Ringo", 1.04),
                new Snack("Mikado", 1.87),
            };
        }

        [TestMethod]
        public void TestBeverageAndSnack()
        {            
            Assert.AreEqual("Lizard Wine - Small: € 5,20, Medium: € 7,45, Large: € 9,60", menu[0].printToString());
            Assert.AreEqual("Bilk - Small: € 2,00, Medium: € 3,50, Large: € 5,00", menu[1].printToString());
            Assert.AreEqual("Coco Voda - Small: € 7,50, Medium: € 9,00, Large: € 12,00", menu[2].printToString());
            Assert.AreEqual("Manhattan - Small: € 9,00, Medium: € 11,00, Large: € 14,00", menu[3].printToString());
            Assert.AreEqual("Plasmon - Price: € 2,66", menu[4].printToString());
            Assert.AreEqual("Ringo - Price: € 1,04", menu[5].printToString());
            Assert.AreEqual("Mikado - Price: € 1,87", menu[6].printToString());

        }
    }
}
