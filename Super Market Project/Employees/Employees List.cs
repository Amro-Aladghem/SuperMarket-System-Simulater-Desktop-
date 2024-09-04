using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuesineesLyer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Super_Market_Project
{
    public partial class Employees_List : Form
    {
        public Employees_List()
        {
            InitializeComponent();
        }


        private void ReffreshData()
        {
            dataGridView1.DataSource = clsEmployees.GetAllEmployees();
            lbRecords.Text=dataGridView1.RowCount.ToString(); 
        }

        private void Employees_List_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdateEmployee frm = new AddUpdateEmployee();
            frm.ShowDialog();
            ReffreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        if(dataGridView1.SelectedRows.Count == 0||dataGridView1.SelectedRows.Count>1)
            {
                MessageBox.Show("You Must Select one Person");
            }
            else
            {
                AddUpdateEmployee frm = new AddUpdateEmployee((int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                ReffreshData();
            }
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
                    if (cbxFilter.SelectedIndex == 2)
                    {
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, filterValue);
                        lbRecords.Text = dataGridView1.RowCount.ToString();
                    }
                    else if (cbxFilter.SelectedIndex == 3||cbxFilter.SelectedIndex==5)
                    {
                        if (DateTime.TryParse(filterValue, out DateTime date))
                        {
                            // تأكد من استخدام تنسيق التاريخ المتوافق مع InvariantCulture
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("{0} = #{1:dd/MM/yyyy}#", filterColumn, date);
                        }

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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateEmployee frm = new AddUpdateEmployee((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            Refresh();
        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeInfo frm = new EmployeeInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure to delete this Employee?","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(clsEmployees.DeleteEmployee((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Process has Done :=)");
                    ReffreshData();
                }
            }
            else
            {
                return;
            }
            
        }
    }
}
