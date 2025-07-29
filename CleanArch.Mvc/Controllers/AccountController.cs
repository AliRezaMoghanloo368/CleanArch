using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private readonly IEncrypter _encrypter;
        public AccountController(IUserService userService, IEncrypter encrypter)
        {
            _userService = userService;
            _encrypter = encrypter;
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_userService.CheckWithUserName(register.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "کاربر وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }
            User user = new User()
            {
                Name = register.UserName,
                PhoneNumber = register.PhoneNumber,
                Password = register.Password,
                CreateAt = DateTime.UtcNow,
            };
            await _userService.RegisterAsync(user, false);
            return View("SuccessRegister", register);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.GetWithUserName(login.UserName);
            if (user == null || !user.ValidatePassword(login.Password, _encrypter))
            {
                ModelState.AddModelError("UserName", "اطلاعات صحیح نیست");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);
            return Redirect("/");
        }
        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
