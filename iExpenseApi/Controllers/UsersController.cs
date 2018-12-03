using iExpenseApi.Dtos;
using iExpenseApi.Models;
using iExpenseApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iExpenseApi
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto user)
        {
            var usernameExists = await _userService.UserExists(user.UserName ?? "");
            if (usernameExists) ModelState.AddModelError("UserName", "User already exists.");

            var emailExists = await _userService.UserExists(user.Email ?? "");
            if (usernameExists) ModelState.AddModelError("Email", "Email already exists.");

            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(new { errors });
            }

            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth
            };
            var result = await _userService.Register(userToCreate, user.Password);
            if (result.Errors.Count > 0) return BadRequest(new { errors = result.Errors });

            var response = new
            {
                result.Id,
                result.UserName,
                result.Email,
                FullName = $"{result.FirstName} {result.LastName}"
            };
            return Ok(response);

        }
    }
}