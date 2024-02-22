using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            User model = _dbContext.Users.First(u => u.Id == id);
            _dbContext.Users.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<IQueryable<User>> GetAll()
        {
            IQueryable<User> queryUsers = _dbContext.Users;
            return queryUsers;
        }

        public async Task<bool> Insert(User model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(User model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
