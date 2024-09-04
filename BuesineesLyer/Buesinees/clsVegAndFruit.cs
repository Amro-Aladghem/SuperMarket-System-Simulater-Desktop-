using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuesineesLyer
{

    public class clsVegAndFruit
    {

        enum eMode { AddNew=1,Udpate=2};
        eMode Mode;

        public int VegOrFruitID {  get; set; }  
        public string VegOrFruitQR { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsExpired { get; set; }  
        public double Price { get; set; }
        public int ProviderID { get; set; } 
        public float Kilogram {  get; set; }
        public DateTime DateOfSet { get; set; } 

        public string ImageLocation { get; set; }
        public clsVegAndFruit()
        {
            VegOrFruitID = -1;
            VegOrFruitQR = string.Empty;
            EnrollDate = DateTime.MinValue;
            IsExpired = false;
            Price = 0;
            ProviderID = 0;
            Kilogram = 0;
            DateOfSet = DateTime.MinValue;
            ImageLocation= string.Empty;

            Mode = eMode.AddNew;

        }

        public clsVegAndFruit( int vegOrFruitID, string vegOrFruitQR, DateTime enrollDate, bool isExpired, double price, int providerID, float kilogram, DateTime dateOfSet,string ImageLocation)
        {
            VegOrFruitID = vegOrFruitID;
            VegOrFruitQR = vegOrFruitQR;
            EnrollDate = enrollDate;
            IsExpired = isExpired;
            Price = price;
            ProviderID = providerID;
            Kilogram = kilogram;
            DateOfSet = dateOfSet;
            this.ImageLocation = ImageLocation;
            Mode = eMode.Udpate;
        }


        public static clsVegAndFruit FindVegOrFruitByQR(string QR)
        {
            int ID = 0, ProviderID = 0;float Kilogram = 0;double Price = 0;
            DateTime DateOfSet= DateTime.MinValue,Enrolldate= DateTime.MinValue;bool isExpired = false;string ImageLocation = ""; 
            if(clsVegOrFruitData.GetRecordByQR(ref ID,QR,ref Enrolldate,ref isExpired,ref Price,ref ProviderID,ref Kilogram,ref DateOfSet,ref ImageLocation))
            {
                return new clsVegAndFruit(ID, QR, Enrolldate, isExpired,  Price,  ProviderID, Kilogram, DateOfSet,ImageLocation);
            }
            else
            {
                return null;
            }

        }

        public static clsVegAndFruit FindVegOrFruitByQRAndEnrollDate(string QR,DateTime Enrolldate)
        {
            int ID = 0, ProviderID = 0; float Kilogram = 0; double Price = 0;
            DateTime DateOfSet = DateTime.MinValue; bool isExpired = false;string ImageLocation = "";
            if (clsVegOrFruitData.GetRecordByQRAndEnrrollDate(ref ID, QR,  Enrolldate, ref isExpired, ref Price, ref ProviderID, ref Kilogram, ref DateOfSet,ref ImageLocation))
            {
                return new clsVegAndFruit(ID, QR, Enrolldate, isExpired, Price, ProviderID, Kilogram, DateOfSet, ImageLocation);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNew()
        {

            this.VegOrFruitID=clsVegOrFruitData.AddNewRecord(this.VegOrFruitQR,this.EnrollDate,this.IsExpired,this.Price,this.ProviderID,this.Kilogram,this.DateOfSet,this.ImageLocation);
            return this.VegOrFruitID != -1;


        }

        private bool _Update()
        {
            return clsVegOrFruitData.UpdateRecord(this.VegOrFruitID, this.VegOrFruitQR, this.EnrollDate, this.IsExpired, this.Price, this.ProviderID, this.Kilogram, this.DateOfSet,this.ImageLocation);


        }

        public  bool Save()
        {

            switch(Mode)
            {

                case eMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            Mode = eMode.Udpate;
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                case eMode.Udpate:
                    {
                        if(_Update())
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

        public static bool  AddNewVegOrFruitAtTheSystem(string QR,string VegOrFruitName)
        {
            return clsVegOrFruitData.AddNewVegOrFruitToSystem(QR, VegOrFruitName);
        }

        public  bool IsVegOrFruitHasMoreThanOneDate(string QR)
        {
            return clsVegOrFruitData.IsRecordHasMoreThan1EnrollDate(QR);
        }

        public static bool DecreesTheQunatity(int VegOrFruitID,string VegOrFruitQR,float CurrentQuatity,decimal DecreesAmount)
        {
            return clsVegOrFruitData.DeccressQuantity(VegOrFruitID,VegOrFruitQR,CurrentQuatity,DecreesAmount);
        }

        public static bool IsVegOrFruitExitesInTheSystem(string QR)
        {
            return clsVegOrFruitData.IsVegORFruitExitsInTheSystem(QR);
        }

        public static string GetVegOrFruitName(string QR)
        {
            return clsVegOrFruitData.GetVegORFruitName(QR);
        }

        public static bool IsExpiredVegOrFruit(int VegFruitID)
        {
            return clsVegOrFruitData.isExpierd(VegFruitID);
        }

        public static DataTable GetAllVegAndFruit()
        {
            return clsVegOrFruitData.GetAllRecords();
        }

        public static bool DeleteVegOrFruit(int VegFruitID)
        {
            return clsVegOrFruitData.DeleteRecord(VegFruitID);
        }

        public static  clsVegAndFruit FindByID(int VegFruitID)
        {
            int ProviderID = 0; float Kilogram = 0; double Price = 0;
            string QR = "";
            DateTime DateOfSet = DateTime.MinValue, Enrolldate = DateTime.MinValue; bool isExpired = false;string ImageLocation = "";
            if (clsVegOrFruitData.GetRecordByID( VegFruitID, ref QR, ref Enrolldate, ref isExpired, ref Price, ref ProviderID, ref Kilogram, ref DateOfSet,ref ImageLocation))
            {
                return new clsVegAndFruit(VegFruitID, QR, Enrolldate, isExpired, Price, ProviderID, Kilogram, DateOfSet, ImageLocation);
            }
            else
            {
                return null;
            }


        }

        public static bool IsVegOrProductExitsInTheStorage(int VegAndFruitID)
        {
            return clsVegOrFruitData.IsVegOrFruitExitsInTheStorage(VegAndFruitID);
        }






    }
}