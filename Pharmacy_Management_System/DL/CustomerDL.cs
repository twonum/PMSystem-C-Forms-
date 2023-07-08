using Pharmacy_Management_System.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.DL
{
    public class CustomerDL
    {
        private static List<Customer> customers = new List<Customer>();
        public static List<Customer> getList()
        {
            return customers;
        }
        public static void setList(Customer customer)
        {
            customers.Add(customer);
        }
        public static float calculateTotal()
        {
            float total = 0;
            foreach (Customer item in customers)
            {
                for (int i = 0; i < item.getMedicine().Count; i++)
                {
                    //total = total + item.getTotal();
                    total = total + item.getMedicine()[i].Price;
                    item.addTotal(total);
                }
            }
            return total;
        }
        //public static void setBillAmount(Customer customer, float bill)
        //{
        //    customer.addTotal(bill);
        //}
        //public static float getBillAmount(Customer customer)
        //{
        //    return customer.getTotal();
        //}

        public static User getUser(string id)
        {
            foreach (User item in UserDL.getUsers())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public static Customer addCustomer(string name, string password, string id, string userType, DateTime dob,string email,int phone)
        {
            Customer c = new Customer(name, password, id, userType,dob,email,phone);
            return c;
        }
        public static Customer getCustomer(string id)
        {
            foreach (Customer item in customers)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string password = splittedRecord[1];
                    string id = splittedRecord[2];
                    string userType = splittedRecord[3];
                    DateTime dob = DateTime.Parse(splittedRecord[4]);
                    string email = splittedRecord[5];
                    Int64 phone = Int64.Parse(splittedRecord[6]);
                    string[] splittedRecordForMedicine = splittedRecord[7].Split(';');
                    Customer customer = new Customer(name, password, id, userType,dob,email,phone);
                    for (int i = 0; i < splittedRecordForMedicine.Length; i++)
                    {
                        Medicine m = MedicineDL.searcher(splittedRecordForMedicine[i]);
                        if (m != null)
                        {
                            customer.setMedicine(m);
                        }
                    }
                    setList(customer);
                }
                f.Close();
                return true;
            }
            else { return false; }
        }
        //public static void storeIntoFile(string path,Customer customer)
        //{
        //    StreamWriter f = new StreamWriter(path,true);
        //    string medicineName = "";
        //    for (int i = 0; i < customer.boughtMedicines.Count-1; i++)
        //    {
        //        medicineName = medicineName + customer.boughtMedicines[i].getName() + ";";
        //    }
        //    medicineName = medicineName + customer.boughtMedicines[customer.boughtMedicines.Count - 1].getName();
        //    f.WriteLine(customer.getName() + "," + customer.getPassword() + "," + customer.getId() + "," + customer.getUserType() + "," + medicineName);
        //    f.Flush();
        //    f.Close();
        //}
        public static void storeIntoFile(string path, Customer customer)
        {
            string medicineName = string.Join(";", customer.getMedicine().Select(medicine => medicine.Name));

            List<string> fileData = new List<string>();

            if (File.Exists(path))
            {
                fileData = File.ReadAllLines(path).ToList();

                for (int i = 0; i < fileData.Count; i++)
                {
                    string[] customerInfo = fileData[i].Split(',');
                    if (customerInfo[0] == customer.Name)
                    {
                        List<string> existingMedicines = customerInfo[7].Split(';').ToList();
                        existingMedicines.AddRange(customer.getMedicine().Select(medicine => medicine.Name));
                        customerInfo[4] = string.Join(";", existingMedicines.Distinct());
                        fileData[i] = string.Join(",", customerInfo);
                        break;
                    }
                }
            }

            if (!fileData.Any(line => line.StartsWith(customer.Name + ",")))
            {
                string customerInfo = $"{customer.Name},{customer.Password},{customer.Id},{customer.UserType},{customer.DOB},{customer.Email},{customer.PhoneNo},{medicineName}";
                fileData.Add(customerInfo);
            }

            File.WriteAllLines(path, fileData);
        }
    }
}
