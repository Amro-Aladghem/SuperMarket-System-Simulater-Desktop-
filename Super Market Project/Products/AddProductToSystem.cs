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

namespace Super_Market_Project
{
    public partial class AddProductToSystem : Form
    {
        public AddProductToSystem()
        {
            InitializeComponent();
        }

        private void btnProductQR_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtProductQR.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtProductQR, "You must fill it!");
                txtProductQR.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtProductQR, "");
            }
        }

        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtProductName.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtProductName, "You must fill it!");
                txtProductName.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtProductName, "");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                if (MessageBox.Show("Are You sure To Add This Prduct/Veg", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (clsProducts.AddNewProductToSystem(txtProductQR.Text, txtProductName.Text))
                    {
                        MessageBox.Show("The Product/Veg has been added successfully!");
                        btnConfirm.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The Process Cancled Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
