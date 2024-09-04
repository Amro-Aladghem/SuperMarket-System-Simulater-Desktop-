using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccessLayer
{
    
    public class clsOrderData
    {
        private static void AddParameterWithValue(SqlCommand command, string parameterName, object value)
        {
            if (value != null)
            {
                command.Parameters.AddWithValue(parameterName, value);
            }
            else
            {
                command.Parameters.AddWithValue(parameterName, System.DBNull.Value);
            }
        }

        public static DataTable GetAllRecordForOrder()
        {
            DataTable dt = new DataTable();

            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select *from OrderView";

                    using(SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        using(SqlDataReader reader =command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dt.Load(reader);    
                            }
                        }

                    }


                }


            }
            catch
            {
                //
            }

            return dt;



        }

        public static int AddNewOrderRecord(int? CustomerID,int UserID,DateTime DateOfSet)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "Insert Into Orders(CustomerID,UserID,DateOfOrder)\r\nvalues\r\n" +
                        "(@CustomerID,@UserID,@DateOfSet);select SCOPE_IDENTITY()";

                    using(SqlCommand command=new SqlCommand(qurey, connection))
                    {

                        AddParameterWithValue(command, "@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);
                        
                       object reader =command.ExecuteScalar();
                        if(reader!=null&&int.TryParse(reader.ToString(), out int value)) 
                        {
                            NewID = value;
                        }
                    }
                }
            }
            catch
            {
                //
            }

            return NewID;

        }

        public static int AddNewOrderDetailsRecord(int OrderID,int ?ProductID,int ?VegAndFruitID,int? OfferID,decimal Amount,decimal TotalPrice)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "Insert Into OrdersDetails(OrderID,ProductID,VegAndFruitID,OfferID,Amount,TotalPrice)\r\nvalues\r\n" +
                        "(@OrderID,@ProductID,@VegAndFruitID,@OfferID,@Amount,@TotalPrice);select SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        AddParameterWithValue(command, "@ProductID", ProductID);
                        AddParameterWithValue(command, "@VegAndFruitID", VegAndFruitID);
                        AddParameterWithValue(command, "@OfferID", OfferID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        object reader = command.ExecuteScalar();
                        if (reader != null && int.TryParse(reader.ToString(), out int value))
                        {
                            NewID = value;

                        }
                    }
                }
            }
            catch
            {
                //
            }
            return NewID;
        }

        public static bool DeleteOrderFromSystem(int OrderID)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "delete Orders where OrderID=@OrderID;" +
                        "\r\ndelete OrdersDetails where OrderID=OrderID";

                    using(SqlCommand command =new SqlCommand(qurey,connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        int rowaffected = command.ExecuteNonQuery();
                        if(rowaffected> 0)
                        {
                            isDone = true;
                        }
                    }

                }
            }
            catch
            {
                //
            }
            return isDone;
        }

        public static DataTable GetAllOrderDetailsForInvoice(int OrderID)
        {

          DataTable dt =new DataTable();
          
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select QROfProducts.ProductName,QROfVegORFruit.VegORFruitName,Offers.Persentage,OrdersDetails.Amount,OrdersDetails.TotalPrice \r\nfrom OrdersDetails" +
                        " Left join Products on Products.ProductID=OrdersDetails.ProductID\r\n" +
                        "Left join QROfProducts on QROfProducts.ProductQR=Products.ProductQR" +
                        " Left join \r\nVegAndFruit on VegAndFruit.VegAndFruitID=OrdersDetails.VegAndFruitID " +
                        "Left join \r\nQROfVegORFruit on QROfVegORFruit.VegOrFruitQR=VegAndFruit.QR " +
                        "Left join\r\nOffers on Offers.OfferID=OrderDetailsID\r\nwhere OrdersDetails.OrderID=@OrderID";



                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {

                            if(reader.HasRows)
                            {
                                dt.Load(reader);
                            }

                        }

                    }
                }
            }
            catch
            {
                //
            }
            return dt;

        }

        public static bool CheckIfProductExitsInOrderDetails(int OrderID,int ProductID)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select  ProductID from OrdersDetails where ProductID=@ProductID and OrderID=@OrderID";

                    using(SqlCommand command=new SqlCommand(qurey,connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                            }
                        }
                    }
                }
            }
            catch
            {
                //
            }
            return isFound;


        }

        public static bool CheckIfVegOrFruitExitsInOrderDetails(int OrderID,int VegAndFruitID)
        {
            bool isFound = false;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select VegAndFruitID from OrdersDetails where VegAndFruitID=@VegAndFruitID and OrderID=@OrderID";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruitID", VegAndFruitID);
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                            }
                        }

                    }
                }

            }
            catch
            {
                //
            }

            return isFound;


        }

        public static bool UpdateRecordInOrderDetailsForProduct(int OrderID,decimal TotalPrice,int ProductID)
        {
            bool isDone = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "";
                    connection.Open();
                    query = "Update OrdersDetails\r\nset Amount=Amount+1,TotalPrice=TotalPrice+@ProductPrice where ProductID=@ProductID And OrderID=@OrderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductPrice", TotalPrice);
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        int rowaffected = command.ExecuteNonQuery();
                        if (rowaffected > 0)
                        {
                            isDone = true;
                        }
                    }
                }

            }
             catch
            {
                //
            }

            return isDone;



        }

        public static bool UpdateRecordInOrderDetailsForVegOrFruit(int OrderID,decimal TotalPrice,int VegAndFruitID,decimal Kilograme)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Update OrdersDetails\r\nset Amount=Amount+@Kilograme, TotalPrice=TotalPrice+@VegAndFruit where VegAndFruitID=@ID And OrderID=@OrderID";

                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruit", TotalPrice);
                        command.Parameters.AddWithValue("@ID", VegAndFruitID);
                        command.Parameters.AddWithValue("@OrderID", OrderID);
                        command.Parameters.AddWithValue("+@Kilograme", Kilograme);

                        int rowaffected = command.ExecuteNonQuery();
                        if(rowaffected>0)
                        {
                            isDone = true;
                        }


                    }
                }

            }
            catch
            {
                //
            }

            return isDone;

        }




























    }
}
