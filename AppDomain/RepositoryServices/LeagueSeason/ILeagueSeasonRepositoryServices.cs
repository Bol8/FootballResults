﻿namespace AppDomain.RepositoryServices.LeagueSeason
{
    public interface ILeagueSeasonRepositoryServices:IRepositoryServices<LigaTemporada>
    {
        LigaTemporada getElementById(int id);
    }
}