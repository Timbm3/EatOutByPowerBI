using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Data;
using System.Data.Entity;
using EatOutByBI.Data.Classes;
using EatOutByBI.Domain.Models;

namespace EatOutByBI.Domain.Controllers
{
    public class BookingController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Booking
        public ActionResult Index()
        {

            var booking =  db.Bookings.Include(b => b.BookingTime).ToList();

            return View(booking);
        }

        public ActionResult _PartialBookingTime()
        {
            var bookingTime = db.BookingTimes.ToList();

            return View(bookingTime);
        }

    }
}