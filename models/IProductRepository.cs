using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork.models
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();
        Products GetProductByID(int productID);
        bool InsertProduct(Products product);
        bool DeleteProduct(int productID);
        bool UpdateProduct(Products product);
        Products searchProduct(int product);
    }
}
