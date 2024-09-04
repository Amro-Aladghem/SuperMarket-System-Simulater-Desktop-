using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsProdutsData
    {

        public static DataTable GetAllRecords()
        {
            DataTable dt = new DataTable();

            try
            {
               
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Products.ProductID, Products.ProductQR, QROfProducts.ProductName, Products.ProducedDate, Products.EndDate, Products.ProviderID, Products.Price, Products.Quantity, Products.DateOfSet\r\nFROM   QROfProducts INNER JOIN\r\n             Products ON QROfProducts.ProductQR = Products.ProductQR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        public static bool GetFullRecordByProductQR(ref int ProductID, string ProductQR,ref DateTime ProducedDate,ref DateTime EndDate,ref int ProviderID,ref double Price,ref int Quantity,ref DateTime DateOfSet,ref string ImageLocation)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Products where ProductQR=@ProductQR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR",ProductQR);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductID = (int)reader[0];
                                ProducedDate = (DateTime)reader[2];
                                EndDate = (DateTime)reader[3];
                                ProviderID = (int)reader[4];
                                Price = (double)(decimal)reader[5];
                                Quantity = (int)reader[6];
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];

                            }
                        }
                    }
                }

            }
            catch
            {

            }

            return isFound;
        }

        public static bool GetFullRecordByID( int ProductID,ref string ProductQR, ref DateTime ProducedDate, ref DateTime EndDate, ref int ProviderID, ref double Price, ref int Quantity, ref DateTime DateOfSet, ref string ImageLocation)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Products where ProductID=@ProductID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductQR = (string)reader[1];
                                ProducedDate = (DateTime)reader[2];
                                EndDate = (DateTime)reader[3];
                                ProviderID = (int)reader[4];
                                Price = (double)(decimal)reader[5];
                                Quantity = (int)reader[6];
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];

                            }
                        }
                    }
                }

            }
            catch
            {

            }

            return isFound;
        }


        public static bool GetFullRecordByProductQRAndProducedDate(ref int ProductID, string ProductQR,  DateTime ProducedDate, ref DateTime EndDate, ref int ProviderID, ref double Price, ref int Quantity, ref DateTime DateOfSet, ref string ImageLocation)
        {
            bool isFound = false;
            string ProDate = ProducedDate.ToString("yyyy-MM-dd");

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Products where ProductQR=@ProductQR And ProducedDate=@ProducedDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProducedDate", ProDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductID = (int)reader[0];
                                EndDate = (DateTime)reader[3];
                                ProviderID = (int)reader[4];
                                Price = (double)(decimal)reader[5];
                                Quantity = (int)reader[6];
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];

                            }
                        }
                    }
                }

            }
            catch
            {

            }

            return isFound;
        }

        public static int AddNewRecord(string ProductQR,DateTime ProducedDate,DateTime EndDate,int ProviderID,double Price ,int Quantity,DateTime DateOfSet,string ImageLocation)
        {

            int ID = -1;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "Insert Into Products(ProductQR,ProducedDate,EndDate,ProviderID,Price,Quantity,DateOfSet,ImageLocation)\r\nvalues\r\n " +
                        "(@ProductQR,@ProducedDate,@EndDate,@ProviderID,@Price,@Quantity,@DateOfSet,@ImageLocation);select SCOPE_IDENTITY();";

                    using(SqlCommand command =new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProducedDate", ProducedDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@ProviderID",ProviderID);
                        command.Parameters.AddWithValue("@Price",Price);
                        command.Parameters.AddWithValue("@Quantity",Quantity);
                        command.Parameters.AddWithValue("@DateOfSet",DateOfSet);

                        if(ImageLocation==null||ImageLocation=="")
                        {
                            command.Parameters.AddWithValue("@ImageLocation",System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImageLocation", ImageLocation);

                        }

                        object reader = command.ExecuteScalar();
                        if (reader != null && int.TryParse(reader.ToString(), out int value))
                        {
                            ID = value;
                        }

                    }
                }

            }
            catch
            {
                //
            }
            return ID;





        }

        public static bool UdpateRecord(int ProductID,string ProductQR, DateTime ProducedDate, DateTime EndDate, int ProviderID, double Price, int Quantity, DateTime DateOfSet,string ImageLocation)
        {

            bool isDone = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = " Update Products \r\nSet ProductQR=@ProductQR,ProducedDate=@ProducedDate,EndDate=@EndDate,ProviderID=@ProviderID,Price=@Price,Quantity=@Quantity,DateOfSet=@DateOfSet,ImageLocation=@ImageLocation where ProductID= @ProductID";

                    using (SqlCommand command=new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProducedDate", ProducedDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);
                        if (ImageLocation == null || ImageLocation == "")
                        {
                            command.Parameters.AddWithValue("@ImageLocation", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImageLocation", ImageLocation);

                        }

                        int rowaffected = command.ExecuteNonQuery();
                        if(rowaffected > 0)
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

        public static bool DeleteRecord(int ProductID)
        {
            bool isDone = false;    

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "delete Products where ProductID=@ProductID";

                    using (SqlCommand command=new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);

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


            }

            return isDone;




        }


        public static bool isExpieredProduct(int ProductID,string ProductQR)
        {
            bool isExpierd = true;

            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select EndDate from Products where ProductID=@ProductID and ProductQR=@ProductQR";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {

                        command.Parameters.AddWithValue("@ProductID", ProductID);
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);

                        using(SqlDataReader reader=command.ExecuteReader())
                        {

                            if(reader.Read())
                            {
                                if ((DateTime)reader[0]<DateTime.Now)
                                {
                                    isExpierd = false;
                                }

                            }

                        }

                    }

                }

            }
            catch
            {

            }

            return isExpierd;


        }

        public static bool isProductHasMoreThanOneProducedDate(string ProductQR)
        {

            bool isFound=false;

            try
            {

                using(SqlConnection connectionn=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connectionn.Open();
                    string query = "select COUNT(Products.ProductQR) from Products Where ProductQR=@ProductQR";

                    using(SqlCommand command=new SqlCommand(query,connectionn))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);

                        object reader = command.ExecuteScalar();
                        if(reader!=null && int.TryParse(reader.ToString(),out int value))
                        {
                            if(value>1)
                            {
                                isFound = true; 
                            }

                        }
                    }

                }

            }
          catch
            {

            }

            return isFound;




        }


        public static bool DecreeseQuantityAmount(int ProductID, string ProductQR, int CurrentQuantity, int DecreesAmount)
        {

            bool isDone = false;
            int NewQuantity = CurrentQuantity - DecreesAmount;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    string query = "Update Products\r\nset Quantity=@Quantity where ProductQR=@ProductQR and ProductID=@ProductID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity",NewQuantity);

                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static bool IncreeseQuantityAmount(int ProductID, string ProductQR, int CurrentQuantity, int IncreeseAmount)
        {

            bool isDone = false;
            int NewQuantity = CurrentQuantity + IncreeseAmount;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    string query = "Update Products\r\nset Quantity=@Quantity where ProductQR=@ProductQR and ProductID=@ProductID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity",NewQuantity);

                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProductID", ProductID);

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

        public static bool ChangProductPrice(int ProductID,double NewPrice)
        {
            bool isDone = false;

            try
            {

                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Update Products \r\nset Price=@Price where ProductID=@ProductID";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {

                        command.Parameters.AddWithValue("@Price", NewPrice);
                        command.Parameters.AddWithValue("@ProductID", ProductID);

                        int rowaffected=command.ExecuteNonQuery();
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

        public static bool AddNewProductToSystem(string ProductQR,string ProductName)
        {
            bool isDone = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Insert Into QROfProducts\r\nvalues\r\n" +
                        "(@ProductQR,@ProductName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);
                        command.Parameters.AddWithValue("@ProductName", ProductName);

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

        public static string GetProductName(string ProductQR)
        {
            string Name = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open ();
                    string query = "select ProductName from QROfProducts where ProductQR=@ProductQR";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Name = (string)reader[0];
                            }
                        }

                    }

                }
            }
            catch
            {

            }

            return Name;

        }

        public static bool isProductExistsInTheSystem(string ProductQR)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select ProductName from QROfProducts where ProductQR=@ProductQR";
                    
                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ProductQR", ProductQR);

                        using(SqlDataReader reader =command.ExecuteReader())
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

        public static bool isProductExistsInTheStorage(int ProductID)
        {

            bool isFound = false;

            try
            {
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select Products.ProductID from Products where ProductID=@ProductID";

                    using(SqlCommand command =new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);
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










    }
}
