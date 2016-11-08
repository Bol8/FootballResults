using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;

namespace StatisticsWeb.Controllers
{
    public class EquipoController : Controller
    {
        AppControler appControl = new AppControler();
        
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