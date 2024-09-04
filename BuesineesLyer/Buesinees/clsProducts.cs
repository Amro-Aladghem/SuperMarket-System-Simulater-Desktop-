using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuesineesLyer
{

    enum eMode { AddNew=1,Update =2}
    public class clsProducts
    {
        eMode Mode = eMode.AddNew;
        public int ProductID { get; set; }

        public string ProductQR { get; set; }
        public DateTime ProducedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProviderID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSet { get; set; }
        public string ImageLocation { get; set; }


        public clsProducts()
        {
            ProductID = -1;
            ProductQR = string.Empty;
            ProducedDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            ProviderID = 0;
            Price = 0;
            Quantity = 0;
            DateOfSet = DateTime.MinValue;
            ImageLocation = string.Empty;

            Mode = eMode.AddNew;

        }
        public clsProducts(int ProductID, string ProductQR, DateTime ProducedDate, DateTime EndDate, int ProviderID, double Price, int Quantity, DateTime DateOfSet, string ImageLocation)
        {

            this.ProductID = ProductID;
            this.ProductQR = ProductQR;
            this.ProducedDate = ProducedDate;
            this.EndDate = EndDate;
            this.ProviderID = ProviderID;
            this.Price = Price;
            this.Quantity = Quantity;
            this.DateOfSet = DateOfSet;
            this.ImageLocation = ImageLocation;

            Mode = eMode.Update;

        }

        public static clsProducts FindProductByQR(string ProductQR)
        {
            int ProductID = 0, ProviderID = 0, Quantity = 0;
            double Price = 0; string ImageLocation = "";
            DateTime ProducedDate = DateTime.MinValue, EndDate = DateTime.MinValue, DateOfSet = DateTime.MinValue;

            if (clsProdutsData.GetFullRecordByProductQR(ref ProductID, ProductQR, ref ProducedDate, ref EndDate, ref ProviderID, ref Price, ref Quantity, ref DateOfSet, ref ImageLocation))
            {
                return new clsProducts(ProductID, ProductQR, ProducedDate, EndDate, ProviderID, Price, Quantity, DateOfSet, ImageLocation);
            }
            else
            {
                return null;
            }
        }

        public static clsProducts FindProductByQRAndProducedDate(string ProductQR, DateTime ProducedDate)
        {
            int ProductID = 0, ProviderID = 0, Quantity = 0;
            double Price = 0; string ImageLocation = "";
            DateTime EndDate = DateTime.MinValue, DateOfSet = DateTime.MinValue;

            if (clsProdutsData.GetFullRecordByProductQRAndProducedDate(ref ProductID, ProductQR, ProducedDate, ref EndDate, ref ProviderID, ref Price, ref Quantity, ref DateOfSet, ref ImageLocation))
            {
                return new clsProducts(ProductID, ProductQR, ProducedDate, EndDate, ProviderID, Price, Quantity, DateOfSet, ImageLocation);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewProduct()
        {
            this.ProductID = clsProdutsData.AddNewRecord(this.ProductQR, this.ProducedDate, this.EndDate, this.ProviderID, this.Price, this.Quantity, this.DateOfSet, this.ImageLocation);
            return ProductID != -1;
        }

        private bool _UpdateProduct()
        {
            return clsProdutsData.UdpateRecord(this.ProductID, this.ProductQR, this.ProducedDate, this.EndDate, this.ProviderID, this.Price, this.Quantity, this.DateOfSet, this.ImageLocation);
        }

        public bool Save()
        {
            switch(Mode)
            {

                case eMode.AddNew:
                    {
                        if(_AddNewProduct())
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
                        if(_UpdateProduct())
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

        public static bool DeleteProduct(int ProductID)
        {

            return clsProdutsData.DeleteRecord(ProductID);

        }

        public static bool isExpiaredProduct(int ProductID,string ProductQr)
        {
            return clsProdutsData.isExpieredProduct(ProductID,ProductQr);
        }

        public bool isExpiaredProduct()
        {
            return clsProdutsData.isExpieredProduct(this.ProductID, this.ProductQR);
        }

        public bool IsProductHasMoreThanOneProducedDate()
        {
            return clsProdutsData.isProductHasMoreThanOneProducedDate(this.ProductQR);
        }

        public static bool IsProductHasMoreThanOneProducedDate(string ProductQR)
        {
            return clsProdutsData.isProductHasMoreThanOneProducedDate(ProductQR);
        }

        public static bool DecressQuantity(int ProductID,string ProdcutQR,int CurrentQuantity,int DecressQuantity)
        {
            return clsProdutsData.DecreeseQuantityAmount(ProductID, ProdcutQR, CurrentQuantity, DecressQuantity);
        }

        public static bool IncressQuantity(int ProductID,string ProductQR,int CurrentQuantity,int IncressQuantity)
        {
            return clsProdutsData.IncreeseQuantityAmount(ProductID,ProductQR, CurrentQuantity, IncressQuantity);
        }

        public static bool ChangeProductPrice(int ProductID,double Price)
        {
            return clsProdutsData.ChangProductPrice(ProductID, Price);
        }

        public static DataTable GetAllProducts()
        {
            return clsProdutsData.GetAllRecords();
        }

        public static bool AddNewProductToSystem(string ProductQR,string ProductName)
        {
            return clsProdutsData.AddNewProductToSystem(ProductQR,ProductName);
        }

        public static string GetProductName(string ProductQR)
        {
            return clsProdutsData.GetProductName(ProductQR);
        }
 
        public static bool IsProductExitsInTheSystem(string ProductQR)
        {
            return clsProdutsData.isProductExistsInTheSystem(ProductQR);    
        }

        public static clsProducts FindByID(int ProductID)
        {
            int  ProviderID = 0, Quantity = 0;
            double Price = 0; string ImageLocation = "", ProductQR = "";
            DateTime ProducedDate = DateTime.MinValue, EndDate = DateTime.MinValue, DateOfSet = DateTime.MinValue;

            if (clsProdutsData.GetFullRecordByID ( ProductID, ref ProductQR, ref ProducedDate, ref EndDate, ref ProviderID, ref Price, ref Quantity, ref DateOfSet, ref ImageLocation))
            {
                return new clsProducts(ProductID, ProductQR, ProducedDate, EndDate, ProviderID, Price, Quantity, DateOfSet, ImageLocation);
            }
            else
            {
                return null;
            }
        }

        public static bool IsProductExitsInTheStorage(int ProductID)
        {
            return clsProdutsData.isProductExistsInTheStorage(ProductID);

        }





    }
}
