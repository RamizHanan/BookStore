using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BookStore
{
    public partial class BookStoreGUI : Form
    {
        public const Double tax = .1;
        public Double? subTotal = 0;
        public BookStoreGUI()
        {
            InitializeComponent();
            this.AutoSize = true; //resize auto
            this.dataGridView1.AllowUserToAddRows = false; //disable user changes


            try
            {
                // deserialize JSON directly from a file
                string BookJSON = File.ReadAllText(@"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Books.json");
                JObject json = JObject.Parse(BookJSON);
                //access books
                JArray bookList = (JArray)json["Books"];
                //made list of only book names for the combobox. See JSON File
                List<string> Books = JsonConvert.DeserializeObject<List<string>>(bookList.ToString());
                comboBox1.Items.Clear();
                for (int i = 0; i < Books.Count; i++)
                {
                    comboBox1.Items.Add(json[Books[i]]["bookName"].ToString());
                }

            }
            catch {
                TotalText.Text = "Check JSON File/Location";
            }

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
                    decimal? totalCost = Quantity * Convert.ToDecimal(PriceText.Text);//Get the total
                    // Populate the rows.
                    string selectedItem = (string)comboBox1.SelectedItem;
                    string[] row = new string[] { selectedItem, "$" + PriceText.Text, Quantity.ToString(), "$" + totalCost.ToString() };//populate and add row
                   //populate dataGridView upon click Add Title
                    dataGridView1.Rows.Add(row);
                    subTotal += Quantity * Convert.ToDouble(PriceText.Text); //add total
                    Subtotal_Text.Text = "$" + subTotal.ToString();
                    TaxText.Text =(subTotal * tax).ToString();
                    TotalText.Text = "$" + ((subTotal * tax) + subTotal).ToString();
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
        
            try
            {
                //access books
                string BookJSON = File.ReadAllText(@"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Books.json");
                JObject json = JObject.Parse(BookJSON);
                
                JObject BookTarget = (JObject)json[SelectedItem];

                string book_target = BookTarget.ToString();

                Book foundBook = new Book();
                Newtonsoft.Json.JsonConvert.PopulateObject(book_target, foundBook);
                AuthorText.Text = foundBook.author; ;
                IsbnText.Text = foundBook.ISBN;
                PriceText.Text = foundBook.price.ToString();
                
            }
            catch {
                //clear form
                AuthorText.Clear();
                IsbnText.Clear();
                PriceText.Clear();
            }

            QuantityText.Focus();
        }

        public void SaveToTxt(string receipt) {

            //write string to file
            System.IO.File.WriteAllText(@"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Order.txt", receipt);
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
            if (dataGridView1.Rows.Count == 0)
            {//means nothing was added
                MessageBox.Show("Please add a book to check out.");
            }
            else
            {//populate receipt
                Dictionary<string, string> order = new Dictionary<string, string>();
                string itemDesc = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string key = "Item " + (i+1).ToString();
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        string columnName = dataGridView1.Columns[j].Name + ": ";
                        itemDesc += columnName + dataGridView1[j, i].Value.ToString() + "    ";
                    }
                    order.Add(key, itemDesc);
                    itemDesc = "";
                }
                //format receipt txt file
                string totalItems = "Subtotal: " + Subtotal_Text.Text + "   Tax: 10.00%" + "   Tax Total: " + TaxText.Text + "   Total: " + TotalText.Text;
                order.Add("Order Total", totalItems);
                string dateTimeString = $"{DateTime.Today.ToString("d")} {DateTime.Now.ToString("HH:mm:ss")}";
                order.Add("Transaction Completed", dateTimeString);
                string receipt = JsonConvert.SerializeObject(order,Formatting.Indented);
                SaveToTxt(receipt);
                dataGridView1.Rows.Clear(); //clear fields
                ClearTextBoxes();//clear boxes
                MessageBox.Show("Thank you! Your order has been placed!");
            }
        }

        private void ClearTextBoxes() //Found on stack overflow
        {
            comboBox1.SelectedIndex = -1;
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainMenu store = new MainMenu();
            store.Show();
            Hide();
        }
    }
}
