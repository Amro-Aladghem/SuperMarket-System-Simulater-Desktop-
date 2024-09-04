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

namespace Super_Market_Project.MainAndLog
{
    public partial class CustomerInvoicesHistory : Form
    {
        public CustomerInvoicesHistory()
        {
            InitializeComponent();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
                txtFilter.Clear();
            }
            else
            {
                txtFilter.Visible = true;
            }
        }


        private void LoadData()
        {
            dataGridView1.DataSource = clsCusInvoice.GetAllInvoicesForCustomer();
            lbRecords.Text = dataGridView1.RowCount.ToString();
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
                  
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format($"{filterColumn}={filterValue}");
                        lbRecords.Text = dataGridView1.RowCount.ToString();
                    
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty; // إلغاء الفلتر
                    lbRecords.Text = dataGridView1.RowCount.ToString();
                }
            }
        }

        private void deleteFromSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure to delete this Invoice From System!","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(!clsCusInvoice.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Somthin Error!, The Process Cancled");
                    return;
                }

                LoadData();
            }
            else
            {
                return;
            }
        }

        private void openDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerInvoiceInfo frm = new CustomerInvoiceInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerInvoicesHistory_Load(object sender, EventArgs e)
        {
            cbxFilter.SelectedIndex = 0;
            LoadData();
        }
    }
}
