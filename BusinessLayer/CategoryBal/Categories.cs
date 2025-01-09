using BusinessLayer.Categories;
using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CategoryBal
{
    public class Categories:ICategory
    {
        private readonly CategoryDal _categoryDal;

        public Categories(CategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetCategory(string commandType, string tableName)
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = _categoryDal.GetCategory(commandType, tableName);
            }
            catch (Exception exception)
            {
            }
            return categories;
        }
        public ResponseClass AddOrEditCategory(Category category, string commandType)
        {

            ResponseClass result = new ResponseClass();
            try
            {
                result = _categoryDal.AddOrEditCategory(category, commandType);
            }
            catch (Exception exception)
            {
            }
            return result;
        }
        public ResponseClass DeleteCategory(Category category, string commandType)
        {

            ResponseClass result = new ResponseClass();
            try
            {
                result = _categoryDal.AddOrEditCategory(category, commandType);
            }
            catch (Exception exception)
            {
            }
            return result;
        }
    }
}
