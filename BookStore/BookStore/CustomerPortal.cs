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
    public partial class CustomerPortal : Form
    {
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
                }

            }
            catch
            {
                statusTextBox.Text = "Check JSON File/Location";
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }

        private void newCustomerButton_Click(object sender, EventArgs e)
        {

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
