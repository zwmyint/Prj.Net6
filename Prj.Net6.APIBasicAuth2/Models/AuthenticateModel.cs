using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.APIBasicAuth2.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
