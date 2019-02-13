using System;
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
    public partial class BookStoreGUI : Form
    {
        public const Double tax = .1;
        public Double? Subtotal = 0;
        public BookStoreGUI()
        {
            InitializeComponent();
            this.AutoSize = true; //resize auto
            this.dataGridView1.AllowUserToAddRows = false; //disable user changes

        }
        
        private void AddTitle_Click(object sender, EventArgs e)
        {
             //get title of book
            try
            {
                int Quantity;
                bool Qty = int.TryParse(QuantityText.Text, out Quantity); //grab number input
                if (Qty && Quantity != 0 && !(Quantity < 0)) //handle exception 0 and negative numbers
                {
                    decimal? TotalCost = Quantity * Convert.ToDecimal(PriceText.Text);//Get the total
                    // Populate the rows.
                    string SelectedItem = (string)comboBox1.SelectedItem;
                    string[] row = new string[] { SelectedItem, "$" + PriceText.Text, Quantity.ToString(), "$" + TotalCost.ToString() };//populate and add row

                    dataGridView1.Rows.Add(row);
                    Subtotal += Quantity * Convert.ToDouble(PriceText.Text); //add total
                    Subtotal_Text.Text = "$" + Subtotal.ToString();
                    TaxText.Text =(Subtotal * tax).ToString();
                    TotalText.Text = "$" + ((Subtotal * tax) + Subtotal).ToString();
                }
                else { MessageBox.Show("Please enter a valid number");
                    QuantityText.Focus();//cursor on field
                }
            }
            catch {

                MessageBox.Show("Please select a book from the list.");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //event handle when picking an item
        {
            string SelectedItem = (string)comboBox1.SelectedItem;
            string Book1Name = "The Great Gatsby";
            decimal Book1Price = 20.00m;
            string Book1ISBN = "9780743273565";
            string Book1Author = "F. Scott Fitzgerald";

            string Book2Name = "To Kill a Mockingbird";
            decimal Book2Price = 24.95m;
            string Book2ISBN = "9780446310789";
            string Book2Author = "Harper Lee";

            string Book3Name = "Harry Potter";
            decimal Book3Price = 35.00m;
            string Book3ISBN = "978059035342";
            string Book3Author = "J.K. Rowling";

            Book Book1 = new Book(Book1Name, Book1Author, Book1ISBN, Book1Price);
            Book Book2 = new Book(Book2Name, Book2Author, Book2ISBN, Book2Price);
            Book Book3 = new Book(Book3Name, Book3Author, Book3ISBN, Book3Price);
            
            if (SelectedItem == "The Great Gatsby")//match selected object fields
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
                AuthorText.Text = Book3.author;
                IsbnText.Text = Book3.ISBN;
                PriceText.Text = Book3.price.ToString();
            }
            else {
                AuthorText.Clear();
                IsbnText.Clear();
                PriceText.Clear();
                TotalText.Text = "Select a Book to purchase!";
            }
            QuantityText.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuantityText_TextChanged(object sender, EventArgs e)
        {
        }

        private void TotalText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0){//means nothing was added
                MessageBox.Show("Please add a book to check out.");
            }
            else {
                dataGridView1.Rows.Clear(); //clear fields
                ClearTextBoxes();//clear boxes
                MessageBox.Show("Your order has been placed!");
            }
        }

        private void ClearTextBoxes() //Found on stack overflow
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>//lambda expression
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel your order?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                ClearTextBoxes();
                MessageBox.Show("Your order has been cancelled.");
            }
            else if (dialogResult == DialogResult.No) { }
            
        }

        private void BookStoreGUI_Load(object sender, EventArgs e)
        {

        }

        private void AuthorLabel_Click(object sender, EventArgs e)
        {

        }

        private void AuthorText_TextChanged(object sender, EventArgs e)
        {

        }

        private void IsbnText_TextChanged(object sender, EventArgs e)
        {

        }

        private void IsbnLabel_Click(object sender, EventArgs e)
        {

        }

        private void OrderSummaryLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
