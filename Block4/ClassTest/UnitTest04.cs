using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise04;

namespace ClassTest
{
    [TestClass]
    public class UnitTest04
    {
        static DoubleLinkedList<string> sList;

        [TestInitialize]
        public void TestInitialize()
        {
            sList = new DoubleLinkedList<string>("hello", "world");
        }

        // to array
        [TestMethod]
        public void ToArray()
        {
            string[] array = sList.ToArray();
            string[] expected = { "hello", "world" };

            CollectionAssert.AreEqual(expected, array);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
