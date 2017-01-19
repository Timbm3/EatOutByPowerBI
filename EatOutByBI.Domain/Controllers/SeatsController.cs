using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class SeatsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Seats

        private SeatDTO ViewModelFromSeats(Seat seat)
        {
            var viewModel = new SeatDTO()
            {
                SeatID = seat.SeatID,
                SeatPlace = seat.SeatPlace
            };
            return viewModel;
        }
        [Authorize]

        public ActionResult Index()
        {
            var seat = from s in db.Seats
                       select new SeatDTO()
                       {
                           SeatID = s.SeatID,
                           SeatPlace = s.SeatPlace
                       };

            return View(seat);
        }

        // GET: Seats/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromSeats(seat));
        }

        // GET: Seats/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeatID,SeatPlace,DateCreated,DateModified,Factor1,Factor2")] SeatDTO seatDto)
        {
            if (ModelState.IsValid)
            {
                var seat = new Seat()
                {
                    SeatID = seatDto.SeatID,
                    SeatPlace = seatDto.SeatPlace
                };

                db.Seats.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Index", "Seats");
            }
            else
            {

                return View("Create", seatDto);
            }


        }

        // GET: Seats/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromSeats(seat));
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeatID,SeatPlace,DateCreated,DateModified,Factor1,Factor2")] Seat seat, SeatDTO sDto)
        {



            if (ModelState.IsValid)
            {
                seat.SeatID = sDto.SeatID;
                seat.SeatPlace = sDto.SeatPlace;


                db.Entry(seat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Seats");
            }
            else
            {
                return View("Edit", sDto);
            }

        }

        // GET: Seats/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromSeats(seat));
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seat seat = db.Seats.Find(id);
            db.Seats.Remove(seat);
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
