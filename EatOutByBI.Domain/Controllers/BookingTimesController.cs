using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Data;
using EatOutByBI.Data.Classes;

namespace EatOutByBI.Domain.Controllers
{
    public class BookingTimesController : Controller
    {
        private EatOutContext db = new EatOutContext();

        [Authorize]
        // GET: BookingTimes
        public ActionResult Index()
        {
            return View(db.BookingTimes.ToList());
        }

        [Authorize]
        // GET: BookingTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTime bookingTime = db.BookingTimes.Find(id);
            if (bookingTime == null)
            {
                return HttpNotFound();
            }
            return View(bookingTime);
        }

        [Authorize]
        // GET: BookingTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: BookingTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingTimeId,Time,DateCreated,DateModified")] BookingTime bookingTime)
        {
            if (ModelState.IsValid)
            {
                db.BookingTimes.Add(bookingTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingTime);
        }

        [Authorize]
        // GET: BookingTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTime bookingTime = db.BookingTimes.Find(id);
            if (bookingTime == null)
            {
                return HttpNotFound();
            }
            return View(bookingTime);
        }

        [Authorize]
        // POST: BookingTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingTimeId,Time,DateCreated,DateModified")] BookingTime bookingTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingTime);
        }

        [Authorize]
        // GET: BookingTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTime bookingTime = db.BookingTimes.Find(id);
            if (bookingTime == null)
            {
                return HttpNotFound();
            }
            return View(bookingTime);
        }

        [Authorize]
        // POST: BookingTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingTime bookingTime = db.BookingTimes.Find(id);
            db.BookingTimes.Remove(bookingTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
