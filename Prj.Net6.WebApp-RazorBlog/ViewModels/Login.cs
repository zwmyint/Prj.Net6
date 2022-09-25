using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.WebApp_RazorBlog.ViewModels
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
