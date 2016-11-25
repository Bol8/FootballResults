using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDomain.RepositoryServices.Match;
using AppDomain.RepositoryServices.Team;
using Domain.Manage;
using Infrastructure.AppManage.Manage;

namespace StatisticsWeb.Controllers
{
    public class EquipoController : Controller
    {
        private ITeamRepositoryServices _teamRepository;
        private IMatchRepositoryServices _matchRepository;

        private AppControler appControl;

        public EquipoController()
        {
            
        }


        public ActionResult Index(string league)
        {
            ViewBag.League = league;
            return View(appControl.TotalResults(league).OrderByDescending(x=> x.Points));
        }

        public ActionResult HomeResults(string league)
        {
            ViewBag.League = league;
            return View(appControl.HomeResults(league).OrderByDescending(x => x.Points));
        }

        public ActionResult AwayResults(string league)
        {
            ViewBag.League = league;
            return View(appControl.AwayResults(league).OrderByDescending(x => x.Points));
        }

        public ActionResult AddTeams()
        {
            var success = appControl.addTeams();

            if (!success) return HttpNotFound();

            return RedirectToAction("Index");
        }


        public ActionResult TeamMatchs(string team)
        {
            return View(appControl.getMatchs(team));
        }
    }
}