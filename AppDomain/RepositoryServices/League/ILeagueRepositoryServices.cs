using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.RepositoryServices.League
{
    public interface ILeagueRepositoryServices:IRepositoryServices<Liga>
    {
        Liga getElementById(string id);
        
    }
}
