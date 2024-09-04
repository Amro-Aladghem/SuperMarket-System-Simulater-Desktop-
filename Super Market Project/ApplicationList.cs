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

namespace Super_Market_Project
{
    public partial class ApplicationList : Form
    {
        public ApplicationList()
        {
            InitializeComponent();
        }



        private void LoadData()
        {
            dataGridView1.DataSource = clsApplication.GetAllApplicationRecord();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplicationList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
