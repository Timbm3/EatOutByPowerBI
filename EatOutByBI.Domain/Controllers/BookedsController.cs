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
    public class BookedsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Bookeds
        public ActionResult Index()
        {
            return View(db.Bookeds.ToList());
        }

        // GET: Bookeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booked booked = db.Bookeds.Find(id);
            if (booked == null)
            {
                return HttpNotFound();
            }
            return View(booked);
        }

        // GET: Bookeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookedId,DateAndTime,Plats,BookingTimeId,IsAvailable")] Booked booked)
        {
            if (ModelState.IsValid)
            {
                db.Bookeds.Add(booked);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booked);
        }

        // GET: Bookeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booked booked = db.Bookeds.Find(id);
            if (booked == null)
            {
                return HttpNotFound();
            }
            return View(booked);
        }

        // POST: Bookeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookedId,DateAndTime,Plats,BookingTimeId,IsAvailable")] Booked booked)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booked).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booked);
        }

        // GET: Bookeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booked booked = db.Bookeds.Find(id);
            if (booked == null)
            {
                return HttpNotFound();
            }
            return View(booked);
        }

        // POST: Bookeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booked booked = db.Bookeds.Find(id);
            db.Bookeds.Remove(booked);
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
