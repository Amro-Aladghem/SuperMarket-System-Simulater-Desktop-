using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuesineesLyer;
using Super_Market_Project.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Super_Market_Project
{
    public partial class ctrAddUpdateEmployee : UserControl
    {
        enum eMode { AddNew=1,Update=2 };
        eMode Mode;

        public class OnEmployeeID
        {
           public int EmployeeID { get; }

            public OnEmployeeID(int EmployeeID)
            {
                this.EmployeeID=EmployeeID;
            }
        }

        public event EventHandler<OnEmployeeID> OnSaveClick;

        public ctrAddUpdateEmployee()
        {
            InitializeComponent();
            Mode = eMode.AddNew;
            Employees =new clsEmployees();
        }

        public ctrAddUpdateEmployee(int EmployeeID)
        {

            InitializeComponent();
            Mode = eMode.Update;
            Employees=clsEmployees.FindEmployeeByID(EmployeeID);
            pictureBox1.Image = Resources.reload__1_;
        }

        clsEmployees Employees;

        public void CreatClassUpdate(int EmployeeID)
        {
            Employees = clsEmployees.FindEmployeeByID(EmployeeID);
            Mode = eMode.Update;
            pictureBox1.Image = Resources.reload__1_;
        }

        private void LoadData()
        {
            lbEmployeeID.Text = Employees.EmployeeId.ToString();
            txtFirstName.Text = Employees.FirstName;
            txtSecondName.Text = Employees.SecoundName;
            txtLastName.Text = Employees.LastName;
            dateTimePicker1.Value = Employees.DateOfBirth;
            numericUpDown1.Value = (decimal)Employees.Salary;
        }

        private void RestartData()
        {
            lbEmployeeID.Text = "N/A";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtLastName.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            if (Mode == eMode.Update)
            {
                LoadData();
            }
        }

        private void ctrAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            RestartData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employees.FirstName = txtFirstName.Text;
            Employees.SecoundName = txtSecondName.Text;
            Employees.LastName=txtLastName.Text;
            Employees.DateOfBirth = dateTimePicker1.Value;
            Employees.Salary =(double)numericUpDown1.Value;
            Employees.DateOfSet = DateTime.Now;

            if(MessageBox.Show("Are You Sure To Add/Update This Person ?","Warnnig",MessageBoxButtons.OKCancel,MessageBoxIcon.Question ) == DialogResult.OK)
            {
                if(Employees.Save())
                {
                    MessageBox.Show("The Process Done Successfully!");
                    Mode = eMode.Update;
                    pictureBox1.Image = Resources.reload;
                    OnSaveClick?.Invoke(this,new OnEmployeeID(Employees.EmployeeId));
                }
                else
                {
                    MessageBox.Show("The Process Not Done Successfully :-(!");
                }
            }
            else
            {
                return;
            }
            
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "You must Fill it!");
                txtFirstName.Focus();
                e.Cancel = true;
            }
            else if(txtFirstName.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtFirstName, "There are numbers");
                txtFirstName.Focus();
                e.Cancel = true;
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                errorProvider1.SetError(txtSecondName, "You must Fill it!");
                txtSecondName.Focus();
                e.Cancel = true;
            }
            else if (txtSecondName.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtSecondName, "There are numbers");
                txtSecondName.Focus();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecondName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {

            if (txtLastName.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtLastName, "There are numbers");
                txtLastName.Focus();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLastName, "");
            }
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numericUpDown1, "The Salary must above 0 dollar");
                numericUpDown1.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numericUpDown1, "");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Are you sure about Salary=0 ?");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
