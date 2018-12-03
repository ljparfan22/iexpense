using System.Threading.Tasks;

namespace iExpenseApi.Services
{
    interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}
