using DataAccessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuesineesLyer
{
    public class clsOffers
    {

        enum eMode { AddNew=1,Update=2};
        eMode Mode;
        
        public int OfferID { get; set; }

        public  int ?ProductID { get; set; }
        public int ?VegAndFruitID { get; set; }
        public float Percentage {  get; set; }  

        public DateTime DateOfSet { get; set; }

        public clsOffers()
        {
            OfferID =-1;
            ProductID = null;
            VegAndFruitID = null;
            Percentage = 0;
            DateOfSet = DateTime.MinValue;
            Mode = eMode.AddNew;
            
        }

        public clsOffers(int OfferID,int? ProductID,int ?VegAndFruitID,float Percentage,DateTime DateOfSet)
        {
            this.OfferID= OfferID;
            this.Percentage = Percentage;
            this.DateOfSet = DateOfSet;
            this.ProductID = ProductID;
            this.VegAndFruitID = VegAndFruitID;

            Mode = eMode.Update;
        }

        public static DataTable GetAllOffersInTheSystem()
        {
            return clsOffersData.GetAllRecords();
        }

        public static clsOffers FindOfferByID(int offerID)
        {
            float Perscentage = 0;DateTime DateOfSet= DateTime.MinValue;
            int? ProductID= 0;int? VegAndFruitID = 0;

            if(clsOffersData.GetFullRecordByID(offerID, ref ProductID,ref VegAndFruitID, ref Perscentage, ref DateOfSet))
            {
                return new clsOffers(offerID,ProductID,VegAndFruitID, Perscentage, DateOfSet);
            }
            else
            {
                return null;
            }

        }

        public static clsOffers FindOfferForPrdouctByID(int ProductID)
        {
            float Percentage = 0; DateTime DateOfSet = DateTime.MinValue;int OfferID = 0;
             int? VegAndFruitID = 0;

            if(clsOffersData.GetFullRecordForProductByID(ref OfferID,ProductID,ref VegAndFruitID,ref Percentage,ref DateOfSet))
            {
                return new clsOffers(OfferID, ProductID, VegAndFruitID, Percentage, DateOfSet);
            }
            else
            {
                return null;
            }


        }

        public static clsOffers FindOfferFroVegORFruitByID(int VegAndFruitID)
        {
            float Percentage = 0; DateTime DateOfSet = DateTime.MinValue;int OfferID = 0;
            int? ProductID = 0;

            if (clsOffersData.GetFullRecordForVegAndFruitByID(ref OfferID, ref ProductID, VegAndFruitID, ref Percentage, ref DateOfSet))
            {
                return new clsOffers(OfferID,ProductID,VegAndFruitID,Percentage,DateOfSet);
            }
            else
            {
                return null;
            }
        }

        public static bool IsProductHasAnOffer(int ProductID)
        {

            return clsOffersData.CheckIfProductHasAnOffer(ProductID);
        }

        public static bool IsVegOrFruitHasAnOffer(int VegAndFruitID)
        {
            return clsOffersData.CheckIfVegOrFruitHasAnOffer(VegAndFruitID);
        }

        public static bool DeleteOfferFromTheSystem(int OfferID)
        {
            return clsOffersData.DeleteRecord(OfferID);
        }

        private bool AddNewOffer()
        {
            this.OfferID = clsOffersData.AddNewRecord(this.ProductID, this.VegAndFruitID, this.Percentage, this.DateOfSet);
            return OfferID != -1;

        }

        private bool UpdateOffer()
        {
            return clsOffersData.UpdateReord(this.OfferID, this.Percentage, this.DateOfSet);
        }

        public bool Save()
        {
            switch (Mode)
            {

                case eMode.AddNew:
                    {
                        if (AddNewOffer())
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
                        if (UpdateOffer())
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

        public static bool CheckIfProductHaveAnOffer(int ProductID)
        {
            return clsOffersData.CheckIfProductHasAnOffer(ProductID);
        }












    }
}
