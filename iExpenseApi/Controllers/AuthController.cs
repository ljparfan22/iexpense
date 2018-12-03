using iExpenseApi.Dtos;
using iExpenseApi.Models;
using iExpenseApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iExpenseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
           _authService = authService;
           _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto requestBody)
        {
            try
            {
                var succeeded = await _authService.Login(requestBody.UserName, requestBody.Password);
                if (!succeeded) return BadRequest(new { errors = new List<string> { "Invalid username or password." } });

                var currentUser = await _userService.GetUser(requestBody.UserName);
                var token = _userService.GenerateAuthToken(currentUser, "APPLICATIONSECREEEEEEEEEEEEEEEEEEET");
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
           
        }
    }
}