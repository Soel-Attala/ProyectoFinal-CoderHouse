using Business.DTOs;
using Entities.Database;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserServices
    {
        private CoderContext coderContext;
        public UserServices(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public async Task<bool> EditUserById(int id, User actualUser)
        {
            try
            {
                var existingUser = await coderContext.Users.FindAsync(id);

                if (existingUser == null)
                {
                    return false; // User with the specified id not found
                }

                // Update the properties of the existing user
                existingUser.FirstName = actualUser.FirstName;
                existingUser.LastName = actualUser.LastName;
                existingUser.Username = actualUser.Username;
                existingUser.Password = actualUser.Password;
                existingUser.Email = actualUser.Email;

                await coderContext.SaveChangesAsync();

                return true; // User updated successfully
            }
            catch (DbUpdateException)
            {
                // Handle database update exception if needed
                return false;
            }
        }

        public List<User> GetUsersList()
        {
            return this.coderContext.Users.ToList();
        }
    }
}
