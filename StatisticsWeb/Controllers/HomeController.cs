using System.Web.Mvc;

namespace StatisticsWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "My Bootstrap Site";
            return View();
        }
    }
}