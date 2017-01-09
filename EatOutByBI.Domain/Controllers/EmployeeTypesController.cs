using EatOutByBI.Data;
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
    public class EmployeeTypesController : Controller
    {
        private EatOutContext db = new EatOutContext();

        private EmployeeTypeDTO ViewModelFromEmpType(EmployeeType empType)
        {

            var viewModel = new EmployeeTypeDTO()
            {
                EmployeeTypeID = empType.EmployeeTypeID,
                EmployeeTypeName = empType.EmployeeTypeName,
                EmployeeTypeOrderRow = empType.EmployeeTypeOrderRow
            };

            return viewModel;
        }


        // GET: EmployeeTypes
        public ActionResult Index()
        {
            var employeeType = from e in db.EmployeeTypes
                               orderby e.EmployeeTypeOrderRow
                               select new EmployeeTypeDTO()
                               {
                                   EmployeeTypeID = e.EmployeeTypeID,
                                   EmployeeTypeName = e.EmployeeTypeName,
                                   EmployeeTypeOrderRow = e.EmployeeTypeOrderRow

                               };

            return View(employeeType);
        }

        // GET: EmployeeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromEmpType(employeeType));
        }

        // GET: EmployeeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeTypeID,EmployeeTypeName,EmployeeTypeOrderRow,DateCreated,DateModified")] EmployeeTypeDTO empTypeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employeeType = new EmployeeType()
                    {
                        EmployeeTypeID = empTypeDto.EmployeeTypeID,
                        EmployeeTypeName = empTypeDto.EmployeeTypeName,
                        EmployeeTypeOrderRow = empTypeDto.EmployeeTypeOrderRow
                    };
                    db.EmployeeTypes.Add(employeeType);
                    db.SaveChanges();

                    return RedirectToAction("Index", "EmployeeTypes");
                }
                return View("Create");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "EmployeeTypes", "Create"));
            }
        }

        // GET: EmployeeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeTypeID,EmployeeTypeName,EmployeeTypeOrderRow,DateCreated,DateModified")] EmployeeTypeDTO employeeTypeDto, EmployeeType employeeType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeType.EmployeeTypeID = employeeTypeDto.EmployeeTypeID;
                    employeeType.EmployeeTypeName = employeeTypeDto.EmployeeTypeName;
                    employeeType.EmployeeTypeOrderRow = employeeTypeDto.EmployeeTypeOrderRow;

                    db.Entry(employeeType).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "EmployeeTypes");
                }
                return View("Edit");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeTypes", "Edit"));
            }
        }

        // GET: EmployeeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromEmpType(employeeType));
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            db.EmployeeTypes.Remove(employeeType);
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
