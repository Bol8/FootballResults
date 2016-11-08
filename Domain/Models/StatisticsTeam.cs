using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Domain.Models
{
    public class StatisticsTeam
    {
        public string Team { get; set; }

        public int MatchesPlayed { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Loses { get; set; }

        public int Points { get; set; }

        [Display(Name ="% Wins")]
        public decimal PercentWins { get; set; }

        [Display(Name = "% Loses")]
        public decimal PercentLoses { get; set; }

        [Display(Name = "% Draws")]
        public decimal PercentDraws { get; set; }

    }
}
