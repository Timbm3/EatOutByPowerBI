using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EventController : Controller
    {
        private EatOutContext db = new EatOutContext();
        // GET: Event
        public ActionResult EventIndex()
        {
            var upcomingEvents = db.Events.Include(e => e.EventType).Where(e => e.DateTime > DateTime.Now);

            return View(upcomingEvents);
        }

        public ActionResult EmployeeEventIndex()
        {
            var upcomingEvents = db.EmployeeEvents.Include(e => e.EmployeeEventType).Where(e => e.DateTime > DateTime.Now);

            return View(upcomingEvents);
        }


        // GET: Event

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateEvent()
        {
            var viewModel = new EventViewModel
            {
                EventTypes = db.EventTypes.ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(EventViewModel viewModel, HttpPostedFileBase image1)
        {
            if (!ModelState.IsValid)
            {
                viewModel.EventTypes = db.EventTypes.ToList();
                return View("CreateEvent", viewModel);
            }
            if (image1 != null)
            {
                viewModel.Image = new byte[image1.ContentLength];
                image1.InputStream.Read(viewModel.Image, 0, image1.ContentLength);
            }
            var event1 = new Event()
            {
                Description = viewModel.Description,
                CreatedId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                EventTypeId = viewModel.EventType,
                NameOfEvent = viewModel.NameOfEvent,
                Image = viewModel.Image,
                FinnishTime = viewModel.GetEndTime()
            };


            db.Events.Add(event1);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateEmployeeEvent()
        {
            var viewModel = new EmployeeEventViewModel()
            {
                EmployeeEventTypes = db.EmployeeEventTypes.ToList()
            };

            return View(viewModel);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployeeEvent(EmployeeEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.EmployeeEventTypes = db.EmployeeEventTypes.ToList();
                return View("CreateEmployeeEvent", viewModel);
            }

            var event1 = new EmployeeEvent()
            {
                Description = viewModel.Description,
                CreatedId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                EmployeeEventTypeId = viewModel.EmployeeEventType,
                NameOfEvent = viewModel.NameOfEvent,
            };


            db.EmployeeEvents.Add(event1);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
