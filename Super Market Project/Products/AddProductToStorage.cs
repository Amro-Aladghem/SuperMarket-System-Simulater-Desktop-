using BuesineesLyer;
using Super_Market_Project.Properties;
using Super_Market_Project.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project.Products
{
    public partial class AddProductToStorage : Form
    {
        public AddProductToStorage()
        {
            InitializeComponent();
        }

        string ImageLocation;
        clsProducts Product = new clsProducts();
        string ProductQR;















        private void lbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // عرض الصورة المختارة في PictureBox
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);

                // إنشاء معرف فريد (GUID) للصورة الجديدة
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog.FileName);

                // تحديد المسار الجديد للصورة على محرك الأقراص C
                string folderPath = @"C:\SuperMarket\";
                string newFilePath = Path.Combine(folderPath, uniqueFileName);
                ImageLocation = newFilePath;

                // التحقق من وجود المجلد وإذا لم يكن موجودًا يتم إنشاؤه


                // حذف الصورة القديمة إذا كانت موجودة
                if (!string.IsNullOrEmpty(Product.ImageLocation) && File.Exists(Product.ImageLocation))
                {
                    File.Delete(Product.ImageLocation);
                }

                // نسخ الصورة الجديدة إلى المسار الجديد
                File.Copy(openFileDialog.FileName, newFilePath);

                pictureBox2.ImageLocation = Path.Combine(folderPath, uniqueFileName);

                lbRemove.Enabled = true;
            }
        }

        private void lbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are You sure for delete this picture ?", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                File.Delete(ImageLocation);
                pictureBox2.ImageLocation = "";
                pictureBox2.Image = Resources.working;
                lbRemove.Enabled = false;
            }
            else
            {
                MessageBox.Show("Procces Canceld !");
            }
        }

       

        private void FillProvidercbx()
        {
            DataTable dataTable = clsProviders.GetAllProviders();
            foreach(DataRow row in dataTable.Rows)
            {
                cbxProviders.Items.Add(row["Name"]);
            }
        }

        private void LoadData()
        {
            lbProductName.Text = clsProducts.GetProductName(ProductQR);
            lbProductQR.Text = ProductQR;
            lbProductQR2.Text = ProductQR;
            FillProvidercbx();
            foreach(Control control in tabPage2.Controls)
            {
                control.Enabled = true;
            }
        }

        private void ResetData()
        {
            foreach(Control control in tabPage2.Controls)
            {
                control.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            if(clsProducts.IsProductExitsInTheSystem(txtFind.Text))
            {
                ProductQR = txtFind.Text;
                LoadData();
                tabControl1.SelectedIndex = 1;
            }
            else
            {
               MessageBox.Show("This Product Not Found\n Cheack the QR Or you can add new one","Warrning",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void lbAddProvider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateProvider frm = new AddUpdateProvider();
            frm.ShowDialog();
            FillProvidercbx();
        }

        private void dateTimeEnd_Validating(object sender, CancelEventArgs e)
        {
            if( dateTimeEnd.Value<=dateTimeProduced.Value)
            {
                e.Cancel = true;
                errorProvider1.SetError(dateTimeEnd, "The date is less than ProducedDate!");
                dateTimeEnd.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dateTimeEnd, "");
            }
        }

        private void numericPrice_Validating(object sender, CancelEventArgs e)
        {
            if((int)numericPrice.Value==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericPrice, "The Price must be above 0 dollar!");
                numericPrice.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericPrice, "");
            }
        }

        private void numericQuantity_Validating(object sender, CancelEventArgs e)
        {
            if ((int)numericQuantity.Value == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericQuantity, "The Price must be above 0 dollar!");
                numericQuantity.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericQuantity, "");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {

                if(MessageBox.Show("Are You sure to Add this Product?","Querstion",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    Product.ProductQR = ProductQR;
                    Product.ProducedDate = dateTimeProduced.Value;
                    Product.EndDate = dateTimeEnd.Value;
                    Product.Price =(double) numericPrice.Value;
                    Product.Quantity = (int)numericQuantity.Value;
                    if(pictureBox2.Image==Resources.innovation)
                    {
                        Product.ImageLocation = null;
                    }
                    else
                    {
                        Product.ImageLocation = pictureBox2.ImageLocation;
                    }

                    Product.ProviderID = clsProviders.FindWithName(cbxProviders.Text).ProviderId;
                    Product.DateOfSet= DateTime.Now;

                    if(Product.Save())
                    {
                        MessageBox.Show("The Product Save Successfully!", "Infromation", MessageBoxButtons.OK);
                        clsApplication.AddNewApplicationToSystem((int)eOperationType.Add, DateTime.Now, Product.ProductID, null, null, LogedInUser.UserID);
                        btnSave.Enabled = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The Process faild Something Error!");
                    }

                }
                else
                {
                    return;
                }    





            }
        }

        private void AddProductToStorage_Load(object sender, EventArgs e)
        {
            MessageBox.Show("You must Determine if product is New Or Exits First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetData();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductToSystem frm = new AddProductToSystem();
            frm.ShowDialog();
            tabControl1.Enabled = true;
        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
