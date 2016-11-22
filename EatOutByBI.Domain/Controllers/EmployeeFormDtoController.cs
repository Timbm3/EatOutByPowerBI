using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System.Linq;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EmployeeFormDtoController : Controller
    {

        private EatOutContext db = new EatOutContext();

        // GET: EmployeeFormDto
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

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmployeeFormDTO eDto)
        {
            var dto = new EmployeeForm()
            {

                EmployeeFormName = eDto.EmployeeFormName,
                EmployeeFormOrderRow = eDto.EmployeeFormOrderRow
            };

            db.EmployeeForms.Add(dto);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}