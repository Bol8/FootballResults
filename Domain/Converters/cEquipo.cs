using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Manage;
using Repository;
using Domain.Models;

namespace Domain.Converters
{
    public class cEquipo
    {
        private gEquipo gEquipo;
        private Equipos team;
        private StatisticsTeam statistics;


        #region Constructores

        public cEquipo()
        {
            gEquipo = new gEquipo();
        }

        #endregion

        public bool addTeams(List<string> teams)
        {
            // bool isOk = false;

            try
            {
                foreach (var team in teams)
                {
                    if (!gEquipo.exists(team))
                    {
                        this.team = new Equipos
                        {
                            Nombre = team
                        };

                        gEquipo.add(this.team);

                        //  if (!isOk) return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
               // throw;
            }

        }


        public List<Equipos> getTeams()
        {
            return gEquipo.getElements();
        }

        public List<Equipos> getTeams(string league)
        {
            return gEquipo.getElements(league);
        }



    }
}
