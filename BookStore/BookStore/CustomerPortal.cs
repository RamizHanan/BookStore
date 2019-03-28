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


        public CustomerPortal()
        {
            InitializeComponent();
            try
            {

                // deserialize JSON directly from a file
                string customerJSON = File.ReadAllText(@"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Customers.json");
                JObject json = JObject.Parse(customerJSON);
                //access books
                JArray custoList = (JArray)json["Customer"];
                //made list of only book names for the combobox. See JSON File
                List<string> Customers = JsonConvert.DeserializeObject<List<string>>(custoList.ToString());
                comboBox.Items.Clear();
                for (int i = 0; i < Customers.Count; i++)
                {
                    comboBox.Items.Add(json[Customers[i]]["first"].ToString() + " " + json[Customers[i]]["last"].ToString());
                    customerNames.Add(json[Customers[i]]["first"].ToString() + " " + json[Customers[i]]["last"].ToString());
                }

            }
            catch
            {
                statusTextBox.Text = "Check JSON File/Location";
            }
        }
        private Customer CreateCustomer()
        {
            Customer custo = new Customer();

            if (firstTextBox.Text == "" || Regex.IsMatch(firstTextBox.Text, name)) {
                custo = null;

                MessageBox.Show("Please Enter First Name", "First Name is a required field");
            firstTextBox.Focus();
            }
            else if (lastTextBox.Text == "" || Regex.IsMatch(lastTextBox.Text, name))
            {
                custo = null;

                MessageBox.Show("Please Enter Last Name", "Last name is a required field");
                firstTextBox.Focus();
            }
            else if (PhoneTextBox.Text == "" || Regex.IsMatch(PhoneTextBox.Text, phone))
            {
                custo = null;

                MessageBox.Show("Please Enter Phone Number", "First Name is a required field");
                firstTextBox.Focus();
            }
            else if (addressTextBox.Text == "" || Regex.IsMatch(addressTextBox.Text, zip))
            {
                custo = null;

                MessageBox.Show("Please Enter Address", "Address is a required field");
                addressTextBox.Focus();
            }
            else if (stateTextBox.Text == "" || Regex.IsMatch(stateTextBox.Text, name))
            {
                custo = null;

                MessageBox.Show("Please Enter State", "State is a required field");
                stateTextBox.Focus();
            }
            else if (cityTextBox.Text == "")
            {
                custo = null;

                MessageBox.Show("Please Enter city", "city is a required field");
                cityTextBox.Focus();
            }
            else if (zipTextBox.Text == "" )
            {
                custo = null;

                MessageBox.Show("Please Enter Zip", "Zip is a required field");
                zipTextBox.Focus();
            }
            else if (emailTextBox.Text == "" || Regex.IsMatch(emailTextBox.Text, email))
            {
                MessageBox.Show("Please Enter Email", "Email is a required field");
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

        void WriteToJSON(string newCustomer)
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
        private int checkIfCustoExists(string custoName) {
            int result = 1;
            foreach (var name in customerNames) {
                if (name == custoName)
                    return 0;
            }
            return result;
        }
        
        void AddCustomer(string custoName) //custoName = first + last
        {
            Customer newCustomer = new Customer();
            
            //If employee exists
            if (checkIfCustoExists(custoName)==1)
            {

                newCustomer = CreateCustomer();
                if (newCustomer is null) {
                    return;
                }
                string custoJSON = File.ReadAllText(path);
                JObject json = JObject.Parse(custoJSON);
                //access employees
                JArray custoList = (JArray)json["Customer"];
                //add customer name to list
                custoList.Add(custoName);

                
                    // Create a file to write to.
                    File.WriteAllText(path, json.ToString());
                
                

                string temp = json.ToString();

                //Make JSON string from dictionary
                string newCustomerJSON = CreateCustomerJSON(custoName, newCustomer);
                //Write to employee JSON
                WriteToJSON(newCustomerJSON);

                //**Write Employee Successfully Added**
                statusTextBox.Text = "SUCCESS - EMPLOYEE ADDED";


                //**Write customer Successfully Added**
                statusTextBox.Text = "SUCCESS - CUSTOMER ADDED";
                
            }
            //If customer already exists
            else
                statusTextBox.Text = "ERROR - CUSTOMER ALREADY EXISTS";
        }

        string CreateCustomerJSON(string username, Customer newCustomer)
        {
            //Create employee dictionary
            Dictionary<string, Customer> tempCustomer = new Dictionary<string, Customer>
                {
                    { username, newCustomer }
                };


            //Make JSON string from dictionary
            return JsonConvert.SerializeObject(tempCustomer, Formatting.Indented);
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = (string)comboBox.SelectedItem;

            try
            {
                //access books
                string BookJSON = File.ReadAllText(@"C:\Users\RMBonMAC\Documents\GitHub\BookStore\BookStore\BookStore\bin\Debug\Customers.json");
                JObject json = JObject.Parse(BookJSON);

                JObject CustoTarget = (JObject)json[SelectedItem];

                string custo_target = CustoTarget.ToString();

                Customer foundCusto = new Customer();
                Newtonsoft.Json.JsonConvert.PopulateObject(custo_target, foundCusto);
                firstTextBox.Text = foundCusto.first; 
                lastTextBox.Text = foundCusto.last;
                addressTextBox.Text = foundCusto.address;
                cityTextBox.Text = foundCusto.city;
                stateTextBox.Text = foundCusto.state;
                zipTextBox.Text = foundCusto.zip;
                PhoneTextBox.Text = foundCusto.phone;
                emailTextBox.Text = foundCusto.email;
            }
            catch
            {
                //clear form
                firstTextBox.Clear();
                lastTextBox.Clear();
                addressTextBox.Clear();
                cityTextBox.Clear();
                stateTextBox.Clear();
                zipTextBox.Clear();
                PhoneTextBox.Clear();
                //emailTextBox.Clear();
            }

            comboBox.Focus();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BookStoreGUI store = new BookStoreGUI();
            store.Show();
            Hide();
        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            AddCustomer(firstTextBox.Text + " " + lastTextBox.Text);
            
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
    }
}
