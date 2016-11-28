using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise10;

namespace ClassTest
{
    [TestClass]
    public class UnitTest10
    {
        Employee[] workers;
        HourlyWorker[] employee;

        [TestInitialize]
        public void TestEmployee()
        {            
            workers = new Employee[]
            {
                new HourlyWorker("Pippo", 10.5, 200),
                new HourlyWorker("Paperino",15.25, 150),
                new SalaryWorker("ZioPaperone",15000000),
                new SalaryWorker("Gastaldo", 12500000)
            };

        }
        [TestMethod]
        public void CheckHourPay()
        {
            Assert.AreEqual(2100, workers[0].calcPaidCheck());
            Assert.AreEqual(2287.5, workers[1].calcPaidCheck());
        }

        public void CheckAnnualPay()
        {
            Assert.AreEqual(1250000, workers[2].calcPaidCheck());
            Assert.AreEqual(1041666.667, workers[3].calcPaidCheck());
        }
    }
}
