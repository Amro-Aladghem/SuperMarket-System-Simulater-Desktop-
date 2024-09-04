using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class clsVegOrFruitData
    {

        public static DataTable GetAllRecords()
        {

            DataTable dataTable = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT VegAndFruit.VegAndFruitID, VegAndFruit.QR, QROfVegORFruit.VegORFruitName, VegAndFruit.EnrollDate, VegAndFruit.IsExpired, VegAndFruit.Price, VegAndFruit.ProviderID, VegAndFruit.Kilograms, VegAndFruit.DateOfSet\r\nFROM   QROfVegORFruit INNER JOIN\r\n             VegAndFruit ON QROfVegORFruit.VegOrFruitQR = VegAndFruit.QR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }

                    }

                }


            }
            catch
            {
                //
            }

            return dataTable;

        }

        public static bool GetRecordByQR(ref int VegFruitID, string QR, ref DateTime EnrollDate, ref bool IsExpired, ref double Price, ref int ProviderID, ref float Kilograme, ref DateTime DateOfSet,ref string ImageLocation)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select *from VegAndFruit where QR=@QR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@QR", QR);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                VegFruitID = (int)reader[0];
                                EnrollDate = (DateTime)reader[2];
                                IsExpired = (bool)reader[3];
                                Price = (float)(decimal)reader[4];
                                ProviderID = (int)reader[5];
                                Kilograme = (float)Convert.ToDouble(reader[6]);
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];
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

        public static bool GetRecordByID( int VegFruitID,ref  string QR, ref DateTime EnrollDate, ref bool IsExpired, ref double Price, ref int ProviderID, ref float Kilograme, ref DateTime DateOfSet,ref string ImageLocation)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select *from VegAndFruit where VegAndFruitID=@ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", VegFruitID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                QR = (string)reader[1];
                                EnrollDate = (DateTime)reader[2];
                                IsExpired = (bool)reader[3];
                                Price = (float)(decimal)reader[4];
                                ProviderID = (int)reader[5];
                                Kilograme =(float)Convert.ToDouble(reader[6]);
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];
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
        public static bool GetRecordByQRAndEnrrollDate(ref int VegFruitID, string QR,  DateTime EnrollDate, ref bool IsExpired, ref double Price, ref int ProviderID, ref float Kilograme, ref DateTime DateOfSet,ref string ImageLocation)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select *from VegAndFruit where QR=@QR And EnrollDate=@EnrollDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@QR", QR);
                        command.Parameters.AddWithValue("@EnrollDate", EnrollDate);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                VegFruitID = (int)reader[0];
                                IsExpired = (bool)reader[3];
                                Price = (float)(decimal)reader[4];
                                ProviderID = (int)reader[5];
                                Kilograme = (float)Convert.ToDouble(reader[6]);
                                DateOfSet = (DateTime)reader[7];
                                ImageLocation = (string)reader[8];  
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


        public static int AddNewRecord(string QR, DateTime EnrollDate, bool IsExpired, double Price, int ProviderID, float Kilograme, DateTime DateOfSet,string ImageLcoation)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Insert Into VegAndFruit(QR,EnrollDate,IsExpired,Price,ProviderID,Kilograms,DateOfSet,ImagLocation)\r\nvalues\r\n" +
                        "(@QR,@EnrollDate,@IsExpired,@Price,@ProviderID,@Kilograms,@DateOfSet,@ImageLocation);select SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@QR", QR);
                        command.Parameters.AddWithValue("@EnrollDate", EnrollDate);
                        command.Parameters.AddWithValue("@IsExpired", IsExpired);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@Kilograms", Kilograme);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);

                        if (ImageLcoation == null||ImageLcoation=="")
                        {
                            command.Parameters.AddWithValue("@ImageLocation", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImageLocation", ImageLcoation);
                        }

                        object reader = command.ExecuteScalar();
                        if (reader != null && int.TryParse(reader.ToString(), out int Value))
                        {
                            NewID = Value;



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

        public static bool UpdateRecord(int VegFruitID, string QR, DateTime EnrollDate, bool IsExpired, double Price, int ProviderID, float Kilograme, DateTime DateOfSet,string ImageLocation)
        {
            bool isDone = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Update VegAndFruit\r\nSet QR=@QR,EnrollDate=@EnrollDate,IsExpired=@IsExpired,Price=@Price,ProviderID=@ProviderID,Kilograms=@Kilograms,DateOfSet=@DateOfSet,ImagLocation=@ImageLocation where VegAndFruitID=@VegAndFruitID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruitID", VegFruitID);
                        command.Parameters.AddWithValue("@QR", QR);
                        command.Parameters.AddWithValue("@EnrollDate", EnrollDate);
                        command.Parameters.AddWithValue("@IsExpired", IsExpired);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@Kilograms", Kilograme);
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

        public static bool DeleteRecord(int VegFruitID)
        {

            bool isDone = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "delete VegAndFruit where VegAndFruitID=@VegAndFruitID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruitID", VegFruitID);

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

        public static bool isExpierd(int VegFruitID)
        {
            bool isDone = true;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select IsExpired from VegAndFruit where VegAndFruitID=@VegAndFruit";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruit", VegFruitID);

                      using(SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!(bool)reader[0])
                                {
                                    isDone = false;
                                }
                            }

                        }
                    }
                }
            }
            catch
            {

            }

            return isDone;
        }

        public static bool IsRecordHasMoreThan1EnrollDate(string VegFruitQR)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "select COUNT(QR)from VegAndFruit where QR=@QR";

                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@QR",VegFruitQR);

                        object reader=command.ExecuteScalar();
                        if(reader!=null&&int.TryParse(reader.ToString(),out int value))
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
                //
            }

            return isFound;
        }

        public static bool DeccressQuantity(int VegFruitId,string QR,float CurrnetQunatity,decimal DeccressQuantity)
        {
            bool isDone = false;
            decimal NewQunatity = (decimal)CurrnetQunatity - DeccressQuantity;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Update VegAndFruit\r\nSet Kilograms=@NewKilogram where Qr=@QR And VegAndFruitID=@VegAndFruitID";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@NewKilogram", NewQunatity);
                        command.Parameters.AddWithValue("@QR", QR);
                        command.Parameters.AddWithValue("@VegAndFruitID", VegFruitId);

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

        public static string GetVegORFruitName(string VegFruitQR)
        {
            string Name = "";

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select VegORFruitName from QROfVegORFruit where VegOrFruitQR=@VegOrFruitQR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VegOrFruitQR", VegFruitQR);

                        using(SqlDataReader reader =command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Name = (string)reader[0];
                            }
                        }
                    }



                }


            }
            catch
            {
                //
            }

            return Name;

        }

        public static bool IsVegORFruitExitsInTheSystem(string VegFruitQR)
        {
            bool isFound = true;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select QROfVegORFruit.VegOrFruitQR from QROfVegORFruit where QROfVegORFruit.VegOrFruitQR=@VegOrFruitQR";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VegOrFruitQR", VegFruitQR);

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

        public static bool AddNewVegOrFruitToSystem(string QR,string VegFruitName)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Insert INto QROfVegORFruit(VegOrFruitQR,VegORFruitName)\r\nvalues\r\n " +
                        "(@QR,@Name);select VegORFruitName from QROfVegORFruit where VegOrFruitQR=@QR; \r\n";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@QR", QR);
                        command.Parameters.AddWithValue("@Name", VegFruitName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isDone = true;
                            }



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



        public static bool IsVegOrFruitExitsInTheStorage(int VegAndFruitID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select VegAndFruit.VegAndFruitID from VegAndFruit where VegAndFruitID=@VegID";
                    
                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VegID", VegAndFruitID);

                        using(SqlDataReader reader=command.ExecuteReader())
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
