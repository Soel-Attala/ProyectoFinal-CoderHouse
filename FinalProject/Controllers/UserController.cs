using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Entities.Database;
using FinalProject.Front.Services;

namespace FinalProject.Front.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private UserServices userServices;

        public UserController(UserServices userServices)
        {
            this.userServices = userServices;
        }
        [HttpGet]
        public List<User> GetUsersList()
        {
            return this.userServices.GetUsersList();
        }
    }
}
