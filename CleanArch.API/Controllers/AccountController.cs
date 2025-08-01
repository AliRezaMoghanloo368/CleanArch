﻿using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("Account")]
    public class AccountController:Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel command)
        {
            return Json(await _userService.LoginAsync(command.UserName, command.Password));
        }

        [HttpPost("register")]
        public async Task Register([FromBody] User user)
        {
            await _userService.RegisterAsync(user);
        }
    }
}
