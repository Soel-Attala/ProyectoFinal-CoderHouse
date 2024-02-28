using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Business.Services;
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

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            var result = await saleService.CreateSale(sale);

            if (result)
            {
                return Ok(new { message = "Sale created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to create sale" });
            }
        }
    }
}
