using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Data.Database;

namespace Final_Project.Data.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly DBContext _dbContext;

        public ProductRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            Product model = _dbContext.Products.First(p => p.Id == id);
            _dbContext.Products.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IQueryable<Product>> GetAll()
        {
            IQueryable<Product> queryProducts = _dbContext.Products;
            return queryProducts;
        }

        public async Task<bool> Insert(Product model)
        {
            _dbContext.Products.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
