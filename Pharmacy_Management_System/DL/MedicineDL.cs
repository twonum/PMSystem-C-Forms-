using Pharmacy_Management_System.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.DL
{
    public class MedicineDL
    {
        private static List<Medicine> medicines = new List<Medicine>();
        public static void setList(Medicine medicine)
        {
            medicines.Add(medicine);
        }
        public static List<Medicine> getList()
        {
            return medicines;
        }
        public static bool updateMedicineInList(string name, float price)
        {
            foreach (Medicine item in MedicineDL.getList())
            {
                if (name == item.Name)
                {
                    item.Price = price;
                    return true;
                }
            }
            return false;
        }
        public static bool updateMedicineInList(string name, DateTime expiry)
        {
            foreach (Medicine item in MedicineDL.getList())
            {
                if (name == item.Name)
                {
                    item.Expiry_date = expiry;
                    return true;
                }
            }
            return false;
        }
        public static bool removeMedicineInList(string ID)
        {
            for (int i = 0; i < MedicineDL.getList().Count; i++)
            {
                if (MedicineDL.getList()[i].MedicineID == ID)
                {
                    MedicineDL.getList().RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public static List<Medicine> sortMedicinesByPrice()
        {
            List<Medicine> sortedList = MedicineDL.getList().OrderBy(o => o.Price).ToList();
            return sortedList;
        }
        public static Medicine searcher(string id)
        {
            foreach (Medicine item in MedicineDL.getList())
            {
                if (id == item.MedicineID)
                {
                    return item;
                }
            }
            return null;
        }
        public static List<Medicine> listSearcher(string name)
        {
            List<Medicine> medicines = new List<Medicine>();
            lock (MedicineDL.getList())
            {
                foreach (Medicine item in MedicineDL.getList())
                {
                    if (item.Name == name)
                    {
                        medicines.Add(item);
                    }
                }
            }
            return medicines;
        }

        public static Medicine searchByName(string name)
        {
            foreach (Medicine item in MedicineDL.getList())
            {
                if (name == item.Name)
                {
                    return item;
                }
            }
            return null;
        }
        public static bool readFromFile(string filePath)
        {
            StreamReader f = new StreamReader(filePath);
            string record;
            if (File.Exists(filePath))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string medicineID = splittedRecord[0];
                    string medicineName = splittedRecord[1];
                    string medicineNumber = splittedRecord[2];
                    DateTime manufacturingDate = DateTime.Parse(splittedRecord[3]);
                    DateTime medicineExpiry = DateTime.Parse(splittedRecord[4]);
                    int quantity = int.Parse(splittedRecord[5]);
                    float medicinePrice = float.Parse(splittedRecord[6]);
                    Medicine medicine = new Medicine(medicineID, medicineName, medicineNumber,manufacturingDate, medicineExpiry, quantity,medicinePrice);
                    setList(medicine);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeintoFile(string filePath)
        {
            StreamWriter f = new StreamWriter(filePath);
            foreach (Medicine medicine in MedicineDL.getList())
            {

            f.WriteLine(medicine.MedicineID + "," + medicine.Name + "," + medicine.MedicineNumber + "," + medicine.Manufacturing_date + "," + medicine.Expiry_date + "," + medicine.Quantity + "," + medicine.Price );
            }
            f.Flush();
            f.Close();
        }
    }
}
