using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Domain.Models;
using Microsoft.AspNet.Identity;

namespace EatOutByBI.Domain.Controllers
{
    public class AdminPageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

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

        public ActionResult Employees()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFroEmployee(applicationUser));
        }

        private RegisterViewModel ViewModelFroEmployee(ApplicationUser applicationUser)
        {
            var viewModel = new RegisterViewModel();
            {
                viewModel.Id = applicationUser.Id;

            };
            return viewModel;
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Password")] ApplicationUser applicationUser)
        {

            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }
    }
}