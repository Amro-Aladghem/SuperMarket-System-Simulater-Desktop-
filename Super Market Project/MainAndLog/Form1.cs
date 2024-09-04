using BuesineesLyer;
using Super_Market_Project.Custormers;
using Super_Market_Project.MainAndLog;
using Super_Market_Project.Offers;
using Super_Market_Project.Products;
using Super_Market_Project.Properties;
using Super_Market_Project.Providers;
using Super_Market_Project.Users;
using Super_Market_Project.VegOrFruit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Super_Market_Project.LoggedInUser;

namespace Super_Market_Project
{
    public partial class Form1 : Form
    {

        public static int OrderNum;
        public static decimal TotalPrice = 0;
        int? CustomerID = null;

        enum eElementType { Prduct = 1, VegOrFruit = 2 };
        eElementType ElementType;
        enum eSystemProcess { Order = 1, Customer = 2, Prducts = 4, VegAndFruit = 8, Invoics = 16, Offers = 32, Application = 64, Employees = 128, Users = 256 };
        eSystemProcess Process;

        public Form1(Form frm)
        {
            InitializeComponent();
            LoggedForm = frm;

        }

        Form LoggedForm;
        clsProducts Product;
        clsVegAndFruit VegOrFruit;
        clsOffers Offer;
        clsOrder Order = new clsOrder();
        clsCustomers Customer;
        clsCusInvoice NewInvoice = new clsCusInvoice();


