using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.Models;

namespace ABCGereedschap.DataLayer.Repository
{
    class ProductRepository
    {
        IProductContext icontext = null;

        public ProductRepository(IProductContext icontext)
        {
            this.icontext = icontext;
        }

        public List<Product> GetBranchProducts(Branch branch)
        {
            return icontext.GetBranchProducts(branch);
        }
        public List<Product> GetGlobalProducts()
        {
            return icontext.GetGlobalProducts();
        }
        public Product GetProduct(int ID)
        {
            return icontext.GetProduct(ID);
        }
        public bool RemoveProduct(int ID)
        {
            return icontext.RemoveProduct(ID);
        }
        public bool UpdateProduct(int productID)
        {
            return icontext.UpdateProduct(productID);
        }

        public bool AddProduct(Product product)
        {
            return icontext.AddProduct(product);
        }
    }
}
