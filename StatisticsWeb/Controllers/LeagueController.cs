using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Domain.Models;

namespace StatisticsWeb.Controllers
{
    public class LeagueController : Controller
    {
        private gLeague gLeague;

        #region Constructores

        public LeagueController()
        {
            gLeague = new gLeague();
        }
        #endregion


        // GET: League
        public ActionResult Index()
        {
            var leagues = gLeague.list;

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