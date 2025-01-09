using DataLayer.DataContext;
using DataLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryDal:DataUtility
    {
        private readonly ProductContext _productContext;
        public CategoryDal(ProductContext productContext) : base(productContext)
        {
            _productContext = productContext;
        }
        public List<Category> GetCategory(string commandType, string tableName)
        {
            var result = new List<Category>();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName ", Value = tableName }
                };

                result = GetData<Category>(commandText, parameters);
            }
            catch (Exception exception)
            {
                
            }
            return result;
        }
        public ResponseClass AddOrEditCategory(Category category, string commandType)
        {
            var result = new ResponseClass();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName", Value = "Category" },
                    new() { ParameterName = "@CategoryID", Value = category.CategoryID },
                    new() { ParameterName = "@CategoryName", Value = category.CategoryName },
                    new() { ParameterName = "@Description", Value = category.Description },
                };

                result = GetData<ResponseClass>(commandText, parameters).SingleOrDefault();
            }
            catch (Exception exception)
            {

            }
            return result;
        }

        public ResponseClass DeleteCategory(Category category, string commandType)
        {
            var result = new ResponseClass();
            try
            {
                var commandText = "exec Sp_Product_Category";

                var parameters = new SqlParameter[]
                {
                    new() { ParameterName = "@CommandType", Value = commandType },
                    new() { ParameterName = "@TableName", Value = "Category" },
                    new() { ParameterName = "@CategoryID", Value = category.CategoryID },
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
