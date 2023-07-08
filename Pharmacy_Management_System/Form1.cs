using Pharmacy_Management_System.BL;
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

namespace Pharmacy_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void clearAll()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {

            User user = UserDL.login(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                if (user.UserType == "Administrator")
                {
                    Administrator admin = new Administrator(user);
                    admin.Show();
                    this.Hide();
                }
                else if (user.UserType == "Pharmist")
                {
                    Pharmist pharmist = new Pharmist();
                    pharmist.Show();
                    this.Hide();
                }
            }
            if (user == null)
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearAll();
            }
            if (UserDL.getUsers().Count == 0)
            {
                if (txtUsername.Text == "root" && txtPassword.Text == "root")
                {
                    DialogResult result = MessageBox.Show("Do You want to Login as an Admin ? ", "Conformation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Administrator admin = new Administrator();
                        admin.Show();
                        this.Hide();
                    }
                    else if (result == DialogResult.No)
                    {
                        Pharmist pharmist = new Pharmist();
                        pharmist.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearAll();
                }
            }
        }
    }
}