        private bool CheckIfUserCanAccess(int ProcessType)
        {
            if ((ProcessType & LoggedInUser.LogedInUser.Permisions) == ProcessType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripDropDownButton1.Text = LoggedInUser.LogedInUser.UserName;
            cbxElementType.SelectedIndex = 0;
            ElementType = eElementType.Prduct;
            dataGridView1.Font = new Font("Arial", 8);

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Order))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomersList frm = new CustomersList();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mohmmadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            Employees_List frm = new Employees_List();
            frm.ShowDialog();
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            UsersList frm = new UsersList();
            frm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggedForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Customer))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Prducts))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.VegAndFruit))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Invoics))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Offers))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Application))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Employees))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            if (CheckIfUserCanAccess((int)eSystemProcess.Users))
            {
                return;
            }
            else
            {
                ((ToolStripMenuItem)sender).DropDown.Enabled = false;
                MessageBox.Show("Access Denaid You Cant Make This Opperation, Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo frm = new UserInfo(LoggedInUser.LogedInUser.UserID);
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.FindUserByID(LoggedInUser.LogedInUser.UserID);
            ChangePassword frm = new ChangePassword(User);
            frm.ShowDialog();
            clsApplication.AddNewApplicationToSystem((int)eOperationType.UpdateUser, DateTime.Now, null, null, null, LogedInUser.UserID);

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are You sure?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)) == DialogResult.OK)
            {
                LoggedInUser.LogedInUser = null;
                LoggedForm.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void prrovidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProvidersList frm = new ProvidersList();
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ListOfProducts frm = new ListOfProducts();
            frm.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FindProduct frm = new FindProduct();
            frm.ShowDialog();
        }

        private void addNewPrdouctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductToStorage frm = new AddProductToStorage();
            frm.ShowDialog();
        }

        private void deleteProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteProductShortCut frm = new DeleteProductShortCut();
            frm.ShowDialog();
        }

        private void updateProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProductShortCut frm = new UpdateProductShortCut();
            frm.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            VegOrFruitList frm = new VegOrFruitList();
            frm.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FindVegOrFruit frm = new FindVegOrFruit();
            frm.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            ProvidersList frm = new ProvidersList();
            frm.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            AddNewVegOrFruitToStorage frm = new AddNewVegOrFruitToStorage();
            frm.ShowDialog();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            OffersList frm = new OffersList();
            frm.ShowDialog();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            FindOffers frm = new FindOffers();
            frm.ShowDialog();
        }

        private void contactWithCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactWithCustomer frm = new ContactWithCustomer();
            frm.ShowDialog();
        }

        private void customerReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomerReview frm = new AddCustomerReview();
            frm.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void orderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderHistory frm = new OrderHistory();
            frm.ShowDialog();
        }


        private decimal GetTotalPrice()
        {
            switch (ElementType)
            {

                case eElementType.Prduct:
                    {
                        return TotalPrice += CheckIfProductHasOfferAndGetPrice();

                    }
                case eElementType.VegOrFruit:
                    {
                        return TotalPrice += CheckIfVegOrFruitHasAnOfferAndGetPrice();

                    }

                default: return 0;
            }




        }

        private decimal CheckIfProductHasOfferAndGetPrice()
        {
            if (clsOffers.IsProductHasAnOffer(Product.ProductID))
            {
                Offer = clsOffers.FindOfferForPrdouctByID(Product.ProductID);
                decimal SavingAmount = (decimal)(Product.Price) * (decimal)Offer.Percentage;
                decimal Price = (Math.Round((decimal)Product.Price - SavingAmount, 3));
                return Price;
            }
            else
            {
                Offer = null;
                decimal Price = (decimal)(Product.Price);
                return Price;
            }
        }

        private decimal CheckIfVegOrFruitHasAnOfferAndGetPrice()
        {
            if (clsOffers.IsVegOrFruitHasAnOffer(VegOrFruit.VegOrFruitID))
            {
                Offer = clsOffers.FindOfferFroVegORFruitByID(VegOrFruit.VegOrFruitID);
                decimal SavingAmount = (decimal)(VegOrFruit.Price) * (decimal)Offer.Percentage;
                decimal Price = (Math.Round((decimal)VegOrFruit.Price - SavingAmount, 3));
                Price = Math.Round(Price * Convert.ToDecimal(txtKilo.Text), 2);

                return Price;
            }
            else
            {
                Offer = null;
                decimal Price = Math.Round((decimal)(VegOrFruit.Price)* Convert.ToDecimal(txtKilo.Text),2);
                return Price;
            }
        }

        private decimal GetElementPrice()
        {
            if (ElementType == eElementType.Prduct)
            {
                return CheckIfProductHasOfferAndGetPrice();
            }
            else
            {
                return CheckIfVegOrFruitHasAnOfferAndGetPrice();
            }
        }

        private void LoadData()
        {
            switch (ElementType)
            {
                case eElementType.Prduct:
                    {
                        lbLastElementPrice.Text = Product.Price.ToString();
                        TotalPrice = GetTotalPrice();
                        lbTotalPrice.Text = TotalPrice.ToString();
                        lbElementName.Text = clsProducts.GetProductName(txtElementQR.Text);

                        if (Product.ImageLocation != null)
                        {
                            pictureBoxForElement.ImageLocation = Product.ImageLocation;
                        }
                        else
                        {
                            pictureBoxForElement.Image = Resources.add_to_basket1;
                        }
                        break;
                    }
                case eElementType.VegOrFruit:
                    {
                        lbLastElementPrice.Text = VegOrFruit.Price.ToString();
                        TotalPrice = GetTotalPrice();
                        lbTotalPrice.Text = TotalPrice.ToString();
                        lbElementName.Text = clsVegAndFruit.GetVegOrFruitName(txtElementQR.Text);

                        if (VegOrFruit.ImageLocation != null)
                        {
                            pictureBoxForElement.ImageLocation = VegOrFruit.ImageLocation;
                        }
                        else
                        {
                            pictureBoxForElement.Image = Resources.add_to_basket1;
                        }

                        break;
                    }
            }
        }

        private void ResetAfterAdded()
        {
            txtElementQR.Clear();
            lbEnterDate.Visible = false;
            dateTimeForProduced.Visible = false;
            btnElementSearchwithDate.Visible = false;

            if (btnElementSearch.Enabled == false)
            {
                btnElementSearch.Enabled = true;
                txtElementQR.Enabled = true;
            }
        }

        private void ResetAllOrderSettings()
        {
            OrderPanel.Enabled = false;
            pictureBoxForElement.Image = Resources.add_to_basket1;
            lbLastElementPrice.Text = 0.ToString();
            lbElementName.Text = "Element";
            cbxElementType.SelectedIndex = 0;
            TotalPrice = 0;
            lbTotalPrice.Text = 0.ToString();
            tabControl1.SelectedIndex = 0;

            Product = null;
            VegOrFruit = null;
            Offer = null;
            Customer = null;
            clsOrder Order = new clsOrder();
            clsCusInvoice NewInvoice = new clsCusInvoice();
        }

        private void OpenSearchwithDate()
        {
            btnElementSearch.Enabled = false;
            txtElementQR.Enabled = false;
            lbEnterDate.Visible = true;
            dateTimeForProduced.Visible = true;
            btnElementSearchwithDate.Visible = true;
        }

        private bool AddNewProductToOrder()
        {
            decimal Price = GetElementPrice();
            int? OfferID;
            if(Offer==null)
            {
                OfferID = null;
            }
            else
            {
                OfferID=Offer.OfferID;
            }

            if (!Order.AddProductElementToOrderDetials(OfferID, Price, Product))
            {
                MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsProducts.DecressQuantity(Product.ProductID, Product.ProductQR, Product.Quantity, 1);
            return true;
        }

        private bool UpdateProductInOrder()
        {
            decimal Price = GetElementPrice();

            if (!clsOrder.UpdateProductRecordInOrder(Order.OrderID, Price, Product.ProductID))
            {
                MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsProducts.DecressQuantity(Product.ProductID, Product.ProductQR, Product.Quantity, 1);
            return true;
        }

        private void AddNewProductToOrderTheProcess()
        {
            LoadData();

            if (!clsOrder.CheckIfProductExitsInOrderDetails(Order.OrderID, Product.ProductID))
            {
                AddNewProductToOrder();
            }
            else
            {
                UpdateProductInOrder();
            }

            ResetAfterAdded();
        }

        private bool AddNewVegToOrder()
        {
            decimal Price=GetElementPrice();

            int? OfferID;
            if (Offer == null)
            {
                OfferID = null;
            }
            else
            {
                OfferID = Offer.OfferID;
            }

            decimal KilogramAmount = Convert.ToDecimal(txtKilo.Text);

            if (!Order.AddVegOrFruitElementToOrderDetails(OfferID,Price,KilogramAmount,VegOrFruit))
            {
                MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsVegAndFruit.DecreesTheQunatity(VegOrFruit.VegOrFruitID, VegOrFruit.VegOrFruitQR, VegOrFruit.Kilogram, KilogramAmount);
            return true;
        }

        private bool UpdateVegOrFruitInOrder()
        {
            decimal Price = GetElementPrice(); 
           

            decimal KilogramAmount = Convert.ToDecimal(txtKilo.Text);

            if (!clsOrder.UpdateVegOrFruitRecordInOrder(Order.OrderID, Price, VegOrFruit.VegOrFruitID,KilogramAmount))
            {
                MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsVegAndFruit.DecreesTheQunatity(VegOrFruit.VegOrFruitID, VegOrFruit.VegOrFruitQR, VegOrFruit.Kilogram, KilogramAmount);

            return true;

        }

        private void AddNewVegOrFruitToOrderTheProcess()
        {
            LoadData();
            if (!clsOrder.CheckIfVegORFruitExitsInOrderDetails(Order.OrderID, VegOrFruit.VegOrFruitID))
            {
                AddNewVegToOrder();
            }
            else
            {
                UpdateVegOrFruitInOrder();
            }

            ResetAfterAdded();
        }


        private void btnElementSearchwithDate_Click(object sender, EventArgs e)
        {

            switch (ElementType)
            {
                case eElementType.Prduct:
                    {
                        Product = clsProducts.FindProductByQRAndProducedDate(txtElementQR.Text, dateTimeForProduced.Value);


                        if (Product == null)
                        {
                            MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        AddNewProductToOrderTheProcess();
                        txtKilo.Clear();
                        break;

                    }
                case eElementType.VegOrFruit:
                    {

                        if (ValidateChildren() == false)
                        {
                            MessageBox.Show("You must Enter The Amount Of Kilo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        VegOrFruit = clsVegAndFruit.FindVegOrFruitByQR(txtElementQR.Text);

                        if (VegOrFruit == null)
                        {
                            MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        AddNewVegOrFruitToOrderTheProcess();
                        break;
                    }
            }



        }

        private void btnElementSearch_Click(object sender, EventArgs e)
        {
            switch (ElementType)
            {

                case eElementType.Prduct:
                    {

                        Product = clsProducts.FindProductByQR(txtElementQR.Text);

                        if(Product==null)
                        {
                            MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        if (Product.IsProductHasMoreThanOneProducedDate())
                        {
                            OpenSearchwithDate();
                            return;
                        }

                        AddNewProductToOrderTheProcess();

                        break;
                    }
                case eElementType.VegOrFruit:
                    {
                        if (ValidateChildren() == false)
                        {
                            MessageBox.Show("You must Enter The Amount Of Kilo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        VegOrFruit = clsVegAndFruit.FindVegOrFruitByQR(txtElementQR.Text);

                        if (VegOrFruit == null)
                        {
                            MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if(VegOrFruit.IsVegOrFruitHasMoreThanOneDate(txtElementQR.Text))
                        {
                            OpenSearchwithDate();
                            return;
                        }

                        AddNewVegOrFruitToOrderTheProcess();
                        txtKilo.Clear();
                        break;

                    }







            }
        }
        private void SetCustomerID(int? CustomerID)
        {
           this.CustomerID = CustomerID;
           txtCustomer.Text = this.CustomerID.ToString();
        }


        public bool OpenNewOrder()
        {
            OrderPanel.Enabled = true;
            OrderNum++;
            lbOrderNum.Text = OrderNum.ToString();

            Order = new clsOrder(CustomerID, LoggedInUser.LogedInUser.UserID, DateTime.Now);

            if (!Order._AddOrder())
            {
                MessageBox.Show("Somthing Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindCustomerForMainForm frm = new FindCustomerForMainForm();
            frm.DataBackCustomerID +=SetCustomerID;
            frm.ShowDialog();   
            OpenNewOrder();
           
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            NewInvoice.OrderID = Order.OrderID;
            NewInvoice.CustomerID = CustomerID;
            NewInvoice.TotalAmount = TotalPrice;
            NewInvoice.DateOfInvoice = DateTime.Now;
            NewInvoice.UserID = LoggedInUser.LogedInUser.UserID;

            if(!NewInvoice.Save())
            {
                MessageBox.Show("Somthin Error At Making This  Invoice!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lbInvoiceNum.Text = NewInvoice.InvoiceID.ToString();
            LoadElementOfOrderForInvoice(Order.OrderID);
            tabControl1.SelectedIndex = 1;
            OrderPanel.Enabled = false;

        }


        private void EnabledOrDisabelKilo(bool enabled)
        {
            switch (enabled)
            {
                case true:
                    {
                        lbKilo.Visible = true;
                        txtKilo.Visible = true ; break;
                    }
                case false:
                    {
                        lbKilo.Visible = false;
                        txtKilo.Visible = false; break;
                    }
            }
        }
        private void cbxElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxElementType.SelectedIndex == 0)
            {
                ElementType = eElementType.Prduct;
                EnabledOrDisabelKilo(false);
            }
            else
            {
                ElementType = eElementType.VegOrFruit;
                EnabledOrDisabelKilo(true);
            }
        }

        private void txtElementQR_TextChanged(object sender, EventArgs e)
        {
            if(txtElementQR.Text!="")
            {
                btnElementSearch.Enabled = true;
            }
            else
            {
                btnElementSearch.Enabled = false;
            }
        }

        private void btnCustomerSearching_Click(object sender, EventArgs e)
        {
            if(txtCustomer.Text=="")
            {
                MessageBox.Show("You must Enter the ID of the customer!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            Customer = clsCustomers.FindCustomerByID(Convert.ToInt32(txtCustomer.Text));
            if(Customer==null)
            {
                MessageBox.Show("The Customer not Found!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CustomerID = Customer.CustomerID;
            lbCustomerName.Text = Customer.FirstName;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the key is not a digit or control key, prevent the input
                e.Handled = true;
            }
        }
        private void txtKilo_Validating_1(object sender, CancelEventArgs e)
        {
            if(txtElementQR.Text=="")
            {
                return;
            }


            if (txtKilo.Text=="  .")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKilo, "You must enter the Kilo!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtKilo, "");
            }
        }


        private void LoadElementOfOrderForInvoice(int OrderID)
        {
          dataGridView1.DataSource= clsOrder.GetOrderElementForInvoice(OrderID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ResetAllOrderSettings();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            CustomerInvoicesHistory frm = new CustomerInvoicesHistory();
            frm.ShowDialog();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            FindCustomerInvoice frm = new FindCustomerInvoice();
            frm.ShowDialog();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Process Dosenot implmentaion yet!", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            FindCustomerInvoice frm = new FindCustomerInvoice();
            frm.ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddUpdateCustomer frm = new AddUpdateCustomer();
            frm.ShowDialog();
        }

        private void btnVeg_Click(object sender, EventArgs e)
        {
            FindVegOrFruit frm = new FindVegOrFruit();
            frm.ShowDialog();
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            FindProduct frm = new FindProduct();
            frm.ShowDialog();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            ApplicationList frm = new ApplicationList();
            frm.ShowDialog();
        }
    }
}





    