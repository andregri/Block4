using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class Book
    {
        private string title;
        private string author;
        private string publisher;
        private int numberISBN;
        private DateTime releaseDate;
        
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public int NumberISBN
        {
            get { return numberISBN; }
            set { numberISBN = value; }
        }
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public Book(string title, string author, string publisher, int isbn, DateTime release)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            NumberISBN = isbn;
            ReleaseDate = release;

        }
    }
}
