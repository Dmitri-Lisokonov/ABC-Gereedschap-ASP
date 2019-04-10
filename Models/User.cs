using ABCGereedschap.DataLayer.Repository;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string branch { get; set; }
        public int userID { get; set; }
        public string functionName { get; set; }
        public string password { get; set; }

        public bool status { get; set; }

        public User()
        {

        }

        public User(string name, string email, string phone, string branch, int userID, bool status, string functionName, string password)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.branch = branch;
            this.userID = userID;
            this.status = status;
            this.functionName = functionName;
            this.password = password;
        }
        public User(string name, string email, string phone, string branch, string functionName)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.branch = branch;
            this.functionName = functionName;
        }

        public override string ToString()
        {
            return this.name + " " + this.email + " " + this.phone + " " +
                $"Name: {name} Email: {email} Phone: {phone} Branch: {branch} ID: {userID}";
        }
    }
}
