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
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            UC_Dashboard_Load(this, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            AdminLabel.Text = getUsersCount(UserDL.getUsers(), "Administrator").ToString();
            PharmistLabel.Text = getUsersCount(UserDL.getUsers(), "Pharmist").ToString();
            CustomerLabel.Text = getUsersCount(UserDL.getUsers(), "user").ToString();
        }
        private int getUsersCount(List<BL.User> users, string role)
        {
            int count = 0;
            foreach (BL.User user in UserDL.getUsers())
            {
                if (user.UserType == role)
                {
                    count = count + 1;
                }
            }
            return count;
        }

        private void AdminLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
