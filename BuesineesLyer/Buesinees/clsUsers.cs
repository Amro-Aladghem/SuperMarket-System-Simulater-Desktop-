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
    public class clsUsers
    {
        enum eMode { AddNew = 1, Update = 2 };
        eMode Mode; 

        public enum eSystemProcess {Order=1,Customer=2,Products=4,VegAndFruit=8,Invoices=16,Offers=32,Application=64,Employees=128,Users=256};
        public static eSystemProcess SystemProccesPer;


        public int UserID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public int EmployeeID { get; set; }

        private string ImagePath;
        public int Permisions { get; set; }

        public string ImagePicture
        {
            get { return ImagePath; }

            set { ImagePath = value; }

        }

        public clsUsers()
        {
            UserID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            isActive = false;
            EmployeeID = -1;
            ImagePath = string.Empty;
            Mode = eMode.AddNew;
        }

        public clsUsers(int UserID, string UserName, string Password, bool isActive, int EmployeeID, string ImgaePath, int Permisions)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;
            this.EmployeeID = EmployeeID;
            this.ImagePicture = ImgaePath;
            this.Permisions = Permisions;
            Mode = eMode.Update;
        }

        public static clsUsers FindUserByID(int UserID)
        {
            string UserName = "", Password = "", ImagePath = "";
            bool isActive = false; int EmployeeID = -1, Permisions = -1;
            if (clsUsersData.GetFullRecordByID(UserID, ref UserName, ref EmployeeID, ref Password, ref isActive, ref ImagePath, ref Permisions))
            {
                return new clsUsers(UserID, UserName, Password, isActive, EmployeeID, ImagePath, Permisions);
            }
            else
            {
                return null;
            }
        }

        public static clsUsers FindUserByUserName(string UserName)
        {
            string Password = "", ImagePath = "";
            bool isActive = false; int EmployeeID = -1, Permisions = -1, UserID = -1;
            if (clsUsersData.GetFullRecordByUserName(ref UserID, UserName, ref EmployeeID, ref Password, ref isActive, ref ImagePath, ref Permisions))
            {
                return new clsUsers(UserID, UserName, Password, isActive, EmployeeID, ImagePath, Permisions);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewRecord(this.UserName, this.EmployeeID, this.Password, this.isActive, this.ImagePath, this.Permisions);
            return UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateRecord(this.UserID, this.UserName, this.EmployeeID, this.Password, this.isActive, this.ImagePicture, this.Permisions);
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


        public bool isUserExits(int UserID)
        {
            return clsUsersData.UserExits(UserID);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteRecord(UserID);
        }

        public static bool ChangePasswordForUser(int UserID,string NewPassword)
        {
            return clsUsersData.ChangePasswordForUser(UserID, NewPassword);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUsersData.ChangePasswordForUser(this.UserID,NewPassword);
        }

        public static bool IsEmployeeAnUser(int EmployeeID)
        {
            return clsUsersData.IsEmployeeAnUser(EmployeeID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllRecord();
        }



    }
}
