using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.DataLayer.Interface
{
    interface IProductInterface
    {
        List<Product> GetBranchProducts(Branch branch);
        List<Product> GetGlobalProducts();
        bool RemoveProduct(int productID);
        bool UpdateProduct(int productID);
        bool AddProduct(Product product);
    }
}
