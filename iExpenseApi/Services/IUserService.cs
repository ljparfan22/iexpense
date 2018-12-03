using iExpenseApi.Models;
using System.Threading.Tasks;

namespace iExpenseApi.Services
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string userNameOrEmail);

    }
}
