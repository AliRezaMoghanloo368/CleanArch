
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    public class UserController : IControllerBase
    {
        public UserController(IUserService userService) 
            :base(userService) { }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] LoginViewModel userInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //User user = new User();
            //await _userService.AddUser(userInput);
            return Ok(new { message = "User added" });
        }

    }
}
