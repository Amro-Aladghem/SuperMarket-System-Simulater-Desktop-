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

namespace Super_Market_Project.VegOrFruit
{
    public partial class ctrVegOrFruitInfo : UserControl
    {
        public ctrVegOrFruitInfo()
        {
            InitializeComponent();
        }

        clsVegAndFruit vegAndFruit;

        public void GetIDAndCreatClassAndLoadData(int vegAndFruitID)
        {
            vegAndFruit = clsVegAndFruit.FindByID(vegAndFruitID);
            LoadData();
        }

        private void LoadData()
        {
            lbID.Text = vegAndFruit.VegOrFruitID.ToString();
            lbQR.Text = vegAndFruit.VegOrFruitQR.ToString();
            lbEnrollDate.Text = vegAndFruit.EnrollDate.ToShortDateString();
            lbIsEnd.Text = vegAndFruit.IsExpired == true ? "yes" : "NO";
            lbPrice.Text = vegAndFruit.Price.ToString() + " JD";
            lbQunatity.Text = vegAndFruit.Kilogram.ToString() + " Kilogram";
            lbProviderID.Text = vegAndFruit.ProviderID.ToString();
            lbDateOfSet.Text = vegAndFruit.EnrollDate.ToShortDateString();
        }

        public void Reset()
        {
            lbQR.Text = "N/A";
            lbEnrollDate.Text = "[???]";
            lbID.Text = "N/A";
            lbIsEnd.Text = "[???]";
            lbPrice.Text = "[???}";
            lbQunatity.Text = "[???]";
            lbProviderID.Text = "[???]";
            lbDateOfSet.Text = "[???]";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrVegOrFruitInfo_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
