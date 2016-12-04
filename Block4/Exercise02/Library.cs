using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    public class Library
    {
        private string name;
        public List<Book> bookList;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                    name = value;
                else
                    throw new ArgumentNullException("Library name cannot be empty");
            }
        }

        public List<Book> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }

        public Library(string name)
        {
            Name = name;
            BookList = new List<Book>();
        }


        // several method to perform library actions
        // add option
        public void AddBook(Book newBook)
        {
            bookList.Add(newBook);
        }

        // remove options
        public void RemoveBookByTitle(string title)
        {
            bookList.RemoveAll(book => book.Title == title);
        }

        // ----------------------------------------------------------
        public void RemoveBookByAuthor(string author)
        {
            bookList.RemoveAll(book => book.Author == author);
        }

        // ----------------------------------------------------------
        public void RemoveBookByPublisher(string publisher)
        {
            bookList.RemoveAll(book => book.Publisher == publisher);
        }

        // ----------------------------------------------------------
        public void RemoveBookByISBN(string number)
        {
            bookList.RemoveAll(book => book.NumberISBN == number);
        }


        // search options
        public List<Book> SearchBookByTitle(string title)
        {     
            return bookList.FindAll(book => book.Title == title);
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByAuthor(string author)
        {
            return bookList.FindAll(book => book.Author == author);
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByPublisher(string publisher)
        {
            return bookList.FindAll(book => book.Publisher == publisher);
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByISBN(string number)
        {
            return bookList.FindAll(book => book.NumberISBN == number);
        }


        // display information about a book
        public string DisplayInfo(Book book)
        {
            const string fullInfo = "Title: {0}\nAuthor: {1}\nPublisher: {2}\nISBN: {3}\nRelease Date: {4}\n" ;
            return string.Format(fullInfo, book.Title, book.Author, book.Publisher, book.NumberISBN, book.ReleaseDate.Year); 
        }
    }
}
