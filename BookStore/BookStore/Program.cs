using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            string Book1Name = "";
            string Book1Price = "";
            string Book1ISBN = "";
            string Book1Author = "";

            string Book2Name = "";
            string Book2Price = "";
            string Book2ISBN = "";
            string Book2Author = "";

            string Book3Name = "";
            string Book3Price = "";
            string Book3ISBN = "";
            string Book3Author = "";

            Book Book1 = new Book(Book1Name, Book1Author, Book1ISBN, Book1Price);
            Book Book2 = new Book(Book2Name, Book2Author, Book2ISBN, Book2Price);
            Book Book3 = new Book(Book3Name, Book3Author, Book3ISBN, Book3Price);


        }
    }
}
