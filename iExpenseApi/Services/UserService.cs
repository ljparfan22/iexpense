using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using iExpenseApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace iExpenseApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string GenerateAuthToken(User user, string applicationSecret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(applicationSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public async Task<User> GetUser(string username) => await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == username);

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
