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

namespace Super_Market_Project
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo(int EmployeeID)
        {
            InitializeComponent();
            Employees=clsEmployees.FindEmployeeByID(EmployeeID);
        }

        clsEmployees Employees;

        private void LoadAllData()
        {
            lbEmployeeID.Text=Employees.EmployeeId.ToString();
            lbFullName.Text=Employees.FirstName+" "+Employees.SecoundName+" "+Employees.LastName;
            lbDateOfBirth.Text = Employees.DateOfBirth.ToShortDateString();
            lbDateOfSet.Text=Employees.DateOfSet.ToShortDateString();
        }

        private void UpdateEmployeeclass(clsEmployees employees)
        {
            Employees = employees;
        }
        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            LoadAllData();  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateEmployee frm = new AddUpdateEmployee(Employees.EmployeeId);
            frm.DataBackFromSave += UpdateEmployeeclass;
            frm.ShowDialog();
            LoadAllData();
        }
    }
}
