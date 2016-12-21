using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using EatOutByBI.Domain.Models;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Ast.Selectors;

namespace EatOutByBI.Domain.Controllers
{
    public class BookingsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Bookings
        public ActionResult BookingsIndex()
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
        public ActionResult BookingsDetails(int? id)
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


        //Get: /Bookings/Test
        public ActionResult _BookingsPreCreatePartial(int id)
        {
            Booked booked = db.Bookeds.Find(id);


            var testQuery = from bt in db.BookingTimes
                            where bt.BookedId == id
                            select bt;



            var dtoMod = new BookingDTO()
            {
                //BookingTimes = booked.BookingTimes.ToList(),
                BookingTimes = testQuery.ToList(),
                Booked = new[] { booked },
                Booking = db.Bookings.ToList(),
                //BookedId = id,
                //Date = date,
                IsAvailable = true

            };

            return PartialView(dtoMod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _BookingsPreCreatePartial(
    [Bind(
                Include =
                    "BookingId,Name,Telephone,Email,Date,DateAndTime,DateCreated,BookingTimeId,Time,AntalPersoner,AntalPlatser,Plats,Pers,BookedId"
                )] BookingDTO bookingDto, int id, string date)
        {
            var stringConvertBookedId = bookingDto.Date;

            string[] splitBookedId = stringConvertBookedId.Split('/');

            int finalBookedId = Convert.ToInt32(splitBookedId[0] + splitBookedId[1] + splitBookedId[2]);
            //finalBookedId = Convert.ToInt32(splitBookedId[0] + splitBookedId[1] + splitBookedId[2]);

            var idExists = db.Bookeds.Any(d => d.BookedId == finalBookedId);

            id = finalBookedId;

            Booked teestt = db.Bookeds.Find(id);



            Booked boooked = db.Bookeds.Find(finalBookedId);

            if (!idExists)
            {
                var time1 = "17:00:00";
                var time2 = "19:00:00";
                var time3 = "21:00:00";

                List<BookingTime> bookingTimes = new List<BookingTime>()
                    {
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time1,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        },
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time2,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        },
                        new BookingTime()
                        {
                            BookedId = finalBookedId,
                            Time = time3,
                            Date = bookingDto.Date,
                            DateAndTime = Convert.ToDateTime(bookingDto.Date + " " + time1)
                        }
                    };

                foreach (var bookingTime in bookingTimes)
                {
                    //bookingTime.Plats -= bookingDto.Pers;
                    db.BookingTimes.Add(bookingTime);
                }

                boooked = new Booked()
                {
                    BookedId = finalBookedId,
                    //DateAndTime = converToDatAndTime,
                    BookingTimes = bookingTimes.ToList(),

                };

                //boooked.Plats -= bookingDto.Pers;


                db.Bookeds.Add(boooked);
                db.SaveChanges();

                return RedirectToAction("BookingsCreate", "Bookings", new { id = finalBookedId, date = bookingDto.Date });

            }


            return RedirectToAction("BookingsCreate", "Bookings", new { id = finalBookedId, date = bookingDto.Date });

        }




