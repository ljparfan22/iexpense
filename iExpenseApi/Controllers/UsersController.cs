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
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto requestBody)
        {
            try
            {
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
                var user = new User
                {
                    UserName = requestBody.UserName,
                    Email = requestBody.Email,
                    FirstName = requestBody.FirstName,
                    LastName = requestBody.LastName,
                    MiddleName = requestBody.MiddleName,
                    PhoneNumber = requestBody.PhoneNumber,
                    DateOfBirth = requestBody.DateOfBirth
                };
                var result = await _userService.Register(user, requestBody.Password);
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
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
           
        }
    }
}