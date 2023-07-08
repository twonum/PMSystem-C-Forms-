using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System
{
    public partial class Administrator : Form
    {
        string user = "";
        public Administrator()
        {
            InitializeComponent();
        }
        private string ID
        {
            get { return user.ToString(); }
        }

        public Administrator(BL.User username)
        {
            InitializeComponent();
            UserNamelabel.Text = username.Name;
            user = username.Id;
            uC_View_User1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_View_User1.Visible = false;
            uC_Profile1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_View_User1.Visible = true;
            uC_View_User1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }

        private void uC_Profile1_Load(object sender, EventArgs e)
        {

        }
    }
}
