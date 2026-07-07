using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer
{
    public class clsSalary
    {
        public static bool SaveSalary(string EmployeeID, string Period,
            int Base, int DaysWorked, int PaidAmount, string PDate)
        { 
            //call DataAccess;

            return clsSalariesData.SaveSalary(EmployeeID,Period,Base,DaysWorked,PaidAmount,PDate) > 0;

        }

        public static DataTable GetAllSalaries()
        {
            //call DataAccess;
            return clsSalariesData.GetAllSalaries();
        }

        public static bool DeleteSalartRecord(int SalaryID)
        {
            //call DataAccess;
            return clsSalariesData.DeleteSalary(SalaryID) > 0;
        }


    }
}
