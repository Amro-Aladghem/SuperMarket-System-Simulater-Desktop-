using BuesineesLyer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project.Offers
{
    public partial class AddNewOffer : Form
    {

        enum echooseType { Both=1,Product=2,Veg=3}
        echooseType choosed;
        public AddNewOffer()
        {
            InitializeComponent();
            InitializeNumericUpDown();
        }

        clsOffers NewOffer = new clsOffers();

        private void InitializeNumericUpDown()
        {

             numericOffer.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
             numericOffer.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
             numericOffer.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
             numericOffer.Increment = (decimal)0.01;

        }

        private void RestartData()
        {
            txtProductID.Visible = false;
            txtVegID.Visible = false;
            btnSave.Enabled = false;
        }

       

        private void AddNewOffer_Load(object sender, EventArgs e)
        {
            rdBoth.Checked = false;
            rdProduct.Checked = false;
            rdVegFruit.Checked = false;

            RestartData();
        }

        private void FillDataToOfferClass()
        {
            switch(choosed)
            {
                case echooseType.Both:
                    {
                        NewOffer.ProductID = Convert.ToInt32(txtProductID.Text);
                        NewOffer.VegAndFruitID = Convert.ToInt32(txtVegID.Text); break;
                    }
                    case echooseType.Product:
                    {
                        NewOffer.ProductID = Convert.ToInt32(txtProductID.Text);
                        break; 
                    }
                case echooseType.Veg:
                    {
                        NewOffer.VegAndFruitID= Convert.ToInt32(txtVegID.Text); break;
                    }
            }

            NewOffer.DateOfSet=DateTime.Now;
            NewOffer.Percentage = (float)Convert.ToDouble(numericOffer.Value);

        }


        private void txtProductID_Validating(object sender, CancelEventArgs e)
        {

            if (txtProductID.Visible== false)
            {
                return;
            }



            if(string.IsNullOrEmpty(txtProductID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductID, "You must Fill It!");
                txtProductID.Focus();
            }
            else if(!clsProducts.IsProductExitsInTheStorage(Convert.ToInt32(txtProductID.Text)))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductID, "This Product Not Found");
                txtProductID.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtProductID, "");
            }
        }

        private void txtVegID_Validating(object sender, CancelEventArgs e)
        {
           
            if(txtVegID.Visible== false)
            {
                return;
            }

            if(string.IsNullOrEmpty(txtVegID.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtVegID, "You must Fill it!");
                txtVegID.Focus();
            }
            else if (!clsProducts.IsProductExitsInTheStorage(Convert.ToInt32(txtVegID.Text)))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVegID, "This Product Not Found");
                txtVegID.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtVegID, "");
            }
        }

        private void rdBoth_CheckedChanged(object sender, EventArgs e)
        {
            choosed = echooseType.Both;
            RestartData();
            txtVegID.Visible = true;
            txtProductID.Visible = true;
            btnSave.Enabled = true;
        }

        private void rdProduct_CheckedChanged(object sender, EventArgs e)
        {
            choosed= echooseType.Product;
            RestartData();
            txtProductID.Visible=true;
            btnSave.Enabled = true;
        }

        private void rdVegFruit_CheckedChanged(object sender, EventArgs e)
        {
            choosed = echooseType.Veg;
            RestartData();
            txtVegID.Visible=true;
            btnSave.Enabled = true;
        }


        private bool CheckIfElementHasAnOffer()
        {
            switch(choosed)
            {
                case echooseType.Product:
                    {
                        if (clsOffers.CheckIfProductHaveAnOffer(Convert.ToInt32(txtProductID.Text)))
                        {
                            return true;
                        }

                        return false;
                    }
                case echooseType.Veg:
                    {
                        if(clsOffers.IsVegOrFruitHasAnOffer(Convert.ToInt32(txtVegID.Text)))
                        {
                            return true;
                        }

                        return false;
                    }
                    case echooseType.Both:
                    {
                        if(clsOffers.CheckIfProductHaveAnOffer(Convert.ToInt32(txtProductID.Text))&& clsOffers.IsVegOrFruitHasAnOffer(Convert.ToInt32(txtVegID.Text)))
                        {
                            return true;
                        }

                        return false;
                    }

                default:
                    return false;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CheckIfElementHasAnOffer())
            {
                MessageBox.Show("This Product Has already an offer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ValidateChildren())
            {

                if(MessageBox.Show("Are You sure to add this Offer in the system","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    FillDataToOfferClass();

                    if(NewOffer.Save())
                    {
                        btnSave.Enabled = false;
                        groupBox1.Enabled = false;
                        MessageBox.Show("The Process has Done Successfully!","Inforation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        clsApplication.AddNewApplicationToSystem((int)eOperationType.Add, DateTime.Now,null, null,NewOffer.OfferID, LogedInUser.UserID);

                    }
                    else
                    {
                        MessageBox.Show("The Proccess Failed Somthing Error!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("The Process Canceled!");
                }
            }
        }

        private void numericOffer_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericOffer_Validating(object sender, CancelEventArgs e)
        {
            if(numericOffer.Value==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericOffer,"The Persentage must above 0");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericOffer, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
