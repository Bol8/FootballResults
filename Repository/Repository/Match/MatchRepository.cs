using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.RepositoryServices;
using AppDomain.RepositoryServices.Match;

namespace Repository.Repository.Match
{
    public class MatchRepository:IMatchRepositoryServices
    {
        private readonly IGenericRepository<Partido> _context;


        public MatchRepository(IGenericRepository<Partido> context )
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Partido> getElements()
        {
            return _context.GetAll().ToList();
        }

        public void add(Partido element)
        {
            _context.Add(element);
            _context.Save();
        }

        public void saveChanges()
        {
            _context.Save();
        }

        public void edit(Partido elemnt)
        {
            _context.Edit(elemnt);
            _context.Save();
        }

        public void Delete(Partido element)
        {
            _context.Delete(element);
            _context.Save();
        }

        public Partido getElementById(int id)
        {
            return _context.FindBy(x => x.IdPartido == id).FirstOrDefault();
        }

        public Partido getElement(string localTeamName, string awayTeamName, DateTime date)
        {
            return
                _context.FindBy(
                        x => Equals(x.HomeTeam, localTeamName) && Equals(x.AwayTeam, awayTeamName) && x.Date == date)
                    .FirstOrDefault();
        }
    }
}
