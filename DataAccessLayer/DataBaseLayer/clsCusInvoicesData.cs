using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCusInvoicesData
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
                    string query = "select *from [Customer Invoices]";

                    using (SqlCommand command = new SqlCommand(query, connection))
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

        public static  bool GetRecordByInvoiceID(int InvoiceID,ref int OrderID,ref int?CustomerID,ref decimal TotalAmount,ref DateTime DateOfSet,ref int UserID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "select *from [Customer Invoices] where InvoiceID=@InvoiceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                OrderID = (int)reader[1];
                                CustomerID = (int?)reader[2];
                                TotalAmount = (decimal)reader[3];
                                DateOfSet = (DateTime)reader[4];
                                UserID = (int)reader[5];

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

        public static int AddNewRecord(  int OrderID,  int? CustomerID,  decimal TotalAmount,  DateTime DateOfSet, int UserID)
        {
            int NewID = OrderID;

            try
            {

                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Insert Into [Customer Invoices](OrderID,CustomerID,TotalAmount,DateOfInvoice,UserID)\r\nvalues\r\n" +
                        "(@OrderID,@CustomerID,@TotalAmount,@DateOfSet,@UserID);select SCOPE_IDENTITY();";

                    using(SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", OrderID);
                        AddParameterWithValue(command, "@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@DateOfSet", DateOfSet);
                        command.Parameters.AddWithValue("@UserID", UserID);

                        object reader = command.ExecuteScalar();
                        if(reader!=null&&int.TryParse(reader.ToString(),out int value))
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


        public static bool        DeleteRecord(int InvoiceID)
        {
            bool isDone = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    connection.Open();
                    string query = "delete [Customer Invoices] where InvoiceID=@InvoiceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceID", InvoiceID);

                        int rowaffected=command.ExecuteNonQuery();
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
