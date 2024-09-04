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

namespace Super_Market_Project
{
    public partial class AddUpdateEmployee : Form
    {

        enum eMode { AddNew = 1, Update = 2 };
        eMode Mode;


        public delegate void SaveClickData(clsEmployees employees);
        public SaveClickData DataBackFromSave;

        public AddUpdateEmployee()
        {
            InitializeComponent();
            Mode = eMode.AddNew;
        }

        public AddUpdateEmployee(int EmployeeId)
        {
            InitializeComponent();
            ctrAddUpdateEmployee1.CreatClassUpdate(EmployeeId);
            Mode = eMode.Update;
        }


        private void AddUpdateEmployee_Load(object sender, EventArgs e)
        {
            if(Mode == eMode.AddNew)
            {
                lbAdd_Update.Text = "Add New Employee";
            }
            else
            {
                lbAdd_Update.Text = "Update Employee";
            }
        }

        private void ctrAddUpdateEmployee1_OnSaveClick(object sender, ctrAddUpdateEmployee.OnEmployeeID e)
        {
            if(Mode==eMode.AddNew)
            {
                lbAdd_Update.Text = "Update Employee";
                Mode = eMode.Update;
            }

            clsEmployees employees =clsEmployees.FindEmployeeByID(e.EmployeeID);
            DataBackFromSave?.Invoke(employees);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrAddUpdateEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
