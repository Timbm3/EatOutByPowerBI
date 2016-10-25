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
    public class EmployeeFormsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: EmployeeForms
        public ActionResult Index()
        {
            return View(db.EmployeeForms.ToList());
        }

        // GET: EmployeeForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForm employeeForm = db.EmployeeForms.Find(id);
            if (employeeForm == null)
            {
                return HttpNotFound();
            }
            return View(employeeForm);
        }

        // GET: EmployeeForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeFormID,EmployeeFormName,EmployeeFormOrderRow,DateCreated,DateModified")] EmployeeForm employeeForm)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeForms.Add(employeeForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeForm);
        }

        // GET: EmployeeForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForm employeeForm = db.EmployeeForms.Find(id);
            if (employeeForm == null)
            {
                return HttpNotFound();
            }
            return View(employeeForm);
        }

        // POST: EmployeeForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeFormID,EmployeeFormName,EmployeeFormOrderRow,DateCreated,DateModified")] EmployeeForm employeeForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeForm);
        }

        // GET: EmployeeForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeForm employeeForm = db.EmployeeForms.Find(id);
            if (employeeForm == null)
            {
                return HttpNotFound();
            }
            return View(employeeForm);
        }

        // POST: EmployeeForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeForm employeeForm = db.EmployeeForms.Find(id);
            db.EmployeeForms.Remove(employeeForm);
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
