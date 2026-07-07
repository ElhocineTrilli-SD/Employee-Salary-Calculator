using Business_layer;
using Employee_Salary_Calculator.Salaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Employee_Salary_Calculator.Dashbord
{
    public partial class frmEmployee : Form
    {
        public DataTable _dtEmployee;

        public frmEmployee()
        {
            InitializeComponent();
        }
        public void ShowAllEmployee()
        {
            _dtEmployee = clsEmployee.GetAllEmployee();

            if (_dtEmployee.Rows.Count >0)
            {
            dgvEmployees.DataSource = _dtEmployee;
            }
            else
            {
                MessageBox.Show("No Employee records ound.");
            }
           
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

                if (clsEmployee.AddNewEmployee(Name, Gender, Phone, Position, Salary, JDate))
                {
                    MessageBox.Show("The new employee has been added successfully.","Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                     );
                    frmEmployee_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to add the new employee.", "Error",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


            }

        }
    
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ShowAllEmployee();
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int EmpID = (int)dgvEmployees.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show(
                              "Are you sure you want to delete this employee?",
                              "Confirm Delete",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Warning
                              );

            if (result == DialogResult.Yes)
            {
                // delete Code : 
                if (clsEmployee.DeleteEmployee(EmpID))
                {
                    MessageBox.Show(
                                    "The employee with ID " + EmpID + " was deleted successfully.",
                                    "Delete Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                   );
                    frmEmployee_Load(null, null);
                }
                else
                {
                    MessageBox.Show(
                                    "Failed to delete the employee with ID " + EmpID + ". Please try again.",
                                    "Delete Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                   );
                }
            }

           


        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

                txtEName.Text = row.Cells[1].Value.ToString();
                cbGen.Text = row.Cells[2].Value.ToString();
                txtEPhone.Text = row.Cells[3].Value.ToString();
                txtEPosition.Text = row.Cells[4].Value.ToString();
                txtESalary.Text = row.Cells[5].Value.ToString();
                dtpEmployee.Value = Convert.ToDateTime(row.Cells[6].Value);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int EmpID = (int)dgvEmployees.CurrentRow.Cells[0].Value;
            string Name = txtEName.Text;
            string Gender = cbGen.SelectedItem.ToString();
            string Phone = txtEPhone.Text;
            string Position = txtEPosition.Text;
            int Salary = Convert.ToInt32(txtESalary.Text);
            string JDate = dtpEmployee.Value.ToString();
            DialogResult result = MessageBox.Show(
                             "Are you sure you want to update employee Info?",
                             "Confirm Update",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning
                             );

            if (result == DialogResult.Yes)
            {
                // Update Code : 
                if (clsEmployee.UpdateEmployee(EmpID,Name,Gender,Phone,Position,Salary,JDate))
                {
                    MessageBox.Show(
                                    "The employee with ID " + EmpID + " was updated successfully.",
                                    "Update Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                   );
                    frmEmployee_Load(null, null);
                }
                else
                {
                    MessageBox.Show(
                                    "Failed to update the employee info Please try again.",
                                    "Update Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                   );
                }
            }

        }
        private void RefreshEmployeeForm()
        {
            ShowAllEmployee();

            txtEName.Clear();
            txtEPhone.Clear();
            txtEPosition.Clear();
            txtESalary.Clear();
            cbGen.SelectedIndex = 0;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
           RefreshEmployeeForm();
        }

        private void btnSalaryies_Click(object sender, EventArgs e)
        {
            frmsalaries frmsalaries = new frmsalaries();
            frmsalaries.Show();
            this.Hide();
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

        private void txtESalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // JustNumbers
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
