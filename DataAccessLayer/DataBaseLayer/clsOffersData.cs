using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class clsOffersData
    {

        public static DataTable GetAllRecords()
        {

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select *from OfferDetail;";
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
        public static bool GetFullRecordByID(int OfferID, ref int? ProductID, ref int? VegAndFruitID, ref float Percentage, ref DateTime DateOfSet)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select *from Offers where OfferID=@OfferID";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@OfferID", OfferID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                VegAndFruitID = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                                Percentage = (float)Convert.ToDouble(reader[3]);
                                DateOfSet = (DateTime)reader[4];
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

        public static bool GetFullRecordForProductByID(ref int offerID, int? ProductID, ref int? VegAndFruitID, ref float Percentage, ref DateTime DateOfSet)
        {
            bool isFound = false;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Offers where ProductID=@ProductID";

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", ProductID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                offerID = (int)reader[0];
                                VegAndFruitID = reader.IsDBNull(2)?(int?)null: reader.GetInt32(2);
                                Percentage = (float)Convert.ToDouble(reader[3]);
                                DateOfSet = (DateTime)reader[4];    
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

        public static bool GetFullRecordForVegAndFruitByID(ref int offerID,ref int?ProductID,int? VegAndFruitID,ref  float Percentage,ref DateTime DateOfSet)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Offers where VegAndFruitID=@VegAndFruitID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruitID",VegAndFruitID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                offerID = (int)reader[0];
                                ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                                Percentage = (float)Convert.ToDouble(reader[3]);
                                DateOfSet = (DateTime)reader[4];
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

        public static bool CheckIfProductHasAnOffer(int ProductID)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select ProductID *from Offers where ProductID=@Product";
                    
                    using(SqlCommand command=new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@Product", ProductID);

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

        public static bool CheckIfVegOrFruitHasAnOffer(int VegAndFruitID)
        {

            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "select VegAndFruitID *  Offers where VegAndFruitID=@VegAndFruitID;";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@VegAndFruitID", VegAndFruitID);

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

        public static bool DeleteRecord(int OfferID)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "delete Offers where OfferID=@OfferID";

                    using(SqlCommand command = new SqlCommand(qurey,connection))
                    {
                        command.Parameters.AddWithValue("@OfferID", OfferID);

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

        public static int AddNewRecord(int?ProductID,int?VegAndFruitID,float Percentage,DateTime DateOffset)
        {
            int NewID = -1;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "Insert Into Offers(ProductID,VegAndFruitID,Persentage,DateOfSet)\r\nvalues\r\n " +
                        "(@ProductID,@VegAndFruitID,@Persentage,@DateOfSet);select SCOPE_IDENTITY()";

                    using(SqlCommand command=new SqlCommand(qurey, connection))
                    {
                        if(ProductID==null)
                        {
                            command.Parameters.AddWithValue("@ProductID", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ProductID", ProductID);
                        }

                        if(VegAndFruitID==null)
                        {
                            command.Parameters.AddWithValue("@VegAndFruitID", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@VegAndFruitID", VegAndFruitID);
                        }

                        command.Parameters.AddWithValue("@Persentage", Percentage);
                        command.Parameters.AddWithValue("@DateOfSet", DateOffset);

                        object reader = command.ExecuteScalar();
                        if(int.TryParse(reader.ToString(),out int value)||reader!=null)
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

        public static bool UpdateReord(int OfferID,float Percentage,DateTime DateOfSet)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "Update Offers \r\nSet Persentage=@Persentage,DateOfSet=@DateOfSet where OfferID=@OfferID";

                    using(SqlCommand command=new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@Persentage", Percentage);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);
                        command.Parameters.AddWithValue("@OfferID", OfferID);

                        int rowaffected = command.ExecuteNonQuery();
                        if(rowaffected>0)
                        {
                            isDone=true;
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
