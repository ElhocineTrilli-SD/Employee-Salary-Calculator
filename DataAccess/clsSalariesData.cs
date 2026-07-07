using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsSalariesData
    {
     
        public static int SaveSalary(string EmployeeID, string Period, int Base, int DaysWorked,int PaidAmount, string PDate)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();
                    string Query = "insert into salaries values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, EmployeeID, Period, Base, DaysWorked, PaidAmount, PDate);

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            return RowAffected;
        }

        public static DataTable GetAllSalaries()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    string Query = "Select * From VSalariesList";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }


                }


            }
            catch (Exception ex) { }
            ;
            return dt;
        }

        public static int DeleteSalary(int SalaryID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();
                    string Query = @"Delete from Salaries where SalaryID = @SalaryID;";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@SalaryID", SalaryID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            return RowAffected;

        }

        
    }
}
