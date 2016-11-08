using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ProgResult
    {
        [Display(Name = "Match played")]
        public int MatchsPlayed { get; set; }

        [Display(Name ="Home percent")]
        public decimal HomePercent { get; set; }

        [Display(Name = "Away percent")]
        public decimal AwayPercent { get; set; }

        [Display(Name = "Total percent")]
        public decimal TotalPercent { get; set; }

        [Display(Name = "Share")]
        public decimal Share { get; set; }


        [Display(Name = "Share")]
        public string sShare { get; set; }

    }
}
