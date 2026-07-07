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
        public static bool UpdateEmployee(int ID, string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            //call DataAccess;
            return clsEmployeeData.UpdateEmployee(ID,Name,Gender,Phone,Position,Salary,JDate) > 0;
        }
        public static bool GetEmployeeSalaryByID(int ID, ref int Salary)
        {
            return clsEmployeeData.GetEmployeeSalaryByID(ID,ref Salary);
        }
        public static bool GetEmployeeNameAndID(int ID, string Name)
        {
            return clsEmployeeData.GetEmployeeNameByID( ref ID, ref Name);
        }
    }
}
