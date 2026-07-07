using Business_layer;
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
        public DataTable _dtSalaries;

        public frmsalaries()
        {
            InitializeComponent();
          
        }
        public void ShowAllSalariesList()
        {
         _dtSalaries = clsSalary.GetAllSalaries();
           if(_dtSalaries.Rows.Count> 0)
            {
            dgvSalaries.DataSource = _dtSalaries;
            }
            else
            {
                MessageBox.Show("No salary records found.");
            }
        }

        public void FillComboboxWithEmployeeNames()
        {
          

            cbEmp.ValueMember = clsEmployee.GetAllEmployee().Columns["EmpID"].ToString(); 
            cbEmp.DisplayMember = clsEmployee.GetAllEmployee().Columns["Name"].ToString();

            cbEmp.DataSource = clsEmployee.GetAllEmployee();

         
           
            
        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            if (txtDaysWorked.Text == "" || txtDailysalary.Text == "" || txtTotalAmount.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                string EmployeeID = cbEmp.SelectedValue.ToString();
                string Period = dtpSalary1.Value.Month.ToString() + " - " + dtpSalary1.Value.Year.ToString();
                int Base = Convert.ToInt32(txtDailysalary.Text);
                int DaysWorked = Convert.ToInt32(txtDaysWorked.Text);
                int PaidAmount = Convert.ToInt32(txtTotalAmount.Text);
                string PDate = dtpPayment.Value.Date.ToString();

                if(clsSalary.SaveSalary(EmployeeID, Period, Base, DaysWorked,PaidAmount, PDate))
                {
                    MessageBox.Show("The Payment has been added successfully.", "Success",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
                   );
                    frmsalaries_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to add the Payment.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }  

        private void cbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmployeeSalary();
            txtTotalAmount.Text = "";
        }

        private void GetEmployeeSalary()
        {
            int EmpID =Convert.ToInt32( cbEmp.SelectedValue.ToString());
            int Salary = 0;
            if(clsEmployee.GetEmployeeSalaryByID(EmpID,ref Salary))
            {
                txtDailysalary.Text = Salary.ToString();
            }

            //try
            //{
            //    string Q = "Select * from Employees where EmpID = {0} ";
            //    Q = string.Format(Q,cbEmp.SelectedValue.ToString());
            //    txtDailysalary.Text = con.GetData(Q).Rows[0]["Salary"].ToString();

            //}
            //catch ( Exception x  )
            //{
            //    MessageBox.Show(x.Message);
            //}

        }
       
        private void ShowTotalAmount_Click(object sender, EventArgs e)
        {
            int Tot = 0;
            if (Convert.ToInt32( txtDaysWorked.Text) >= 1 )
            {
                Tot = Convert.ToInt32(txtDailysalary.Text) * Convert.ToInt32(txtDaysWorked.Text);
                txtTotalAmount.Text =  Tot.ToString();
                    
            }
            
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.Show();
            this.Hide();
        }
        private void RefreshSalariesForm()
        {
            ShowAllSalariesList();

            txtDailysalary.Clear();
            txtDaysWorked.Clear();
            txtTotalAmount.Clear();

            cbEmp.SelectedIndex = 0;
            
        }
        private void btnSalaryies_Click(object sender, EventArgs e)
        {
         RefreshSalariesForm(); 
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmsalaries_Load(object sender, EventArgs e)
        {
            ShowAllSalariesList();
            FillComboboxWithEmployeeNames();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          int salaryID = (int)dgvSalaries.CurrentRow.Cells[0].Value;
            DialogResult result = MessageBox.Show(
                             "Are you sure you want to delete this Record?",
                             "Confirm Delete",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning
                             );

            if (result == DialogResult.Yes)
            {
                // delete Code : 
                if (clsSalary.DeleteSalartRecord(salaryID))
                {
                    MessageBox.Show(
                                    "The record with ID " + salaryID + " was deleted successfully.",
                                    "Delete Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                   );
                    frmsalaries_Load(null, null);
                }
                else
                {
                    MessageBox.Show(
                                    "Failed to delete the record with ID " + salaryID + ". Please try again.",
                                    "Delete Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                   );
                }
            }
        }
    }
}
