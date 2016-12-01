using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Data.DTO;
using EatOutByBI.Domain.Models;

namespace EatOutByBI.Domain.Controllers
{
    public class ManagerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmpDiagrams()
        {

            var users = db.Users.ToList();
            return View(users);
        }

    }
}