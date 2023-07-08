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
    public partial class UC_Profile : UserControl
    {
        public UC_Profile()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { userNameLabel.Text = value; }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string role = txtUserRole.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            DateTime DOB = DateTime.Parse(txtDOB.Text);
            int phone = int.Parse(txtPhone.Text);
            BL.User user  = UserDL.check(userNameLabel.Text);
            user.UserType = role;
            user.Email = email;
            user.DOB = DOB;
            user.Name = name;
            user.Password = password;
            user.PhoneNo = phone;
            UserDL.storeintoFile(Program.userPath);
            MessageBox.Show("Profile Updation Complete !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation  );
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            BL.User user = UserDL.check(userNameLabel.Text);
            txtUserRole.Text = user.UserType.ToString();
            txtName.Text = user.Name.ToString();
            txtEmail.Text = user.Email.ToString();
            txtDOB.Text = user.DOB.ToString();
            txtPassword.Text = user.Password.ToString();
            txtPhone.Text = user.PhoneNo.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UC_Profile_Enter(this, null);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