        //Get: Bookings/PreCreate
        public ActionResult BookingsPreCreate()
        {
            //var testQuery = from bt in db.BookingTimes
            //                where bt.BookedId == bt.BookedId
            //                select bt;


            var dtoMod = new BookingDTO()
            {
                BookingTimes = db.BookingTimes.ToList(),
                //Booked = db.Bookeds.ToList(),
                Booked = db.Bookeds.ToList(),
                Booking = db.Bookings.ToList()
            };


            return View(dtoMod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingsPreCreate(
            [Bind(
                Include =
                    "BookingId,Name,Telephone,Email,Date,DateAndTime,DateCreated,BookingTimeId,Time,AvailableSeats,NrOfPeople,BookedId"
                )] BookingDTO bookingDto, int id, string date)
        {
            int finalBookedId = BookingDTO.ConvertDateFiledToBookedId(bookingDto);

            var idExists = db.Bookeds.Any(d => d.BookedId == finalBookedId);

            id = finalBookedId;

            Booked teestt = db.Bookeds.Find(id);


            Booked boooked = db.Bookeds.Find(finalBookedId);

            if (!idExists)
            {
                //Creates list with default values
                List<BookingTime> bookingTimes =
                    BookingTime.AddDefaultTimes(bookingDto, finalBookedId);

                foreach (var bookingTime in bookingTimes)
                {
                    db.BookingTimes.Add(bookingTime);
                }

                boooked = new Booked()
                {
                    BookedId = finalBookedId,
                    //Adding custom list to Booked
                    BookingTimes = bookingTimes.ToList(),

                };


                db.Bookeds.Add(boooked);
                db.SaveChanges();

                return RedirectToAction("BookingsCreate", "Bookings", new { id = finalBookedId, date = bookingDto.Date });

            }

            //return PartialView("_BookingsPreCreatePartial",  new { id = finalBookedId, date = bookingDto.Date });


            return RedirectToAction("BookingsCreate", "Bookings", new { id = finalBookedId, date = bookingDto.Date });

        }


        // GET: Bookings/Create

        public ActionResult BookingsCreate(int id, string date)
        {

            Booked booked = db.Bookeds.Find(id);


            var testQuery = from bt in db.BookingTimes
                            where bt.BookedId == id
                            select bt;



            var dtoMod = new BookingDTO()
            {
                //BookingTimes = booked.BookingTimes.ToList(),
                BookingTimes = testQuery.ToList(),
                Booked = new[] { booked },
                Booking = db.Bookings.ToList(),
                //BookedId = id,
                Date = date,
                IsAvailable = true

            };


            return View(dtoMod);
        }


        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingsCreate([Bind(Include = "BookingId,Name,Telephone,Email,Date,DateAndTime,DateCreated,BookingTimeId,Time,AvailableSeats,NrOfPeople,BookedId")] BookingDTO bookingDto, int id)
        {



            var converToDatAndTime = Convert.ToDateTime(bookingDto.Date + " " + bookingDto.Time);


            //Mapping Dto values to Booking Values
            Booking bDTo = BookingDTO.DtoMappToBooking(bookingDto, converToDatAndTime);


            int finalBookedId = BookingDTO.ConvertDateFiledToBookedId(bookingDto);

            //var dateExists = db.Bookeds.Any(d => d.DateAndTime == converToDatAndTime);

            var idExists = db.Bookeds.Any(d => d.BookedId == finalBookedId);


            Booked boooked = db.Bookeds.Find(finalBookedId);

            Booked test = db.Bookeds.Find(id);



            if (ModelState.IsValid)
            {
                db.Bookings.Add(bDTo);

                var idForBt = db.BookingTimes.Find(bookingDto.BookingTimeId);
                idForBt.AvailableSeats -= bookingDto.NrOfPeople;

                //db.Entry(boooked).State = EntityState.Modified;
                db.Entry(idForBt).State = EntityState.Modified;



                db.SaveChanges();
                Thread.Sleep(5000);
                return RedirectToAction("BookingsIndex");
            }

            //ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", bTo.BookingTimeId);
            Thread.Sleep(5000);
            return View(bookingDto);
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
                return RedirectToAction("BookingsIndex");
            }
            ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", booking.BookingTimeId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult BookingsDelete(int? id)
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
        [HttpPost, ActionName("BookingsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, BookingDTO dDto, Booking booking)
        {
            booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("BookingsIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
                BookingTimeId = booking.BookingTimeId,
                //Booked = booking.Bookeds.ToList(),
                //Booked = booking.Booked,
                BookingTimes = booking.BookingTime.ToList(),
                Booked = booking.Bookeds.ToList()
            };

            return viewModel;
        }


        private BookingDTO ViewModelFromBooked(Booked booked)
        {
            var viewModel = new BookingDTO()
            {
                BookedId = booked.BookedId,
                BookingTimes = booked.BookingTimes.ToList()

            };

            return viewModel;
        }
    }
}
