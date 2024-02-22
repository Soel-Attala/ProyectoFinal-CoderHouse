using Final_Project.Entity;
using Final_Project.Data.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Data.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly coderhouseContext _dbContext;

        public UserRepository(coderhouseContext context)
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
        public async Task<User> GetByName(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.FirstName == userName);
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
