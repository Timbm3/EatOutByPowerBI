﻿using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EmployeesController : Controller
    {
        private EatOutContext db = new EatOutContext();



        private EmployeeDTO ViewModelFromEmployee(Employee employee)
        {
            var viewModel = new EmployeeDTO()
            {
                EmployeeId = employee.EmployeeID,
                EmployeeName = employee.EmployeeName,
                EmployeeFormID = employee.EmployeeFormID,
                EmployeeTypeID = employee.EmployeeTypeID,
                FormName = employee.EmployeeForm.EmployeeFormName,
                TypeName = employee.EmployeeType.EmployeeTypeName,
                EmployeeForms = db.EmployeeForms.ToList(),
                EmployeeTypes = db.EmployeeTypes.ToList(),


            };
            return viewModel;
        }


        // GET: Employees
        [Authorize]
        public ActionResult Index()
        {
            var employee = from e in db.Employees
                           select new EmployeeDTO()
                           {
                               EmployeeId = e.EmployeeID,
                               EmployeeName = e.EmployeeName,
                               FormName = e.EmployeeForm.EmployeeFormName,
                               TypeName = e.EmployeeType.EmployeeTypeName
                           };

            return View(employee);
        }

        // GET: Employees/Details/5
        [Authorize]
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
            return View(ViewModelFromEmployee(employee));
        }

        // GET: Employees/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            var dtoModel = new EmployeeDTO()
            {
                EmployeeForms = db.EmployeeForms.ToList(),
                EmployeeTypes = db.EmployeeTypes.ToList()
            };

            return View(dtoModel);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,EmployeeFormID,EmployeeTypeID,DateCreated,DateModified")] EmployeeDTO eDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        EmployeeName = eDto.EmployeeName,
                        EmployeeFormID = eDto.EmployeeFormID,
                        EmployeeTypeID = eDto.EmployeeTypeID,

                    };

                    db.Employees.Add(employee);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    eDto.EmployeeForms = db.EmployeeForms.ToList();
                    eDto.EmployeeTypes = db.EmployeeTypes.ToList();
                    return View("Create", eDto);
                }
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Employees", "Create"));
            }
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "Admin,Manager")]
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

            return View(ViewModelFromEmployee(employee));
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "EmployeeID,EmployeeName,EmployeeFormID,EmployeeTypeID,DateCreated,DateModified")] Employee emp,
            EmployeeDTO eDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emp.EmployeeID = eDto.EmployeeId;
                    emp.EmployeeName = eDto.EmployeeName;
                    emp.EmployeeFormID = eDto.EmployeeFormID;
                    emp.EmployeeTypeID = eDto.EmployeeTypeID;
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    eDto.EmployeeForms = db.EmployeeForms.ToList();
                    eDto.EmployeeTypes = db.EmployeeTypes.ToList();

                    return View("Edit", eDto);

                }
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Employees", "Edit"));
            }
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "Admin,Manager")]
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
            return View(ViewModelFromEmployee(employee));
        }

        // POST: Employees/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Employees", "Delete"));
            }
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
