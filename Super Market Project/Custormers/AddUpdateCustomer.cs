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
    public partial class AddUpdateCustomer : Form
    {

        enum eMode { AddNew=1,Update=2}

        eMode Mode;


        public AddUpdateCustomer()
        {
            InitializeComponent();
            Mode=eMode.AddNew;
        }

        public AddUpdateCustomer(int customerID)
        {
            InitializeComponent();
            Customer = clsCustomers.FindCustomerByID(customerID);
            Mode = eMode.Update;
            chxIsActive.Enabled = true;
        }


        private void ReffreshData()
        {
            lbCustomerID.Text = "N/A";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            chxIsActive.Checked = true;

            if (Mode == eMode.Update)
            {
                LoadData();
            }

        }

        private void LoadData()
        {
            if (Customer != null)
            {

                lbCustomerID.Text = Customer.CustomerID.ToString();
                txtFirstName.Text = Customer.FirstName.ToString();
                txtLastName.Text = Customer.LastName.ToString();
                txtEmail.Text = Customer.Email.ToString();
                txtPhoneNumber.Text = Customer.PhoneNumber.ToString();
                chxIsActive.Checked = Customer.isActive;
            }
        }


        clsCustomers Customer=new clsCustomers();

        private void Save_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text=="" && txtPhoneNumber.Text=="")
            {
                MessageBox.Show("You must enter at least one of Email Or Phone","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (ValidateChildren())
            {
                if (MessageBox.Show("Are You srur to Add/Update this Customer!", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    Customer.FirstName = txtFirstName.Text;
                    Customer.LastName = txtLastName.Text;
                    Customer.Email = txtEmail.Text;
                    Customer.PhoneNumber = txtPhoneNumber.Text;
                    Customer.isActive = chxIsActive.Checked;
                    if(Mode==eMode.AddNew)
                    {
                        Customer.LastOrderDate = DateTime.Now;
                    }
                    

                    if (Customer.Save())
                    {
                        MessageBox.Show("The Process has been done Successfully!");
                        if (Mode == eMode.AddNew)
                        {
                            lbLabel.Text = "Update Customer";
                            Mode = eMode.Update;
                            chxIsActive.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Process Cancled");
                    }



                }
                else
                {
                    MessageBox.Show("The Message Canceled!");
                }

            }




        }

        private void AddNewCustomer_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "You Must Fill It!");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = "@gmail.com";
            if(!txtEmail.Text.Contains(email)&&txtEmail.Text!="")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "The Email is Not Valied!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }    
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }


    }
}
