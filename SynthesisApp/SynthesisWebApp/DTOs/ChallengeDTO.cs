using System.ComponentModel.DataAnnotations;
using Entities;

namespace SynthesisWebApp.DTOs
{
    public class ChallengeDTO
    {
        [Required(ErrorMessage = "Please fill in a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please pick a date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please pick a sport")]
        public string Sport { get; set; }

    }
}