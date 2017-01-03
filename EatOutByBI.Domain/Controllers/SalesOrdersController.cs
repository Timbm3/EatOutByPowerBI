﻿using System;
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
    public class SalesOrdersController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: SalesOrders
        public ActionResult Index()
        {
            var salesOrders = db.SalesOrders.Include(s => s.Employee).Include(s => s.PaymentMethod).Include(s => s.Seat);
            return View(salesOrders.ToList());
        }

        // GET: SalesOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "PaymentMethodId", "PaymentMethodType");
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatPlace");
            return View();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesOrderId,CustomerName,SeatId,EmployeeId,PaymentMethodId,DateTime,DateCreated,DateModified,Factor1,Factor2,TimeStamp")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrders.Add(salesOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", salesOrder.EmployeeId);
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "PaymentMethodId", "PaymentMethodType", salesOrder.PaymentMethodId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatPlace", salesOrder.SeatId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", salesOrder.EmployeeId);
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "PaymentMethodId", "PaymentMethodType", salesOrder.PaymentMethodId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatPlace", salesOrder.SeatId);
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesOrderId,CustomerName,SeatId,EmployeeId,PaymentMethodId,DateTime,DateCreated,DateModified,Factor1,Factor2,TimeStamp")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", salesOrder.EmployeeId);
            ViewBag.PaymentMethodId = new SelectList(db.PaymentMethods, "PaymentMethodId", "PaymentMethodType", salesOrder.PaymentMethodId);
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatPlace", salesOrder.SeatId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(salesOrder);
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
