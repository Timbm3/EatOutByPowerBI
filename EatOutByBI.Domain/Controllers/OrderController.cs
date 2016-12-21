using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class OrderController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Employee).Include(o => o.Seat).Include(o => o.TimeTable);
            //var Dto = new OrderDTO();
            //var orders = Dto.OrderRowDtos.ToList();
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


        // GET: Order/Create
        public ActionResult Create(OrderRowDTO oDto)
        {
            var viewModel = new OrderDTO()
            {
                Employees = db.Employees.ToList(),
                Seats = db.Seats.ToList(),
                ProduktNamn = oDto.ProduktNamn,
                Kvantitet = oDto.Kvantitet,
            };
            var viewModel2 = new OrderRowDTO()
            {
                Products = oDto.Products,
            };
            return View(viewModel);
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,SeatID,EmployeeID,TimeTableID,DateCreated,DateModified,Factor1,Factor2,TimeStamp")] OrderDTO oDto, OrderRow orderRow)
        {
            var order = new Order()
            {
                OrderID = oDto.OrderID,
                EmployeeID = oDto.EmployeeID,
                SeatID = oDto.SeatID,
                TimeTableID = oDto.TimeTableID,

            };
            var orderRow2 = new OrderRow()
            {
                ProductID = orderRow.ProductID,
                //Product = orderRow.Product,
                Kvantitet = orderRow.Kvantitet
            };

            db.Orders.Add(order);
            db.OrderRows.Add(orderRow2);
            db.SaveChanges();

            return RedirectToAction("Index", "Order");
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", order.EmployeeID);
            ViewBag.SeatID = new SelectList(db.Seats, "SeatID", "SeatPlace", order.SeatID);
            ViewBag.TimeTableID = new SelectList(db.TimeTables, "TimeTableID", "MonthName", order.TimeTableID);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,SeatID,EmployeeID,TimeTableID,DateCreated,DateModified,Factor1,Factor2,TimeStamp")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Name", order.EmployeeID);
            ViewBag.SeatID = new SelectList(db.Seats, "SeatID", "SeatPlace", order.SeatID);
            ViewBag.TimeTableID = new SelectList(db.TimeTables, "TimeTableID", "MonthName", order.TimeTableID);
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
