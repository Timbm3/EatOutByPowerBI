﻿using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EmployeesDTOController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: EmployeesDTO
        public ActionResult Index()
        {
            var employee = from e in db.Employees
                           select new EmployeeDTO()
                           {
                               EmployeeID = e.EmployeeID,
                               Name = e.Name,
                               FormName = e.EmployeeForm.EmployeeFormName,
                               TypeName = e.EmployeeType.EmployeeTypeName
                           };

            return View(employee);
        }



        public ActionResult Show()
        {
            var employee = from e in db.Employees
                           select new EmployeeDTO()
                           {
                               EmployeeID = e.EmployeeID,
                               Name = e.Name,
                               FormName = e.EmployeeForm.EmployeeFormName,
                               TypeName = e.EmployeeType.EmployeeTypeName
                           };

            return View(employee);

        }

        private EmployeeDTO ViewModelFromEmployee(Employee employee)
        {
            var viewModel = new EmployeeDTO()
            {
                EmployeeID = employee.EmployeeID,
                Name = employee.Name,
                EmployeeFormID = employee.EmployeeFormID,
                EmployeeTypeID = employee.EmployeeTypeID,
                FormName = employee.EmployeeForm.EmployeeFormName,
                TypeName = employee.EmployeeType.EmployeeTypeName,
                EmployeeForms = db.EmployeeForms.ToList(),
                EmployeeTypes = db.EmployeeTypes.ToList(),


            };
            return viewModel;
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


            var dtoModel = new EmployeeDTO()
            {
                EmployeeForms = db.EmployeeForms.ToList(),
                EmployeeTypes = db.EmployeeTypes.ToList()
            };

            return View(dtoModel);
        }

        // POST: EmployeesDTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,EmployeeFormID,EmployeeTypeID,Factor1,Factor2,DateCreated,DateModified")]EmployeeDTO eDto)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Name = eDto.Name,
                        EmployeeFormID = eDto.EmployeeFormID,
                        EmployeeTypeID = eDto.EmployeeTypeID,

                    };

                    db.Employees.Add(employee);
                    db.SaveChanges();

                    return RedirectToAction("Index", "EmployeesDTO");
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

                return View("Error", new HandleErrorInfo(ex, "EmployeesDTO", "Create"));
            }

        }

        // GET: EmployeesDTO/Edit/5
        public ActionResult Edit(int? id, EmployeeDTO eDto)
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



        // POST: EmployeesDTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,EmployeeFormID,EmployeeTypeID,Factor1,Factor2,DateCreated,DateModified")] EmployeeDTO eDto, Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emp.EmployeeID = eDto.EmployeeID;
                    emp.Name = eDto.Name;
                    emp.EmployeeFormID = eDto.EmployeeFormID;
                    emp.EmployeeTypeID = eDto.EmployeeTypeID;
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "EmployeesDTO");
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

                return View("Error", new HandleErrorInfo(ex, "EmployeesDTO", "Edit"));
            }

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
            return View(ViewModelFromEmployee(employee));
        }

        // POST: EmployeesDTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, EmployeeDTO eDto, Employee emp)
        {

            try
            {
                emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "EmployeesDTO", "Delete"));
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
