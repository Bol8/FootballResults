using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.RepositoryServices;
using AppDomain.RepositoryServices.Team;

namespace Repository.Repository.Team
{
    public class TeamRepository:ITeamRepositoryServices
    {
        private readonly IGenericRepository<Equipos> _context;

        public TeamRepository(IGenericRepository<Equipos> context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Equipos> getElements()
        {
            return _context.GetAll().ToList();
        }

        public void add(Equipos element)
        {
            _context.Add(element);
            _context.Save();
        }

        public void saveChanges()
        {
            _context.Save();
        }

        public void edit(Equipos elemnt)
        {
            _context.Edit(elemnt);
            _context.Save();
        }

        public void Delete(Equipos element)
        {
            _context.Delete(element);
            _context.Save();
        }

        public Equipos getElementById(string id)
        {
            return _context.FindBy(x => Equals(x.Liga, id)).FirstOrDefault();
        }
    }
}
