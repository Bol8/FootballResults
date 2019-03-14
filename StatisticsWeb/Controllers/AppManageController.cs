using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;

namespace StatisticsWeb.Controllers
{
    public class AppManageController : Controller
    {

         private readonly string remoteUri = "http://www.football-data.co.uk/mmz4281/1819/";
         private readonly string localPath = @"C:\Users\OBB\PROYECTOS\FootballResults\Resultados\";

        // GET: AppManage
        public ActionResult Update()
        {
           // AppManage.UpdateApp();

            var AppManage = new AppManage(new FileConfigManage(),
                                          new FileManage(new WebClient(), remoteUri, localPath));

            AppManage.UpdateFiles();
            AppManage.UpdateDb();

            return RedirectToAction("Index","Home");
        }
    }
}