using DataAccess;
using System.Data;

namespace Business_layer
{
    public static  class clsEmployee
    {

        public static bool AddNewEmployee(string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            return clsEmployeeData.AddNewEmployee(Name, Gender, Phone, Position, Salary, JDate);

        }
        public static DataTable GetAllEmployee()
        {
            return clsEmployeeData.GetAllEmployee();
        }

    }
}
