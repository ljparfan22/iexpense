using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iExpenseApi.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth{ get; set; }
        [Required]
        public Gender Gender { get; set; }
        [NotMapped]
        public List<string> Errors { get; set; } = new List<string>();
    }
}
