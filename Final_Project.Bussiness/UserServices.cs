using Final_Project.Data;
using Final_Project.Entity;

namespace Final_Project.Bussiness
{
    public static class UserServices
    {
        public static List<User> GetAllUsers()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            return databaseManager.GetUserById();
        }

        public interface IUserService
        {
            Task<bool> AddUser(User user);
            Task<bool> UpdateUser(User user);
            Task<bool> DeleteUser(int id);
            Task<User> GetUserById(int id);
            Task<IEnumerable<User>> GetAllUsers();
            Task<User> GetUserByName(string userName);
        }


    }
}