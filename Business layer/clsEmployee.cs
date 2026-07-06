using DataAccess;

namespace Business_layer
{
    public static  class clsEmployee
    {

        public static bool AddNewEmployee(string Name, string Gender, string Phone, string Position, int Salary, string JDate)
        {
            return clsEmployeeData.AddNewEmployee(Name, Gender, Phone, Position, Salary, JDate);

        }


    }
}
