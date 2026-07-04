using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Salary_Calculator.Salaries
{
    public partial class frmsalaries : Form
    {
        public frmsalaries()
        {
            InitializeComponent();
            con = new function();
            ShowAllSalaries();
            GetEmployee();
        }
        public void ShowAllSalaries()
        {
            string Query = "Select * from Salaries";
            dgvSalaries.DataSource = con.GetData(Query);
        }

        public void GetEmployee()
        {
            string Q = "Select * from Employees";

            cbEmp.ValueMember = con.GetData(Q).Columns["EmpID"].ToString();
            cbEmp.DisplayMember = con.GetData(Q).Columns["Name"].ToString();
            cbEmp.DataSource = con.GetData(Q);    
            
        }

        function con;
        private void btnSavePayment_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmpSalary();
        }

        private void GetEmpSalary()
        {
            try
            {
                string Q = "Select * from Employees where EmpID = {0} ";
                Q = string.Format(Q,cbEmp.SelectedValue.ToString());
                txtDailysalary.Text = con.GetData(Q).Rows[0]["Salary"].ToString();

            }
            catch ( Exception x  )
            {
                MessageBox.Show(x.Message);
            }

        }
    }
}
