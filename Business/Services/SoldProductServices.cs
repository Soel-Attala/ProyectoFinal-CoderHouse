
using Business.DTOs;
using Entities.Database;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SoldProductServices
    {
        private CoderContext coderContext;

        public SoldProductServices(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<SoldProduct> GetSoldProductsList()
        {
            return coderContext.SoldProducts.ToList();
        }

        public async Task<bool> CreateSoldProduct(SoldProductDTO soldProductDTO)
        {
            try
            {
                var soldProduct = new SoldProduct
                {
                    Stock = soldProductDTO.Stock,
                    ProductId = soldProductDTO.ProductId,
                    SaleId = soldProductDTO.SaleId

                };

                coderContext.SoldProducts.Add(soldProduct);
                await coderContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {

                return false;
            }
        }


    }
}
