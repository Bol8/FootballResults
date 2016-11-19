using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.RepositoryServices;
using AppDomain.RepositoryServices.League;

namespace Repository.Repository.League
{
    public class LeagueRepository:ILeagueRepositoryServices
    {
        private readonly IGenericRepository<Liga> _context;

        public LeagueRepository(IGenericRepository<Liga> context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Liga> getElements()
        {
            return _context.GetAll().ToList();
        }

        public void add(Liga element)
        {
            _context.Add(element);
            _context.Save();
        }

        public void saveChanges()
        {
            _context.Save();
        }

        public void edit(Liga elemnt)
        {
            _context.Edit(elemnt);
            _context.Save();
        }

        public void Delete(Liga element)
        {
            _context.Delete(element);
            _context.Save();
        }

        public Liga getElementById(string id)
        {
            return _context.FindBy(x => Equals(x.IdLiga, id)).FirstOrDefault();
        }
    }
}
