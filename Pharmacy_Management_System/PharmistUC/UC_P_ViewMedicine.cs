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
    public partial class UC_P_ViewMedicine : UserControl
    {
        public UC_P_ViewMedicine()
        {
            InitializeComponent();
        }

        private void UC_P_ViewMedicine_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
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
                guna2DataGridView2.DataSource = matchingMedicines;
            

        }

        string medicineID;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Conformation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Medicine medicine = guna2DataGridView2.CurrentRow.DataBoundItem as Medicine;
                MedicineDL.getList().Remove(medicine);
                MedicineDL.storeintoFile(Program.medPath);

                MessageBox.Show("User Record Deleted. ", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshGrid();
            }
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineID = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void refreshGrid()
        {
            guna2DataGridView2.DataSource = null;
            guna2DataGridView2.DataSource = MedicineDL.getList();
            guna2DataGridView2.Refresh();
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string medicineName = txtSearch.Text;
            List<Medicine> medicines = MedicineDL.listSearcher(medicineName);
            guna2DataGridView2.DataSource = null;
            guna2DataGridView2.DataSource = medicines;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            guna2DataGridView2.DataSource = null;
            UC_P_ViewMedicine_Load(this, null);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
