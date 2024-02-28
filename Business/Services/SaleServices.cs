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

        public async Task<bool> CreateSale(Sale sale)
        {


            var userExists = await coderContext.Users.AnyAsync(u => u.Id == sale.UserId);

            if (!userExists)
            {
                return false;
            }

            coderContext.Sales.Add(sale);
            await coderContext.SaveChangesAsync();

            return true;




            return false;

        }
    }
}
