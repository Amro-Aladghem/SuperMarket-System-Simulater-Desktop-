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
    public partial class FindCustomerInvoice : Form
    {
        public FindCustomerInvoice()
        {
            InitializeComponent();
        }

        int OrderID;
        clsCusInvoice Invoice;
        private void LoadDataToDetailsGrid()
        {
            dataGridView2.DataSource = clsOrder.GetOrderElementForInvoice(OrderID);
        }

        private void LoadDataToInvoiceGrid()
        {
            dataGridView1.DataSource = clsCusInvoice.GetAllInvoicesForCustomer();
            string filterColumn = "OrderID";
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format($"{filterColumn}={this.OrderID}");
        }













        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            if(txtInvoice.Text=="")
            {
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled= true;
            }
        }

        private void FindCustomerInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Invoice = clsCusInvoice.FindInvoiceForCustomer(Convert.ToInt32(txtInvoice.Text));
            if(Invoice== null)
            {
                MessageBox.Show("This Invoice Not Found In System!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                return;
            }

            this.OrderID = Invoice.OrderID;
            LoadDataToDetailsGrid();
            LoadDataToInvoiceGrid();

        }
    }
}
