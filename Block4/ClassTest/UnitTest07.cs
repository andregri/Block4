using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise07;

namespace ClassTest
{
    [TestClass]
    public class UnitTest07
    {
        // invalid mail
        [TestMethod]
        [ExpectedException(typeof(InvalidMailAddressException))]
        public void InvalidMailTest1()
        {
            Person p = new Person("a", "b", "test@test");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMailAddressException))]
        public void InvalidMailTest2()
        {
            Person p = new Person("a", "b", "@gmail.com");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMailAddressException))]
        public void InvalidMailTest3()
        {
            Person p = new Person("a", "b", "a@a.b");
        }

        //invalid birth date
        [TestMethod]
        [ExpectedException(typeof(FutureBirthdayException))]
        public void InvalidBirthdayTestFuture()
        {
            Person p = new Person("a", "b", DateTime.Now.AddDays(1));
        }

        [TestMethod]
        [ExpectedException(typeof(TooOldBirthdayException))]
        public void InvalidBirthdayTestTooOld()
        {
            Person p = new Person("a", "b", new DateTime(1899, 1, 1));
        }

        // properties

        // Adult
        [TestMethod]
        public void AdultTestOver18()
        {
            DateTime td = DateTime.Today;
            DateTime date = new DateTime(td.Year - 18, td.Month, td.Day + 1);
            Person p = new Person("a", "b", date);
            Assert.IsTrue(p.Adult);
        }

        [TestMethod]
        public void AdultTestUnder18()
        {
            DateTime td = DateTime.Today;
            DateTime date = new DateTime(td.Year - 18, td.Month, td.Day - 1);
            Person p = new Person("a", "b", date);
            Assert.IsFalse(p.Adult);
        }

        // sunSign
        [TestMethod]
        public void SunSignTestAll()
        {
            DateTime date = new DateTime(2000, 1, 25);
            Person p = new Person("a", "b", date);

            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(Person.sunSigns[i], p.SunSign);
                date = date.AddMonths(1);
                p.Birthday = date;
            }
        }

        [TestMethod]
        public void SunSignTest2()
        {
            DateTime date = new DateTime(2000, 1, 3);
            Person p = new Person("a", "b", date);
            Assert.AreEqual(Person.sunSigns[11], p.SunSign);
        }

        // chinese sign
        [TestMethod]
        public void ChineseSignTest()
        {
            Person p = new Person("a", "b", new DateTime(1996, 9, 5));
            Assert.AreEqual(Person.chineseSigns[0], p.ChineseSign);
        }

        // Birthday
        [TestMethod]
        public void IsBirthDayTest()
        {
            Person p = new Person("a", "b", DateTime.Today);
            Assert.IsTrue(p.IsBirthday);
        }

        // screenname
        [TestMethod]
        public void ScreenNameTest()
        {
            Person p = new Person("John", "Doe", new DateTime(1980, 2, 25));
            Assert.AreEqual("johndoe022580", p.ScreenName);
        }
    }
}
