using BuesineesLyer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market_Project.Users
{
    public partial class UserInfo : Form
    {
        public UserInfo(int UserID)
        {
            InitializeComponent();
            User=clsUsers.FindUserByID(UserID);
        }

        clsUsers User;

        private void LoadAllData()
        {
            lbUserID.Text = User.UserID.ToString();
            lbEmployeeName.Text = clsEmployees.FindEmployeeByID(User.EmployeeID).FirstName;
            lbUserName.Text = User.UserName;
            if(User.isActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "No";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }
    }
}
