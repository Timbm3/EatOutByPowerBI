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
    public class EmployeesDTOController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: EmployeesDTO
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.EmployeeForm).Include(e => e.EmployeeType);
            return View(employees.ToList());
        }

        // GET: EmployeesDTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: EmployeesDTO/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeFormID = new SelectList(db.EmployeeForms, "EmployeeFormID", "EmployeeFormName");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeName");
            return View();
        }

        // POST: EmployeesDTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,EmployeeFormID,EmployeeTypeID,Factor1,Factor2,DateCreated,DateModified")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeFormID = new SelectList(db.EmployeeForms, "EmployeeFormID", "EmployeeFormName", employee.EmployeeFormID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: EmployeesDTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeFormID = new SelectList(db.EmployeeForms, "EmployeeFormID", "EmployeeFormName", employee.EmployeeFormID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // POST: EmployeesDTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,EmployeeFormID,EmployeeTypeID,Factor1,Factor2,DateCreated,DateModified")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeFormID = new SelectList(db.EmployeeForms, "EmployeeFormID", "EmployeeFormName", employee.EmployeeFormID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: EmployeesDTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: EmployeesDTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
