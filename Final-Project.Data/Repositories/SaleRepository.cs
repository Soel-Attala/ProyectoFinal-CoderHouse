using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Repositories
{
    public class SaleRepository : IGenericRepository<Sale>
    {
        private readonly DBContext _dbContext;

        public SaleRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            Sale model = _dbContext.Sales.First(s => s.Id == id);
            _dbContext.Sales.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Sale> Get(int id)
        {
            return await _dbContext.Sales.FindAsync(id);
        }

        public async Task<IQueryable<Sale>> GetAll()
        {
            IQueryable<Sale> querySales = _dbContext.Sales;
            return querySales;
        }

        public async Task<bool> Insert(Sale model)
        {
            _dbContext.Sales.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Sale model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
