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
    public partial class UC_P_UpdateMedicine : UserControl
    {
        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text!=null)
            {
                string ID = txtMedicineID.Text;
                Medicine medicine = MedicineDL.searcher(ID);
                if (medicine != null)
                {
                    txtMedicineName.Text = medicine.Name.ToString();
                    txtMedicineNumber.Text = medicine.MedicineNumber.ToString();
                    txtPrice.Text = medicine.Price.ToString();
                    txtManufacturingDate.Text = medicine.Manufacturing_date.ToString();
                    txtExpiryDate.Text = medicine.Expiry_date.ToString();
                    txtAvailableQuantity.Text = medicine.Quantity.ToString();
                    
                }
                else
                {
                    MessageBox.Show("No Medicine with ID : " + txtMedicineID.Text + "exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();
            }
        }
        private void clearAll()
        {
            txtMedicineID.Clear();
            txtMedicineName.Clear();
            txtPrice.Clear();
            txtManufacturingDate.ResetText();
            txtExpiryDate.ResetText();
            if (txtAddQuantity.Text!="0")
            {
                txtAddQuantity.Text = "0";
            }
            else
            {
                txtAddQuantity.Text = "0";
            }
            txtMedicineNumber.ResetText();
            txtAvailableQuantity.ResetText();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        int totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtMedicineName.Text;
            Int64 price = Int64.Parse(txtPrice.Text);
            string number = txtMedicineNumber.Text;
            DateTime mDate = DateTime.Parse(txtManufacturingDate.Text);
            DateTime expiryDate = DateTime.Parse(txtExpiryDate.Text);
            
            int availableQuantity = int.Parse(txtAvailableQuantity.Text);
            int addQuantity = int.Parse(txtAddQuantity.Text);
            totalQuantity = availableQuantity + addQuantity;

            string ID = txtMedicineID.Text;
            Medicine medicine = MedicineDL.searcher(ID);
            if (medicine != null)
            {
                medicine.Name = name;
                medicine.Price = price;
                medicine.MedicineNumber = number;
                medicine.Manufacturing_date = mDate;
                medicine.Expiry_date = expiryDate;
                medicine.Quantity = totalQuantity;

                MedicineDL.storeintoFile(Program.medPath);
                MessageBox.Show("Medicine Updation Complete !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No Medicine with ID : " + txtMedicineID + "exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMedicineNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtAvailableQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtAddQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }
    }
}
