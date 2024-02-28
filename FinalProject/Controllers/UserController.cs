using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Business.Services;
using Business.DTOs;
using System.Threading.Tasks;

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
        public IActionResult GetUsersList()
        {
            var usersList = this.userServices.GetUsersList();
            return Ok(usersList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserDTO updatedUserData)
        {
            if (id > 0)
            {
                var result = await this.userServices.EditUserById(id, updatedUserData);

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

