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

namespace Super_Market_Project.Offers
{
    public partial class UpdatePercentage : Form
    {
        public UpdatePercentage(int OfferID)
        {
            InitializeComponent();
            InitializeNumericUpDown();
            Offer=clsOffers.FindOfferByID(OfferID); 
        }

        private void InitializeNumericUpDown()
        {

             numericPersentage.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
             numericPersentage.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
             numericPersentage.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
             numericPersentage.Increment = (decimal)0.01;

        }

        clsOffers Offer;
        private void LoadData()
        {
            if(Offer!=null)
            {
                lbOfferID.Text = Offer.OfferID.ToString();
                lbProductID.Text=Offer.ProductID.ToString();
                lbVegID.Text = Offer.VegAndFruitID.ToString();
                numericPersentage.Value = (decimal)Offer.Percentage;
            }
        }




        private void UdpatePercentage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void numericPersentage_Validating(object sender, CancelEventArgs e)
        {
            if((float)numericPersentage.Value==Offer.Percentage)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericPersentage, "If you want to Update You must change value");
                btnConfirm.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(numericPersentage, "");
                btnConfirm.Enabled = true;

            }
        }

        private void numericPersentage_ValueChanged(object sender, EventArgs e)
        {
            if((float)numericPersentage.Value == Offer.Percentage)
            {
                btnConfirm.Enabled = false;
            }
            else
            {
                btnConfirm.Enabled = true;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You  Sure To Make This Update For This Product!","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                Offer.Percentage = (float)Convert.ToDouble(numericPersentage.Value);
                Offer.DateOfSet = DateTime.Now;

                if(Offer.Save())
                {
                    MessageBox.Show("The Proccess is done successfully!");
                    btnConfirm.Enabled = false;
                   clsApplication.AddNewApplicationToSystem((int)eOperationType.Add, DateTime.Now, null, null, Offer.OfferID, LogedInUser.UserID);
                }
                else
                {
                    MessageBox.Show("The Process Canceled Somthing Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
