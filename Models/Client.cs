using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Models
{
    public class Client
    {
        public string name { get; set; }
        public string adress { get; set; }
        public string description { get; set; }
        public string phonenumber { get; set; }

        public Client(string description, string name, string adress, string phonenumber)
        {
            this.name = name;
            this.adress = adress;
            this.description = description;
            this.phonenumber = phonenumber;
        }

        public Client()
        {

        }
    }
}
