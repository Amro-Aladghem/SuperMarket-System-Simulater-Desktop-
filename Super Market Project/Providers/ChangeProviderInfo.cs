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


namespace Super_Market_Project.Providers
{
    public partial class ChangeProviderInfo : Form
    {
     
      
        public ChangeProviderInfo(clsProviders.eTypeChange eTypChange,int ProviderId) 
        {
            InitializeComponent();
            this.eTypChange = eTypChange;
            Provider=clsProviders.FindWithId(ProviderId);
        }

        clsProviders Provider;
        clsProviders.eTypeChange eTypChange;

        public void LoadData()
        {
            switch(eTypChange)
            {
                case clsProviders.eTypeChange.PhoneNumber:
                    {
                        lbType.Text = "PhoneNumber:";
                        txtInfo.MaxLength = 10;
                        break;
                    }
                case clsProviders.eTypeChange.Email:
                    {
                        lbType.Text = "Email:";
                        break;
                    }
                case clsProviders.eTypeChange.DateOfComing:
                    {
                        lbType.Text = "DateOfComing:";
                        break;
                    }
            }
        }
        private void ChangeProviderInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(eTypChange)
            {
                case clsProviders.eTypeChange.PhoneNumber:
                    {
                        if (Provider.ChangePhoneNumber(txtInfo.Text))
                        {
                            MessageBox.Show("The Process Done Sucssfully!");
                        }
                        else
                        {
                            MessageBox.Show("The Process Canceled Error!");
                        }
                        break;

                    }
                    case clsProviders .eTypeChange.Email:
                    {
                        if (Provider.ChangeEmail(txtInfo.Text))
                        {
                            MessageBox.Show("The Process Done Sucssfully!");
                        }
                        else
                        {
                            MessageBox.Show("The Process Canceled Error!");
                        }
                        break;
                    }
                case clsProviders.eTypeChange.DateOfComing:
                    {
                       if( Provider.ChangeDateOfComing(txtInfo.Text))
                        {
                            MessageBox.Show("The Process Done Sucssfully!");
                        }
                        else
                        {
                            MessageBox.Show("The Process Canceled Error!");
                        }
                        break;
                    }
            }
        }
    }
}
