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
    public partial class FindProductByFilter : UserControl
    {
        public FindProductByFilter()
        {
            InitializeComponent();
        }

        public class GetProductQR
        {
            public  string ProductQR { get; }

            public GetProductQR(string QR)
            {
               this.ProductQR = QR;
            }
        }


        public event EventHandler<GetProductQR> OnSearchClick;

        clsProducts Product;
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }
        
        private void LoadAllData()
        {
            if (Product != null)
            {
                lbProductID.Text = Product.ProductID.ToString();
                lbProductQR.Text = Product.ProductQR.ToString();
                lbProducedDate.Text = Product.ProducedDate.ToShortDateString();
                lbEndDate.Text = Product.EndDate.ToShortDateString();
                lbProviderID.Text = Product.ProviderID.ToString();
                lbPrice.Text = Product.Price.ToString() + " " + "jd";
                lbQuantity.Text = Product.Quantity.ToString() + " " + "Unit";
                lbDateOFSet.Text = Product.DateOfSet.ToShortDateString();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product=clsProducts.FindProductByQR(txtFind.Text);
            if(Product!=null)
            {
                if(Product.IsProductHasMoreThanOneProducedDate())
                {
                    btnSearchByDate.Enabled = true;
                    label10.Visible = true;
                    dateTimePicker2. Visible = true;
                    btnSearchByDate.Visible = true;
                    btnSearch.Enabled = false;
                }
                else
                {
                    LoadAllData();
                    OnSearchClick?.Invoke(this, new GetProductQR(Product.ProductQR));
                }

            }
            else
            {
                MessageBox.Show("The Product Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FindProductByFilter_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            btnSearchByDate.Enabled = true;
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            Product = clsProducts.FindProductByQRAndProducedDate(txtFind.Text,dateTimePicker2.Value);
            if(Product != null)
            {
                LoadAllData();
                OnSearchClick?.Invoke(this, new GetProductQR(Product.ProductQR));
            }
            else
            {
                MessageBox.Show("The Product Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
