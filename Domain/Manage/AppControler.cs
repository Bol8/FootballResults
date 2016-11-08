using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Manage;
using Repository;
using Domain.Models;
using Domain.Converters;

namespace Domain.Manage
{
    public class AppControler
    {
        private cEquipo cEquipo;
        private cPartido cPartido;

        #region Constructores

        public AppControler() { }


        #endregion


        public bool addTeams()
        {
            cPartido = new cPartido();
            var teams = cPartido.getTeams();

            cEquipo = new cEquipo();
            var isOk = cEquipo.addTeams(teams);


            return isOk;
        }



        public List<StatisticsTeam> TotalResults(string league)
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams(league);

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.getStatistics());
            }

            return list;
        }



        public List<StatisticsTeam> HomeResults(string league)
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams(league);

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.HomeTeamStatistics());
            }

            return list;
        }



        public List<StatisticsTeam> AwayResults(string league)
        {
            cEquipo = new cEquipo();

            var teams = cEquipo.getTeams(league);

            List<StatisticsTeam> list = new List<StatisticsTeam>();

            foreach (var team in teams)
            {
                cPartido = new cPartido(team.Nombre);
                list.Add(cPartido.AwayTeamStatistics());
            }

            return list;
        }



        public List<Match> getMatchs(string Team)
        {
            cPartido = new cPartido(Team);

            return cPartido.getMatchs();
        }


        public Prognostic goPrognostic(string league)
        {
            Prognostic prognostic = new Prognostic(league);

            return prognostic;
        }


        public ProgResult calculateShare(Prognostic prognostic)
        {
            ProgResult proRes = new ProgResult();

            switch (prognostic.result)
            {
                case "1":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var HomeStatistic = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var AwayStatistics = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(HomeStatistic.PercentWins, AwayStatistics.PercentLoses,HomeStatistic.MatchesPlayed);

                    break;

                case "2":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var a = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var b = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(a.PercentLoses, b.PercentWins,a.MatchesPlayed);

                    break;

                case "X":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var c = cPartido.HomeTeamStatistics();

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var d = cPartido.AwayTeamStatistics();

                    proRes = getMatchPercent(c.PercentDraws, d.PercentDraws,c.MatchesPlayed);
                    
                    break;
            }
            
            return proRes;
        }

        public ProgResult calculateShare(Prognostic prognostic,int lastMatchs)
        {
            ProgResult proRes = new ProgResult();

            switch (prognostic.result)
            {
                case "1":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var HomeStatistic = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var AwayStatistics = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(HomeStatistic.PercentWins, AwayStatistics.PercentLoses, lastMatchs);

                    break;

                case "2":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var a = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var b = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(a.PercentLoses, b.PercentWins, lastMatchs);

                    break;

                case "X":
                    cPartido = new cPartido(prognostic.HomeTeam);
                    var c = cPartido.HomeTeamStatistics(lastMatchs);

                    cPartido = new cPartido(prognostic.AwayTeam);
                    var d = cPartido.AwayTeamStatistics(lastMatchs);

                    proRes = getMatchPercent(c.PercentDraws, d.PercentDraws, lastMatchs);

                    break;
            }

            return proRes;
        }


        #region métodos privados

        private ProgResult getMatchPercent(decimal homePercent, decimal awayPercent,int matchsPlayed)
        {
            decimal shared = 0;
            var result = ((homePercent + awayPercent) / 2);
            var p = result / 100;
            decimal n = 10;

            if (p != 0)
            {
                 n = 10 / p;
                shared = n / 10;
            }



            ProgResult prog = new ProgResult
            {
                MatchsPlayed = matchsPlayed,
                HomePercent = homePercent,
                AwayPercent = awayPercent,
                TotalPercent = result,
                Share = decimal.Round(shared, 1, MidpointRounding.AwayFromZero),
                sShare = decimal.Round(shared, 2, MidpointRounding.ToEven).ToString()

            };

            return prog;
        }

        #endregion

    }
}
