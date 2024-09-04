using BuesineesLyer;
using Super_Market_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project.Users
{
    public partial class ctrAddUser : UserControl
    {
        public ctrAddUser()
        {
            InitializeComponent();
        }

        
        clsUsers User = new clsUsers();
        string ImageLocation = "";


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private int GetTotalPermision()
        {
            int TotalPermision = 0;
            int BinaryCounter = 1;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    TotalPermision += BinaryCounter;
                }

              BinaryCounter*= 2;
            }

            return TotalPermision;
            
        }


        private void ctrAddUpdateUser_Load(object sender, EventArgs e)
        {
            //lbUserName.Text = LoggedInUser.LogedInUser.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "")
            {
                MessageBox.Show("You must Enter an EmployeeID!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                if(clsEmployees.isExist(EmployeeID))
                {
                    if (!clsUsers.IsEmployeeAnUser(EmployeeID))
                    {
                        EmployeeInfo frm = new EmployeeInfo(EmployeeID);
                        frm.ShowDialog();
                        groupBox1.Enabled = true;
                        lbEmployeeID.Text = EmployeeID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("This Employee is already an User", "Error", MessageBoxButtons.OK);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("This Person not found", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {

                if(MessageBox.Show("Are You Sure To Add This User ?","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    User.UserName = txtUserName.Text;
                    User.isActive = chBisActive.Checked;
                    User.Password= txtPassword.Text;
                    User.Permisions= GetTotalPermision();
                    if(pictureBox1.Image==Resources.working)
                    {
                        User.ImagePicture = null;
                    }
                    User.ImagePicture = pictureBox1.ImageLocation;
                    User.EmployeeID = Convert.ToInt32(lbEmployeeID.Text);
                    if(User.Save())
                    {
                        MessageBox.Show("The User Added Successfully");
                        btnSave.Enabled = false;
                        lbUserID.Text= User.UserID.ToString();
                        clsApplication.AddNewApplicationToSystem((int)eOperationType.AddUser, DateTime.Now, null, null, null, LogedInUser.UserID);

                    }
                    else
                    {
                        MessageBox.Show("The Process Canceld Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "You must Fill it!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void checkedListBox1_Validating(object sender, CancelEventArgs e)
        {
            if(checkedListBox1.CheckedItems.Count==0)
            {
                e.Cancel = true;
                checkedListBox1.Focus();
                errorProvider1.SetError(checkedListBox1, "You must choose at least one item!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(checkedListBox1, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "You must Fill it !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtConfirmPass, "You must Fill it!");
            }
            else if(txtPassword.Text!=txtConfirmPass.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPass, "The Password is not the same");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPass, "");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPass.Clear();
        }

        private void lbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // إنشاء OpenFileDialog للسماح للمستخدم باختيار صورة
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // عرض الصورة المختارة في PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                // إنشاء معرف فريد (GUID) للصورة الجديدة
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog.FileName);

                // تحديد المسار الجديد للصورة على محرك الأقراص C
                string folderPath = @"C:\SuperMarket\";
                string newFilePath = Path.Combine(folderPath, uniqueFileName);
                ImageLocation = newFilePath;

                // التحقق من وجود المجلد وإذا لم يكن موجودًا يتم إنشاؤه


                // حذف الصورة القديمة إذا كانت موجودة
                if (!string.IsNullOrEmpty(User.ImagePicture) && File.Exists(User.ImagePicture))
                {
                    File.Delete(User.ImagePicture);
                }

                // نسخ الصورة الجديدة إلى المسار الجديد
                File.Copy(openFileDialog.FileName, newFilePath);

                pictureBox1.ImageLocation = Path.Combine(folderPath, uniqueFileName);

                lbRemoveImage.Enabled = true;
            }
        }

        private void lbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are You sure for delete this picture ?", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                File.Delete(ImageLocation);
                pictureBox1.ImageLocation = "";
                pictureBox1.Image = Resources.working;
                lbRemoveImage.Enabled = false;
            }
            else
            {
                MessageBox.Show("Procces Canceld !");
            }
        }
    }
}
