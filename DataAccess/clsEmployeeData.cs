using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public class clsEmployeeData
    {
        public static bool  AddNewEmployee(string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();
                    string Query = "insert into Employees values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Name, Gender, Phone, Position, Salary, JDate);

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                      RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
                return RowAffected > 0;
        }










    }
}
