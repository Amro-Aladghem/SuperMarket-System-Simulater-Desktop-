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

namespace Super_Market_Project.Providers
{
    public partial class ProviderInfo : Form
    {
        public ProviderInfo(int ProviderID)
        {
            InitializeComponent();
            Provider=clsProviders.FindWithId(ProviderID);
        }

        clsProviders Provider;

        private void  LoadAll()
        {
            lbProviderID.Text = Provider.ProviderId.ToString();
            lbProName.Text = Provider.ProviderName.ToString();
            lbPhonNumber.Text = Provider.PhoneNumber.ToString();
            if (Provider.Email != null)
            {
                lbEmail.Text = Provider.Email.ToString();
            }
            else
            {
                lbEmail.Text = "No Email Set";
            }

            lbDate.Text = Provider.DateOfComing;

        }
        private void ProviderInfo_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetNewClass(clsProviders provider)
        {
            this.Provider=provider;
        }
        private void lbUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateProvider frm = new AddUpdateProvider(Provider.ProviderId);
            frm.DataBack += SetNewClass;
            frm.ShowDialog();
            LoadAll();
            
        }
    }
}
