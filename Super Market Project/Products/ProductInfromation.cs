using BuesineesLyer;
using Super_Market_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market_Project.Products
{
    public partial class ProductInfromation : Form
    {
        public ProductInfromation(string ProductQR)
        {
            InitializeComponent();
            Product=clsProducts.FindProductByQR(ProductQR);
        }

        clsProducts Product;

        private void LoadAllData()
        {
            if(Product!=null)
            {
                lbProductID.Text = Product.ProductID.ToString();
                lbProductQR.Text=Product.ProductQR.ToString();
                lbProducedDate.Text = Product.ProducedDate.ToShortDateString();
                lbEndDate.Text=Product.EndDate.ToShortDateString();
                lbProviderID.Text=Product.ProviderID.ToString();
                lbPrice.Text = Product.Price.ToString() + " " + "jd";
                lbQuantity.Text = Product.Quantity.ToString() + " " + "Unit";
                lbDateOFSet.Text = Product.DateOfSet.ToShortDateString();
                if(Product.ImageLocation!=null)
                {
                    pictureBox1.ImageLocation= Product.ImageLocation;
                }
                else
                {
                    pictureBox1.Image = Resources.innovation;
                }
            }
        }

        private void ProductInfromation_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
