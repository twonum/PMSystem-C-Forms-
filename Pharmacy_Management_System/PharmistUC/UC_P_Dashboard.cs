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
using System.Windows.Forms.DataVisualization.Charting;

namespace Pharmacy_Management_System.PharmistUC
{
    public partial class UC_P_Dashboard : UserControl
    {
        public UC_P_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_P_Dashboard_Load(object sender, EventArgs e)
        {
            LoadChart();
        }
        public void LoadChart()
        {
            // Get the current date.
            DateTime currentDate = DateTime.Now;
            Int64 count1 = 0;
            Int64 count2 = 0;

            // Iterate through the list of medicines and add the data to the DataTable.
            foreach (Medicine medicine in MedicineDL.getList())
            {
                // Only add medicines that have a date greater than the current date.

                if (medicine.Expiry_date >= currentDate)
                {
                    count1 ++;
                }
            }
            this.chart1.Series["Valid Medicines"].Points.AddXY("Medicine Validity Chart", count1);

            foreach (Medicine medicine in MedicineDL.getList())
            {
                // Only add medicines that have a date greater than the current date.

                if (medicine.Expiry_date <= currentDate)
                {
                    count2++;
                }
            }
            this.chart1.Series["Expired Medicines"].Points.AddXY("Medicine Validity Chart", count2);

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Valid Medicines"].Points.Clear();
            chart1.Series["Expired Medicines"].Points.Clear();
            LoadChart();
        }
    }
}
