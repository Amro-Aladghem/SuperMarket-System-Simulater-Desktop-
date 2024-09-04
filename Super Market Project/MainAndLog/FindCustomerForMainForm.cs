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

namespace Super_Market_Project.MainAndLog
{
    public partial class FindCustomerForMainForm : Form
    {

        public delegate void OnSearchClick(int?CustomerID);
        public OnSearchClick DataBackCustomerID;

        public FindCustomerForMainForm()
        {
            InitializeComponent();
        }
        clsCustomers Customer;
        private void FindCustomerForMainForm_Load(object sender, EventArgs e)
        {

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Customer = clsCustomers.FindCustomerByID(Convert.ToInt32(txtSearch.Text));
            if(Customer==null)
            {
                MessageBox.Show("This Customer Not Fonud Try again!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            btnSearch.Enabled = false;
            txtSearch.Enabled = false;

            int? CustomerID = Customer == null ? null : (int?)Customer.CustomerID;
            DataBackCustomerID.Invoke(CustomerID);
            this.Close();

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            
        }

        private void lbNotExtits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataBackCustomerID.Invoke(null);
            this.Close();
        }
    }
}
