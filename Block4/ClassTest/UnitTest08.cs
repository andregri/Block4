using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise08;

namespace ClassTest
{
    [TestClass]
    public class UnitTest08
    {
        Employee e;
        string first = "albert";
        string last = "Green";
        string email = "albert.grenn90@gmail.com";
        string address = "50th street";
        decimal salary = (decimal)300.4;
        DateTime birthday = new DateTime(1990, 1, 4);

        [TestInitialize]
        public void Initialize()
        {
            e = new Employee(first, last, birthday, email, address, salary);
            e.AddAmount(e.Salary);
        }

        [TestMethod]
        public void PaymentAddressTest()
        {
            Assert.AreEqual(address, e.PaymentAddress);
        }

        [TestMethod]
        public void AddAmountTest()
        {
            e.AddAmount(500);
            Assert.AreEqual(800.4m, e.Amount);
        }

        [TestMethod]
        public void RetrieveAmountTest()
        {
            e.RetrieveAmount(100);
            Assert.AreEqual(200.4m, e.Amount);
        }
    }
}
