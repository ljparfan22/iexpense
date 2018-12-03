using System;
using System.Threading.Tasks;
using iExpenseApi.Models;
using Microsoft.AspNetCore.Identity;

namespace iExpenseApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> Register(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded) return user;

            var failedUser = new User();
            foreach (var error in result.Errors)
            {
                failedUser.Errors.Add(error.Description);
            }

            return failedUser;
        }

        public async Task<bool> UserExists(string identifier)
        {
            var user = await _userManager.FindByEmailAsync(identifier);

            user = user ?? await _userManager.FindByNameAsync(identifier);

            return user != null;
        }
    }
}
