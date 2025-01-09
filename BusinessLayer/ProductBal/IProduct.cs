using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Products
{
    public interface IProduct
    {
        List<Product> GetProduct(string commandType, string tableName);
        ResponseClass? AddOrEditProduct(Product product, string commandType);
        ResponseClass? DeleteProduct(Product product, string commandType);
    }
}
