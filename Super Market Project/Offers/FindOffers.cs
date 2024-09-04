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

namespace Super_Market_Project.Offers
{
    public partial class FindOffers : Form
    {
        enum eTypeSearch { OfferID=1,ProductID=2,VegOrFruitID=3}
        eTypeSearch TypeSearch;


        clsOffers Offer;

        public FindOffers()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if(Offer!=null)
            {
                lbOfferID.Text = Offer.OfferID.ToString();
                lbProductID.Text= Offer.ProductID.ToString();
                lbVegID.Text = Offer.VegAndFruitID.ToString();
                lbPersectage.Text=((Offer.Percentage*100)).ToString()+"%";
                lbDate.Text = Offer.DateOfSet.ToShortDateString();
                if(Offer.VegAndFruitID!=null)
                {
                    clsVegAndFruit vegAndFruit = clsVegAndFruit.FindByID((int)Offer.VegAndFruitID);
                    lbPriceBefore.Text = vegAndFruit.Price.ToString() + " JD";
                    decimal SavingAmount = (decimal)(vegAndFruit.Price) * (decimal)Offer.Percentage;
                    lbPriceAfter.Text = (Math.Round((decimal)vegAndFruit.Price - SavingAmount,3)).ToString() + " JD";
                }
                else
                {
                    clsProducts Product = clsProducts.FindByID((int)Offer.ProductID);
                    lbPriceBefore.Text = Product.Price.ToString() + " JD";
                    decimal SavingAmount = (decimal)Product.Price * (decimal)Offer.Percentage;
                    lbPriceAfter.Text = ((decimal)Product.Price - SavingAmount).ToString() + " JD";
                }

            }
        }

        private void ResteData()
        {
            lbOfferID.Text = "[???]";
            lbProductID.Text = "[???]";
            lbVegID.Text = "[???]";
            lbPersectage.Text = "[???]";
            lbDate.Text = "[???]";
            lbPriceBefore.Text = "[???]";
            lbPriceAfter.Text = "[???]";
        }


        private void FindOffers_Load(object sender, EventArgs e)
        {
            cbxFilter.SelectedIndex = 0;
            TypeSearch = eTypeSearch.OfferID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (TypeSearch)
            {

                case eTypeSearch.OfferID:
                    {

                        Offer = clsOffers.FindOfferByID((Convert.ToInt32(txtFilter.Text)));
                        if (Offer != null)
                        {
                            LoadData();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("This Product Not Found In The System!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResteData();
                            break;
                          
                        }
                    }
                case eTypeSearch.ProductID:
                    {

                        Offer = clsOffers.FindOfferForPrdouctByID((Convert.ToInt32(txtFilter.Text)));
                        if (Offer != null)
                        {
                            LoadData();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("This Product Not has an offer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResteData();

                            break;
                        }

                    }
                case eTypeSearch.VegOrFruitID:
                    {
                        Offer = clsOffers.FindOfferForPrdouctByID((Convert.ToInt32(txtFilter.Text)));
                        if (Offer != null)
                        {
                            LoadData();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("This Product Not has an Offer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResteData();

                            break;
                        }


                    }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbxFilter.SelectedIndex)
            {
                case 0:
                    {
                        TypeSearch = eTypeSearch.OfferID; break;
                    }
                case 1:
                    {
                        TypeSearch=eTypeSearch.ProductID; break;
                    }
                    case 2:
                    {
                        TypeSearch=eTypeSearch.VegOrFruitID; break;
                    }
            }
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtFilter.Text!="")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
