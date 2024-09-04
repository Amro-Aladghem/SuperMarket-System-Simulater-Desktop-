using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace DataAccessLayer
{
    public class clsEmployeeData
    {

        public static DataTable GetAllRecord()
        {
            DataTable table = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string qurey = "\r\n\r\nselect EmployeeID,(FirstName+' '+SecondName+' '+LastName) as FullName,DateOfBirth,Salary, DateOfSet from Employees\r\n";

                    using (SqlCommand command = new SqlCommand(qurey, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                table.Load(reader);
                            }
                        }
                    }

                }
            }
            catch
            {
                //
            }

            return table;

        }
        public static bool GetFullRecordByID(int EmployeeID, ref string FirstName, ref string SecondName, ref string LastName, ref DateTime DateOfBirht, ref double Salary, ref DateTime DateOfSet)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Employees where EmployeeID=@EmployeeID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                LastName = (string)reader["LastName"];
                                DateOfBirht = (DateTime)reader["DateOfBirth"];
                                Salary = (double)(decimal)reader["Salary"];
                                DateOfSet = (DateTime)reader["DateOfSet"];
                            }


                        }
                    }
                }
            }
            catch
            {
                ///
            }

            return isFound;

        }

        public static bool GetFullRecordByFirstName(ref int EmployeeID, string FirstName, ref string SecondName, ref string LastName, ref DateTime DateOfBirht, ref double Salary, ref DateTime DateOfSet)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from Employees where FirstName@FirstName;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                EmployeeID = (int)reader["EmployeeID"];
                                SecondName = (string)reader["SecondName"];
                                LastName = (string)reader["LastName"];
                                DateOfBirht = (DateTime)reader["DateOfBirth"];
                                Salary = (double)(decimal)reader["Salary"];
                                DateOfBirht = (DateTime)reader["DateOfSet"];
                            }


                        }
                    }
                }
            }
            catch
            {
                ///
            }

            return isFound;
        }

        public static int AddNewRecord(string FirstName, string SecondName, string LastName, DateTime DateOfBirht, double Salary, DateTime DateOfSet)
        {
            int ID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Insert Into Employees(FirstName,SecondName,LastName,DateOfBirth,Salary,DateOfSet)\r\nvalues\r\n" +
                        "(@FirstName,@SecoundName,@LastNamem,@DateOfBirth,@Salary,@DateOfSet);select SCOPE_IDENTITY();";
                    using (SqlCommand commmand = new SqlCommand(query, connection))
                    {
                        commmand.Parameters.AddWithValue("@FirstName", FirstName);
                        commmand.Parameters.AddWithValue("@SecoundName", SecondName);
                        commmand.Parameters.AddWithValue("@LastNamem", LastName);
                        commmand.Parameters.AddWithValue("@DateOfBirth", DateOfBirht);
                        commmand.Parameters.AddWithValue("@Salary", Salary);
                        commmand.Parameters.AddWithValue("@DateofSet", DateOfSet);


                        object reader = commmand.ExecuteScalar();
                        if (int.TryParse(reader.ToString(), out int value))
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
        public static bool UpdateRecord(int EmployeeID, string FirstName, string SecondName, string LastName, DateTime DateOfBirht, double Salary, DateTime DateOfSet)
        {

            bool isDone = false;


            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "\r\nUpdate Employees\r\nset FirstName=@FirstName,SecondName=@SecoundName,LastName=@LastName,DateOfBirth=@DateofBirth,Salary=@Salary,DateOfSet=@DateofSet where EmployeeID=@EmployeeID";

                    using (SqlCommand commmand = new SqlCommand(query, connection))
                    {
                        commmand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        commmand.Parameters.AddWithValue("@FirstName", FirstName);
                        commmand.Parameters.AddWithValue("@SecoundName", SecondName);
                        commmand.Parameters.AddWithValue("@LastName", LastName);
                        commmand.Parameters.AddWithValue("@DateOfBirth", DateOfBirht);
                        commmand.Parameters.AddWithValue("@Salary", Salary);
                        commmand.Parameters.AddWithValue("@DateofSet", DateOfSet);

                        int reader = commmand.ExecuteNonQuery();
                        if (reader > 0)
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

        public static bool isExsits(int EmployeeID)
        {

            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                
                {
                    connection.Open();
                    string query = "select EmployeeID from Employees where EmployeeID=@EmployeeID;select SCOPE_IDENTITY();";
                    
                    using (SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        object reader = command.ExecuteScalar();
                        if (reader!=null&&int.TryParse(reader.ToString(), out int Id))
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

        public static bool DeleteRecord(int EmployeeID)
        {
            bool isDone = false;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "delete Employees where EmployeeID=@EmployeeID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        int reader = command.ExecuteNonQuery();
                        if (reader > 0)
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












            