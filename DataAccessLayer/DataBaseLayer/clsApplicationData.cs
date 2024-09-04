using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsApplicationData
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


        public static void AddNewApplication(int ApplicationTypeID,DateTime DateOfApplication,int?ProductID,int?vegAndfruitId,int?OfferID,int UserID)
        {
            int Num = -1;
            try
            {
                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    string query = "Insert Into Applications(ApplicationTypeID,DateOfApplication,ProductID,VegAndFruitID,OffersID,UserID)\r\nvalues\r\n" +
                        "(@ApplicationTypeId,@DateOfApplication,@ProductID,@VegAndFruitId,@OffersId,@UserID);select SCOPE_IDENTITY()";

                    using(SqlCommand command=new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeID);
                        command.Parameters.AddWithValue("@DateOfApplication", DateOfApplication);
                        AddParameterWithValue(command, "@ProductID", ProductID);
                        AddParameterWithValue(command, "@VegAndFruitId", vegAndfruitId);
                        AddParameterWithValue(command, "@OffersId", OfferID);
                        command.Parameters.AddWithValue("@UserID", UserID);

                        object reader= command.ExecuteScalar();
                        if(reader!=null&& int.TryParse(reader.ToString(),out int value))
                        {
                            Num = value;
                        }

                        
                    }
                }

            }
            catch
            {
                //
            }

            
        }

       public static DataTable GetAllRecord()
        {
            DataTable dt = new DataTable();

            try
            {

                using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection
                        .Open();
                    string query = "select *from Applications";

                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        using(SqlDataReader reader=command.ExecuteReader())
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









    }
}
