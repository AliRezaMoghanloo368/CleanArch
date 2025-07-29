using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    public class ActivitiesController : IBaseController
    {
        public ActivitiesController(IUserService userService) : base(userService)
        {
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get() => Content("secure");
    }
}
