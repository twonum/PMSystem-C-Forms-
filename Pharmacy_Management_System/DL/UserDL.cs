using Pharmacy_Management_System.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pharmacy_Management_System.DL
{
    public class UserDL
    {
        private static List<User> users = new List<User>();
        public static List<User> getUsers()
        {
            return users;
        }
        public static void setUser(User user)
        {
            users.Add(user);
        }
        
        public static List<User> searchUser(string name)
        {
            List<User> users = new List<User> ();
            foreach (User item in UserDL.getUsers())
            {
                if (item.Name == name)
                {
                    users.Add(item);
                }
            }
            if (users.Count!=0)
            {
                return users;
            }
            return null;
        }
        public static User login(string username, string password)
        {
            foreach (User item in UserDL.getUsers())
            {
                if (item.Name == username && item.Password == password)
                {
                    return item;
                }
            }
            return null;
        }
        public static User check(string ID)
        {
            foreach (User item in UserDL.getUsers())
            {
                if (item.Id == ID)
                {
                    return item;
                }
            }
            return null;
        }
        public static User checkByName(string name)
        {
            foreach (User item in UserDL.getUsers())
            {
                if (item.Name == name)
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
                    string username = splittedRecord[0];
                    string password = splittedRecord[1];
                    string id = splittedRecord[2];
                    string userType = splittedRecord[3];
                    DateTime dob = DateTime.Parse(splittedRecord[4]);
                    string email = splittedRecord[5];
                    Int64 phone = Int64.Parse(splittedRecord[6]);
                    User user = new User(userType, username, dob, phone, email, password, id);
                    setUser(user);
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
            foreach (User user in UserDL.getUsers())
            {

            f.WriteLine(user.Name + "," + user.Password + "," + user.Id + "," + user.UserType + "," + user.DOB + "," + user.Email + "," + user.PhoneNo);
            }
            f.Flush();
            f.Close();
            
        }
        public static bool removeUserInList(string usernameOrID)
        {
            foreach (User item in UserDL.getUsers())
            {
                if (item.Id == usernameOrID)
                {
                    UserDL.getUsers().Remove(item);
                    UserDL.storeintoFile(Program.userPath);
                    return true;
                }
            }
            return false;
        }
    }
}
