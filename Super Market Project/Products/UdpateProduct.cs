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

namespace Super_Market_Project.Products
{
    public partial class UdpateProduct : Form
    {
        public UdpateProduct(string ProductQR)
        {
            InitializeComponent();
            Product = clsProducts.FindProductByQR(ProductQR);
        }


        clsProducts Product;

        private void LoadData()
        {
            lbProductQR.Text = Product.ProductQR;
            lbProductName.Text = clsProducts.GetProductName(Product.ProductQR);
            numericPrice.Value = (decimal)Product.Price;
            numericQuantity.Value= (decimal)Product.Quantity;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UdpateProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product.Price=(double)numericPrice.Value;
            Product.Quantity=(int)numericQuantity.Value;

            if(MessageBox.Show("Are You sure to Update The Product with QR\n"+Product.ProductQR,"Warnning",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                if (Product.Save())
                {
                    MessageBox.Show("The Product Update Successfully!");
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.Update, DateTime.Now, Product.ProductID, null, null, LogedInUser.UserID);

                    btnSave.Enabled = false;
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
    }
}
