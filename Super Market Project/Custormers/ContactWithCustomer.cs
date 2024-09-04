using BuesineesLyer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market_Project.Custormers
{
    public partial class ContactWithCustomer : Form
    {
        public ContactWithCustomer()
        {
            InitializeComponent();
        }

        clsCustomers Customer;

        private void LoadAll()
        {
            lbCustmName.Text = Customer.FirstName;
            lbPhone.Text = Customer.PhoneNumber.ToString();
            lbEmail.Text= Customer.Email;
            if(Customer.isActive)
            {
                lbisActive.Text = "yes";
            }
            else
            {
                lbisActive.Text = "NO";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text=="")
            {
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        { 
              // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }

        private void ContactWithCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Customer = clsCustomers.FindCustomerByID(Convert.ToInt32(txtSearch.Text));
            if (Customer != null)
            {
                LoadAll();
            }
            else
            {
                MessageBox.Show("This Custmer Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
