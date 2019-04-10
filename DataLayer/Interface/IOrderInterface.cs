using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.Interface
{
    interface IOrderInterface
    {
        List<Order> GetBranchOrders(Branch branch);
        List<Order> GetGlobalOrders();
        Order GetOrder(int OrderID);
        bool RemoveOrder(int OrderID);
        bool UpdateOrder(int OrderID);
        bool AddOrder(Order Order);
    }
}
