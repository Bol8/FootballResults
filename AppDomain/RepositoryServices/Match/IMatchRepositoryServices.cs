using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.RepositoryServices.Match
{
    public interface IMatchRepositoryServices:IRepositoryServices<Partido>
    {

        Partido getElementById(int id);
        Partido getElement(string localTeamName, string awayTeamName, DateTime date);

        List<string> getTeams();
        bool exist(DateTime date,string league,string homeTeam);

    }
}
