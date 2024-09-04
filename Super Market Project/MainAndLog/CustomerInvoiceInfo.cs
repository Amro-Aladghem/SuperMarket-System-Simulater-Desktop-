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
    public partial class CustomerInvoiceInfo : Form
    {
        public CustomerInvoiceInfo(int OrderID)
        {
            InitializeComponent();
            this.OrderID = OrderID;
        }

        int OrderID;

        private  void LoadData()
        {
            dataGridView2.DataSource=clsOrder.GetOrderElementForInvoice(OrderID);
        }

        private void CustomerInvoiceInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
