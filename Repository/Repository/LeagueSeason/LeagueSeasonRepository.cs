using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.RepositoryServices;
using AppDomain.RepositoryServices.LeagueSeason;

namespace Repository.Repository.LeagueSeason
{
    public class LeagueSeasonRepository:ILeagueSeasonRepositoryServices
    {
        private readonly IGenericRepository<LigaTemporada> _context;

        public LeagueSeasonRepository(IGenericRepository<LigaTemporada> context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<LigaTemporada> getElements()
        {
            return _context.GetAll().ToList();
        }

        public void add(LigaTemporada element)
        {
            _context.Add(element);
            _context.Save();
        }

        public void saveChanges()
        {
            _context.Save();
        }

        public void edit(LigaTemporada elemnt)
        {
            _context.Edit(elemnt);
            _context.Save();
        }

        public void Delete(LigaTemporada element)
        {
            _context.Delete(element);
            _context.Save();
        }

        public LigaTemporada getElementById(int id)
        {
            return _context.FindBy(x => x.Id == id).FirstOrDefault();
        }

        public void addLeagues(List<Liga> leaguesList,int idSeason)
        {
            foreach (var league in leaguesList)
            {
                var seasonLeague = new LigaTemporada()
                {
                    IdLiga = league.IdLiga,
                    IdTemporada = idSeason,
                };

                _context.Add(seasonLeague);
            }

            _context.Save();
        }
    }
}
