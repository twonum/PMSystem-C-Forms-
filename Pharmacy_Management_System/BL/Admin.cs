using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pharmacy_Management_System.BL
{
    public class Admin : User
    {
        public Admin(string name, string password, string id, string userType, DateTime dob, string email, Int64 phoneNo) : base(userType,name,dob,phoneNo,email,password,id)
        {

        }


        public override string ToString()
        {
            return "Admin Details : \n Name: " + this.Name + " Password: " + this.Password + " ID: " + this.Id + " UserType: " + this.UserType + " DOB: " + this.DOB + " Contact: " + this.PhoneNo + " Email: " + this.Email;
        }
    }
}