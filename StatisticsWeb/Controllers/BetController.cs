using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Domain.Models;
using Repository;
using Calendar = System.Web.UI.WebControls.Calendar;

namespace StatisticsWeb.Controllers
{
    public class BetController : Controller
    {
        AppControler appControl = new AppControler();


        // GET: Bet
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(string homeTeam, string awayTeam)
        {
            var bet = new Bet
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Week = DateTime.Now.DayOfYear / 7,
            };

            return View(bet);
        }


        [HttpPost]
        public ActionResult Create(Bet model)
        {
            var prognostic = new Prognostic
            {
                AwayTeam = model.AwayTeam,
                HomeTeam = model.HomeTeam,

            };

            var Results = new List<string> { "1", "X", "2" };
            var Dictionary = new Dictionary<string, ProgResultList>();

            foreach (var result in Results)
            {
                prognostic.result = result;
                var progResults = new ProgResultList();

                progResults.Add(appControl.calculateShare(prognostic));
                progResults.Add(appControl.calculateShare(prognostic, 8));
                progResults.Add(appControl.calculateShare(prognostic, 6));
                progResults.Add(appControl.calculateShare(prognostic, 3));

                Dictionary.Add(result, progResults);
            }


            foreach (var prog in Dictionary)
            {
                foreach (var progResult in prog.Value.getList())
                {
                    var betProg = new BetPrognostic
                    {
                        Condition = prog.Key,
                        Matchs = progResult.MatchsPlayed,
                        HomePercent = progResult.HomePercent,
                        AwayPercent = progResult.AwayPercent,
                        TotalPercent = progResult.TotalPercent,
                        Share = progResult.Share,
                    };

                    model.BetPrognostics.Add(betProg);
                }
            }

            var db = new FootbalEntities();
            db.Bets.Add(model);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}