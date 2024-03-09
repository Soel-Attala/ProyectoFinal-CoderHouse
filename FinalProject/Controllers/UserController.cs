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



        [HttpGet("{id}/GetName")]
        public async Task<IActionResult> GetUserName(int id)
        {
            var userName = await userServices.GetName(id);

            if (userName != null)
            {
                return Ok(new { UserName = userName });
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }

        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var result = await userServices.CreateUser(userDTO);

            if (result != null)
            {
                return CreatedAtAction(nameof(UserServices.GetUserById), new { id = result.Id }, new { message = "User created successfully", userId = result.Id });
            }
            else
            {
                return BadRequest(new { message = "Failed to create user" });
            }
        }


        [HttpGet("/UserList")]
        public IActionResult GetUsersList()
        {
            var usersList = this.userServices.GetUsersList();
            return Ok(usersList);
        }

        [HttpGet("{id}/GetUser")]
        public IActionResult GetUserById(int id)
        {
            var user = userServices.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }



        [HttpPut("{id}/EditUser")]
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



        [HttpDelete("{id}/DeleteUser")]
        public IActionResult DeleteProductById(int id)
        {
            if (id > 0)
            {
                if (this.userServices.DeleteUserById(id))
                {
                    return base.Ok(new { message = "User deleted successfully", id });
                }
            }
            else
            {
                return base.Conflict(new { message = "User could not be deleted" });
            }
            return base.BadRequest(new { status = 400, message = "The id cant be negative" });
        }

    }
}


