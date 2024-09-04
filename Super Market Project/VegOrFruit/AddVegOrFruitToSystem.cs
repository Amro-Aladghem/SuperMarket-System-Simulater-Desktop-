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
using static Super_Market_Project.Products.FindProductByFilter;

namespace Super_Market_Project.VegOrFruit
{
    public partial class AddVegOrFruitToSystem : Form
    {
        public AddVegOrFruitToSystem()
        {
            InitializeComponent();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVegOrFruitToSystem_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtQR.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtQR, "You must Fill it!");
                txtQR.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtQR, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "You must fill it!");
                txtName.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                if (MessageBox.Show("Are You sure To Add This Veg/Fruit", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (clsVegAndFruit.AddNewVegOrFruitAtTheSystem(txtQR.Text,txtName.Text))
                    {
                        MessageBox.Show("The Veg/Fruit has been added successfully!");
                        btnConfirm.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The Process Cancled Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }







            }
        }

        private void AddVegOrFruitToSystem_Load(object sender, EventArgs e)
        {

        }
    }
}
