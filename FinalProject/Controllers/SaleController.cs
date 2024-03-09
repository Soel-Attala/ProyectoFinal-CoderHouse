using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Business.Services;
using Business.DTOs;
using System.Threading.Tasks;

namespace FinalProject.Front.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private SaleService saleService;

        public SaleController(SaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet("/GetSales")]
        public IActionResult GetSalesList()
        {
            var salesList = saleService.GetSalesList();
            return Ok(salesList);
        }

        [HttpPost("/CreateSale")]
        public async Task<IActionResult> CreateSale([FromBody] SaleDTO saleDTO)
        {
            var result = await saleService.CreateSale(saleDTO);

            if (result)
            {
                return Ok(new { message = "Sale created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to create sale" });
            }
        }

        [HttpDelete("{id}/DeleteSale")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var result = await saleService.DeleteSaleById(id);

            if (result)
            {
                return Ok(new { message = "Sale deleted successfully" });
            }
            else
            {
                return NotFound(new { message = "Sale not found" });
            }
        }



    }
}
