using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuesineesLyer
{
    public class clsCusInvoice
    {
        public int InvoiceID { get; set; }
        public int OrderID { get; set; }
        public decimal TotalAmount {  get; set; }
        public DateTime DateOfInvoice {  get; set; }    
        public int UserID { get; set; }
        public int?CustomerID { get; set; }

        public clsCusInvoice()
        {
            InvoiceID = 0;
            OrderID = 0;
            TotalAmount = 0;
            DateOfInvoice = DateTime.MinValue;
            UserID = 0;
            CustomerID = null;
        }

        public clsCusInvoice(int InvoiceID,int OrderID,int?CustomerID,decimal TotalAmount, DateTime DateOfInvoice, int UserID)
        {
            this.InvoiceID=InvoiceID;
            this.OrderID=OrderID;
            this.TotalAmount = TotalAmount;
            this.DateOfInvoice=DateOfInvoice;
            this.UserID = UserID;
            this.CustomerID=CustomerID;

        }

        public static DataTable GetAllInvoicesForCustomer()
        {
            return clsCusInvoicesData.GetAllRecord();
        }

        public static clsCusInvoice FindInvoiceForCustomer(int InvoiceID)
        {
            int OrderID = 0, UserID = 0;  int? CustomerID = null;
            decimal TotalAmount = 0;
            DateTime DateOfInvoice= DateTime.MinValue;

            if(clsCusInvoicesData.GetRecordByInvoiceID(InvoiceID,ref OrderID,ref CustomerID,ref TotalAmount,ref DateOfInvoice,ref UserID))
            {
                return new clsCusInvoice(InvoiceID,OrderID,CustomerID,TotalAmount,DateOfInvoice,UserID);
            }
            else
            {
                return null;
            }
            
        }

        private bool _AddNewInvoice()
        {
            this.InvoiceID=clsCusInvoicesData.AddNewRecord(this.OrderID,this.CustomerID,this.TotalAmount,this.DateOfInvoice,this.UserID);
            return InvoiceID != -1;
        }

        public bool Save()
        {
            return _AddNewInvoice();
        }



        public static bool Delete(int InvoiceID)
        {
            return clsCusInvoicesData.DeleteRecord(InvoiceID);
        }

    }
}
