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
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
         //   lbUser.Text = LoggedInUser.LogedInUser.UserName;
        }

        private void ctrAddUser1_Load(object sender, EventArgs e)
        {

        }
    }
}
