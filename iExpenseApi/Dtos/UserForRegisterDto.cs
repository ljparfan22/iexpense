using System;
using System.ComponentModel.DataAnnotations;

namespace iExpenseApi.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string UserName { get; set; }
        [MinLength(7)]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string MiddleName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        public string Email { get; set; }
        [Required]
        [Phone]
        [StringLength(100, MinimumLength = 5)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth{ get; set; }
    }
}
