using Microsoft.VisualBasic.ApplicationServices;
using Pharmacy_Management_System.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.AdministrartorUC
{
    public partial class UC_AddUser : UserControl
    {
        private DataGridView userGrid;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void clearAll()
        {
            txtDOB.ResetText();
            txtEmail.ResetText();
            txtPassword.ResetText();
            txtUserName.ResetText();
            txtMobileNO.ResetText();
            txtName.ResetText();
            pictureBox1.Visible = false;
            txtUserRole.SelectedIndex = -1;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UC_AddUser_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            BL.User data = UserDL.check(txtUserName.Text);
            if (data == null)
            {
                pictureBox1.ImageLocation = @"C:\\Users\\Muhammad Taha Saleem\\Desktop\\New folder\\Pharmacy Management System in C#\\yes.png";
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\\Users\\Muhammad Taha Saleem\\Desktop\\New folder\\Pharmacy Management System in C#\\no.png";
            }
        }

        
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string role = txtUserRole.Text;
            string name = txtName.Text;
            DateTime DOB = DateTime.Parse(txtDOB.Text);
            int number = int.Parse(txtMobileNO.Text);
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string userID = txtUserName.Text;
            BL.User check = UserDL.check(userID);
            if (check!=null)
            {
                MessageBox.Show("Sorry another user already exists with that id !", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BL.User user = new BL.User(role, name, DOB, number, email, password, userID);
                UserDL.setUser(user);
                UserDL.storeintoFile(Program.userPath);
                MessageBox.Show("Signed Up successfully !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll();
            }
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }
    }
}
