using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCustomerData
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
        public static DataTable GetAllRecord()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select *from Customers;";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
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
      
        public static bool GetFullRecordByID(int CustomerID,ref string FirstName,ref string LastName,ref string Email,ref string Phone,ref bool isActive,ref DateTime LastDateOrder)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Customers where CustomersID=@Customers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Customers", CustomerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                FirstName = (string)reader[1];
                                LastName = (string)reader[2];
                                Email = (string)reader[3];
                                Phone = (string)reader[4];
                                isActive = (bool)reader[5];
                                LastDateOrder = (DateTime)reader[6];

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

        public static bool GetFullRecordByName(ref int CustomerID,string FirstName, ref string LastName, ref string Email, ref string Phone, ref bool isActive, ref DateTime LastDateOrder)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from where FirstName=@FirstName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@FirstName",FirstName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CustomerID = (int)reader[0];
                                LastName = (string)reader[2];
                                Email = (string)reader[3];
                                Phone = (string)reader[4];
                                isActive = (bool)reader[5];
                                LastDateOrder = (DateTime)reader[6];

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

        public static int AddNewRecord(string FirstName,string LastName,string Email,string Phone,bool isActive,DateTime LastDateOrder)
        {
            int NewID = -1;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "Insert Into  Customers(FirstName,LastName,Email,PhoneNumber,IsActive,LastOrderDate)\r\nvalues\r\n" +
                        "(@FirstName,@Lastname,@Email,@PhoneNumber,@IsActive,@LastOrderDate);select SCOPE_IDENTITY()";

                    using(SqlCommand command =new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        AddParameterWithValue(command, "@Lastname", LastName);
                        AddParameterWithValue(command, "@Email", Email);
                        AddParameterWithValue(command, "@PhoneNumber",Phone);

                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@LastOrderDate", LastDateOrder);

                        object reader = command.ExecuteScalar();
                        if(int.TryParse(reader.ToString(),out int value))
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

        public static bool UdpateRecord(int CustomerID, string Email, string Phone, bool isActive, DateTime LastDateOrder)
        {
            bool isDone = false;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "Update Customers \r\nset Email=@Email,PhoneNumber=@PhoneNumber,IsActive=@IsActive,LastOrderDate=@LastOrderDate where CustomersID=@CustomersID";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {

                        command.Parameters.AddWithValue("@CustomersID", CustomerID);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@LastOrderDate", LastDateOrder);
                        AddParameterWithValue(command, "@Email", Email);
                        AddParameterWithValue(command, "@PhoneNumber", Phone);

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

        public static bool DeleteRecord(int CustomerID)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "delete Customers where CustomersID=@CustomersID";

                    using(SqlCommand command =new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomersID", CustomerID);

                        int rowaffected = command.ExecuteNonQuery();    
                        if( rowaffected > 0 )
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

        public static bool UpdateLastDateOrder(int CustomerID,DateTime NewLastDateOrder)
        {
            bool isDone = false;

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "Update Customers \r\nset LastOrderDate=@LastDateOrder where CustomersID=@CustomersID";

                    using(SqlCommand command=new SqlCommand(qurey,connection))
                    {
                        command.Parameters.AddWithValue("@CustomersID", CustomerID);
                        command.Parameters.AddWithValue("@LastDateOrder", NewLastDateOrder);

                        int rowaffected= command.ExecuteNonQuery();

                        if(rowaffected> 0 )
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
        
        public static DataTable GetAllCustomersRev()
        {
           DataTable dt = new DataTable();

            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select *from CustomerRev";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        using(SqlDataReader reader=command.ExecuteReader())
                        {
                            if(reader.Read())
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

        public static bool DeleteCustomerReview(int CustomerRevwieID)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "delete CustomerRev where CustomersReviweID=@CustomerRevId";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerRevId", CustomerRevwieID);

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

        public static int AddNewCustomerReview(int CustomerID,int? ProductID,int?VegAndFruitID,int NumberOfStars,string Nots)
        {
            int NewId = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Insert Into CustomersReviwes (CustomerID,ProductID,VegAndFruitID,NumberOfStars,Nots)\r\nvalues\r\n" +
                        "(@CustomerId,@ProductID,@VegAndFruitID,@NumberOfStars,@Nots);select SCOPE_IDENTITY(); ";

                    using(SqlCommand command=new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerID);
                        AddParameterWithValue(command, "@ProductID", ProductID);
                        AddParameterWithValue(command, "@VegAndFruitID", VegAndFruitID);
                        AddParameterWithValue(command, "@NumberOfStars", NumberOfStars);
                        AddParameterWithValue(command, "@Nots", Nots);

                        object reader= command.ExecuteScalar();
                        if (reader != null && int.TryParse(reader.ToString(), out int value))
                        {
                            NewId = value;
                        }
                    }


                }

            }
            catch
            {
                //
            }


            return NewId;







        }

        public static bool IsExits(int CustomerID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select CustomersID from Customers where CustomersID=@CustomerID";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

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
