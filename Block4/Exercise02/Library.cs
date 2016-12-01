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
        List<Book> findBook = new List<Book>();

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
            findBook.Clear();     
            findBook = bookList.FindAll(book => book.Title == title);

            return findBook;
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByAuthor(string author)
        {
            findBook.Clear();
            findBook = bookList.FindAll(book => book.Author == author);

            return findBook;
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByPublisher(string publisher)
        {
            findBook.Clear();
            findBook = bookList.FindAll(book => book.Publisher == publisher);

            return findBook;
        }

        // ----------------------------------------------------------
        public List<Book> SearchBookByISBN(string number)
        {
            findBook.Clear();
            findBook = bookList.FindAll(book => book.NumberISBN == number);

            return findBook;
        }


        // display information about a book
        public string DisplayInfo(Book book)
        {
            const string fullInfo = "Title: {0}\nAuthor: {1}\nPublisher: {2}\nISBN: {3}\nRelease Date: {4}\n" ;
            return string.Format(fullInfo, book.Title, book.Author, book.Publisher, book.NumberISBN, book.ReleaseDate.Year); 
        }
    }
}
