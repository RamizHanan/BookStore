using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Book
    {
        public const decimal tax = .08m;

        string author = "";
        string price = "";
        string ISBN = "";
        string bookName = "";

        public Book(string BookName, string Author, string isbn, string Price)
        {
            author = Author;
            price = Price;
            ISBN = isbn;
            bookName = BookName;
        }

        public Book() {
            author = null;
            price = null;
            ISBN = null;
            bookName = null;
        }

    }
    
}
