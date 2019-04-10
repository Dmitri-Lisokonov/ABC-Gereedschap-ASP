using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Models
{
    class Order
    {
        public int serialNumber { get; set; }
        public int quantity { get; set; }
        public int clientID { get; set; }
        public DateTime date { get; set; }

        public Order()
        {

        }

        public Order(int serialNumber, int quantity, int clientID, DateTime date)
        {
            this.serialNumber = serialNumber;
            this.quantity = quantity;
            this.clientID = clientID;
            this.date = date;
        }
    }
}
