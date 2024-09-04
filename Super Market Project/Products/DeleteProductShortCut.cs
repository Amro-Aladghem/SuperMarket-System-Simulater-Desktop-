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
    public partial class DeleteProductShortCut : Form
    {
        public DeleteProductShortCut()
        {
            InitializeComponent();
        }

        clsProducts Product;
        private void findProductByFilter1_OnSearchClick(object sender, FindProductByFilter.GetProductQR e)
        {
            btnDelete.Enabled = true;
            Product = clsProducts.FindProductByQR(e.ProductQR);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Product.Quantity!=0)
            {
                if (MessageBox.Show("Are You sure to delete this product from storage!", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (clsProducts.DeleteProduct(Product.ProductID))
                    {
                        MessageBox.Show("The Product has deleted Successfully");
                        clsApplication.AddNewApplicationToSystem((int)eOperationType.Delete, DateTime.Now, Product.ProductID, null, null, LogedInUser.UserID);
                    }
                    else
                    {
                        MessageBox.Show("The Procees cancled Somthing Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("You cant delete this product , because Quantity not Zero","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
            }
        }
    }
}
