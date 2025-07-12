using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IControllerBase : ControllerBase
    {
        protected readonly IUserService _userService;
        public IControllerBase(IUserService userService)
        {
            _userService = userService;
        }
    }
}
