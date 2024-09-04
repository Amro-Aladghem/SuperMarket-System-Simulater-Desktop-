using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuesineesLyer
{
    public class clsCustomers
    { 
        enum eMode { AddNew=1,Update=2 }
        eMode Mode;

        public int CustomerID {  get; set; }    
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        public string LastName {  get; set; }   
        public string PhoneNumber {  get; set; }
        public bool isActive {  get; set; }
        public DateTime LastOrderDate { get; set; }

        public clsCustomers()
        {
            CustomerID = -1;
            Email = "";
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            isActive = false;
            LastOrderDate = DateTime.MinValue;
            Mode = eMode.AddNew;
        }

        public clsCustomers(int CustomerID,string FirstName,string LastName,string Email,string PhoneNumber,bool isActive,DateTime LastOrderDate)
        {
            this.CustomerID=CustomerID;
            this.FirstName=FirstName;
            this.LastName=LastName;
            this.Email=Email;
            this.isActive = isActive;
            this.PhoneNumber= PhoneNumber;
            this.LastOrderDate = LastOrderDate;
            Mode = eMode.Update;
        }


        public static clsCustomers FindCustomerByID(int CustomerID)
        {
            string Email = "", PhoneNumber = "";
            bool isActive = false; DateTime LastOrderDate = DateTime.MinValue;
            string FirstName = "", LastName = "";

            if(clsCustomerData.GetFullRecordByID(CustomerID, ref FirstName,ref LastName,ref Email,ref PhoneNumber,ref isActive,ref LastOrderDate))
            {

                return new clsCustomers(CustomerID,FirstName,LastName,Email,PhoneNumber,isActive,LastOrderDate);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllCustomerInSystem()
        {
            return clsCustomerData.GetAllRecord();

        }
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewRecord(this.FirstName, this.LastName, this.Email, this.PhoneNumber, this.isActive, this.LastOrderDate);
            return CustomerID != -1;
        }

        private bool _UpdateCustomer()
        {
            return clsCustomerData.UdpateRecord(this.CustomerID, this.Email, this.PhoneNumber, this.isActive, this.LastOrderDate);
        }

        public bool Save()
        {
            switch(Mode)
            {

                case eMode.AddNew:
                    {
                        if(_AddNewCustomer())
                        {
                            Mode = eMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case eMode.Update:
                    {
                        if(_UpdateCustomer())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                default:
                    return false;





            }
        }

        public static bool DeleteCustomerFromSystem(int CustomerID)
        {
            return clsCustomerData.DeleteRecord(CustomerID);
        }

        public static bool UdpateLastDateOrder(int CustomerID,DateTime NewLastDateOrder)
        {
            return clsCustomerData.UpdateLastDateOrder(CustomerID, NewLastDateOrder);
        }

        public bool UpdateLastDateOrder()
        {
            return clsCustomerData.UpdateLastDateOrder(this.CustomerID, this.LastOrderDate);
        }

        public static DataTable GetAllCustomerReviews()
        {
            return clsCustomerData.GetAllCustomersRev();
        }

        public static bool DeletCustomerReview(int CustomerRevID)
        {
            return clsCustomerData.DeleteCustomerReview(CustomerRevID);
        }

        public static bool AddNewCustomerReview(int CustomerID,int? ProductID,int? VegAndFruit,int NumberOfStars,string Nots)
        {
            int ID = clsCustomerData.AddNewCustomerReview(CustomerID, ProductID, VegAndFruit, NumberOfStars, Nots);
            return ID != -1;
        }

        public static bool IsThisCustomerExits(int CustomerID)
        {
            return clsCustomerData.IsExits(CustomerID);
        }

















    }
}
