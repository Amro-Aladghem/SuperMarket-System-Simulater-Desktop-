using BuesineesLyer;
using Super_Market_Project.Properties;
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


namespace Super_Market_Project.Users
{
    public partial class ctrUpdateUser : UserControl
    {
        public ctrUpdateUser()
        {
            InitializeComponent();
        }

        public void GetUserAndCreatObject(int UserId)
        {
            User = clsUsers.FindUserByID(UserId);
        }

        clsUsers User;
        string ImageLocation;

        

        private void SetCheckPermisions()
        {
            int TotalPermisions = User.Permisions;
            int BinaryCounter = 1;
            for(int i=0;i<chxPermisions.Items.Count;i++)
            {
                if((BinaryCounter&TotalPermisions)==BinaryCounter)
                {
                   chxPermisions.SetItemChecked(i, true);
                }

                BinaryCounter *= 2;
            }

        }

        private void LoadAllData()
        {
            if (User != null)
            {
                lbUserID.Text = User.UserID.ToString();
                txtUserName.Text = User.UserName;
                chxIsActive.Checked = User.isActive;
                txtPassword.Text = User.Password;
                SetCheckPermisions();
                if (User.ImagePicture != null||User.ImagePicture=="")
                {
                    pictureBox1.ImageLocation = User.ImagePicture;
                    lbRemovePic.Enabled = true;
                    ImageLocation = User.ImagePicture;
                }
            }
        }

        private void SetNewPassword(string Password)
        {
            this.User.Password= Password;
        }

        public int GetTotalPermisions()
        {
            int TotalPermisions = 0;
            int BinaryCounter = 1;
            for(int i=0;i<chxPermisions.Items.Count; i++)
            {
                if(chxPermisions.GetItemChecked(i))
                {
                    TotalPermisions += BinaryCounter;
                }

                BinaryCounter *= 2;
            }

            return TotalPermisions;
        }

        private void ctrUpdateUser_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword frm = new ChangePassword(User);
            frm.DataBack += SetNewPassword;
            frm.ShowDialog();
            txtPassword.Text = User.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure To Update This User?","Warnning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {

                User.UserName = txtUserName.Text;
                User.isActive = chxIsActive.Checked;
                User.Password = txtPassword.Text;
                User.Permisions = GetTotalPermisions();
                if (pictureBox1.Image != Resources.working)
                {
                    User.ImagePicture = pictureBox1.ImageLocation;
                }
                else
                {
                    User.ImagePicture = null;
                }

                if(User.Save())
                {
                    MessageBox.Show("Update Has done Successfully!");
                    btnSave.Enabled = false;
                    clsApplication.AddNewApplicationToSystem((int)eOperationType.UpdateUser, DateTime.Now, null, null, null, LogedInUser.UserID);

                }
                else
                {
                    MessageBox.Show("The Process Canceld Somthing Error!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else
            {
                return;
            }
        }

        private void lbChangePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                if (lbRemovePic.Enabled!= true)
                {
                    lbRemovePic.Enabled = true;
                }

             
            }
        }

        private void lbRemovePic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are You sure for delete this picture ?", "Warrning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                File.Delete(ImageLocation);
                pictureBox1.ImageLocation = "";
                pictureBox1.Image = Resources.working;
                lbRemovePic.Enabled = false;
            }
            else
            {
                MessageBox.Show("Procces Canceld !");
            }
        }
    }
}
