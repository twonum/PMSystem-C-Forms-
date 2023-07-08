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

namespace Pharmacy_Management_System.AdministrartorUC
{
    public partial class UC_View_User : UserControl
    {
        string currentUser = "";
        public UC_View_User()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { currentUser = value; }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void UC_View_User_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
                // Get the list of medicines.
                List<User> users = UserDL.getUsers();

                // Create a new list to store the matching medicines.
                List<User> matchingUsers = new List<User>();

                // Iterate through the list of medicines and add any medicine that matches the text in the text box to the new list.
                foreach (User user in users)
                {
                    if (user.Name.StartsWith(txtUserName.Text) || user.Name.Contains(txtUserName.Text))
                    {
                        matchingUsers.Add(user);
                    }
                }

            // Set the data grid source to the new list of matching medicines.
            guna2DataGridView1.DataSource = matchingUsers;
            

        }

        string usernameOrID;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usernameOrID = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch 
            {

                //throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Conformation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                if (currentUser != usernameOrID)
                {
                    User user = guna2DataGridView1.CurrentRow.DataBoundItem as User;
                    UserDL.getUsers().Remove(user);
                    UserDL.storeintoFile(Program.userPath);
                    
                    MessageBox.Show("User Record Deleted. ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("You are trying to Delete \n Your own Profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void refreshGrid()
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = UserDL.getUsers();
            guna2DataGridView1.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            List<User> users = UserDL.searchUser(username);
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = users;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            guna2DataGridView1.DataSource = null;
            UC_View_User_Load(this, null);
        }
    }
}
