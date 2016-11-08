using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain;
using Repository;

namespace Domain.Interfaces
{
    public interface IEquipoRepositoryServices:IRepositoryServices<Equipos>
    {
        Equipos getElement(string TeamName);
        bool exists(string TeamName);
        List<Equipos> getTeamsFromMatchs(List<Partido> matchs);
        
    }
}
