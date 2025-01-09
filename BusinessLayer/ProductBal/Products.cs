using BusinessLayer.Categories;
using BusinessLayer.Products;
using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductsBal
{
    public class Products : IProduct
    {
        private readonly ProductDal _productDal;
        public Products(ProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetProduct(string commandType, string tableName)
        {

            List<Product> products = new List<Product>();
            try
            {
                products = _productDal.GetProduct(commandType, tableName);
            }
            catch (Exception exception)
            {
            }
            return products;
        }
        public ResponseClass AddOrEditProduct(Product product, string commandType)
        {

            ResponseClass result = new ResponseClass();
            try
            {
                result = _productDal.AddOrEditProduct(product, commandType);
            }
            catch (Exception exception)
            {
            }
            return result;
        }
        public ResponseClass DeleteProduct(Product product, string commandType)
        {

            ResponseClass result = new ResponseClass();
            try
            {
                result = _productDal.DeleteProduct(product, commandType);
            }
            catch (Exception exception)
            {
            }
            return result;
        }
    }
}
