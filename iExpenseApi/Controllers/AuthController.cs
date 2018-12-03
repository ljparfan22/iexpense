using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iExpenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }
    }
}