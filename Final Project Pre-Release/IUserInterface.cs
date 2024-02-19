using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Pre_Release
{
    public interface IUserInterface
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        bool AddUser(User user);
        bool DeleteUserById(int id);
        bool UpdateUserById(int id, User user);
        bool UpdateUserLastNameById(int id, string lastName);
    }
}
