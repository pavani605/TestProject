using DataLayer.DataContext;
using DataLayer.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductDal : DataUtility
    {
        private readonly ProductContext _productContext;
        public ProductDal(ProductContext productContext) : base(productContext)
        {
            _productContext = productContext;
        }
        public List<Product> GetProduct(string commandType, string tableName)
        {
            var result = new List<Product>();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName ", Value = tableName }
                };

                result = GetData<Product>(commandText, parameters);
            }
            catch (Exception exception)
            {

            }
            return result;
        }
        public ResponseClass AddOrEditProduct(Product product, string commandType)
        {
            var result = new ResponseClass();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName", Value = "Product" },
                    new() { ParameterName = "@ProductID", Value = product.ProductID },
                    new() { ParameterName = "@CategoryID", Value = product.CategoryID },
                    new() { ParameterName = "@ProductName", Value = product.ProductName },
                    new() { ParameterName = "@ProductDescription", Value = product.ProductDescription },
                    new() { ParameterName = "@MRP", Value = product.MRP }
                };

                result = GetData<ResponseClass>(commandText, parameters).SingleOrDefault();
            }
            catch (Exception exception)
            {

            }
            return result;
        }

        public ResponseClass DeleteProduct(Product product, string commandType)
        {
            var result = new ResponseClass();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName", Value = "Product" },
                    new() { ParameterName = "@ProductID", Value = product.ProductID },
                    new() { ParameterName = "@CategoryID", Value = product.CategoryID },
                    new() { ParameterName = "@ProductName", Value = product.ProductName },
                    new() { ParameterName = "@ProductDescription", Value = product.ProductDescription },
                    new() { ParameterName = "@MRP", Value = product.MRP }
                };

                result = GetData<ResponseClass>(commandText, parameters).SingleOrDefault();
            }
            catch (Exception exception)
            {

            }
            return result;
        }
    }
}
