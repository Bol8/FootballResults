using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Domain.Manage;
using Domain.Converters;

namespace StatisticsWeb.Controllers
{
    public class PartidoController : Controller
    {
        // GET: Partido
        public ActionResult Index()
        {
            gPartido gPartido = new gPartido();
            //string path = @"C:\Users\Oscar\Downloads\SP1.csv";

            //var lines = Manage.getData(path);

            //for (int i = 1; i < lines.Length; i++)
            //{
            //    var data = Manage.SubArray(lines[i].Split(','), 1, 6);
            //    var partido = Manage.createMatch(data);
            //    gPartido.save(partido);
            //}

            var list = gPartido.getElements();

            return View(list);
        }



        public ActionResult getMatchs(string Team)
        {
            cPartido cPartido = new cPartido(Team);

            var matchs = cPartido.getMatchs();

            return View(matchs);
        }


        public ActionResult statistics(string Team)
        {
            cPartido cPartido = new cPartido(Team);

            var matchs = cPartido.AwayTeamStatistics();

            return View(matchs);
        }
        

    }
}