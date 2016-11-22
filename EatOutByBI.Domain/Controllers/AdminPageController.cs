using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class AdminPageController : Controller
    {
        // GET: AdminPage
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminAddProdEmp()
        {
            return View();
        }
    }
}