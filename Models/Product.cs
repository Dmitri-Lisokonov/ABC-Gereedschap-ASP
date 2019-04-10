using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Models
{
    class Product
    {
        public string type { get; set; }
        public string description { get; set; }
        public string branch { get; set;  }
        public string name { get; set; }
        public int serialNumber { get; set; }

        public Product()
        {

        }

        public Product(string type, string description, string branch, string name, int serialNumber)
        {
            this.type = type;
            this.description = description;
            this.branch = branch;
            this.name = name;
            this.serialNumber = serialNumber;
        }
    }
}
