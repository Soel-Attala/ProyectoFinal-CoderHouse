
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinalProject.Front.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoldProductController : Controller
    {
        private SoldProductServices soldProductService;

        public SoldProductController(SoldProductServices soldProductService)
        {
            this.soldProductService = soldProductService;
        }

        [HttpGet("/GetSoldProductList")]
        public IActionResult GetSoldProductsList()
        {
            var soldProductsList = soldProductService.GetSoldProductsList();
            return Ok(soldProductsList);
        }


        [HttpPost("/NewSoldProduct")]
        public async Task<IActionResult> CreateSoldProduct([FromBody] SoldProductDTO soldProductDTO)
        {
            var result = await soldProductService.CreateSoldProduct(soldProductDTO);

            if (result)
            {
                return Ok(new { message = "SoldProduct created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to create SoldProduct" });
            }
        }
    }
}
