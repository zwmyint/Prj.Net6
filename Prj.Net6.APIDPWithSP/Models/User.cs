using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.APIDPWithSP.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
