using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Manage;
using Domain.Models;


namespace Domain.Converters
{
    public class cPartido
    {
        private gPartido gPartido;
        protected StatisticsTeam statistics;
        private string Team;

        public cPartido()
        {
            gPartido = new gPartido();
        }


        public cPartido(string Team)
        {
            this.Team = Team;
            gPartido = new gPartido(Team);
        }


        public List<Match> getMatchs()
        {
            var list = new List<Match>();
            var matchs = gPartido.getMatchs();

            foreach (var item in matchs)
            {
                var match = new Match
                {
                    IdPartido = item.IdPartido,
                    HomeTeam = item.HomeTeam,
                    AwayTeam = item.AwayTeam,
                    Date = item.Date.ToShortDateString(),
                    FTHG = item.FTHG,
                    FTAG = item.FTAG,
                    FTR = item.FTR
                };

                list.Add(match);

            }

            return list.OrderByDescending(x => DateTime.Parse(x.Date)).ToList();
        }


        public StatisticsTeam getStatistics()
        {
            statistics = new StatisticsTeam
            {
                Team = Team,
                MatchesPlayed = gPartido.Matchs(),
                Wins = gPartido.Wins(),
                Loses = gPartido.Loses(),
                Draws = gPartido.Draws(),
                Points = calculatePoints(gPartido.Wins(),gPartido.Draws()),
                PercentWins = calculatePercent(gPartido.Matchs(),gPartido.Wins()),
                PercentDraws= calculatePercent(gPartido.Matchs(),gPartido.Draws()),
                PercentLoses = calculatePercent(gPartido.Matchs(),gPartido.Loses())
            };
            
            return statistics;
        }


        public StatisticsTeam HomeTeamStatistics(int lastMatchs)
        {
            StatisticsCalculator sts = new StatisticsCalculator(gPartido.HomeMatchs(lastMatchs), Team);
            
            return sts.getHomeStatistics();
        }

        public StatisticsTeam HomeTeamStatistics()
        {
            StatisticsCalculator sts = new StatisticsCalculator(gPartido.HomeMatchs(), Team);

            return sts.getHomeStatistics();
        }


        public StatisticsTeam AwayTeamStatistics(int lastMatchs)
        {
            StatisticsCalculator sts = new StatisticsCalculator(gPartido.AwayMatchs(lastMatchs), Team);
            
            return sts.getAwayStatistics();
        }

        public StatisticsTeam AwayTeamStatistics()
        {
            StatisticsCalculator sts = new StatisticsCalculator(gPartido.AwayMatchs(), Team);

            return sts.getAwayStatistics();
        }



        public List<string> getTeams()
        {
            return gPartido.getTeams();
        }


        #region métodos privados

        private decimal calculatePercent(int matchPlayed , int matchs)
        {
            //TODO:Revisar división por cero
            decimal percent =  (decimal)matchs * 100  / (decimal)matchPlayed ;

            return decimal.Round(percent, 2, MidpointRounding.AwayFromZero);
        }

       
        private int calculatePoints(int wins , int draws)
        {
            var winsPoints = wins * 3;

            return winsPoints + draws;
        }

        #endregion
    }
}
