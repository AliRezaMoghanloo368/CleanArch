using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(User user)
        {
            _userRepository.Create(user);
            return 0;
        }

        public bool CheckWithUserName(string userName)
        {
            return _userRepository.CheckWithUserName(userName).Result;
        }

        public User GetUserForLogin(string userName, string password)
        {
            return _userRepository.GetUserForLogin(userName, password).Result;
        }

        public async Task<UserViewModel> GetUsers()
        {
            UserViewModel model = new UserViewModel();
            model.Users = await _userRepository.GetAll();
            return model;
        }
    }
}
