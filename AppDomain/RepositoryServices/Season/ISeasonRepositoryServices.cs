using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.RepositoryServices.Season
{
    public interface ISeasonRepositoryServices:IRepositoryServices<Temporada>
    {
        Temporada getElemntById(int id);
    }
}
