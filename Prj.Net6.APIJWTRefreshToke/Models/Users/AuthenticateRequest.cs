using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.APIJWTRefreshToke.Models.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
