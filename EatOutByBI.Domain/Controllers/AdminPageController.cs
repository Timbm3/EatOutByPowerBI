using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Data.DTO;
using EatOutByBI.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EatOutByBI.Domain.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        // GET: AdminPage
        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Employees()
        {
            var users = db.Users.ToList();
            return View(users);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult AdminEmpDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFroEmployee(user));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminEmpEdit(string id)
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



        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEmpEdit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Password")] ApplicationUser applicationUser, UsersDTO usersDto)
        {

            if (ModelState.IsValid)
            {
                applicationUser.Id = usersDto.UserId;
                applicationUser.UserName = usersDto.UserName;
                applicationUser.Email = usersDto.Email;

                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(usersDto);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminEmpDelete(string id)
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
            return View(applicationUser);
        }

        // POST: Bookings/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("AdminEmpDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            ApplicationUser applicationUser = db.Users.Find(id);

            string userRole = applicationUser.Roles.ToString();

            var logins = applicationUser.Logins;

            foreach (var login in logins.ToList())
            {
                UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            UserManager.RemoveFromRole(id, userRole);

            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Employees");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private UsersDTO ViewModelFroEmployee(ApplicationUser applicationUser)
        {
            var viewModel = new UsersDTO()
            {
                UserId = applicationUser.Id,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber

            };

            return viewModel;
        }
    }
}