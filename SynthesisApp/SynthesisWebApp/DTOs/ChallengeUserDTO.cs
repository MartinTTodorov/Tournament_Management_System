using System.ComponentModel.DataAnnotations;

namespace SynthesisWebApp.DTOs
{
    public class ChallengeUserDTO
    {
        [Required(ErrorMessage = "Please fill in a username")]
        public string UserName { get; set; }
    }
}
