using System.ComponentModel.DataAnnotations;

namespace CardMaster.Server.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Empty username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Empty email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Empty password")]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Wrong password")]
        public string ConfirmPassword { get; set; }
    }
}
