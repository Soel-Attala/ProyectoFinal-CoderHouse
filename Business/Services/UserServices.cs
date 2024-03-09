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

        public async Task<string> GetName(int userId)
        {
            try
            {
                var user = await coderContext.Users.FindAsync(userId);
                return user?.FirstName;
            }
            catch (Exception ex)
            {
                return "User not found";
            }

        }

        public User GetUserById(int id)
        {
            return coderContext.Users.Find(id);
        }

        public async Task<User> CreateUser(UserDTO userDTO)
        {
            try
            {
                var user = new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Username = userDTO.Username,
                    Password = userDTO.Password,
                    Email = userDTO.Email

                };

                coderContext.Users.Add(user);
                await coderContext.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException)
            {

                return null;
            }
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


        public bool DeleteUserById(int id)
        {
            User? user = this.coderContext.Users.Where(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                this.coderContext.Remove(user);
                this.coderContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}



