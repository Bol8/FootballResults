using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
   public  class Match
    {
        [Display(Name ="#")]
        public int IdPartido { get; set; }

        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }

        [Display(Name = "Full Time Home Goals")]
        public int FTHG { get; set; }


        [Display(Name = "Full Time Away Goals")]
        public int FTAG { get; set; }

        
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "Full Time Result")]
        public string FTR { get; set; }


    }
}
