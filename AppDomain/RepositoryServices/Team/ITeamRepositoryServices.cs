using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.RepositoryServices.Team
{
    public interface ITeamRepositoryServices:IRepositoryServices<Equipos>
    {
        Equipos getElementById(string id);

    }
}
