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
    public partial class UpdateUser : Form
    {
        public UpdateUser(int UserID)
        {
            InitializeComponent();
            ctrUpdateUser1.GetUserAndCreatObject(UserID);
        }

        private void ctrUpdateUser1_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            //lbUserName.Text=LoggedInUser.LogedInUser.UserName;
        }
    }
}
