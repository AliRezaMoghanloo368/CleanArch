using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
    }
}
