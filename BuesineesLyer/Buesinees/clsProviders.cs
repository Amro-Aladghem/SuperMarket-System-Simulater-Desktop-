using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.SqlServer.Server;

namespace BuesineesLyer
{
    public class clsProviders
    {

        public enum eTypeChange { PhoneNumber=1,Email=2,DateOfComing=3};
       
        public enum eMode { AddNew = 1, Update = 2 };
        eMode Mode;
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfComing { get; set; }

        public DateTime DateOfSet { get; set; }

        public clsProviders()
        {
            ProviderId = -1;
            ProviderName = null;
            PhoneNumber = null;
            Email = null;
            DateOfComing = null;
            DateOfSet = DateTime.Now;

            Mode = eMode.AddNew;
        }

        public clsProviders(int ProviderID, string ProviderName, string PhoneNumber, string Email, string DateOfComing, DateTime DateOfSet)
        {
            this.ProviderId = ProviderID;
            this.ProviderName = ProviderName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.DateOfComing = DateOfComing;
            this.DateOfSet = DateOfSet;

            Mode = eMode.Update;
        }

        public static clsProviders FindWithId(int ProviderID)
        {
            string ProviderName = "", PhoneNumber = "", Email = "", DateOfComing = "";
            DateTime DateOfSet = DateTime.Now;

            if (clsProvidersData.GetFullRecordByID(ProviderID, ref ProviderName, ref PhoneNumber, ref Email, ref DateOfComing, ref DateOfSet))
            {
                return new clsProviders(ProviderID, ProviderName, PhoneNumber, Email, DateOfComing, DateOfSet);
            }
            else
            {

                return null;
            }
        }

        public static clsProviders FindWithName(string ProviderName)
        {
            string PhoneNumber = "", Email = "", DateOfComing = "";
            int ProviderID = 0;
            DateTime DateOfSet = DateTime.Now;

            if (clsProvidersData.GetFullRecordByName(ref ProviderID, ProviderName, ref PhoneNumber, ref Email, ref DateOfComing, ref DateOfSet))
            {
                return new clsProviders(ProviderID, ProviderName, PhoneNumber, Email, DateOfComing, DateOfSet);
            }
            else
            {

                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.ProviderId = clsProvidersData.AddNewRecord(this.ProviderName, this.PhoneNumber, this.Email, this.DateOfComing, this.DateOfSet);
            return this.ProviderId != -1;
        }
        private bool _UpdateUser()
        {
            return clsProvidersData.UpdateRecord(this.ProviderId, this.ProviderName, this.PhoneNumber, this.Email, this.DateOfComing, this.DateOfSet);

        }

        public bool Save()
        {
            switch (Mode)
            {

                case eMode.AddNew:
                    {
                        if (_AddNewUser())
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
                        if (_UpdateUser())
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


        public bool isExits(int Provider)
        {
            return clsProvidersData.isExist(Provider);
        }

        public static bool ChangePhoneNumber(int ProviderID, string NewPhoneNumber)
        {
            return clsProvidersData.ChangePhoneNumber(ProviderID, NewPhoneNumber);
        }

        public bool ChangePhoneNumber(string NewPhoneNumber)
        {
            return clsProvidersData.ChangePhoneNumber(this.ProviderId, NewPhoneNumber);
        }

        public static bool ChangeEmail(int ProviderID, string NewEmail)
        {
            return clsProvidersData.ChangeEmail(ProviderID, NewEmail);
        }

        public bool ChangeEmail(string NewEmail)
        {
            return clsProvidersData.ChangeEmail(this.ProviderId, NewEmail);
        }

        public static bool ChangeDateOfComing(int ProviderID, string NewDateOfComing)
        {
            return clsProvidersData.ChangDateOfComing(ProviderID, NewDateOfComing); 
        }

        public bool ChangeDateOfComing(string NewDateOfComing)
        {
            return clsProvidersData.ChangDateOfComing(this.ProviderId,NewDateOfComing);
        }
        public static DataTable GetAllProviders()
        {
            return clsProvidersData.GetAllRecord();
        }

        public static bool DeleteProvider(int ProviderID)
        {
            return clsProvidersData.DeleteRecord(ProviderID);
        }

        public bool DeleteThisProvider()
        {
            return clsProvidersData.DeleteRecord(this.ProviderId);
        }



    }
}
