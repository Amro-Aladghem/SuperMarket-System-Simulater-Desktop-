using BuesineesLyer;
using Super_Market_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BuesineesLyer.clsProviders.eMode;

namespace Super_Market_Project.Providers
{
    public partial class AddUpdateProvider : Form
    {
         
        public AddUpdateProvider()
        {
            InitializeComponent();
            pictureBox1.Image = Resources.employee__1_;
            lbAdd_Update.Text = "AddNewProvider";
        }

        public delegate void OnSaveClick(clsProviders providers);
        public OnSaveClick DataBack;
        public AddUpdateProvider(int ProviderID)
        {
            InitializeComponent();
            ctrAddUpdateProvider1.GetIDAndCreatClass(ProviderID);
            pictureBox1.Image = Resources.transaction;
            lbAdd_Update.Text = "Update Provider";
            Providers = clsProviders.FindWithId(ProviderID);
        }

        clsProviders Providers;
        private void AddUpdateProvider_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrAddUpdateProvider1_OnSaveClick(object sender, ctrAddUpdateProvider.GetUpdateProvider e)
        {
            pictureBox1.Image = Resources.transaction;
            lbAdd_Update.Text = "Update Provider";

            DataBack?.Invoke(e.ProviderID);
        }
    }
}
