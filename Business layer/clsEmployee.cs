using DataAccess;
using System.Data;

namespace Business_layer
{
    public static  class clsEmployee
    {
        public static bool AddNewEmployee(string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            //call DataAccess;

            return clsEmployeeData.AddNewEmployee(Name, Gender, Phone, Position, Salary, JDate) > 0;

        }
        public static DataTable GetAllEmployee()
        {
            //call DataAccess;

            return clsEmployeeData.GetAllEmployee();
        }
        public static bool DeleteEmployee(int ID)
        {
            //call DataAccess;
            return clsEmployeeData.DeleteEmployee(ID) > 0;
        }

    }
}
