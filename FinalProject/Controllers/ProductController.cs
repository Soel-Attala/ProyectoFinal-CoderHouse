using Microsoft.AspNetCore.Mvc;
using Business.DTOs;
using Business.Services;
namespace FinalProject.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductServices productServices;
        public ProductController(ProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpPost("/AddProduct")]
        public IActionResult AddProduct([FromBody] ProductDTO product)
        {
            if (this.productServices.AddProducts(product))
            {
                return base.Ok(new { message = "Product add successfully", product });
            }
            else
            {
                return base.Conflict(new { message = "Error el producto no fue agregado" });
            }


        }

        [HttpPut("{id}/UpadateProduct")]
        public ActionResult UpdateProductById(int id, ProductDTO productDTO)
        {
            if (id > 0)
            {
                if (this.productServices.UpdateProductById(id, productDTO))
                {
                    return base.Ok(new { message = "Product update successfully", productDTO });
                }
            }

            return base.Conflict(new { message = "product could not be updated" });
        }

        [HttpGet("/ProductList")]
        public IActionResult GetProductList()
        {
            var productList = this.productServices.GetProductList();
            return Ok(productList);
        }

        [HttpDelete("/DeleteProduct/{Id}")]
        public IActionResult DeleteProductById(int id)
        {
            if (id > 0)
            {
                if (this.productServices.DeleteProductById(id))
                {
                    return base.Ok(new { message = "Product deleted successfully", id });
                }
            }
            else
            {
                return base.Conflict(new { message = "product could not be deleted" });
            }
            return base.BadRequest(new { status = 400, message = "The id cant be negative" });
        }

    }
}
