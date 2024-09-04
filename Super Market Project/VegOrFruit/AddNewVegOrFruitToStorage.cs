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

namespace Super_Market_Project.VegOrFruit
{
    public partial class AddNewVegOrFruitToStorage : Form
    {
        public AddNewVegOrFruitToStorage()
        {
            InitializeComponent();
        }

        private void InitializeNumericUpDown()
        {

            numericPrice.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
            numericPrice.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
            numericPrice.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
            numericPrice.Increment = (decimal)0.1;

            numericKilogram.Minimum = (decimal)-100.0; // تعيين الحد الأدنى
            numericKilogram.Maximum = (decimal)100.0;  // تعيين الحد الأقصى
            numericKilogram.DecimalPlaces = 2;         // تعيين عدد الأماكن العشرية
            numericKilogram.Increment = (decimal)0.1;

        }

        string ImageLocation;
        string ProductQR;
        clsVegAndFruit vegAndFruit = new clsVegAndFruit();

        private void ResetData()
        {
            foreach (Control control in tabPage2.Controls)
            {
                control.Enabled = false;
            }
        }

        private void LoadData()
        {
            lbQR.Text = ProductQR;
            lbQr2.Text = ProductQR;
            lbVegName.Text = clsVegAndFruit.GetVegOrFruitName(ProductQR);
            FillProviderBox();
            foreach (Control control in tabPage2.Controls)
            {
                control.Enabled = true;
            }

            cBIsExpired.Enabled = false;
        }

        private void FillProviderBox()
        {
            DataTable data = clsProviders.GetAllProviders();
            foreach(DataRow row in data.Rows)
            {
                cbxProvider.Items.Add(row["Name"]);
            }

            cbxProvider.SelectedIndex = 0;
        }

      
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
                if (!string.IsNullOrEmpty(vegAndFruit.ImageLocation) && File.Exists(vegAndFruit.ImageLocation))
                {
                    File.Delete(vegAndFruit.ImageLocation);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddVegOrFruitToSystem frm = new AddVegOrFruitToSystem();
            frm.ShowDialog();
            tabControl1.Enabled = true;
        }

        private void btnExsits_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsVegAndFruit.IsVegOrFruitExitesInTheSystem(txtFilter.Text))
            {
                ProductQR = txtFilter.Text;
                LoadData();
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("This Veg/Fruit Not Found\n Cheack the QR Or you can add new one", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void AddNewVegOrFruitToStorage_Load(object sender, EventArgs e)
        {

            ResetData();
        }

        private void numericPrice_Validating(object sender, CancelEventArgs e)
        {
            if((float)(numericPrice.Value)<0.5||(float)(numericPrice.Value)==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericPrice, "The Price must above 0.5");
                numericPrice.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericKilogram, "");
            }
        }

        private void numericKilogram_Validating(object sender, CancelEventArgs e)
        {
            if  ((float)(numericKilogram.Value) == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericKilogram, "The Quantity must above 0");
                numericKilogram.Focus();

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericKilogram, "");
            }
        }

        private void lbAddProvider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateProvider frm = new AddUpdateProvider();
            frm.ShowDialog();
            FillProviderBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if(ValidateChildren())
            {
                if (MessageBox.Show("Are You sure to Add this Veg/Fruit?", "Querstion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    vegAndFruit.VegOrFruitQR = ProductQR;
                    vegAndFruit.EnrollDate = dateTimeEnrolled.Value;
                    vegAndFruit.IsExpired = false;
                    vegAndFruit.Price = (double)numericPrice.Value;
                    vegAndFruit.Kilogram=(float)numericKilogram.Value;
                    vegAndFruit.ProviderID = clsProviders.FindWithName(cbxProvider.Text).ProviderId;
                    vegAndFruit.DateOfSet = DateTime.Now;

                    if (pictureBox2.Image == Resources.add_to_basket)
                    {
                        vegAndFruit.ImageLocation = null;
                    }
                    else
                    {
                        vegAndFruit.ImageLocation = pictureBox2.ImageLocation;
                    }

                    if (vegAndFruit.Save())
                    {
                        MessageBox.Show("The Veg/Fruit Save Successfully!", "Infromation", MessageBoxButtons.OK);
                        btnSave.Enabled = false;

                        clsApplication.AddNewApplicationToSystem((int)eOperationType.Add, DateTime.Now, null, vegAndFruit.VegOrFruitID, null, LogedInUser.UserID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
