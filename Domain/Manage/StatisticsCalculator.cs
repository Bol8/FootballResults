using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using Domain.Models;
using Repository;

namespace Domain.Manage
{
    public class StatisticsCalculator
    {
        const string HomeWin = "H";
        const string Draw = "D";
        const string AwayWin = "A";
        StatisticsTeam statistics;

        private List<Partido> matchsList { get; set; }
        string Team;


      

        public StatisticsCalculator(List<Partido> matchs, string team)
        {
            this.matchsList = matchs;
            this.Team = team;
        }

       


      

        public StatisticsTeam getHomeStatistics()
        {
            statistics = new StatisticsTeam
            {
                Team = Team,
                MatchesPlayed = matchsList.Count,
                Wins = Wins(),
                Loses = Loses(),
                Draws = Draws(),
                Points = calculatePoints(HomeWins(), HomeDraws()),
                PercentWins = calculatePercent(matchsList.Count, HomeWins()),
                PercentDraws = calculatePercent(matchsList.Count, HomeDraws()),
                PercentLoses = calculatePercent(matchsList.Count, HomeLoses())
            };

            return statistics;
        }


        public StatisticsTeam getAwayStatistics()
        {
            statistics = new StatisticsTeam
            {
                Team = Team,
                MatchesPlayed = matchsList.Count,
                Wins = Wins(),
                Loses = Loses(),
                Draws = Draws(),
                Points = calculatePoints(AwayWins(), AwayDraws()),
                PercentWins = calculatePercent(matchsList.Count, AwayWins()),
                PercentDraws = calculatePercent(matchsList.Count, AwayDraws()),
                PercentLoses = calculatePercent(matchsList.Count, AwayLoses())
            };

            return statistics;
        }

        

     

        private decimal calculatePercent(int matchPlayed, int matchs)
        {
            decimal percent = (decimal)matchs * 100 / (decimal)matchPlayed;

            return decimal.Round(percent, 2, MidpointRounding.AwayFromZero);
        }


        private int calculatePoints(int wins, int draws)
        {
            var winsPoints = wins * 3;

            return winsPoints + draws;
        }

        private int Wins()
        {
            int matchs = matchsList.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin)));

            return matchs;
        }



        private int Loses()
        {
            int matchs = matchsList.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(AwayWin)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(HomeWin)));

            return matchs;
        }



        private int Draws()
        {
            int matchs = matchsList.Count(x => (x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw)) || (x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw)));

            return matchs;
        }


        public int HomeDraws()
        {
            int matchs = matchsList.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw));

            return matchs;
        }

        //public int HomeDraws(int numMatchs)
        //{
        //    int matchs = matchsList.Where(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(Draw)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

        //    return matchs;
        //}


        public int AwayDraws()
        {
            int matchs = matchsList.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw));

            return matchs;
        }

        //public int AwayDraws(int numMatchs)
        //{
        //    int matchs = matchsList.Where(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(Draw)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

        //    return matchs;
        //}


        public int HomeWins()
        {
            int matchs = matchsList.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin));

            return matchs;
        }

        //public int HomeWins(int numMatchs)
        //{
        //    int matchs = matchsList.Where(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(HomeWin)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

        //    return matchs;
        //}


        public int AwayWins()
        {
            int matchs = matchsList.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin));

            return matchs;
        }


        //public int AwayWins(int numMatchs)
        //{
        //    int matchs = matchsList.Where(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(AwayWin)).OrderByDescending(x => x.Date).Take(numMatchs).Count();

        //    return matchs;
        //}

        public int HomeLoses()
        {
            int matchs = matchsList.Count(x => x.HomeTeam.Equals(Team) && x.FTR.Equals(AwayWin));

            return matchs;
        }


        public int AwayLoses()
        {
            int matchs = matchsList.Count(x => x.AwayTeam.Equals(Team) && x.FTR.Equals(HomeWin));

            return matchs;
        }



      

    }
}
