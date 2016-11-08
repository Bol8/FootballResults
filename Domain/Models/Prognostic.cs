using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;
using System.Web.Mvc;

namespace Domain.Models
{
    public class Prognostic
    {
        private FootbalEntities dB;

        public Liga League { get; }

        public SelectList HomeTeamList { get; set; }

        [Required(ErrorMessage ="Field required")]
        public string HomeTeam { get; set; }

        public SelectList AwayTeamList { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string AwayTeam { get; set; }

        public List<string> Results { get; set; }
        public SelectList ResultsList { get; set; }
        public string result { get; set; }



        public Prognostic() { }

        public Prognostic(string league)
        {
            dB = new FootbalEntities();
            Results = new List<string> {"1","X","2"};
            League = dB.Ligas.Find(league);
            ResultsList = new SelectList(Results);
            HomeTeamList = new SelectList(dB.Equipos.OrderBy(x => x.Nombre).Where(x => x.Liga.Equals(league)), "Nombre", "Nombre");
            AwayTeamList = new SelectList(dB.Equipos.OrderBy(x => x.Nombre).Where(x => x.Liga.Equals(league)), "Nombre", "Nombre");
        }




    }
}
