using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using AppDomain.RepositoryServices;
using AppDomain.RepositoryServices.Season;

namespace Repository.Repository.Season
{
    public class SeasonRepository:ISeasonRepositoryServices
    {
        private readonly IGenericRepository<Temporada> _context;

        public SeasonRepository(IGenericRepository<Temporada> context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Temporada> getElements()
        {
            return _context.GetAll().ToList();
        }

        public void add(Temporada element)
        {
            _context.Add(element);
            _context.Save();
        }

        public void saveChanges()
        {
            _context.Save();
        }

        public void edit(Temporada elemnt)
        {
            _context.Edit(elemnt);
            _context.Save();
        }

        public void Delete(Temporada element)
        {
            _context.Delete(element);
            _context.Save();
        }

        public Temporada getElemntById(int id)
        {
            return _context.FindBy(x => x.IdTemporada == id).FirstOrDefault();
        }
    }
}
