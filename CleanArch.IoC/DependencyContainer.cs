using CleanArch.Application.Authenticate;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Context;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            service.AddJwt(configuration);
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IEncrypter, Encrypter>();
            #endregion

            #region Data Layer
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddDbContext<CleanArchDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("CleanArch_Sql")));
            #endregion

            #region Mvc Layer
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
                option.ExpireTimeSpan = TimeSpan.FromDays(365);
            });
            #endregion

            return service;
        }
    }
}
