using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.APIDPWithSP.Models
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
