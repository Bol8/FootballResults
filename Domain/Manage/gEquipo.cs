using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Repository;
using Domain.Models;

namespace Domain.Manage
{
    public class gEquipo:IEquipoRepositoryServices
    {
        private readonly IGenericRepository<Equipos> _context;

        private readonly FootbalEntities db;
        private readonly string Team;
        private readonly List<Equipos> teamList;

       
        public gEquipo(IGenericRepository<Equipos> context)
        {
            _context = context;
        }

        public gEquipo()
        {
            teamList = new List<Equipos>();
            db = new FootbalEntities();

        }

        public gEquipo(string Team)
        {
            teamList = new List<Equipos>();
            this.Team = Team;
            db = new FootbalEntities();
        }
        


        //public Equipos getElement(long id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Equipos> getElements()
        {
            return db.Equipos.ToList();
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
        }

        public void Delete(Equipos element)
        {
            _context.Delete(element);
        }

        public List<Equipos> getElements(string league)
        {
            return db.Equipos.Where(x => x.Liga.Equals(league)).ToList();
        }



        //public bool save(Equipos input)
        //{
        //    try
        //    {
        //        _context.Add(input);
        //        _context.Save();


        //        //db.Equipos.Add(input);
        //       // db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;
        //}


        //public bool exist(string TeamName)
        //{
        //    var team = db.Equipos.Find(Team);

        //    return (team != null);
        //}

            

        public Equipos getElement(string TeamName)
        {
            var team = db.Equipos.Find(TeamName);

            return team;
        }


        public bool exists(string TeamName)
        {
            try
            {
                var team = db.Equipos.Find(TeamName);
                if (team == null) return false;
            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }


        public List<Equipos> getTeamsFromMatchs(List<Partido> matchs)
        {
            var MatchsByLeagues = matchs.GroupBy(x => x.Liga).ToList();

            foreach (var leagues in MatchsByLeagues)
            {
                var Key = leagues.Key;

                foreach (var team in leagues.Select(x => x.HomeTeam).Distinct().ToList())
                {
                    Equipos equipo = new Equipos
                    {
                        Nombre = team,
                        Liga = Key
                    };

                    teamList.Add(equipo);
                }
            }

            return teamList;
        }


        //public bool exist()
        //{
        //    try
        //    {
        //        var team = db.Equipos.Find(Team);
        //    }
        //    catch (Exception)
        //    {
        //        return false;

        //    }

        //    return true;
        //}


        //public bool exist(string Team)
        //{
        //    try
        //    {
        //        var team = db.Equipos.Find(Team);
        //        if (team == null) return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;

        //    }

        //    return true;
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
