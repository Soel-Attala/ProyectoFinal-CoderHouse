using Business.DTOs;
using Entities.Database;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserServices
    {
        private CoderContext coderContext;

        public UserServices(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public async Task<bool> EditUserById(int id, UserDTO updatedUserData)
        {
            try
            {
                var existingUser = await coderContext.Users.FindAsync(id);

                if (existingUser == null)
                {
                    return false; 
                }

                
                existingUser.FirstName = updatedUserData.FirstName;
                existingUser.LastName = updatedUserData.LastName;
                existingUser.Username = updatedUserData.Username;
                existingUser.Password = updatedUserData.Password;
                existingUser.Email = updatedUserData.Email;

                await coderContext.SaveChangesAsync();

                return true; 
            }
            catch (DbUpdateException)
            {
                
                return false;
            }
        }

        public List<User> GetUsersList()
        {
            return this.coderContext.Users.ToList();
        }
    }
}



