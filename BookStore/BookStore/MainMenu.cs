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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void buttonManageCustomers_Click(object sender, EventArgs e)
        {
            CustomerPortal store = new CustomerPortal();
            store.Show();
            Hide();
        }

        private void buttonManageBooks_Click(object sender, EventArgs e)
        {
            BookManager store = new BookManager();
            store.Show();
            Hide();
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            BookStoreGUI store = new BookStoreGUI();
            store.Show();
            Hide();
        }
    }
}
