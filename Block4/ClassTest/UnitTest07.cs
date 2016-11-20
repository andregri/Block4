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
    }
}
