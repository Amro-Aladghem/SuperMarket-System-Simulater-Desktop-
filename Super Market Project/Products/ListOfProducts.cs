using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuesineesLyer;
using Super_Market_Project.Providers;
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project.Products
{
    public partial class ListOfProducts : Form
    {
        public ListOfProducts()
        {
            InitializeComponent();
        }

        private void ReffreshData()
        {
            cbxFilter.SelectedIndex = 0;
            dataGridView1.DataSource = clsProducts.GetAllProducts();
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }


        private void ListOfProducts_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedIndex != -1)
            {
                string filterColumn = cbxFilter.SelectedItem.ToString();
                string filterValue = txtFilter.Text;

                // تطبيق الفلترة على DataTable
                if (!string.IsNullOrEmpty(filterValue))
                {
                    if (cbxFilter.SelectedIndex == 2||cbxFilter.SelectedIndex==3)
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, filterValue);
                        lbRecords.Text = dataGridView1.RowCount.ToString();
                    }
                    else
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format($"{filterColumn}={filterValue}");
                        lbRecords.Text = dataGridView1.RowCount.ToString();
                    }
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty; // إلغاء الفلتر
                    lbRecords.Text = dataGridView1.RowCount.ToString();
                }
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxFilter.SelectedIndex==0)
            {
                txtFilter.Visible = false;
                txtFilter.Clear();
            }
            else
            {
                txtFilter.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProductToStorage frm = new AddProductToStorage();
            frm.ShowDialog();
            ReffreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                UdpateProduct frm = new UdpateProduct((string)dataGridView1.CurrentRow.Cells[1].Value);
                frm.ShowDialog();
                ReffreshData();
            }
            else
            {
                MessageBox.Show("You must select one User least");
                return;
            }
        }

        private void updateProductPriceQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UdpateProduct frm = new UdpateProduct((string)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void productInfromationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductInfromation frm = new ProductInfromation((string)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

        }

        private void isExpiredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsProducts.isExpiaredProduct((int)dataGridView1.CurrentRow.Cells[0].Value, (string)dataGridView1.CurrentRow.Cells[1].Value))
            {
                MessageBox.Show("This Product is Expired!");
            }
            else
            {
                MessageBox.Show("This Product Not Expired!");
            }
        }

        private void providerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProviderInfo frm = new ProviderInfo((int)dataGridView1.CurrentRow.Cells[5].Value);
            frm.ShowDialog();
        }

        private void deleteProductFromStorageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure to delete this product from storage!","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(clsProducts.DeleteProduct((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Product has deleted Successfully");
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.Delete, DateTime.Now, (int)dataGridView1.CurrentRow.Cells[0].Value, null, null, LogedInUser.UserID);
                    ReffreshData();
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
    }
}
