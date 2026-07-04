using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Salary_Calculator
{
    internal class function
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter Sdt;
        private string ConString;

        public function()
        {
            ConString = "Server=.;Database = EmployeeMS;User Id=sa;Password=NewStrongPassword123!";
            Con = new SqlConnection(ConString);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            Sdt = new SqlDataAdapter(Query, ConString);
            Sdt.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int RowAffected = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            RowAffected = Cmd.ExecuteNonQuery();
            Con.Close();
            return RowAffected;
        }
    }
}
