using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise10;

namespace ClassTest
{
    [TestClass]
    public class UnitTest10
    {
        Employee[] workers;

        [TestInitialize]
        public void TestEmployee()
        {
            workers = new Employee[]
            {
                new HourlyWorker("Pippo", 10.5m, 200m),
                new HourlyWorker("Paperino",15.25m, 150m),
                new SalaryWorker("ZioPaperone",15000000m),
                new SalaryWorker("Gastaldo", 12000000m)
            };

        }
        [TestMethod]
        public void CheckHourPay()
        {
            Assert.AreEqual(2100m, workers[0].calcPaidCheck());
            Assert.AreEqual(2287.5m, workers[1].calcPaidCheck());
        }

        [TestMethod]
        public void CheckAnnualPay()
        {
            Assert.AreEqual(1250000m, workers[2].calcPaidCheck());
            Assert.AreEqual(1000000m, workers[3].calcPaidCheck());
        }
    }
}
