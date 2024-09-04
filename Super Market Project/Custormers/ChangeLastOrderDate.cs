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
    public partial class ChangeLastOrderDate : Form
    {
        public ChangeLastOrderDate(int CustomerID)
        {
            InitializeComponent();
            Customer = clsCustomers.FindCustomerByID(CustomerID);
        }

        clsCustomers Customer;
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(Customer.LastOrderDate>dateTimePicker1.Value)
            {
                MessageBox.Show("The Date Must be above the LastDateOrder!");
                return;
            }

            if(MessageBox.Show("Are You Sure To Update LastDateOrder","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Customer.LastOrderDate=dateTimePicker1.Value;
                if(Customer.Save())
                {
                    MessageBox.Show("The Proces Done!");
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The Process Failed!");
                }    
            }
            else
            {
                return;
            }

        }
    }
}
