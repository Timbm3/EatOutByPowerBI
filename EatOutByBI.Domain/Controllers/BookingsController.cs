using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace EatOutByBI.Domain.Controllers
{
    public class BookingsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Bookings
        [Authorize]
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
        [Authorize]
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


        //Get: Bookings/PreCreate
        public ActionResult BookingsPreCreate()
        {

            //var testIds = db.BookingTimes.Where(b => b.IsAvailable == false).OrderBy(bt => bt.BookedId);


            //var testusString = JsonConvert.SerializeObject(testus);
            //ViewBag.testusString = testusString;


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
                )] BookingDTO bookingDto, BookingTime bT, int id, string date)
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
                    BookingTime.AddDefaultTimes(bookingDto, finalBookedId, bT);


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
        public async System.Threading.Tasks.Task<ActionResult> BookingsCreate([Bind(Include = "BookingId,Name,Telephone,Email,Date,DateAndTime,DateCreated,BookingTimeId,Time,AvailableSeats,NrOfPeople,BookedId")] BookingDTO bookingDto, int id)
        {


            int finalBookedId = BookingDTO.ConvertDateFiledToBookedId(bookingDto);


            //var dateExists = db.Bookeds.Any(d => d.DateAndTime == converToDatAndTime);

            var idExists = db.Bookeds.Any(d => d.BookedId == finalBookedId);

            var converToDatAndTime = Convert.ToDateTime(bookingDto.Date + " " + bookingDto.Time);


            //Mapping Dto values to Booking Values
            Booking bDTo = BookingDTO.DtoMappToBooking(bookingDto, finalBookedId, converToDatAndTime);


            Booked boooked = db.Bookeds.Find(finalBookedId);

            Booked test = db.Bookeds.Find(id);

            var getTimeForBookingDate = db.BookingTimes.Where(b => b.BookedId == finalBookedId && b.Time == bDTo.Time);

            bool doubleCheckAvailableSeats = true;

            foreach (var item in getTimeForBookingDate)
            {
                if (item.AvailableSeats < 0)
                {
                    doubleCheckAvailableSeats = false;
                }

            }



            #region reCaptcha

            // Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LfPcxIUAAAAABUG7Ra6l9Wpps-rMrKqrrTLqwlX";
            // ANDRA NYCKEL HÄR / SECRET KEY
            var client = new WebClient();
            var result = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");



            #endregion

            // status = reCaptcha
            if (ModelState.IsValid && status)
            {

                db.Bookings.Add(bDTo);

                var idForBt = db.BookingTimes.Find(bookingDto.BookingTimeId);
                idForBt.AvailableSeats -= bookingDto.NrOfPeople;

                //db.Entry(boooked).State = EntityState.Modified;
                db.Entry(idForBt).State = EntityState.Modified;

                db.SaveChanges();

                //Thread.Sleep(5000);



                try
                {
                    #region Email


                    var body = "<p>Hej {0}!</p><p>Detta är en bekräftelse av din bokning hos Restaurang EatOut för {1} personer den {2} .</p><p>Välkommen!</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(bookingDto.Email));  // replace with valid value 
                    message.From = new MailAddress("EatOut040@outlook.com");  // replace with valid value
                    message.Subject = "EatOut: Bokat Bord";
                    message.Body = string.Format(body, bookingDto.Name, bookingDto.NrOfPeople, converToDatAndTime);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "EatOut040@outlook.com",  // replace with valid value
                            Password = "Eatout17"  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);

                        return RedirectToAction("BookingsIndex");

                        //return RedirectToAction("Sent");
                    }
                    
                    #endregion
                }
                catch (Exception)
                {
                    return View(bookingDto);
                }


                //return RedirectToAction("BookingsIndex");

            }

            //ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", bTo.BookingTimeId);

            //Thread.Sleep(5000);
            return View(bookingDto);
        }


        // GET: Bookings/Edit/5
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Name,Telephone,Email,BookingTimeId,BokedId,Date,DateAndTime,DateCreated,NrOfPeople,Time")] Booking booking, BookingDTO bDto)
        {

            Booking boooking = db.Bookings.Find(booking.BookingId);

            try
            {

                if (booking.BookingId == boooking.BookingId)
                {
                    boooking.Name = bDto.Name;
                    boooking.NrOfPeople = bDto.NrOfPeople;
                    boooking.Telephone = bDto.Telephone;
                    boooking.Date = bDto.Date;
                    boooking.Time = bDto.Time;
                    boooking.DateAndTime = bDto.DateAndTime;

                    var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));



                    db.Entry(boooking).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BookingsIndex");
                }
                else
                {
                    ViewBag.BookingTimeId = new SelectList(db.BookingTimes, "BookingTimeId", "BookingTimeId", booking.BookingTimeId);
                    return View(booking);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Bookings", "Edit"));
            }


        }

        // GET: Bookings/Delete/5
        [Authorize]
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
            return View(ViewModelFromBookingEdit(booking));
        }

        // POST: Bookings/Delete/5
        [Authorize]
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
                Booked = booking.Bookeds.ToList(),

            };

            return viewModel;
        }

        private BookingDTO ViewModelFromBookingEdit(Booking booking)
        {
            var viewModel = new BookingDTO()
            {
                BookingId = booking.BookingId,
                Name = booking.Name,
                Telephone = booking.Telephone,
                Email = booking.Email,
                Date = booking.Date,
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


        public JsonResult GetNonAvailableDates()
        {
            //var testIds = db.BookingTimes
            //    .Where(b => b.IsAvailable == false)
            //    .GroupBy(b => b.BookedId)
            //    .Select(bt => new { Value = bt.Key, Count = bt.Count() })
            //    .OrderByDescending(b => b.Count);

            //List<string> nonAvailableDates = new List<string>() { };

            //foreach (var item in testIds)
            //{
            //    if (item.Count >= 1)
            //    {

            //        nonAvailableDates.Add(item.Value.ToString());
            //    };
            //};
            //nonAvailableDates.ToArray();

            var testIds = db.BookingTimes
                .Where(b => b.IsAvailable == false)
                .GroupBy(b => b.BookedId)
                .Select(bt => new { Value = bt.Key, Count = bt.Count() })
                .OrderByDescending(b => b.Count);

            List<string> nonAvaDates = new List<string>() { };

            foreach (var item in testIds)
            {
                Booked notAvailable = db.Bookeds.Find(item.Value);
                //item.Count >= notAvailable.BookingTimes.Count()
                if (item.Count >= 3)
                {
                    //Booked notAvailable = db.Bookeds.Find(item.Value);

                    notAvailable.IsDateAvailable = false;

                    nonAvaDates.Add(notAvailable.BookedId.ToString());
                };
            };


            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(nonAvaDates);

            var deserializedResult = serializer.Deserialize<List<string>>(serializedResult);

            return new JsonResult { Data = nonAvaDates, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
