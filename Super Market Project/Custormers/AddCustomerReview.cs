using BuesineesLyer;
using Super_Market_Project.Properties;
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
    public partial class AddCustomerReview : Form
    {

        enum eModeSearch { Prodcut=1,VegOrFruit=2}
        eModeSearch ModeSearch;
        public AddCustomerReview()
        {
            InitializeComponent();
        }

        private List<PictureBox> pictureBoxList;
        private void LoadPictureBoxToList()
        {
            pictureBoxList=new List<PictureBox>();
            pictureBoxList.Add(pictureBox1);
            pictureBoxList.Add(pictureBox2);
            pictureBoxList.Add(pictureBox3);
            pictureBoxList.Add(pictureBox4);
            pictureBoxList.Add(pictureBox5);
        }

        private void MoveAndRemoveStarsReview(int FinalStarIndex)
        {
            for(int i = 0;i<5;i++)
            {
                if(i<=FinalStarIndex-1)
                {
                    pictureBoxList.ElementAt(i).Image = Resources.star;
                }
                else
                {
                    pictureBoxList.ElementAt(i).Image = Resources.favourite;
                }
            }


          

        }

        clsCustomers Customer;

        int? ProductID = null;
        int? VegAndFruitID = null;

        int StarCounter=0;



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddCustomerReview_Load(object sender, EventArgs e)
        {
            rdProduct.Checked = true;
            LoadPictureBoxToList();
        }

        private void txtCustomerID_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }

        private void ResetControlSettings()
        {
            panel1.Enabled = true;
            rdProduct.Checked = true;
            ModeSearch = eModeSearch.Prodcut;
            groupBox1.Enabled = false;
            btnConfirm.Enabled = false;
            txtNots.Enabled = false;    
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            Customer = clsCustomers.FindCustomerByID(Convert.ToInt32(txtCustomerID.Text));
            if (Customer != null)
            {
               ResetControlSettings();

            }
            else
            {
                MessageBox.Show("This Customer Not Found!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            
            
            
        }

        private void txtProdOrVeg_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtProdOrVeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }


        private void LoadData()
        {

            if (ModeSearch == eModeSearch.Prodcut)
            {

                if (clsProducts.IsProductExitsInTheStorage(Convert.ToInt32(txtProdOrVeg.Text)))
                {
                    ProductID = Convert.ToInt32(txtProdOrVeg.Text);
                    VegAndFruitID = null;
                    txtNots.Enabled = true;
                    groubBox1.Enabled = true;
                    btnConfirm.Enabled = true;

                }
                else
                {
                    MessageBox.Show("This Product Not Found !");
                }

            }
            else
            {
                if (clsVegAndFruit.IsVegOrProductExitsInTheStorage(Convert.ToInt32(txtProdOrVeg.Text)))
                {
                    ProductID = null;
                    VegAndFruitID = Convert.ToInt32(txtProdOrVeg.Text);
                    txtNots.Enabled = true;
                    groubBox1.Enabled = true;
                    btnConfirm.Enabled = true;

                }
                else
                {
                    MessageBox.Show("This VegOrFruit Not Found!");
                }
            }


        }

        private void btnSearchProd_Click(object sender, EventArgs e)
        {
            if (txtProdOrVeg.Text == "")
            {
                MessageBox.Show("You must Enter Product/Veg ID First!");
                return;
            }

            LoadData();
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (clsCustomers.AddNewCustomerReview(Customer.CustomerID, ProductID, VegAndFruitID, StarCounter, txtNots.Text))
            {
                MessageBox.Show("The Review Added Succesfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("The Process Canceled,Somthing Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void rdProduct_CheckedChanged(object sender, EventArgs e)
        {
            ModeSearch = eModeSearch.Prodcut;
        }

        private void rdVegAndFruit_CheckedChanged(object sender, EventArgs e)
        {
            ModeSearch = eModeSearch.VegOrFruit;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MoveAndRemoveStarsReview(1);
            StarCounter = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MoveAndRemoveStarsReview(2);
            StarCounter = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MoveAndRemoveStarsReview(3);
            StarCounter = 3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MoveAndRemoveStarsReview(4);
            StarCounter = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MoveAndRemoveStarsReview(5);
            StarCounter = 5;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            btnSearchCustomer.Enabled = true;
        }
    }
}
