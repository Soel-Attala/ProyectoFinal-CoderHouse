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


    }
}