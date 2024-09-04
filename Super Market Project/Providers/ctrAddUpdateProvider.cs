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
    public partial class ctrAddUpdateProvider : UserControl
    {
        enum eMode { AddNew = 1, Update = 2 };
        eMode Mode;
        public ctrAddUpdateProvider()
        {
            InitializeComponent();
            Mode = eMode.AddNew;
            Provider = new clsProviders();
        }

        public class GetUpdateProvider
        {
            public clsProviders ProviderID { get; }

            public GetUpdateProvider(clsProviders ProviderID)
            {
                this.ProviderID = ProviderID;
            }
        }


        public event EventHandler<GetUpdateProvider> OnSaveClick;

        clsProviders Provider;

        public void GetIDAndCreatClass(int ProviderID)
        {
            Provider = clsProviders.FindWithId(ProviderID);
            Mode = eMode.Update;
        }


        private void LoadData()
        {
            if(Provider != null)
            {
                lbProviderID.Text = Provider.ProviderId.ToString();
                txtProName.Text = Provider.ProviderName;
                txtPhonNumber.Text=Provider.PhoneNumber.ToString();
                txtEmial.Text =Provider.Email==null?string.Empty:Provider.Email;
                txtDateOfComing.Text=Provider.DateOfComing.ToString();  
            }
        }

        private void ReffreshData()
        {
            lbProviderID.Text = "N/A";
            txtProName.Text = "";
            txtPhonNumber.Text = "";
            txtEmial.Text = "";
            txtDateOfComing.Text = "";

            if(Mode== eMode.Update)
            {
                LoadData();
            }

        }

        private void ctrAddUpdateProvider_Load(object sender, EventArgs e)
        {
            ReffreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateChildren())
            {

                if (MessageBox.Show("Are You Sure To Continue?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Provider.ProviderName = txtProName.Text;
                    Provider.PhoneNumber = txtPhonNumber.Text;
                    Provider.Email = txtEmial.Text;
                    Provider.DateOfComing = txtDateOfComing.Text;
                    if (Provider.Save())
                    {
                        MessageBox.Show("The Process Has Done Successfully!", "Information", MessageBoxButtons.OK);
                        lbProviderID.Text = Provider.ProviderId.ToString();
                        Mode = eMode.Update;
                        OnSaveClick?.Invoke(this, new GetUpdateProvider(Provider));

                    }
                    else
                    {
                        MessageBox.Show("The Process Canceled,Somthing Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    return;
                }
            }
        }

        private void txtProName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProName.Text))
            {
                e.Cancel = true;
                txtProName.Focus();
                errorProvider1.SetError(txtProName, "You Must Fill It!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtProName, "");
            }
        }

        private void txtPhonNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhonNumber.Text))
            {
                e.Cancel = true;
                txtPhonNumber.Focus();
                errorProvider1.SetError(txtPhonNumber, "You Must Fill It!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhonNumber, "");
            }
        }

        private void txtDateOfComing_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDateOfComing.Text))
            {
                e.Cancel = true;
                txtDateOfComing.Focus();
                errorProvider1.SetError(txtDateOfComing, "You Must Fill It!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDateOfComing, "");
            }
        }

        private void txtEmial_Validating(object sender, CancelEventArgs e)
        {
            string word = "@gmail.com";
            if(string.IsNullOrEmpty(txtEmial.Text))
            {
                e.Cancel = true;
                txtEmial.Focus();
                errorProvider1.SetError(txtEmial, "You must Fill it!");
            }
            else if(!txtEmial.Text.Contains(word))
            {
                e.Cancel = true;
                txtEmial.Focus();
                errorProvider1.SetError(txtEmial, "Invalid Email,Try an other one!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmial, "");
            }
        }
    }
}
