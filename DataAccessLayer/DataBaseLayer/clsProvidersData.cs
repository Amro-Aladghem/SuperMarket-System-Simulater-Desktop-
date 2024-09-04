using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsProvidersData
    {

        public static DataTable GetAllRecord()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "select ProviderID,Name,PhoneNumber,Email,DateOfComing from Providers";

                    using(SqlCommand command=new SqlCommand(query, connection))
                    {

                        using(SqlDataReader reader=command.ExecuteReader()) { 
                        
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

            }

            return dt;
        }

        public static bool GetFullRecordByID(int ProviderID,ref string ProviderName,ref string PhoneNumber,ref string Email,ref string DateOfComing,ref DateTime DateOFSet)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Providers where ProviderID=@ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProviderName = (string)reader[1];
                                PhoneNumber = (string)reader[2];
                                if (reader[3]==System.DBNull.Value)
                                {
                                    Email = null;
                                }
                                else
                                {
                                    Email = (string)reader[3];
                                }

                                DateOfComing = (string)reader[4];
                                DateOFSet= (DateTime)reader[5];
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

        public static bool GetFullRecordByName(ref int ProviderID,  string ProviderName, ref string PhoneNumber, ref string Email, ref string DateOfComing, ref DateTime DateOFSet)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Providers where Name=@Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name",ProviderName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ProviderID = (int)reader[0];
                                PhoneNumber = (string)reader[2];
                                Email = (string)reader[3];
                                DateOfComing = (string)reader[4];
                                DateOFSet = (DateTime)reader[5];

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

        public static int AddNewRecord( string ProviderName,  string PhoneNumber, string Email,  string DateOfComing,DateTime DateOfSet)
        {
            int Id = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "Insert Into Providers(Name,PhoneNumber,Email,DateOfComing,DateOfSet)\r\nvalues\r\n" +
                        "(@Name,@PhoneNumberm,@Email,@DateOfComing,@DateOfSet);select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Name", ProviderName);

                        command.Parameters.AddWithValue("@PhoneNumberm", PhoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@DateOfComing", DateOfComing);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);

                        object reader = command.ExecuteScalar();
                        if (reader != null && int.TryParse(reader.ToString(), out int value))
                        {
                            Id = value;
                        }

                    }

                }
            }
            catch
            {
                //
            }

            return Id;
        }

        public static bool UpdateRecord(int ProviderID, string ProviderName, string PhoneNumber, string Email, string DateOfComing, DateTime DateOfSet)
        {
            bool isDone = false;

            try
            {

                using (SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();

                    string query = "Update Providers\r\nSet Name=@Name,PhoneNumber=@PhoneNumber,Email=@Email,DateOfComing=@DateOfComing,DateOfSet=@DateOfSet where ProviderID=@ProviderID";

                    using (SqlCommand command =new SqlCommand(query,connection)) 
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@Name", ProviderName);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@DateOfComing", DateOfComing);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);

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

        public static bool DeleteRecord(int ProviderID)
        {
            bool isDone = false;    

            try
            {

             using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qeury = "delete Providers where ProviderID=@ProvidorId";

                    using(SqlCommand command =new SqlCommand(qeury,connection))
                    {
                        command.Parameters.AddWithValue("@ProvidorId", ProviderID);

                        int rowaffected = command.ExecuteNonQuery();
                        if(rowaffected > 0)
                        {
                            isDone=true;
                        }

                    }
                }

            }
            catch
            {

            }

            return isDone;
        }

        public static bool isExist(int ProviderID)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select Providers.ProviderID from Providers where ProviderID=@ProviderID";

                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = true;
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

        public static bool ChangePhoneNumber(int ProviderID, string NewPhoneNumber)
        {
            bool isDone=false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "Update Providers\r\nset PhoneNumber=@PhoneNumber where ProviderID=@ProviderID";
                    
                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@PhoneNumber", NewPhoneNumber);

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

        public static bool ChangeEmail(int ProviderID, string NewEmail)
        {
            bool isDone = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "Update Providers\r\nset Email=@Email where ProviderID=@ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@Email", NewEmail);

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

            }

            return isDone;
        }

        public static bool ChangDateOfComing(int ProviderID,string NewDateOfComing)
        {
            bool isDone = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "Update Providers\r\nset DateOfComing=@DateOfComing where ProviderID=@ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", ProviderID);
                        command.Parameters.AddWithValue("@DateOfComing",NewDateOfComing);

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

            }

            return isDone;



        }







    }
}
