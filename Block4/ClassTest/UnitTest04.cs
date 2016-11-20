using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise04;

namespace ClassTest
{
    [TestClass]
    public class UnitTest04
    {
        static DoubleLinkedList<string> sList;
        static string[] sArray;
        static int length;

        [TestInitialize]
        public void TestInitialize()
        {
            sList = new DoubleLinkedList<string>("hello", "world");
            sArray = new string[] { "hello", "world" };
            length = sArray.Length; 
        }

        // to array
        [TestMethod]
        public void ToArray()
        {
            string[] array = sList.ToArray();
            CollectionAssert.AreEqual(sArray, array);
        }

        //insert
        [TestMethod]
        public void InsertTest()
        {
            DoubleLinkedList<string> list = new DoubleLinkedList<string>();
            list.Insert("hello", 0).Insert("world", 1).Insert(", ", 1);

            Assert.AreEqual(3, list.Count);

            string[] expected = { "hello", ", ", "world" };
            string[] array = list.ToArray();

            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertTestNegativeIndex()
        {
            sList.Insert("hello", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertTestIndexTooLarge()
        {
            sList.Insert("hello", sList.Count + 1);
        }
    }
}
