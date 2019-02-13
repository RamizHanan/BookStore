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
    public partial class GUI : Form
    {
        public const Double tax = .1;
        public Double? Subtotal = 0;
        public GUI()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.dataGridView1.AllowUserToAddRows = false;

        }
        
        private void AddTitle_Click(object sender, EventArgs e)
        {
            string SelectedItem = (string)comboBox1.SelectedItem;
            try
            {
                int Quantity;
                bool Qty = int.TryParse(QuantityText.Text, out Quantity); //grab number input
                if (Qty && Quantity != 0 && !(Quantity < 0)) //handle exception
                {
                    decimal? TotalCost = Quantity * Convert.ToDecimal(PriceText.Text);//here
                                                                                    // Populate the rows.
                    string[] row = new string[] { SelectedItem, "$" + PriceText.Text, Quantity.ToString(), "$" + TotalCost.ToString() };
                    //populate and add row
                    dataGridView1.Rows.Add(row);
                    Subtotal += Quantity * Convert.ToDouble(PriceText.Text);
                    Subtotal_Text.Text = "$" + Subtotal.ToString();
                    TaxText.Text =(Subtotal * tax).ToString();
                    TotalText.Text = "$" + ((Subtotal * tax) + Subtotal).ToString();
                }
                else { MessageBox.Show("Please enter a valid number");
                    QuantityText.Focus();
                }
            }
            catch {

                MessageBox.Show("Please select a book from the list.");
            }
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
            if (dataGridView1.Rows.Count == 0){
                MessageBox.Show("Please add a book to check out.");
            }
            else {
                dataGridView1.Rows.Clear();
                ClearTextBoxes();
                MessageBox.Show("Your order has been placed!");
            }
        }

        private void ClearTextBoxes() //Found on stack overflow
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
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
    }
}
