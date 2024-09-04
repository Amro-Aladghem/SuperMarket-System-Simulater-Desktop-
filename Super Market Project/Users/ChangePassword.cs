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

namespace Super_Market_Project.Users
{
    public partial class ChangePassword : Form
    {
        public ChangePassword(clsUsers User)
        {
            InitializeComponent();
            this.User = User;
        }

        public delegate void GetNewPassword(string NewPassword);
        public GetNewPassword DataBack;


        clsUsers User;
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtCurrentPass.Focus();
            lbUserId.Text=User.UserID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                User.Password=txtNewPass.Text;

                if(User.Save())
                {
                    MessageBox.Show("The Password has changed Successfully!", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(User.Password);
                }
                else
                {
                    MessageBox.Show("The Process Canceld Somthing Error!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPass.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPass, "You must Enter Current Password!");
                txtCurrentPass.Focus();
            }
           else if(txtCurrentPass.Text!=User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPass, "The Password not correct!");
                txtCurrentPass.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPass, "");
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPass, "You must Fill it");
                txtNewPass.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPass, "");
            }
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPass.Clear();
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPass, "You must Fill it!");
                txtConfirmPass.Focus();
            }
            else if(txtConfirmPass.Text != txtNewPass.Text)
            {
                e.Cancel=true;
                errorProvider1.SetError(txtConfirmPass, "The Password not the same");
                txtConfirmPass.Focus();
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtConfirmPass, "");
                btnConfirm.Enabled = true;
            }
        }
    }
}
