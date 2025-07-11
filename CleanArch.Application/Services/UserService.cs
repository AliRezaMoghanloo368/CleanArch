using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        #region Get
        public async Task<UserViewModel> GetUsers()
        {
            UserViewModel model = new UserViewModel();
            model.Users = await _userRepository.GetAll();
            return model;
        }
        #endregion

        #region Insert
        public async Task AddUser(UserInputModel userInput)
        {
            var user = new User(userInput.PhoneNumber, userInput.Name);
            user.SetPassword(userInput.Password, _encrypter);
            await _userRepository.Create(user);

        }
        #endregion


        #region Update
        public async Task UpdateUser(User user)
        {
            //var existing = await _userRepository.GetAsync(user.Id.ToString());
            //if (existing == null)
            //    throw new Exception("User not found");

            //existing.Name = user.Name;
            //existing.PhoneNumber = user.Email;
            //// سایر فیلدها

            //await _userRepository.Update(existing);
        }
        #endregion
    }
}
