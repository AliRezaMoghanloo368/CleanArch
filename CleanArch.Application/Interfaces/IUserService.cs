using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
        bool CheckWithUserName(string userName);
        User GetUserForLogin(string userName, string password);
        int AddUser(User user);
    }
}
