



using System;
using AppDomain;
using AppDomain.RepositoryServices.League;
using AppDomain.RepositoryServices.LeagueSeason;
using AppDomain.RepositoryServices.Season;
using Domain.Manage;
using Domain.Tools;
using Infrastructure.AppManage.Interfaces;
using Repository.Context;
using Repository.Repository;
using Repository.Repository.League;
using Repository.Repository.LeagueSeason;
using Repository.Repository.Season;

namespace Infrastructure.AppManage.Manage
{
    public class AppManage : IAppUpdateServices
    {
        private readonly IConfigManageServices _configManage;
        private readonly IFileManageServices _fileManage;
        private readonly ISeasonRepositoryServices _seasonRepository;
        private readonly ILeagueRepositoryServices _leagueRepository;
        private readonly ILeagueSeasonRepositoryServices _leagueSeasonRepository;

        private readonly gPartido gPartido = new gPartido();
        private readonly gEquipo gEquipo = new gEquipo();
        
        
        public AppManage(IConfigManageServices configManage, 
                         IFileManageServices fileManage)
        {
            _configManage = configManage;
            _fileManage = fileManage;
            _seasonRepository = new SeasonRepository(new GenericRepository<Temporada>(new FootbalEntities()));
            _leagueRepository = new LeagueRepository(new GenericRepository<Liga>(new FootbalEntities()));
            _leagueSeasonRepository = new LeagueSeasonRepository(new GenericRepository<LigaTemporada>(new FootbalEntities()));
        }
        


        public void UpdateFiles()
        {
           // _fileManage.DownloadFiles(_configManage.getValues("fileNameList"));
        }



        public void UpdateDb()
        {
            try
            {
                updateSeason();
                updateMatchs();
                updateTeams();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void updateSeason()
        {
            var seasonName = _configManage.getValue("LocalPath").Split('\\')[5];
            var name = seasonName.Split()[1];

            if (!_seasonRepository.exists(name))
            {
                var year = name.Split('-')[0];
                var season = new Temporada() {Nombre = name, Año = year };
                _seasonRepository.add(season);

                var leagues = _leagueRepository.getElements();

                _leagueSeasonRepository.addLeagues(leagues,season.IdTemporada);
            }
        }

        private void updateMatchs()
        {
            var fileList = _fileManage.getFiles(_configManage.getValues("pathFiles"));

            foreach (var lines in fileList)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    var data = lines[i].Split(',').SubArray(0, 7);

                    var date = DateTime.Parse(data[1]);
                    var league = data[0];
                    var HomeTeam = data[2];

                    if (!gPartido.exist(date, league, HomeTeam))
                    {
                        var partido = createMatch(data);

                        gPartido.save(partido);
                    }
                }
            }
        }

        private Partido createMatch(string[] data)
        {
            var aux = 0;
            Partido partido = null;

            if (int.TryParse(data[4], out aux))
            {
                partido = new Partido
                {
                    Liga = data[0],
                    Date = DateTime.Parse(data[1]),
                    HomeTeam = data[2],
                    AwayTeam = data[3],
                    FTHG = int.Parse(data[4]),
                    FTAG = int.Parse(data[5]),
                    FTR = data[6]
                };
            }

            return partido;
        }

        private void updateTeams()
        {
            var teams = gEquipo.getTeamsFromMatchs(gPartido.getElements());

            foreach (var team in teams)
            {
                if (!gEquipo.exists(team.Nombre))
                {
                    gEquipo.add(team);
                }
            }
        }
    }
}