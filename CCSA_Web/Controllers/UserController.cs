using CCSA_Web.DTOs;
using CCSANoteApp.Domain;
using CCSANoteApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService DatabaseService { get; }
        public UserController(IUserService databaseService)
        {
            DatabaseService = databaseService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            DatabaseService.CreateUser(userDto.Username, userDto.Email, userDto.Password);
            return Ok("User Created Successfully");
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            DatabaseService.DeleteUser(id);
            return Ok("User Deleted Successfully");
        }
        [HttpGet("user/{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok(DatabaseService.GetUser(id));
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(DatabaseService.GetUsers());
        }
        [HttpPut("updateemail")]
        public IActionResult UpdateEmail(Guid id, string email)
        {
            DatabaseService.UpdateEmail(id, email);
            return Ok("Updated Successfully");
        }
        [HttpPut("updatename")]
        public IActionResult UpdateName(Guid id, string name)
        {
            DatabaseService.UpdateName(id, name);
            return Ok("Updated Successfully");
        }
    }
}
