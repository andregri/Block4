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

        // overload []
        [TestMethod]
        public void IndexersTest()
        {
            string[] array = new string[sList.Count];

            for (int i = 0; i < sList.Count; i++)
            {
                array[i] = sList[i];
            }

            CollectionAssert.AreEqual(sArray, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OverloadTestNegativeIndex()
        {
            string s = sList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OverloadTestTooLargeIndex()
        {
            string s = sList[sList.Count + 1];
        }

        // add methods
        [TestMethod]
        public void AddToStartTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(1, 2, 3);
            list.AddToStart(0);
            int[] expected = new int[] { 0, 1, 2, 3 };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AppendTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(1, 2, 3);
            list.Append(4);
            int[] expected = new int[] { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        // find
        [TestMethod]
        public void FindTest()
        {
            DoubleLinkedListNode<string> node = sList.Find("hello");
            Assert.AreEqual(sList.Head, node);
        }

        [TestMethod]
        public void FindTestNotFound()
        {
            DoubleLinkedListNode<string> node = sList.Find("zzhsdjfk");
            Assert.AreEqual(null, node);
        }

        // remove
        [TestMethod]
        public void RemoveTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(1, 2, 3);
            list.Remove(2);

            int[] expected = new int[] { 1, 3 };
            CollectionAssert.AreEqual(expected, list.ToArray());
            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(3, list.Tail.Value);
        }

        [TestMethod]
        public void RemoveHeadTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(1, 2, 3);
            list.Remove(1);

            int[] expected = new int[] { 2, 3 };
            CollectionAssert.AreEqual(expected, list.ToArray());
            Assert.AreEqual(2, list.Head.Value);
        }

        [TestMethod]
        public void RemoveTailTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>(1, 2, 3);
            list.Remove(3);

            int[] expected = new int[] { 1, 2 };
            CollectionAssert.AreEqual(expected, list.ToArray());
            Assert.AreEqual(2, list.Tail.Value);
        }
    }
}
