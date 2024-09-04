using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuesineesLyer
{
    public class clsOrder
    {
        public int OrderID { get; set; }
        public int ? CustomerID { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfSet { get; set; } 
        public int OrderDetailID { get; set; }
        public int ?ProductID { get; set; }
        public int ?VegAndFruitID { get; set; }
        public int ?OfferID { get; set; }
        public decimal Amount { get; set; }
        public float TotalPrice { get; set; }

        public clsOrder()
        {
            OrderID = 0;
            CustomerID = 0;
            UserID = 0;
            DateOfSet = DateTime.MinValue;
            OrderDetailID = 0;
            Amount = 0;
            TotalPrice = 0;
            ProductID = null;
            VegAndFruitID = null;
            OfferID = null;
        }
        
        public clsOrder(int ?CustomerID,int UserID,DateTime DateOfSet)
        {
            this.CustomerID = CustomerID;
            this.UserID = UserID;
            this.DateOfSet = DateOfSet;
        }

        public static DataTable GetAllOrderHistory()
        {
            return clsOrderData.GetAllRecordForOrder();
        }

        public bool _AddOrder()
        {
            this.OrderID = clsOrderData.AddNewOrderRecord(this.CustomerID, this.UserID, this.DateOfSet);
            return OrderID != -1;
        }

        public  bool AddProductElementToOrderDetials(int? OfferID,decimal TotalPrice, clsProducts Prodcut = null)
        {
           
            this.OrderDetailID = clsOrderData.AddNewOrderDetailsRecord(this.OrderID, Prodcut.ProductID,null, OfferID, 1, TotalPrice);
            return OrderDetailID!= -1;
         }

        public bool AddVegOrFruitElementToOrderDetails(int? OfferID, decimal TotalPrice,decimal KilogramAmount, clsVegAndFruit vegAndFruit=null)
        {
      
            this.OrderDetailID = clsOrderData.AddNewOrderDetailsRecord(this.OrderID,null,vegAndFruit.VegOrFruitID, OfferID, KilogramAmount, TotalPrice);
            return OrderDetailID != -1;
        }

        public static  bool DeleteOrderFromSystem(int OrderID)
        {
            return clsOrderData.DeleteOrderFromSystem(OrderID);
        }

        public static bool UpdateProductRecordInOrder(int OrderID,decimal TotalPrice,int ProductID)
        {
            return clsOrderData.UpdateRecordInOrderDetailsForProduct(OrderID, TotalPrice, ProductID);
        }

        public static bool UpdateVegOrFruitRecordInOrder(int OrderID,decimal TotalPrice,int VegAndFruitID,decimal KilogramAmount)
        {
            return clsOrderData.UpdateRecordInOrderDetailsForVegOrFruit(OrderID, TotalPrice, VegAndFruitID,KilogramAmount);
        }

        public static bool CheckIfProductExitsInOrderDetails(int OrderID,int ProductID)
        {
            return clsOrderData.CheckIfProductExitsInOrderDetails(OrderID, ProductID);
        }

        public static bool CheckIfVegORFruitExitsInOrderDetails(int OrderID,int VegAndFruitID)
        {
            return clsOrderData.CheckIfVegOrFruitExitsInOrderDetails(OrderID, VegAndFruitID);
        }

        public static DataTable GetOrderElementForInvoice(int OrderID)
        {
            return clsOrderData.GetAllOrderDetailsForInvoice(OrderID);
        }



    }
}
