using System.ComponentModel.DataAnnotations;

namespace SynthesisWebApp.DTOs
{
    public class ChallengeResultsDTO
    {
        [Required(ErrorMessage ="Please insert the challenger's results")]
        public int ChallengerScore { get; set; }
        [Required(ErrorMessage ="Please insert your results")]
        public int OpponentScore { get; set; }
    }
}
