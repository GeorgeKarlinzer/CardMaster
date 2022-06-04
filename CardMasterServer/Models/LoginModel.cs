using System.ComponentModel.DataAnnotations;

namespace CardMaster.Server.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Empty username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Empty password")]
        public string Password { get; set; }
    }
}
