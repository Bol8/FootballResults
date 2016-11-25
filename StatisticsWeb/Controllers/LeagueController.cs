using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Domain.Models;
using AppDomain;
using AppDomain.RepositoryServices.League;
using Domain.Repository;
using Repository.Context;
using Repository.Repository;
using Repository.Repository.League;

namespace StatisticsWeb.Controllers
{
    public class LeagueController : Controller
    {
        private gLeague gLeague;
        private readonly ILeagueRepositoryServices _leagueRepository;

        #region Constructores

        public LeagueController()
        {
            _leagueRepository = new LeagueRepository(new Repository.Repository.GenericRepository<Liga>(new FootbalEntities()));
           // gLeague = new gLeague();
        }
        #endregion


        // GET: League
        public ActionResult Index()
        {
            var leagues = _leagueRepository.getElements();
           // var leagues = gLeague.list;

            return View(leagues);
        }


        public ActionResult Leagues()
        {
            var leagues = gLeague.list;

            return View(leagues);
        }


        public ActionResult Leagues2()
        {
            var leagues = gLeague.list;


            return View(leagues);
        }
    }
}