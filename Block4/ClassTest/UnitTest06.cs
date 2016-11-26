using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise06;

namespace ClassTest
{
    [TestClass]
    public class UnitTest06
    {
        int h = 23;
        int m = 45;
        Time t;

        [TestInitialize]
        public void InitializeClass()
        {
            t = new Time(h, m);
        }

        // test properties
        [TestMethod]
        public void HourTest()
        {
            Assert.AreEqual(h, t.Hour);
        }

        [TestMethod]
        public void MinuteTest()
        {
            Assert.AreEqual(m, t.Minute);
        }

        // test to string
        [TestMethod]
        public void ToStringTest1()
        {
            Assert.AreEqual("10:05", new Time(10, 5).ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            Assert.AreEqual("23:45", t.ToString());
        }

        // test overload binary operators + and -
        [TestMethod]
        public void SumTest()
        {
            Time t1 = new Time(9, 30);
            Time sum = t1 + new Time(1, 15);
            Assert.AreEqual("10:45", sum.ToString());
        }

        [TestMethod]
        public void DiffTest()
        {
            Time t1 = new Time(9, 30);
            Time diff = t1 - new Time(1, 15);
            Assert.AreEqual("08:15", diff.ToString());
        }

        // test conversions
        [TestMethod]
        public void TimeToInt()
        {
            Assert.AreEqual(h * 60 + m, (int)t);
        }

        [TestMethod]
        public void TimeToIntOverflow()
        {
            Time t1 = new Time(25, 0); //25 hours will be truncated during conversion
            Assert.AreEqual(60, (int)t1);
        }

        [TestMethod]
        public void IntToTime()
        {
            Time t1 = 120; // Two hours
            Assert.AreEqual(2, t1.Hour);
            Assert.AreEqual(0, t1.Minute);
        }

        [TestMethod]
        public void IntToTimeOverflow()
        {
            int minutes = 25 * 60; // 25 hours: will be truncated during conversion
            Time t1 = minutes;
            Assert.AreEqual(1, t1.Hour);
            Assert.AreEqual(0, t1.Minute);
        }
    }
}
