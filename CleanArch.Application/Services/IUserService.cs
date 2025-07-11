using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
    }
}
