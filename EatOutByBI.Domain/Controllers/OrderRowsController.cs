using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class OrderRowsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: OrderRows
        public ActionResult Index()
        {
            var orderRows = db.OrderRows.Include(o => o.Product);
            return View(orderRows.ToList());
        }

        // GET: OrderRows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRows.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            return View(orderRow);
        }

        // GET: OrderRows/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: OrderRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderRowID,ProductID,Kvantitet,DateCreated,DateModified")] OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                db.OrderRows.Add(orderRow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderRow.ProductID);
            return View(orderRow);
        }

        // GET: OrderRows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRows.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderRow.ProductID);
            return View(orderRow);
        }

        // POST: OrderRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderRowID,ProductID,Kvantitet,DateCreated,DateModified")] OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", orderRow.ProductID);
            return View(orderRow);
        }

        // GET: OrderRows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRow orderRow = db.OrderRows.Find(id);
            if (orderRow == null)
            {
                return HttpNotFound();
            }
            return View(orderRow);
        }

        // POST: OrderRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRow orderRow = db.OrderRows.Find(id);
            db.OrderRows.Remove(orderRow);
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
