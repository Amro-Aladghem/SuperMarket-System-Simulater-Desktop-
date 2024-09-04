using BuesineesLyer;
using Super_Market_Project.Products;
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
    public partial class OffersList : Form
    {
        public OffersList()
        {
            InitializeComponent();
        }

        private void ReffreshData()
        {
            lbCurrentUser.Text = LoggedInUser.LogedInUser.UserName;
            dataGridView1.DataSource = clsOffers.GetAllOffersInTheSystem();
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cbxFilter.SelectedIndex != -1)
            {
                string filterColumn = cbxFilter.SelectedItem.ToString();
                string filterValue = txtFilter.Text;

                // تطبيق الفلترة على DataTable
                if (!string.IsNullOrEmpty(filterValue))
                {
                    if (cbxFilter.SelectedIndex == 3 || cbxFilter.SelectedIndex == 5)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewOffer frm = new AddNewOffer();
            frm.ShowDialog();
            ReffreshData();
        }

        private void OffersList_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0||dataGridView1.SelectedRows.Count>1)
            {
                MessageBox.Show("You Must Select at least and only one Item!");
            }
            else
            {
                UpdatePercentage frm = new UpdatePercentage((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                ReffreshData();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void updatePercentageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePercentage frm = new UpdatePercentage((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void deleteOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete this Offer from system!","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsOffers.DeleteOfferFromTheSystem((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Process  is Done!");
                    ReffreshData();
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.Add, DateTime.Now, null, null, (int)dataGridView1.CurrentRow.Cells[0].Value, LogedInUser.UserID);
                }
                else
                {
                    MessageBox.Show("The Process isnot Done Somthing Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
