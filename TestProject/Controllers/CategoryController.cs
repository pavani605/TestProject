using BusinessLayer.Categories;
using BusinessLayer.CategoryBal;
using DataLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categories;
        public CategoryController(ICategory categories)
        {
            _categories = categories;
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(string commandType, string tableName)
        {
            try
            {
                var result = _categories.GetCategory(commandType, tableName);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("AddOrEditCategory")]
        public IActionResult AddOrEditCategory(Category category, string commandType)
        {
            try
            {
                var result = _categories.AddOrEditCategory(category, commandType);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(Category category, string commandType)
        {
            try
            {
                var result = _categories.DeleteCategory(category, commandType);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }

    }
}
