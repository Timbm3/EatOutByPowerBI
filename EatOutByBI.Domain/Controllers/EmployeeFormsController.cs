using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EmployeeFormsController : Controller
    {
        private EatOutContext db = new EatOutContext();


        private EmployeeFormDTO ViewModelFromEmpForm(EmployeeForm empForm)
        {

            var viewModel = new EmployeeFormDTO()
            {
                EmployeeFormID = empForm.EmployeeFormID,
                EmployeeFormName = empForm.EmployeeFormName,
                EmployeeFormOrderRow = empForm.EmployeeFormOrderRow
            };

            return viewModel;
        }

        // GET: EmployeeForms
        public ActionResult Index()
        {
            var employeeForm = from e in db.EmployeeForms
                               select new EmployeeFormDTO()
                               {
                                   EmployeeFormID = e.EmployeeFormID,
                                   EmployeeFormName = e.EmployeeFormName,
                                   EmployeeFormOrderRow = e.EmployeeFormOrderRow

                               };

            return View(employeeForm);
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
            return View(ViewModelFromEmpForm(employeeForm));
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
        public ActionResult Create([Bind(Include = "EmployeeFormID,EmployeeFormName,EmployeeFormOrderRow,DateCreated,DateModified")]  EmployeeFormDTO empFormDto)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    var employeeForm = new EmployeeForm()
                    {
                        EmployeeFormID = empFormDto.EmployeeFormID,
                        EmployeeFormName = empFormDto.EmployeeFormName,
                        EmployeeFormOrderRow = empFormDto.EmployeeFormOrderRow
                    };
                    db.EmployeeForms.Add(employeeForm);
                    db.SaveChanges();

                    return RedirectToAction("Index", "EmployeeForms");
                }
                return View("Create");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "EmployeeForms", "Create"));
            }

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
            return View(ViewModelFromEmpForm(employeeForm));
        }

        // POST: EmployeeForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeFormID,EmployeeFormName,EmployeeFormOrderRow,DateCreated,DateModified")] EmployeeForm employeeForm, EmployeeFormDTO employeeFormDto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    employeeForm.EmployeeFormID = employeeFormDto.EmployeeFormID;
                    employeeForm.EmployeeFormName = employeeFormDto.EmployeeFormName;
                    employeeForm.EmployeeFormOrderRow = employeeFormDto.EmployeeFormOrderRow;

                    db.Entry(employeeForm).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "EmployeeForms");
                }
                return View("Edit");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeForms", "Edit"));
            }

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
            return View(ViewModelFromEmpForm(employeeForm));
        }

        // POST: EmployeeForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EmployeeForm employeeForm = db.EmployeeForms.Find(id);
                db.EmployeeForms.Remove(employeeForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "EmployeeForms", "Delete"));
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
