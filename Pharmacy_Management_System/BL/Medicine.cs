using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.BL
{
    public class Medicine
    {
        private string medicineID = "";
        private string name = "";
        protected string medicineNumber = "";
        private DateTime manufacturing_date;
        private DateTime expiry_date;
        private int quantity;
        private float price;
        

        public string MedicineID { get => medicineID; set => medicineID = value; }
        public string Name { get => name; set => name = value; }
        public string MedicineNumber { get => medicineNumber; set => medicineNumber = value; }
        public DateTime Expiry_date { get => expiry_date; set => expiry_date = value; }
        public DateTime Manufacturing_date { get => manufacturing_date; set => manufacturing_date = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }

        public Medicine(string medicineID,string name,string medicineNumber,DateTime manufacturing_date,DateTime expiry_date,int Quantity,float price)
        {
            this.medicineID = medicineID;
            this.name = name;
            this.medicineNumber = medicineNumber;
            this.manufacturing_date = manufacturing_date;
            this.expiry_date = expiry_date;
            this.quantity = Quantity;
            this.price = price;
        }
        
    }
}
