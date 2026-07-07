using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace DataAccess
{
    public class clsEmployeeData
    {
        public static int AddNewEmployee(string Name, string Gender, string Phone, string Position, int Salary, string JDate)
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
            return RowAffected;
        }

        public static DataTable GetAllEmployee()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    string Query = "Select * From employees";

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

        public static int DeleteEmployee(int ID)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();
                    string Query = @"Delete from Salaries where EmployeeID = @EmpID
                                     Delete from Employees where EmpID = @EmpID ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", ID);
                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            return RowAffected;

        }

        public static int UpdateEmployee(int ID, string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            int RowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();
                    string Query = @"UPDATE [dbo].[Employees]
   SET [Name] = @Name
      ,[Gender] = @Gender
      ,[Phone] = @Phone
      ,[Position] = @Position
      ,[Salary] = @Salary
      ,[Joindate] = @Joindate
       WHERE EmpID = @EmpID";



                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", ID);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Position", Position);
                        command.Parameters.AddWithValue("@Salary", Salary);
                        command.Parameters.AddWithValue("@Joindate", JDate);


                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            return RowAffected;

        }


        public static bool GetEmployeeSalaryByID(int EmpID, ref int Salart)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees WHERE EmpID = @EmpID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", EmpID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;
                                Salart = (int)reader["Salary"];
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception k)
            {

                IsFound = false;
            }
        return IsFound;
        }
        public static bool GetEmployeeNameByID( ref int EmpID, ref string Name)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnection.ConString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees ";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@EmpID", EmpID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;
                                Name = (string)reader["Name"];

                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception k)
            {

                IsFound = false;
            }
            return IsFound;
        }




        /////
    }
}
