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
using EatOutByBI.Data.DTO;
using EatOutByBI.Domain.Models;

namespace EatOutByBI.Domain.Controllers
{
    public class BookingsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var dtoBooking = from b in db.Bookings.OrderByDescending(a => a.BookingId)
                             select new BookingDTO()
                             {
                                 BookingId = b.BookingId,
                                 Name = b.Name,
                                 Telephone = b.Telephone,
                                 Email = b.Email,
                                 Date = b.Date,
                                 DateAndTime = b.DateAndTime,
                                 BookingTimeId = b.BookingTimeId,
                                 //BookingTimes = b.BookingTime.ToList()
                             };
            //var bookings = db.Bookings.Include(b => b.BookingTime);bookings.ToList()
            return View(dtoBooking);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        private BookingDTO ViewModelFromBooking(Booking booking)
        {
            var viewModel = new BookingDTO()
            {
                BookingId = booking.BookingId,
                Name = booking.Name,
                Telephone = booking.Telephone,
                Email = booking.Email,
                Date = booking.Date,
                DateAndTime = booking.DateAndTime,
                BookingTimeId = booking.BookingTimeId
            };

            return viewModel;
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {

            var dtoMod = new BookingDTO()
            {
                BookingTimes = db.BookingTimes.ToList()
            };

            //ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId");
            return View(dtoMod);
        }


        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,Name,Telephone,Email,Date,DateAndTime,DateCreated,BookingTimeId,Time")] BookingDTO bookingDto)
        {

            var bDTo = new Booking()
            {

                BookingId = bookingDto.BookingId,
                Name = bookingDto.Name,
                Telephone = bookingDto.Telephone,
                Email = bookingDto.Email,
                Date = bookingDto.Date,
                DateAndTime = bookingDto.DateAndTime,
                //DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + bookingDto.Time),
                BookingTimeId = bookingDto.BookingTimeId,
                BookingTime = bookingDto.BookingTimes.ToList()
            };

            if (ModelState.IsValid)
            {
                db.Bookings.Add(bDTo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", bTo.BookingTimeId);
            return View("Create", bookingDto);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", booking.BookingTimeId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Name,Telephone,Email,TimeStamp,DateCreated,DateModified,BookingTimeId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", booking.BookingTimeId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromBooking(booking));
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, BookingDTO dDto, Booking booking)
        {
            booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
