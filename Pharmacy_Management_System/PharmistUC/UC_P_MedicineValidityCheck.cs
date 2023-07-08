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
    public partial class UC_P_MedicineValidityCheck : UserControl
    {
        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            List<Medicine> list = new List<Medicine>();
            if (txtCheck.SelectedIndex==0)
            {
                // Iterate through the list of medicines and add the data to the DataTable.
                foreach (Medicine medicine in MedicineDL.getList())
                {
                    // Only add medicines that have a date greater than the current date.

                    if (medicine.Expiry_date >= currentDate)
                    {
                        list.Add(medicine);
                    }
                }
                setDataGrid("Valid Medicines", Color.Black, list);
            }
            else if (txtCheck.SelectedIndex == 1)
            {
                foreach (Medicine medicine in MedicineDL.getList())
                {
                    // Only add medicines that have a date greater than the current date.

                    if (medicine.Expiry_date <= currentDate)
                    {
                        list.Add(medicine);
                    }
                }
                setDataGrid("Expired Medicines", Color.Red, list);
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                setDataGrid(null, Color.Black, MedicineDL.getList());
            }
        }
        private void setDataGrid(string labelName,Color color,List<Medicine> list)
        {
            guna2DataGridView1.DataSource = list;
            setLabel.Text = labelName;
            setLabel.ForeColor = color;
        }

        private void UC_P_MedicineValidityCheck_Load(object sender, EventArgs e)
        {
            setLabel.Text = null;
        }
    }
}
