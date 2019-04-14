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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace BookStore
{
    public partial class CustomerPortal : Form
    {
        string name = "[^A-Za-z']";
        string phone = "^((1-([(][0-9]{3}[)]|[0-9]{3})-)[0-9]{3}-[0-9]{4})$";
        string email = "^[A-Z0-9._%+-]+@[A-Z0-9.-]+[.][A-Z]{2,4}$";
        string zip = @"^\d{5}(?:[-\s]\d{4})?$";
        public List<string> customerNames = new List<string>();
        public string path = @"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Customers.json";
        public string SelectedItem; //keeps track of selected item from list in add tab
        public string SelectedToEdit; //selected item in edit tab
        public string tempfirst; //used to detect if first name being changed
        public string templast;//used to detect if last name being changed
        public string SelectedToDelete; //selected item in delete tab

        MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");



        public CustomerPortal()
        {
            InitializeComponent();
            try
            {
                populateComboBox();
                this.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch
            {
                statusTextBox.Text = "Cannot connect to database.";
            }
        }
        private void populateComboBox()
        {
            MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");

            string selectedQuery = "SELECT * FROM bookstore.customers";
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectedQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            comboBox.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            while (reader.Read())
            {
                comboBox.Items.Add(reader.GetString("first") + " " + reader.GetString("last"));
                comboBox1.Items.Add(reader.GetString("first") + " " + reader.GetString("last"));
                comboBox2.Items.Add(reader.GetString("first") + " " + reader.GetString("last"));

            }
            connection.Close();
        }
        private Customer CreateCustomer()
        {
            Customer custo = new Customer();

            if (firstTextBox.Text == "" || Regex.IsMatch(firstTextBox.Text, name))
            {
                custo = null;

                MessageBox.Show("Please Enter First Name", "First Name is a required field");
                firstTextBox.Focus();
            }
            else if (lastTextBox.Text == "" || Regex.IsMatch(lastTextBox.Text, name))
            {
                custo = null;

                MessageBox.Show("Please Enter valid Last Name", "Last name is a required field");
                firstTextBox.Focus();
            }
            else if (PhoneTextBox.Text == "" || Regex.IsMatch(PhoneTextBox.Text, phone))
            {
                custo = null;

                MessageBox.Show("Please Enter valid 10 digit Phone Number e.g: xxxxxxxxxx", "First Name is a required field");
                firstTextBox.Focus();
            }
            else if (addressTextBox.Text == "" || Regex.IsMatch(addressTextBox.Text, zip))
            {
                custo = null;

                MessageBox.Show("Please Enter Valid Address", "Address is a required field");
                addressTextBox.Focus();
            }
            else if (stateTextBox.Text == "" || Regex.IsMatch(stateTextBox.Text, name))
            {
                custo = null;

                MessageBox.Show("Please enter Valid State", "State is a required field");
                stateTextBox.Focus();
            }
            else if (cityTextBox.Text == "")
            {
                custo = null;

                MessageBox.Show("Please enter valid city", "city is a required field");
                cityTextBox.Focus();
            }
            else if (zipTextBox.Text == "")
            {
                custo = null;

                MessageBox.Show("Please enter a valid 5 digit zip code", "Zip is a required field");
                zipTextBox.Focus();
            }
            else if (emailTextBox.Text == "" || Regex.IsMatch(emailTextBox.Text, email))
            {
                MessageBox.Show("Please enter a valid Email", "Email is a required field");
                custo = null;
                emailTextBox.Focus();
            }
            else
            {
                custo.first = firstTextBox.Text;
                custo.last = lastTextBox.Text;
                custo.address = addressTextBox.Text;
                custo.city = cityTextBox.Text;
                custo.state = stateTextBox.Text;
                custo.zip = zipTextBox.Text;
                custo.phone = PhoneTextBox.Text;
                custo.email = emailTextBox.Text;
            }


            return custo;
        }

        void WriteToJSON(string newCustomer) //creates structure of JSON manually
        {
            string newFile = File.ReadAllText(path);
            if (newFile == "")
                newFile = newCustomer;
            else
            {
                newFile = newFile.Remove(newFile.Length - 1, 1);
                newCustomer = newCustomer.Remove(0, 1);
                newCustomer = newCustomer.Remove(newCustomer.Length - 1, 1);
                newFile = newFile + ',' + newCustomer + '}';
            }

            File.WriteAllText(path, newFile);



        }
        private int checkIfCustoExists(string custoName)
        { //simple function to check if current customer is in loaded list
            int result = 1;
            foreach (var name in customerNames)
            {
                if (name == custoName)
                    return 0;
            }
            return result;
        }
        private int countFinder()
        {
            MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            string command = $"SELECT COUNT(*) FROM bookstore.customers WHERE first = '{firstTextBox.Text}' AND last = '{lastTextBox.Text}'";
            MySqlCommand counter = new MySqlCommand(command, connection);
            int records = Convert.ToInt32((counter.ExecuteScalar()));

            connection.Close();

            //SELECT COUNT(*) FROM bookstore.books WHERE title LIKE %'African'
            return records;
        }
        void AddCustomer() //custoName = first + last
        {
            try
            {

                MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");

                int records = countFinder();
                if (records == 0)
                {
                    connection.Open();
                    string sql = $"INSERT IGNORE INTO bookstore.customers (first, last, address, city, state, zip, phone, email) VALUES ('{firstTextBox.Text}','{lastTextBox.Text}','{addressTextBox.Text}','{cityTextBox.Text}','{stateTextBox.Text}','{zipTextBox.Text}', '{PhoneTextBox.Text}','{emailTextBox.Text}')";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer successfully Created.");
                    ClearTextBoxes();
                    comboBox.Text = "Select customer from list to edit...";
                    comboBox.Enabled = true;
                    populateComboBox();
                }
                else
                {
                    MessageBox.Show("Customer already exists. Please select from combo box.");
                    ClearTextBoxes();
                    comboBox.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //string CreateCustomerJSON(string username, Customer newCustomer)
        //{
        //    //Create employee dictionary
        //    Dictionary<string, Customer> tempCustomer = new Dictionary<string, Customer>
        //        {
        //            { username, newCustomer }
        //        };

        //    //Make JSON string from dictionary
        //    return JsonConvert.SerializeObject(tempCustomer, Formatting.Indented);
        //}
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.comboBox.Enabled = true;
                ClearTextBoxes();
                populateComboBox();
                MessageBox.Show("Your request has been cancelled.");
            }
            else if (dialogResult == DialogResult.No) { }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu store = new MainMenu();
            store.Show();
            Hide();
        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            this.comboBox.Enabled = false;
            ClearTextBoxes();

        }

        private void ClearTextBoxes() //Found on stack overflow
        {
            comboBox.Text = "";
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
        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedToEdit = comboBox1.SelectedItem.ToString();
            try
            {
                MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");

                SelectedToEdit = comboBox1.SelectedItem.ToString();
                string[] name = SelectedToEdit.Split(null);

                string query = $"SELECT * FROM bookstore.customers WHERE first = \"{name[0]}\" AND last = \"{name[1]}\"";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    textBox9.Text = reader["first"].ToString();
                    textBox4.Text = reader["last"].ToString();
                    textBox8.Text = reader["address"].ToString();
                    textBox7.Text = reader["city"].ToString();
                    textBox3.Text = reader["state"].ToString();
                    textBox2.Text = reader["zip"].ToString();
                    textBox5.Text = reader["email"].ToString();
                    textBox6.Text = reader["phone"].ToString();
                    tempfirst = reader["first"].ToString();
                    templast = reader["last"].ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //clear form
                textBox9.Clear();
                textBox4.Clear();
                textBox8.Clear();
                textBox7.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox6.Clear();
                textBox5.Clear();
            }
            finally
            {
                connection.Close();
            }
            comboBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SelectedToEdit is null)
            {
                MessageBox.Show("Please select customer from list", "Save Error");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                if (textBox9.Text == "" || Regex.IsMatch(textBox9.Text, name))
                {

                    MessageBox.Show("Please Enter First Name", "First Name is a required field");
                    textBox9.Focus();
                }
                else if (textBox4.Text == "" || Regex.IsMatch(textBox4.Text, name))
                {

                    MessageBox.Show("Please Enter Last Name", "Last name is a required field");
                    textBox4.Focus();
                }
                else if (textBox6.Text == "" || Regex.IsMatch(textBox6.Text, phone))
                {

                    MessageBox.Show("Please Enter Phone Number", "Phone Number is a required field");
                    textBox6.Focus();
                }
                else if (textBox8.Text == "" || Regex.IsMatch(textBox8.Text, zip))
                {
                    MessageBox.Show("Please Enter Address", "Address is a required field");
                    textBox8.Focus();
                }
                else if (textBox3.Text == "" || Regex.IsMatch(textBox3.Text, name))
                {

                    MessageBox.Show("Please Enter State", "State is a required field");
                    textBox3.Focus();
                }
                else if (textBox7.Text == "")
                {

                    MessageBox.Show("Please Enter city", "city is a required field");
                    textBox7.Focus();
                }
                else if (textBox2.Text == "")
                {

                    MessageBox.Show("Please Enter Zip", "Zip is a required field");
                    textBox2.Focus();
                }
                else if (textBox5.Text == "" || Regex.IsMatch(textBox5.Text, email))
                {
                    MessageBox.Show("Please Enter Email", "Email is a required field");
                    textBox5.Focus();
                }
                else
                {
                    try
                    {
                        string MyConnection2 = "Datasource=localhost;port=3306;username=root;password=";

                        string Query = $"UPDATE bookstore.customers SET first = '{textBox9.Text}', last = '{textBox4.Text}', address = '{textBox8.Text}', " +
                            $"city = '{textBox7.Text}', state = '{textBox3.Text}', zip = '{textBox2.Text}', phone = '{textBox5.Text}', email = '{textBox6.Text}'  " +
                            $"WHERE first = '{textBox9.Text}' AND last = '{textBox4.Text}'";

                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                        MyConn2.Open();

                        if (MyCommand2.ExecuteNonQuery() == 1 && tempfirst == textBox9.Text && templast == textBox4.Text)
                        {
                            populateComboBox();
                            ClearTextBoxes();
                            MessageBox.Show("Customer Updated Successfully");

                        }
                        else
                        {
                            MessageBox.Show("Not updated, Are you trying to update first or last name?");
                            textBox9.Text = tempfirst;
                            textBox4.Text = templast;
                        }
                        MyConn2.Close();//Connection closed here 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    statusTextBox.Text = "Customer Info Updated Successfully";
                }
            }
            else if (dialogResult == DialogResult.No) { }

            
        }

        private void comboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SelectedItem = comboBox.SelectedItem.ToString();
            try
            {
                MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");

                SelectedItem = comboBox.SelectedItem.ToString();
                string[] name = SelectedItem.Split(null);

                string query = $"SELECT * FROM bookstore.customers WHERE first = \"{name[0]}\" AND last = \"{name[1]}\"";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    firstTextBox.Text = reader["first"].ToString();
                    lastTextBox.Text = reader["last"].ToString();
                    addressTextBox.Text = reader["address"].ToString();
                    cityTextBox.Text = reader["city"].ToString();
                    stateTextBox.Text = reader["state"].ToString();
                    zipTextBox.Text = reader["zip"].ToString();
                    emailTextBox.Text = reader["email"].ToString();
                    PhoneTextBox.Text = reader["phone"].ToString();
                    tempfirst = reader["first"].ToString();
                    templast = reader["last"].ToString();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //clear form
                firstTextBox.Clear();
                lastTextBox.Clear();
                addressTextBox.Clear();
                cityTextBox.Clear();
                stateTextBox.Clear();
                zipTextBox.Clear();
                PhoneTextBox.Clear();
                emailTextBox.Clear();
            }
            finally
            {
                connection.Close();
            }
            comboBox.Focus();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cancelButton_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backButton_Click(sender, e);
        }

        private void backButtonAddCustomer_Click(object sender, EventArgs e)
        {
            backButton_Click(sender, e);
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            cancelButton_Click(sender, e);
        }

        private void newCustomerButton_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to add new customer?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Customer custo = CreateCustomer();
                if (custo != null) AddCustomer();
            }
            else if (dialogResult == DialogResult.No) { }

            }

            private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedToDelete = comboBox2.SelectedItem.ToString();
            string[] name = SelectedToDelete.Split(null);
            textBoxFirstDelete.Text = name[0];
            textBoxLastDelete.Text = name[1];
        }

        private void buttonRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (SelectedToDelete is null)
            {
                MessageBox.Show("Please select customer from list", "Delete Error");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove customer?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("Datasource=localhost;port=3306;username=root;password=");

                    SelectedToDelete = comboBox2.SelectedItem.ToString();
                    string[] name = SelectedToDelete.Split(null);

                    string query = $"DELETE FROM bookstore.customers WHERE first = \"{name[0]}\" AND last = \"{name[1]}\"";
                    MySqlCommand Command = new MySqlCommand(query, connection);
                    connection.Open();
                    if (Command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Customer deleted.");
                        ClearTextBoxes();
                        populateComboBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { connection.Close(); }
            }
            else if (dialogResult == DialogResult.No) { }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            backButton_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelButton_Click(sender, e);
        }
    }
}
