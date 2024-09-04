using BuesineesLyer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Super_Market_Project.Products.FindProductByFilter;

namespace Super_Market_Project.VegOrFruit
{
    public partial class ctrFindVegOrFruitByFilter : UserControl
    {
        public ctrFindVegOrFruitByFilter()
        {
            InitializeComponent();
        }

        public class GetVegOrFruitQR
        {

            public string VegOrFruitQR { get; }
            
            public GetVegOrFruitQR(string VegOrFruitQR)
            {
                this.VegOrFruitQR = VegOrFruitQR;
            }

        }

        
        public event EventHandler<GetVegOrFruitQR> OnSearchClick;


        clsVegAndFruit vegAndFruit;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            vegAndFruit = clsVegAndFruit.FindVegOrFruitByQR(txtFilter.Text);
            if (vegAndFruit!=null)
            {
                if (vegAndFruit.IsVegOrFruitHasMoreThanOneDate(txtFilter.Text))
                {
                    btnSearch.Enabled = false;
                    btnDateSearch.Visible = true;
                    dateTimePicker1.Visible = true;
                    lbEnter.Visible = true;
                }
                else
                {
                    ctrVegOrFruitInfo1.GetIDAndCreatClassAndLoadData(vegAndFruit.VegOrFruitID);
                    OnSearchClick?.Invoke(this, new GetVegOrFruitQR(vegAndFruit.VegOrFruitQR));
                }

            }
            else
            {
                MessageBox.Show("The Product Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrVegOrFruitInfo1.Reset();
            }
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            vegAndFruit = clsVegAndFruit.FindVegOrFruitByQRAndEnrollDate(txtFilter.Text, dateTimePicker1.Value);
            if (vegAndFruit != null)
            {
                ctrVegOrFruitInfo1.GetIDAndCreatClassAndLoadData(vegAndFruit.VegOrFruitID);
                OnSearchClick?.Invoke(this, new GetVegOrFruitQR(vegAndFruit.VegOrFruitQR));
            }
            else
            {
                MessageBox.Show("The Product Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrVegOrFruitInfo1.Reset();
            }
        }
    }
}
