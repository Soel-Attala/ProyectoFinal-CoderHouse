using Final_Project.Data;
using Final_Project.Data.Repositories;
using Final_Project.Entity;

namespace Final_Project.Bussiness
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<User> GetUserByName(string userName)
        {
            return await _userRepository.GetByName(userName);
        }

        public async Task<bool> AddUser(User user)
        {
            return await _userRepository.Insert(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.Delete(id);
        }
    }

}
