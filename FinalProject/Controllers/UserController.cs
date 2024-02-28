using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Entities.Database;
using Business.Services;
using Business.DTOs;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] User actualUser)
        {
            if (id > 0)
            {
                var result = await this.userServices.EditUserById(id, actualUser);

                if (result)
                {
                    return Ok(new { message = "User data updated successfully" });
                }
                else
                {
                    return NotFound(new { message = "User with the specified id not found" });
                }
            }

            return BadRequest(new { message = "Invalid user id" });
        }
    }
}
