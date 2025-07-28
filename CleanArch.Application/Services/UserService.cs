using CleanArch.Application.Authenticate;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler = null)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
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

        public async Task<JsonWebToken> LoginAsync(string userName, string password)
        {
            var user = await _userRepository.GetWithUserName(userName);
            if (user == null)
            {
                throw new ActioException("invalid_credential",
                    $"Invalid user");
            }

            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new ActioException("invalid_credential",
                    $"Invalid user");
            }

            return _jwtHandler.Create(user.Id);
        }

        public async Task RegisterAsync(User user)
        {
            bool isExistUser = await _userRepository.CheckWithUserName(user.Name);
            if (isExistUser == true)
            {
                throw new ActioException("userName_in_use",
                    $"UserName : '{user.Name}' is already in use");
            }

            user.SetPassword(user.Password, _encrypter);
            await _userRepository.Create(user);
        }
    }
}
