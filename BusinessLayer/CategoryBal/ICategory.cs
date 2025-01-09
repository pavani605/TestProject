using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Categories
{
    public interface ICategory
    {
        List<Category>? GetCategory(string commandType, string tableName);
        ResponseClass? AddOrEditCategory(Category category, string commandType);
        ResponseClass? DeleteCategory(Category category, string commandType);
    }
}
