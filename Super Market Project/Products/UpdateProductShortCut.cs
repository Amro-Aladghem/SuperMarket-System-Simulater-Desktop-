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

namespace Super_Market_Project.Products
{
    public partial class UpdateProductShortCut : Form
    {
        public UpdateProductShortCut()
        {
            InitializeComponent();
        }

        clsProducts Product;
        private void findProductByFilter1_OnSearchClick(object sender, FindProductByFilter.GetProductQR e)
        {
            button1.Enabled = true;
            Product = clsProducts.FindProductByQR(e.ProductQR);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpateProduct frm = new UdpateProduct(Product.ProductQR);
            frm.ShowDialog();
            this.Close();
        }
    }
}
