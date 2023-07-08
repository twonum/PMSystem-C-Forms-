using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.BL
{
    public class Customer : User
    {
        private float total;
        private List<Medicine> boughtMedicines = new List<Medicine>();

        public Customer(string name, string password, string id, string userType,DateTime dob,string email, Int64 phoneNo) : base(userType, name, dob, phoneNo, email, password, id)
        {
            this.total = 0;
        }


        public void addTotal(float total)
        {
            //this.total += total;
            this.total = total;
        }
        public float getTotal()
        {
            return this.total;
        }
        public void setMedicine(Medicine boughtMedicine)
        {
            boughtMedicines.Add(boughtMedicine);
        }
        public List<Medicine> getMedicine()
        {
            return this.boughtMedicines;
        }
        public void setMedicine()
        {
            boughtMedicines.Clear();
        }
        public void setMedicine(string name)
        {
            for (int i = 0; i < boughtMedicines.Count; i++)
            {
                if (boughtMedicines[i].Name == name)
                {
                    boughtMedicines.RemoveAt(i);
                    break;
                }
            }
        }
        public override string ToString()
        {
            return "Admin Details : \n Name: " + this.Name + " Password: " + this.Password + " ID: " + this.Id + " UserType: " + this.UserType + " DOB: " + this.DOB + " Contact: " + this.PhoneNo + " Email: " + this.Email;
        }
    }
}
