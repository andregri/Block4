using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise02;

namespace ClassTest
{
    [TestClass]
    public class UnitTest02
    {
        Library myLibrary = new Library("MyLibrary");

        Book bookOne;
        Book bookTwo;
        Book bookThree;
        Book bookFour;
        Book bookFive;

        [TestInitialize]
        public void BookInitialize()
        {
            bookOne = new Book("Joyland", "Sthepen King", "Hard Case Crime", "1781167699", new DateTime(2013, 1, 1));
            myLibrary.AddBook(bookOne);

            bookTwo = new Book("The Stand", "Sthepen King", "Doubleday", "978-0-385-12168-2", new DateTime(1978, 1, 1));
            myLibrary.AddBook(bookTwo);

            bookThree = new Book("It", "Sthepen King", "Viking", "0-670-81302-8", new DateTime(1986, 1, 1));
            myLibrary.AddBook(bookThree);

            bookFour = new Book("Animal Farm", "George Orwell", "Secker & Warburg", "0451526341", new DateTime(1945, 1, 1));
            myLibrary.AddBook(bookFour);

            bookFive = new Book("1984", "George Orwell", "Secker & Warburg", "0-547-24964-0", new DateTime(1949, 1, 1));
            myLibrary.AddBook(bookFive);
        }

        [TestMethod]
        public void TestInformation()
        {
            Assert.AreEqual("Joyland", bookOne.Title);
            Assert.AreEqual("Sthepen King", bookTwo.Author);
            Assert.AreEqual("0-670-81302-8", bookThree.NumberISBN);
            Assert.AreEqual("Secker & Warburg", bookFour.Publisher);
            Assert.AreEqual(new DateTime(1949, 1, 1), bookFive.ReleaseDate);
        }


        [TestMethod]
        public void TestSearchBookByAuthor()
        {
            List<Book> expected = new List<Book>();
            expected.Add(bookOne);
            expected.Add(bookTwo);
            expected.Add(bookThree);

            CollectionAssert.AreEqual(expected, myLibrary.SearchBookByAuthor("Sthepen King"));
        }

        [TestMethod]
        public void TestRemoveBookByAuthor()
        {
            List<Book> expected = new List<Book>();
            expected.Add(bookFour);
            expected.Add(bookFive);

            myLibrary.RemoveBookByAuthor("Sthepen King");

            CollectionAssert.AreEqual(expected, myLibrary.BookList);
        }

        [TestMethod]
        public void TestCheckInformation()
        {
            string expectedBookFour = "Title: Animal Farm\nAuthor: George Orwell\nPublisher: Secker & Warburg\nISBN: 0451526341\nRelease Date: 1945\n";
            string expectedBookFive = "Title: 1984\nAuthor: George Orwell\nPublisher: Secker & Warburg\nISBN: 0-547-24964-0\nRelease Date: 1949\n";

            Assert.AreEqual(expectedBookFour, myLibrary.DisplayInfo(bookFour));
            Assert.AreEqual(expectedBookFive, myLibrary.DisplayInfo(bookFive));

        }


    }
}
