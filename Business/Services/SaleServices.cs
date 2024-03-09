using Business.DTOs;
using Entities.Database;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SaleService
    {
        private CoderContext coderContext;

        public SaleService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }


        public List<Sale> GetSalesList()
        {
            return coderContext.Sales.ToList();
        }

        public async Task<bool> CreateSale(SaleDTO saleDTO)
        {
            try
            {
                var userExists = await coderContext.Users.AnyAsync(u => u.Id == saleDTO.UserId);

                if (!userExists)
                {
                    return false;
                }

                var sale = new Sale
                {
                    Comments = saleDTO.Comments,
                    UserId = saleDTO.UserId
                };

                coderContext.Sales.Add(sale);
                await coderContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }


        public async Task<bool> DeleteSaleById(int id)
        {
            try
            {
                var sale = await coderContext.Sales.FindAsync(id);

                if (sale != null)
                {
                    coderContext.Sales.Remove(sale);
                    await coderContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException)
            {

                return false;

            }
        }
    }
}

