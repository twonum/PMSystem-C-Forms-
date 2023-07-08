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

namespace Pharmacy_Management_System.PharmistUC
{
    public partial class UC_P_AddMedicine : UserControl
    {
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void clearAll()
        {
            pictureBox1.Visible = false;
            txtExpiryDate.ResetText();
            txtManufacturingDate.ResetText();
            txtMedicineName.ResetText();
            txtMedicineNumber.ResetText();
            txtMedicinneID.ResetText();
            txtPrice.ResetText();
            txtQuantity.ResetText();


        }

        private void txtMedicinneID_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            Medicine data = MedicineDL.searcher(txtMedicinneID.Text);
            if (data == null)
            {
                pictureBox1.ImageLocation = @"C:\\Users\\Muhammad Taha Saleem\\Desktop\\New folder\\Pharmacy Management System in C#\\yes.png";
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\\Users\\Muhammad Taha Saleem\\Desktop\\New folder\\Pharmacy Management System in C#\\no.png";
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string medID = txtMedicinneID.Text;
            string name = txtMedicineName.Text;
            string medNum = txtMedicineNumber.Text;
            DateTime manufactureDate = DateTime.Parse(txtManufacturingDate.Text);
            DateTime expiryDate = DateTime.Parse(txtExpiryDate.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int price = int.Parse(txtPrice.Text);
            Medicine med = MedicineDL.searcher(medID);
            if (med!=null)
            {
                MessageBox.Show("Sorry, Another Medicine With Same Id Already Exists !", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Medicine medicine = new Medicine(medID, name, medNum, manufactureDate, expiryDate, quantity, price);
                MedicineDL.setList(medicine);
                MedicineDL.storeintoFile(Program.medPath);
                MessageBox.Show("Medicine added successfully !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtMedicineNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }
    }
}
