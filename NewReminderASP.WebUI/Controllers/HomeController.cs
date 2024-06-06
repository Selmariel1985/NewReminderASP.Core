using System.Web.Mvc;

namespace NewReminderASP.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // Action method for the home page
        public ActionResult Index()
        {
            return View();
        }

        // Action method for the about page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Action method for the contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}