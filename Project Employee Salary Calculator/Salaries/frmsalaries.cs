using Employee_Salary_Calculator.Dashbord;
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
            if (txtDaysWorked.Text == "" || txtDailysalary.Text == "" || txtTotalAmount.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string EmployeeID = cbEmp.SelectedValue.ToString();
                    string PDate = dtpPayment.Value.Date.ToString();
                    int DaysWorked = Convert.ToInt32(txtDaysWorked.Text);
                    int Base = Convert.ToInt32(txtDailysalary.Text);
                    string Period = dtpSalary1.Value.Month.ToString() + " - " + dtpSalary1.Value.Year.ToString();

                    string Query = "insert into Salaries values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, EmployeeID, Period, Base, DaysWorked, Tot, PDate);
                    con.SetData(Query);
                    MessageBox.Show("Salary Added!!");
                    ShowAllSalaries();
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            }
            }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmpSalary();
            txtTotalAmount.Text = "";
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

        private void label2_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmsalaries frm = new frmsalaries();
            frm.Show();
            this.Hide();
        }
        int Tot = 0;
        private void ShowTotalAmount_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32( txtDaysWorked.Text) >= 1 )
            {
                Tot = Convert.ToInt32(txtDailysalary.Text) * Convert.ToInt32(txtDaysWorked.Text);
                txtTotalAmount.Text = "Rs " + Tot.ToString();
                    
            }
            
        }
    }
}
