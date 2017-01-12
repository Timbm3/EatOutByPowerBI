using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EatOutByBI.Data.DTO;
using EatOutByBI.Domain.Models;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data;

namespace EatOutByBI.Domain.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private EatOutContext bd = new EatOutContext();


        // GET: Manager
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult EmpDiagrams()
        {

            var users = db.Users.ToList();
            return View(users);
        }


        [Authorize]
        public ActionResult TodaysBookings()
        {
            var today = DateTime.UtcNow;


            string[] convertToBookedId = today.ToString().Split(' ');

            string[] test = convertToBookedId[0].Split('-');

            int finalBookedId = Convert.ToInt32(test[0] + test[1] + test[2]);

            Booked todaysBooked = bd.Bookeds.Find(finalBookedId);

            var testIds = bd.Bookings.Where(b => b.BookedId == finalBookedId);

            ////.GroupBy(b => b.BookedId)
            //.Select(bt => new { Value = bt.Key, Count = bt.Count() })
            //.OrderByDescending(b => b.Count);


            var dtoBooking = from b in bd.Bookings.OrderByDescending(a => a.BookingId).Where(c => c.BookedId == finalBookedId)
                             select new BookingDTO()
                             {
                                 BookingId = b.BookingId,
                                 Name = b.Name,
                                 Telephone = b.Telephone,
                                 Email = b.Email,
                                 Date = b.Date,
                                 DateAndTime = b.DateAndTime,
                                 BookingTimeId = b.BookingTimeId,
                                 BookedId = b.BookedId,                                                                 

                                 //BookingTimes = b.BookingTime.ToList()
                             };

            return View(dtoBooking);
        }

    }
}