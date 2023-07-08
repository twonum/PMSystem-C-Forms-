using Pharmacy_Management_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string userPath = "usersData.txt";
        public static string medPath = "medicinesData.txt";
        public static string customerPath = "customersData.txt";

        [STAThread]
        static void Main()
        {
            bool flag1 = UserDL.readFromFile(Program.userPath); ;
            if (!flag1)
            {
                MessageBox.Show("Users Data not Loaded Succesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bool flag2 = MedicineDL.readFromFile(Program.medPath);
            if (!flag2)
            {
                MessageBox.Show("Users Data not Loaded Succesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //bool flag3 = UserDL.readFromFile(customersDataPath);
            //if (!flag3)
            //{
            //    MessageBox.Show("Customers Data not Loaded Succesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void integerValidation(KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If the pressed key is not a digit or a control key (e.g., Backspace),
                // cancel the keypress event to prevent the character from being entered
                e.Handled = true;
            }
        }
    }
}
