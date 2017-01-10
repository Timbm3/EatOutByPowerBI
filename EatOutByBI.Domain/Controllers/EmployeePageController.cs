using EatOutByBI.Data;
using EatOutByBI.Data.DTO;
using System.Linq;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class EmployeePageController : Controller
    {
        private EatOutContext db = new EatOutContext();


        // GET: EmployeePage
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult ListEmployees()
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

    }
}