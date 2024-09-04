using BuesineesLyer;
using Super_Market_Project.Providers;
using Super_Market_Project.VegOrFruit;
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

namespace Super_Market_Project
{
    public partial class VegOrFruitList : Form
    {
        public VegOrFruitList()
        {
            InitializeComponent();
        }

       private void ReffreshDate()
        {
            lbUserName.Text = LoggedInUser.LogedInUser.UserName;
            dataGridView1.DataSource = clsVegAndFruit.GetAllVegAndFruit();
            lbRecord.Text=dataGridView1.RowCount.ToString();
        }

        private void VegOrFruitList_Load(object sender, EventArgs e)
        {
            ReffreshDate();
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
                    if (cbxFilter.SelectedIndex == 2 || cbxFilter.SelectedIndex == 3)
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, filterValue);
                        lbRecord.Text = dataGridView1.RowCount.ToString();
                    }
                    else
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format($"{filterColumn}={filterValue}");
                        lbRecord.Text = dataGridView1.RowCount.ToString();
                    }
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty; // إلغاء الفلتر
                    lbRecord.Text = dataGridView1.RowCount.ToString();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0||dataGridView1.SelectedRows.Count>1)
            {
                MessageBox.Show("You must select at lesat one Product!");
            }
            else
            {
                clsVegAndFruit vegAndFruit = clsVegAndFruit.FindByID((int)dataGridView1.CurrentRow.Cells[0].Value);
                UpdateVegOrFruit frm = new UpdateVegOrFruit(vegAndFruit);
                frm.ShowDialog();
                ReffreshDate();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewVegOrFruitToStorage frm = new AddNewVegOrFruitToStorage();
            frm.ShowDialog();
            ReffreshDate();
        }

        private void updateVegOrFruitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsVegAndFruit vegAndFruit = clsVegAndFruit.FindByID((int)dataGridView1.CurrentRow.Cells[0].Value);
            UpdateVegOrFruit frm = new UpdateVegOrFruit(vegAndFruit);
            frm.ShowDialog();
            ReffreshDate();
        }

        private void selectedInfromationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VegOrFruitInfromation frm = new VegOrFruitInfromation((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void isExpiredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsVegAndFruit.IsExpiredVegOrFruit((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This Product is Expired");
            }
            else
            {
                MessageBox.Show("This Product is Not Expired!");
            }
        }

        private void providerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProviderInfo frm = new ProviderInfo((int)dataGridView1.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure to delete this product from storage!", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsVegAndFruit.DeleteVegOrFruit((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Product has deleted Successfully");
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.Delete, DateTime.Now, null, (int)dataGridView1.CurrentRow.Cells[0].Value, null, LogedInUser.UserID);
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
