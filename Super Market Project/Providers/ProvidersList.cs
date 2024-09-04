using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuesineesLyer;

namespace Super_Market_Project.Providers
{
    public partial class ProvidersList : Form
    {
        public ProvidersList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReffreshData()
        {
            dataGridView1.DataSource = clsProviders.GetAllProviders();
            lbRecord.Text = dataGridView1.RowCount.ToString();
            lbUserName.Text = LoggedInUser.LogedInUser.UserName;
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxFilter.SelectedIndex == 0)
            {
                txtFilter.Visible= false;
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
                    if (cbxFilter.SelectedIndex == 2)
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

        private void ProvidersList_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            AddUpdateProvider frm = new AddUpdateProvider();
            frm.ShowDialog();
            ReffreshData();
        }

        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                AddUpdateProvider frm = new AddUpdateProvider((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                ReffreshData();
            }
            else
            {
                MessageBox.Show("You must select At Leaset One Provider", "Error", MessageBoxButtons.OK);
            }
        }

        private void updateProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateProvider frm = new AddUpdateProvider((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void providerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProviderInfo frm = new ProviderInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void deleteProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure To Delete this Provider","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            { 

            if(clsProviders.DeleteProvider((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Process Done Successfully!");
                    ReffreshData();
                }
            else
                {
                    MessageBox.Show("The Process Canceled Somthing Error!");
                }
            }
            else
            {
                return;
            }
        }

        private void changeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeProviderInfo frm = new ChangeProviderInfo(clsProviders.eTypeChange.Email, (int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void changePhoneNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeProviderInfo frm = new ChangeProviderInfo(clsProviders.eTypeChange.PhoneNumber, (int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void changeDateOfComingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeProviderInfo frm = new ChangeProviderInfo(clsProviders.eTypeChange.DateOfComing, (int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }
    }
}
