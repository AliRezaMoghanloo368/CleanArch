using CleanArch.Domain.Models;

namespace CleanArch.Application.ViewModels
{
    public class UserViewModel
    {
        public IQueryable<User> Users { get; set; }
    }
}
