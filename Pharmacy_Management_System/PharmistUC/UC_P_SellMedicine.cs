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
using System.Xml.Linq;

namespace Pharmacy_Management_System.PharmistUC
{
    public partial class UC_P_SellMedicine : UserControl
    {
        public UC_P_SellMedicine()
        {
            InitializeComponent();
            guna2DataGridView1.Rows[n].Cells[0].ReadOnly = true;
            guna2DataGridView1.Rows[n].Cells[1].ReadOnly = true;
            guna2DataGridView1.Rows[n].Cells[2].ReadOnly = true;
            guna2DataGridView1.Rows[n].Cells[3].ReadOnly = true;
            guna2DataGridView1.Rows[n].Cells[4].ReadOnly = true;
            guna2DataGridView1.Rows[n].Cells[5].ReadOnly = true;
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {
            ListBoxMedicines.Items.Clear();
            DateTime currentDate = DateTime.Now;
            foreach (Medicine item in MedicineDL.getList())
            {
                if (item.Expiry_date >= currentDate && item.Quantity > 0)
                {
                    ListBoxMedicines.Items.Add(item.Name.ToString());
                }
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SellMedicine_Load(this, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ListBoxMedicines.Items.Clear();
            // Get the list of medicines.
            List<Medicine> medicines = MedicineDL.getList();
            // Create a new list to store the matching medicines.
            List<Medicine> matchingMedicines = new List<Medicine>();

            // Iterate through the list of medicines and add any medicine that matches the text in the text box to the new list.
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.StartsWith(txtSearch.Text) || medicine.Name.Contains(txtSearch.Text))
                {
                    matchingMedicines.Add(medicine);
                }
            }

            // Set the data grid source to the new list of matching medicines.
            foreach (Medicine medicine in matchingMedicines)
            {

                ListBoxMedicines.Items.Add(medicine.Name.ToString());

            }


        }

        private void ListBoxMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnits.Clear();
            string name = ListBoxMedicines.GetItemText(ListBoxMedicines.SelectedItem);
            txtMedName.Text = name;
            Medicine medicine = MedicineDL.searchByName(name);
            if (medicine != null)
            {
                txtMedID.Text = medicine.MedicineID.ToString();
                txtExpiryDate.Text = medicine.Expiry_date.ToString();
                txtPrice.Text = medicine.Price.ToString();
            }
            else
            {
                MessageBox.Show("No Medicine Found.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUnits_TextChanged(object sender, EventArgs e)
        {
            int noOfUnits;
            if (int.TryParse(txtUnits.Text, out noOfUnits))
            {
                // The conversion was successful.
                int unitPrice = int.Parse(txtPrice.Text);
                int Total = unitPrice * noOfUnits;
                txtTotal.Text = Total.ToString();
            }
            else
            {
                // The conversion was not successful.
                txtTotal.Clear();
            }
        }


        protected int n, totalAmount = 0;
        protected int quantity, newQuantity;

        int valueAmount;
        string valueID;
        protected int noOfUnit;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                valueID = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfUnit = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueID != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch (Exception)
                {

                    //throw;
                }
                finally
                {
                    Medicine medicine = MedicineDL.searcher(valueID);
                    quantity = medicine.Quantity;
                    newQuantity = quantity + noOfUnit;
                    medicine.Quantity = newQuantity;
                    MedicineDL.storeintoFile(Program.medPath);
                    MessageBox.Show("Selected Medicine Removed from Cart.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    totalAmount = totalAmount - valueAmount;
                    totalLabel.Text = "Rs. " + totalAmount.ToString();
                }
                UC_P_SellMedicine_Load(this, null);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selected Bill Printed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            totalAmount = 0;
            totalLabel.Text = "Rs. 00";
            guna2DataGridView1.DataSource = 0;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.integerValidation(e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ListBoxMedicines.Items.Clear();
            string medicineName = txtSearch.Text;
            foreach (Medicine medicine in MedicineDL.getList())
            {
                if (medicineName == medicine.Name)
                {
                    ListBoxMedicines.Items.Add(medicineName.ToString());
                }
            }
        }

        private void txtMedID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtMedID.Text != null)
            {
                string ID = txtMedID.Text;
                Medicine medicine = MedicineDL.searcher(ID);
                if (medicine == null)
                {
                    MessageBox.Show("No Medicine Found.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    quantity = medicine.Quantity;
                    int selectedQuantity = int.Parse(txtUnits.Text);
                    newQuantity = quantity - selectedQuantity;
                    if (newQuantity >= 0)
                    {
                        n = guna2DataGridView1.Rows.Add();
                        guna2DataGridView1.Rows[n].Cells[0].Value = txtMedID.Text;
                        guna2DataGridView1.Rows[n].Cells[1].Value = txtMedName.Text;
                        guna2DataGridView1.Rows[n].Cells[2].Value = txtExpiryDate.Text;
                        guna2DataGridView1.Rows[n].Cells[3].Value = txtPrice.Text;
                        guna2DataGridView1.Rows[n].Cells[4].Value = txtUnits.Text;
                        guna2DataGridView1.Rows[n].Cells[5].Value = txtTotal.Text;

                        totalAmount = totalAmount + int.Parse(txtTotal.Text);
                        totalLabel.Text = "Rs. " + totalAmount.ToString();
                        medicine.Quantity = newQuantity;
                        MedicineDL.storeintoFile(Program.medPath);
                    }
                    else
                    {
                        MessageBox.Show("Medicine is Out of Stock.\n Only " + quantity + " left", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    clearAll();
                    UC_P_SellMedicine_Load(this, null);
                }

            }
            else
            {
                MessageBox.Show("Select Medicine First.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void clearAll()
        {
            txtMedID.Clear();
            txtMedName.Clear();
            txtExpiryDate.ResetText();
            txtPrice.Clear();
            txtUnits.Clear();

        }
    }
}
