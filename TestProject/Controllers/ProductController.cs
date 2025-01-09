using BusinessLayer.Products;
using DataLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(string commandType, string tableName)
        {
            try
            {
                var result = _product.GetProduct( commandType,  tableName);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("AddOrEditProducts")]
        public IActionResult AddOrEditProducts(Product Product, string commandType)
        {
            try
            {
                var result = _product.AddOrEditProduct(Product, commandType);
               
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(Product Product, string commandType)
        {
            try
            {
                var result = _product.DeleteProduct(Product, commandType);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
