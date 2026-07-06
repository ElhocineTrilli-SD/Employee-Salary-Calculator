using Business_layer;
using Employee_Salary_Calculator.Salaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Salary_Calculator.Dashbord
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
            con = new function();
            ShowAllEmployee();
        }
        function con;

        public void ShowAllEmployee()
        {
            string Query = "Select * from Employees";
            dgvEmployees.DataSource = con.GetData(Query);
        }
        private void btAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtEName.Text == "" || txtEPhone.Text == "" || txtEPosition.Text == "" || txtESalary.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                string Name = txtEName.Text;
                string Gender = cbGen.SelectedItem.ToString();
                string Phone = txtEPhone.Text;
                string Position = txtEPosition.Text;
                int Salary = Convert.ToInt32(txtESalary.Text);
                string JDate = dtpEmployee.Value.Date.ToString();

                if (clsEmployee.AddNewEmployee(Name,Gender,Phone,Position,Salary,JDate))
                {
                    MessageBox.Show("Employee Added!!");
                            ShowAllEmployee();
                }


            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
          frmsalaries frmsalaries = new frmsalaries();
            frmsalaries.Show();
            this.Hide();
        }
    }
}
