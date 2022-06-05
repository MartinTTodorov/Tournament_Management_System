using System.ComponentModel.DataAnnotations;

namespace SynthesisWebApp.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Please fill in a username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please fill in a password")]
        public string Password { get; set; }
    }
}
