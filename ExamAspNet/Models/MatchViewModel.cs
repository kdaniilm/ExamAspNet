using System.ComponentModel.DataAnnotations;

namespace ExamAspNet.Models
{
    public class MatchViewModel
    {
        [Required]
        public string FirstPayerName { get; set; }
        [Required]
        public string SecondPayerName { get; set; }
        [Required]
        public string StartTime { get; set; }

        [Required]
        public int FirstPlayerFirstRound { get; set; }
        [Required]
        public int FirstPlayerSecondRound { get; set; }
        [Required]
        public int FirstPlayerThirtRound { get; set; }

        public int FirstPlayerFourthRound { get; set; }
        public int FirstPlayerFivethRound { get; set; }
        [Required]
        public int SecondPlayerFirstRound { get; set; }
        [Required]
        public int SecondPlayerSecondRound { get; set; }
        [Required]
        public int SecondPlayerThirtRound { get; set; }

        public int SecondPlayerFourthRound { get; set; }
        public int SecondPlayerFivethRound { get; set; }
    }
}
