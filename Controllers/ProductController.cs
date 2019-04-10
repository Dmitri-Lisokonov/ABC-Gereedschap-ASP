using ABCGereedschap.DataLayer.MSSQLContext;
using ABCGereedschap.DataLayer.Repository;
using ABCGereedschap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCGereedschap.Logic.Controller
{
    class ProductController
    {
        ProductRepository productRepository = new ProductRepository(new IProductContext());

        public bool ProductAdd(Product product)
        {
            productRepository.AddProduct(product);
            return false;
        }

        public bool ProductEdit(int productID)
        {
            productRepository.UpdateProduct(productID);
            return false;
        }

        public bool ProductRemove(int productID)
        {
            productRepository.RemoveProduct(productID);
            return false;
        }
    }
}
