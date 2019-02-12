﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            
        }

        private void AddTitle_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = (string)comboBox1.SelectedItem;
            string Book1Name = "The Great Gatsby";
            decimal Book1Price = 20.00m;
            string Book1ISBN = "5632432432";
            string Book1Author = "F. Scott Fitzgerald";

            string Book2Name = "To Kill a Mockingbird";
            decimal Book2Price = 24.95m;
            string Book2ISBN = "S32432423";
            string Book2Author = "Harper Lee";

            string Book3Name = "Harry Potter";
            decimal Book3Price = 35.00m;
            string Book3ISBN = "ASD543223";
            string Book3Author = "J.K. Rowling";

            Book Book1 = new Book(Book1Name, Book1Author, Book1ISBN, Book1Price);
            Book Book2 = new Book(Book2Name, Book2Author, Book2ISBN, Book2Price);
            Book Book3 = new Book(Book3Name, Book3Author, Book3ISBN, Book3Price);
            string test = comboBox1.SelectedText;
            string test2 = e.ToString();
            if (SelectedItem == "The Great Gatsby")
            {
                AuthorText.Text = Book1.author;
                IsbnText.Text = Book1.ISBN;
                PriceText.Text = Book1.price.ToString();
            }
            else if (SelectedItem == "To Kill a Mockingbird")
            {
                AuthorText.Text = Book2.author;
                IsbnText.Text = Book2.ISBN;
                PriceText.Text = Book2.price.ToString();
            }
            else if (SelectedItem == "Harry Potter")
            {
                AuthorText.Text = Book2.author;
                IsbnText.Text = Book2.ISBN;
                PriceText.Text = Book2.price.ToString();
            }
            else {
                AuthorText.Clear();
                IsbnText.Clear();
                PriceText.Clear();
                TotalText.Text = "Select a Book to purchase!";
            }
        }
    }
}