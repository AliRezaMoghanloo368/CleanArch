using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUsers();
        Task AddUser(UserInputModel userInput);       
        Task UpdateUser(User user);      // ویرایش کاربر
    }
}
