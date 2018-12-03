using System.Threading.Tasks;

namespace iExpenseApi.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
    }
}
