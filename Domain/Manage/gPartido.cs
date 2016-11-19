using Domain.Interfaces;
using System;
using System.Collections.Generic;
using AppDomain;
using System.Linq;
using Repository;
using Repository.Context;


namespace Domain.Manage
{
    public class gPartido : ICrud<Partido>
    {
        private FootbalEntities db;
        const string HomeWin = "H";
        const string Draw = "D";
        const string AwayWin = "A";
        private string Team;

        #region Constructores

        public gPartido()
        {
            db = new FootbalEntities();
        }

        public gPartido(string team)
        {
            this.Team = team;
            db = new FootbalEntities();
        }

        #endregion Constructores


        #region métodos públicos


        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }



        public Partido getElement(long id)
        {
            throw new NotImplementedException();
        }

       

        /// <summary>
        /// Método que devuele los equipos disponibles
        /// </summary>
        /// <returns></returns>
        public List<string> getTeams()
        {
            
            var teams = db.Partidos.Select(x => x.HomeTeam).Distinct().ToList();

            return teams;
        }



        /// <summary>
        /// Método que devuelve todos los partidos
        /// </summary>
        /// <returns></returns>
        public List<Partido> getElements()
        {
            return db.Partidos.ToList();
        }


        public bool exist(DateTime date, string league,string homeTeam)
        {
            var isOk = db.Partidos.FirstOrDefault(x => x.Date == date && x.Liga.Equals(league) && x.HomeTeam.Equals(homeTeam));
            
            return (isOk != null);
        }


        public bool save(Partido input)
        {
            try
            {
                db.Partidos.Add(input);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }




        public bool update(Partido input)
        {
            throw new NotImplementedException();
        }




        public int Matchs()
        {
            int matchs = db.Partidos.Count(x => x.HomeTeam.Equals(Team) || x.AwayTeam.Equals(Team));

            return matchs;
        }


        public int Matchs(int numMatchs)
        {
            int matchs = db.Partidos.Count(x => x.HomeTeam.Equals(Team) || x.AwayTeam.Equals(Team));

            return matchs;
        }


        /// <summary>
        /// Método que devuelve el total de partidos de un equipo.
        /// </summary>
        /// <returns></returns>
        public List<Partido> getMatchs()
        {
            var matchs = db.Partidos.Where(x => x.HomeTeam.Equals(Team) || x.AwayTeam.Equals(Team)).ToList();

            return matchs;
        }


        /// <summary>
        /// Método que devuelve los últimos partidos jugados.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Partido> getLastMatchs(int num)
        {
            var matchs = db.Partidos.Where(x =>
                                                x.HomeTeam.Equals(Team) ||
                                                x.AwayTeam.Equals(Team))
                                                .OrderByDescending(x => x.Date)
                                                .Take(num)
                                                .ToList();

            return matchs;
        }


        public List<Partido> HomeMatchs()
        {
            var matchs = db.Partidos.Where(x => x.HomeTeam.Equals(Team)).ToList();

            return matchs;
        }


        /// <summary>
        /// Devuelve los últimos partidos jugados en casa.
        /// </summary>
        /// <param name="numMatchs"></param>
        /// <returns></returns>
        public List<Partido> HomeMatchs(int numMatchs)
        {
            var matchs = db.Partidos.Where(x => x.HomeTeam.Equals(Team)).OrderByDescending(x => x.Date).Take(numMatchs).ToList();

            return matchs;
        }


        public List<Partido> AwayMatchs()
        {
            var matchs = db.Partidos.Where(x => x.AwayTeam.Equals(Team)).ToList();

            return matchs;
        }


        /// <summary>
        /// Devuelve los últimos partidos jugados fuera.
        /// </summary>
        /// <param name="numMatchs"></param>
        /// <returns></returns>
        public List<Partido> AwayMatchs(int numMatchs)
        {
           var matchs = db.Partidos.Where(x => x.AwayTeam.Equals(Team)).OrderByDescending(x => x.Date).Take(numMatchs).ToList();

            return matchs;
        }



        public int Wins()
        {
            int matchs = db.Partidos.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin)));

            return matchs;
        }



        public int Loses()
        {
            int matchs = db.Partidos.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(AwayWin)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(HomeWin)));

            return matchs;
        }



        public int Draws()
        {
            int matchs = db.Partidos.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw)));

            return matchs;
        }



        public int HomeDraws()
        {
            int matchs = db.Partidos.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw));

            return matchs;
        }
        


        public int HomeDraws(int numMatchs)
        {
            int matchs = db.Partidos.Where(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

            return matchs;
        }



        public int AwayDraws()
        {
            int matchs = db.Partidos.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw));

            return matchs;
        }



        public int AwayDraws(int numMatchs)
        {
            int matchs = db.Partidos.Where(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

            return matchs;
        }




        public int HomeWins()
        {
            int matchs = db.Partidos.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin));

            return matchs;
        }



        public int HomeWins(int numMatchs)
        {
            int matchs = db.Partidos.Where(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

            return matchs;
        }


        public int AwayWins()
        {
            int matchs = db.Partidos.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin));

            return matchs;
        }


        public int AwayWins(int numMatchs)
        {
            int matchs = db.Partidos.Where(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

            return matchs;
        }

        public int HomeLoses()
        {
            int matchs = db.Partidos.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(AwayWin));

            return matchs;
        }


        public int AwayLoses()
        {
            int matchs = db.Partidos.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(HomeWin));

            return matchs;
        }




        #endregion métodos públicos
    }
}