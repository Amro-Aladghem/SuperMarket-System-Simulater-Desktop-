using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUsersData
    {
        public static DataTable GetAllRecord()
        {
            DataTable dt = new DataTable();
            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select Users.UserID,Users.UserName,(Employees.FirstName+' '+Employees.SecondName+' '+Employees.LastName) as FullName ,Users.Password from Users Inner join Employees on Users.EmployeeID=Employees.EmployeeID;";

                    using (SqlCommand command=new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool GetFullRecordByID(int UserID,ref string UserName,ref int EmployeeID,ref string Password,ref bool isActive,ref string ImagePath,ref int Permisions)
        {
            bool isFound = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select *fROM UserS where UserID=@UserID";
                    using (SqlCommand command =new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                UserName = (string)reader[1];
                                EmployeeID = (int)reader[2];
                                Password = (string)reader[3];
                                isActive = (bool)reader[4];
                                Permisions=(int)reader[6];
                                ImagePath = (string)reader[5];
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

        public static bool GetFullRecordByUserName(ref int UserID, string UserName, ref int EmployeeID, ref string Password, ref bool isActive, ref string ImagePath, ref int Permisions)
        {
            bool isFound = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select *fROM UserS where UserName=@UserName";
                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader[0];
                                EmployeeID = (int)reader[2];
                                Password = (string)reader[3];
                                isActive = (bool)reader[4];
                                Permisions = (int)reader[6];
                                ImagePath = (string)reader[5];
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

        public static int AddNewRecord(string UserName,int EmployeeID,string Password,bool isActive,string ImagePath,int Permisions)
        {
            int ID = -1;

            try
            {
             using (SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Insert Into Users (UserName,EmployeeID,Password,IsActive,ImagePath,Permisions)\r\nvalues\r\n" +
                        "(@UserName,@EmployeeID,@Password,@IsActive,@ImagePath,@Permisions);select SCOPE_IDENTITY();"; 

                    using (SqlCommand command =new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Permisions",Permisions);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        if (string.IsNullOrEmpty(ImagePath))
                        {
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                        }
                        command.Parameters.AddWithValue("@ImagePath",ImagePath);

                        object reader = command.ExecuteScalar();
                        if(int.TryParse(reader.ToString(), out int value))
                        {
                            ID = value;
                        }


                    }


                }
            }
            catch
            {

            }

            return ID;
        }

        public static bool UpdateRecord(int UserID,string UserName, int EmployeeID, string Password, bool isActive, string ImagePath, int Permisions)
        {
            bool isDone = false;
            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Update Users\r\nset UserName=@UserName,Password=@Password,IsActive=@IsActive,ImagePath=@Imagepath,Permisions=@Permisions where UserID=@UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Permisions", Permisions);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        if (string.IsNullOrEmpty(ImagePath))
                        {
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        }

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

        public static bool DeleteRecord(int UserID)
        {
            bool isDone = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "delete Users Where UserID=@UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        int rowaffected = command.ExecuteNonQuery();
                        if (rowaffected > 0)
                        {
                            isDone = false;
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

        public static bool isActiveRecord(int UserID)
        {
            bool isActive = false;

            try
            {

                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Select IsActive from Users Where UserID=@UserID and IsActive=1;";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isActive = true;
                            }
                        }
                    }




                }

            }
            catch
            {
                //
            }

            return isActive;
        }

        public static bool UserExits(int UserID)
        {
            bool isFound = false;


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qeury = "select UserName from Users Where UserID=@UserID";

                    using (SqlCommand command = new SqlCommand(qeury, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

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

        public static int UserPermisions(int UserID)
        {
            int Permisions = 0;
            try
            {

                using(SqlConnection connection= new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string qurey = "select Users.Permisions from Users Where UserID=@UserID";
                    
                    using(SqlCommand command =new SqlCommand(qurey, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Permisions = (int)reader[0];
                            }
                        }
                    }
                }






            }
            catch
            {

            }
            return Permisions;
        }

        public static bool ChangePasswordForUser(int UserId,string NewPassword)
        {
            bool isDone = false;

            try
            {
                
                using(SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Update Users\r\nset Password=@Password where UserID=@UserID";

                    using (SqlCommand command =new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", NewPassword);
                        command.Parameters.AddWithValue("@UserID",UserId);

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

        public static bool IsEmployeeAnUser(int EmployeeID)
        {

            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select UserName from Users where EmployeeID=@EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

            }

            return isFound;


        }







    }
}
