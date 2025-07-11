using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
    }
}
