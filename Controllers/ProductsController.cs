using ProductInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductInfo.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("products")]
        public ActionResult<IEnumerable<ProductDto>> GetProduct()
        { 
            return Ok(ProductsDataStore.Current.Cities);
        }

        [HttpGet("product/{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            // find Product
            var productToReturn = ProductsDataStore.Current.Cities.FirstOrDefault(x=>x.Id==id);

            if (productToReturn == null)
            {
                return NotFound();
            }

            return Ok(productToReturn);
        }

        [HttpPost]
        [Route("product/add")]
        public IActionResult AddProduct(ProductDto product)
        {
            var productIdExist=ProductsDataStore.Current.Cities.Any(x=>x.Id==product.Id);
            if(productIdExist)
                return BadRequest();
            else
            {
                ProductsDataStore.Current.Cities.Add(product);
                return Ok();
            }
        }

        [HttpDelete]
        [Route("product/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productExist=ProductsDataStore.Current.Cities.FirstOrDefault(x=>x.Id==id);
            if(productExist!=null)
            {
                ProductsDataStore.Current.Cities.Remove(productExist);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
