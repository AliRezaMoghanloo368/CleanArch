using CleanArch.Domain.Models;

namespace CleanArch.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckUserExist(string id);
        Task<bool> CheckWithUserName(string userName);
        Task<User> GetWithUserName(string userName);
        Task<User> GetUserForLogin(string userName, string password);
    }
}
