using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Domain.Models;


namespace StatisticsWeb.Controllers
{
    public class StatisticsController : Controller
    {
        AppControler appControl = new AppControler();

        public ActionResult Index(string league)
        {
            //return View(appControl.goPrognostic(league));
            return PartialView(appControl.goPrognostic(league));
        }


        //[HttpGet]
        //public ActionResult Calculate()
        //{
        //   // var prog = new ProgResult();

        //    return PartialView();
        //}


        [HttpPost]
        public ActionResult Pronostico(Prognostic prognostic)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            var progResults = new ProgResultList();
            var Results = new List<string> { "1", "X", "2" };
            var Dictionary = new Dictionary<string,ProgResultList>();




            foreach (var result in Results)
            {
                prognostic.result = result;
                progResults = new ProgResultList();

                progResults.Add(appControl.calculateShare(prognostic));
                progResults.Add(appControl.calculateShare(prognostic, 8));
                progResults.Add(appControl.calculateShare(prognostic, 6));
                progResults.Add(appControl.calculateShare(prognostic, 3));

                Dictionary.Add(result, progResults);
            }


            //progResults.Add(appControl.calculateShare(prognostic));
            //progResults.Add(appControl.calculateShare(prognostic, 8));
            //progResults.Add(appControl.calculateShare(prognostic, 6));
            //progResults.Add(appControl.calculateShare(prognostic, 3));

            return PartialView("Calculate", Dictionary);
        }



        //[HttpPost]
        //public ActionResult Calculator(Prognostic prognostic)
        //{
        //    if (!Request.IsAjaxRequest()) return HttpNotFound();
        //    var progResults = new ProgResultList();

        //    progResults.Add(appControl.calculateShare(prognostic));
        //    progResults.Add(appControl.calculateShare(prognostic,8));
        //    progResults.Add(appControl.calculateShare(prognostic,6));
        //    progResults.Add(appControl.calculateShare(prognostic,4));

        //    return PartialView("Calculate", progResults);
        //}
        
    }
}