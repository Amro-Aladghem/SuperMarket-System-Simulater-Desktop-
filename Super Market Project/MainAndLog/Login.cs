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

namespace Super_Market_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        clsUsers LoggedUser;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AreImagesEqual(Image img1, Image img2)
        {
            if (img1 == null || img2 == null)
            {
                return false;
            }

            // تحويل الصور إلى مصفوفة بايت للمقارنة
            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] img1Bytes = ms1.ToArray();
                byte[] img2Bytes = ms2.ToArray();

                return img1Bytes.SequenceEqual(img2Bytes);
            }
        }



        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
          
            lbDate.Text=DateTime.Now.ToShortDateString();
            lbTime.Text = DateTime.Now.TimeOfDay.ToString();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "You Must Fill It!");
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "You Must Fill It!");
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {

            LoggedUser = clsUsers.FindUserByUserName(txtUserName.Text.Trim().ToString());
            if (LoggedUser != null)
            {
                if(txtPassword.Text.Trim().ToString()==LoggedUser.Password)
                {

                    if(LoggedUser.isActive)
                    {
                        LoggedInUser.ButLoggedInUser(LoggedUser);

                        if(btnRemember.Checked)
                        {
                            LoginRegistry.DeleteDataFromRegsetry();
                            LoginRegistry.SetDataToRegsetry(txtUserName.Text, txtPassword.Text);
                        }
                        else
                        {
                            LoginRegistry.DeleteDataFromRegsetry();
                        }

                        this.Hide();
                        Form1 frm = new Form1(this);
                        clsApplication.AddNewApplicationToSystem((int)eOperationType.EnteringSystem, DateTime.Now, null, null, null, LogedInUser.UserID);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("This User Not Active Now, Try another User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                else
                {
                    MessageBox.Show("This User Not Found wrong UserName/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("This User Not Found wrong UserName/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(AreImagesEqual(pictureBox2.Image,Resources.invisible))
            {
                txtPassword.PasswordChar = '\0';
                pictureBox2.Image = Resources.view;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                pictureBox2.Image = Resources.invisible;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string value1 = "", value2 = "";
            LoginRegistry.GetDataFromRegsetry(ref value1, ref value2);
            if(value1!=null&&value2!=null)
            {
                txtUserName.Text = value1;
                txtPassword.Text = value2;
            }
        }

        private void btnRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
