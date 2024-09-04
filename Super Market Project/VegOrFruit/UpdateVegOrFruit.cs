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
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project.VegOrFruit
{
    public partial class UpdateVegOrFruit : Form
    {
        public UpdateVegOrFruit(clsVegAndFruit vegAndFruit)
        {
            InitializeComponent();
            vegAndFruit1= vegAndFruit;
        }

        clsVegAndFruit vegAndFruit1;

        private void InitializeNumericUpDown()
        {

            numericPricing.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
            numericPricing.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
            numericPricing.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
            numericPricing.Increment = (decimal)0.1;

            numericQuantity.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
            numericQuantity.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
            numericQuantity.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
            numericQuantity.Increment = (decimal)0.1;

        }

        private void LoadAll()
        {
            lbQR.Text = vegAndFruit1.VegOrFruitQR;
            lbName.Text = clsVegAndFruit.GetVegOrFruitName(vegAndFruit1.VegOrFruitQR);
            numericPricing.Value = (decimal)vegAndFruit1.Price;
            numericQuantity.Value = (decimal)vegAndFruit1.Kilogram;
        }

        private void UpdateVegOrFruit_Load(object sender, EventArgs e)
        {
            LoadAll();
            InitializeNumericUpDown();
        }

        private void numericPricing_ValueChanged(object sender, EventArgs e)
        {
            if((double)numericPricing.Value==vegAndFruit1.Price && (float)(numericQuantity.Value) == vegAndFruit1.Kilogram)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericPricing.Value == vegAndFruit1.Price&&(float)(numericQuantity.Value)==vegAndFruit1.Kilogram)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vegAndFruit1.Price =(double)numericPricing.Value;
            vegAndFruit1.Kilogram=(float)numericQuantity.Value;

            if (MessageBox.Show("Are You sure to Update The Product with QR\n" + vegAndFruit1.VegOrFruitQR, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (vegAndFruit1.Save())
                {
                    MessageBox.Show("The Product Update Successfully!");
                    btnSave.Enabled = false;
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.Update, DateTime.Now, null, vegAndFruit1.VegOrFruitID, null, LogedInUser.UserID);

                }
                else
                {
                    MessageBox.Show("The Process Canceled ,Something Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
