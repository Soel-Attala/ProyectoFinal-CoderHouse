using Entities.Database;
using Entities.Models;

namespace FinalProject.Front.Services
{
    public class UserServices
    {
        private CoderContext context;
        public UserServices(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public List<User> GetUsersList()
        {
            return this.context.Users.ToList();
        }
    }
}
