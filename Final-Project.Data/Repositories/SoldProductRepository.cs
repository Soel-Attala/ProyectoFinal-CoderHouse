using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Repositories
{
    public class SoldProductRepository : IGenericRepository<SoldProduct>
    {
        private readonly DBContext _dbContext;

        public SoldProductRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            SoldProduct model = _dbContext.SoldProducts.First(sp => sp.Id == id);
            _dbContext.SoldProducts.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<SoldProduct> Get(int id)
        {
            return await _dbContext.SoldProducts.FindAsync(id);
        }

        public async Task<IQueryable<SoldProduct>> GetAll()
        {
            IQueryable<SoldProduct> querySoldProducts = _dbContext.SoldProducts;
            return querySoldProducts;
        }

        public async Task<bool> Insert(SoldProduct model)
        {
            _dbContext.SoldProducts.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(SoldProduct model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
