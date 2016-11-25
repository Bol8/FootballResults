using System.Collections.Generic;

namespace AppDomain.RepositoryServices.LeagueSeason
{
    public interface ILeagueSeasonRepositoryServices:IRepositoryServices<LigaTemporada>
    {
        LigaTemporada getElementById(int id);
        void addLeagues(List<AppDomain.Liga> leaguesList,int idSeason);

        // bool exists(string year);
    }
}
