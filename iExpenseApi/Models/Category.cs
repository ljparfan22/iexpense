using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iExpenseApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
