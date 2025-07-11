using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Context;
using CleanArch.Data.Repositories;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Interfaces;
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
            //Application Layer
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IEncrypter, Encrypter>();

            //Data Layer
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddDbContext<CleanArchDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("CleanArch_Sql")));

            return service;
        }
    }
}
