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

namespace Employee_Salary_Calculator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Control Temp = ((Control)sender);

            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }


            if (txtUsername.Text =="" &&  txtPassword.Text == "") { return; }

            
            if (txtPassword.Text == "admin" && txtUsername.Text == "admin")
            {
                if(cbRememberMe.Checked)
                {
                    GlobalClass.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    GlobalClass.RememberUsernameAndPassword("", "");
                }

                frmEmployee frm = new frmEmployee();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.","Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.Validating += ValidateEmptyTextBox;
            txtUsername.Validating += ValidateEmptyTextBox;

            string Username = "", Password = "";

            if(GlobalClass.GetStoredCredential( ref Username, ref Password) != null)
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
            {
                cbRememberMe.Checked = false;
            }


        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
