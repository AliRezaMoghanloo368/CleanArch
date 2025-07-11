using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CleanArchDbContext _context;
        public UserRepository(CleanArchDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserExist(string id)
        {
            return await _context.Users.AnyAsync(x => x.Id.ToString() == id);
        }

        public async Task<bool> CheckWithUserName(string userName)
        {
            return await _context.Users.AnyAsync(u => u.Name == userName);
        }

        public async Task<User> GetWithUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == userName);
        }
    }
}
