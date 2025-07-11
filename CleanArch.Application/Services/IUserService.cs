using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
    }
}
