using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.BL
{
    public class User
    {
        private string name = "";
        private string password = "";
        private string id = "";
        private string userType = "";
        private DateTime dOB;
        private string email = "";
        private Int64 phoneNo;

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Id { get => id; set => id = value; }
        public string UserType { get => userType; set => userType = value; }
        public DateTime DOB { get => dOB; set => dOB = value; }
        public string Email { get => email; set => email = value; }
        public Int64 PhoneNo { get => phoneNo; set => phoneNo = value; }

        public User(string userType,string name, DateTime dOB, Int64 phoneNo, string email, string password, string id)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.userType = userType;
            DOB = dOB;
            this.email = email;
            this.phoneNo = phoneNo;
        }
        public virtual string ToString()
        {
            return "Admin Details : \n Name: " + name + " Password: " + password + " ID: " + id + " UserType: " + userType + " DOB: "+ DOB + " Contact: " + phoneNo + " Email: " + email;
        }
    }
}
