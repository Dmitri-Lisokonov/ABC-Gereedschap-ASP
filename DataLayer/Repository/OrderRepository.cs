using ABCGereedschap.DataLayer.Interface;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.Repository
{
    class OrderRepository
    {
        private IOrderInterface icontext = null;

        public OrderRepository(IOrderInterface icontext)
        {
            this.icontext = icontext;
        }
        public List<Order> GetBranchOrders(Branch branch)
        {
            return icontext.GetBranchOrders(branch);
        }
        public List<Order> GetGlobalOrders()
        {
            return icontext.GetGlobalOrders();
        }
        public Order GetOrder(int ID)
        {
            return icontext.GetOrder(ID);
        }
        public bool RemoveUser(int ID)
        {
            return icontext.RemoveOrder(ID);
        }
        public bool UpdateUser(Order order)
        {
            return icontext.UpdateOrder(Convert.ToInt32(order));
        }
    }
}
