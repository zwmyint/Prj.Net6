using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.WebApp_RazorBlog.ViewModels
{
    public class AddUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool AdminCheckbox { get; set; }
    }
}
