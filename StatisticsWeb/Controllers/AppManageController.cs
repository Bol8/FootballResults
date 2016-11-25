using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Infrastructure.AppManage.Interfaces;
using Infrastructure.AppManage.Manage;

namespace StatisticsWeb.Controllers
{
    public class AppManageController : Controller
    {
        private readonly IConfigManageServices _configFileManage;
        private readonly string remoteUri;
        private readonly string localPath;
      


        public AppManageController()
        {
            _configFileManage = new FileConfigManage();
            remoteUri = _configFileManage.getValue("RemoteUri");
            localPath = _configFileManage.getValue("LocalPath");
        }

        // GET: AppManage
        public ActionResult Update()
        {
           // AppManage.UpdateApp();

            var AppManage = new AppManage(_configFileManage,
                                          new FileManage(new WebClient(), remoteUri, localPath));

            AppManage.UpdateFiles();
            AppManage.UpdateDb();

            return RedirectToAction("Index","Home");
        }
    }
}