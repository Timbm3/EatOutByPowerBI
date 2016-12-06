using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult MenuIndex()
        {
            return View();
        }

        public ActionResult ALaCarte()
        {
            return View();
        }

        public ActionResult Drinks()
        {
            return View();
        }

        public ActionResult Desserts()
        {
            return View();
        }

    }
}