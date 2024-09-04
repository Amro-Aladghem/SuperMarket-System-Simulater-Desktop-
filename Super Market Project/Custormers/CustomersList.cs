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

namespace Super_Market_Project.Custormers
{
    public partial class CustomersList : Form
    {
        public CustomersList()
        {
            InitializeComponent();
        }

        private void ReffreshData()
        {
            dataGridView1.DataSource = clsCustomers.GetAllCustomerInSystem();
            lbUsername.Text = LoggedInUser.LogedInUser.UserName;
            lbRecord.Text = dataGridView1.RowCount.ToString();

        }

        private void CustomersList_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdateCustomer frm = new AddUpdateCustomer();
            frm.ShowDialog();
            ReffreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
                AddUpdateCustomer frm = new AddUpdateCustomer((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                ReffreshData();
            }
            else
            {
                MessageBox.Show("You must select one Person and only one");
                return;
            }
        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateCustomer frm = new AddUpdateCustomer((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure to delete this customer!","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(clsCustomers.DeleteCustomerFromSystem((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Process has been Done!");
                    ReffreshData();
                }
                else
                {
                    MessageBox.Show("The Process Cancled Somthing Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("The Process Canceled!");
            }
        }

        private void deActivateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCustomers Customer = clsCustomers.FindCustomerByID((int)dataGridView1.CurrentRow.Cells[0].Value);
            if(Customer.isActive==false)
            {
                MessageBox.Show("This Customer already is DeActivate!");
                return;
            }
        
            
                if(MessageBox.Show("Are You sure to Deactivate This Customer!","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    Customer.isActive = false;
                    if(Customer.Save())
                    {
                        MessageBox.Show("The Proces Done Sucssfully!");
                        ReffreshData();
                    }
                    else
                    {
                        MessageBox.Show("The Process Cancled Somthing Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("The Process Cancled ");
                }
            
        }

        private void activateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCustomers Customer = clsCustomers.FindCustomerByID((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (Customer.isActive == true)
            {
                MessageBox.Show("This Customer already is Active!");
                return;
            }


                if (MessageBox.Show("Are You sure to activate This Customer!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                Customer.isActive = true;
                if (Customer.Save())
                {
                    MessageBox.Show("The Proces Done Sucssfully!");
                    ReffreshData();
                }
                else
                {
                    MessageBox.Show("The Process Cancled Somthing Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                }
                else
                {
                MessageBox.Show("The Process Cancled!");
                }
            
        }

        private void changLastOrderDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLastOrderDate frm = new ChangeLastOrderDate((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ReffreshData();
        }
    }
}
