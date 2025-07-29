using CleanArch.Application.Authenticate;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
        bool CheckWithUserName(string userName);
        User GetWithUserName(string userName);
        User GetUserForLogin(string userName, string password);
        Task<JsonWebToken> LoginAsync(string userName, string password);
        Task RegisterAsync(User user, bool checkup = true);
    }
}
