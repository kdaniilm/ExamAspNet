using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string FirstPayerName { get; set; }
        public string SecondPayerName { get; set; }
        public string StartTime { get; set; }

        public int FirstPlayerFirstRound { get; set; }
        public int FirstPlayerSecondRound { get; set; }
        public int FirstPlayerThirtRound { get; set; }
        public int FirstPlayerFourthRound { get; set; }
        public int FirstPlayerFivethRound { get; set; }

        public int SecondPlayerFirstRound { get; set; }
        public int SecondPlayerSecondRound { get; set; }
        public int SecondPlayerThirtRound { get; set; }
        public int SecondPlayerFourthRound { get; set; }
        public int SecondPlayerFivethRound { get; set; }
    }
}
