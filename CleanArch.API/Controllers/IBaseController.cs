using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IBaseController : ControllerBase
    {
        protected readonly IUserService _userService;
        public IBaseController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
