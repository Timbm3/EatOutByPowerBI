using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private EatOutContext db = new EatOutContext();

        // GET: PaymentMethods

        private PaymentMethodDTO ViewModelFromPaymentMethod(PaymentMethod paymentMethod)
        {
            var viewModel = new PaymentMethodDTO()
            {
                PaymentMethodId = paymentMethod.PaymentMethodId,
                PaymentMethodType = paymentMethod.PaymentMethodType
            };

            return viewModel;
        }

        public ActionResult Index()
        {

            var paymentMethods = from p in db.PaymentMethods
                                 select new PaymentMethodDTO()
                                 {
                                     PaymentMethodId = p.PaymentMethodId,
                                     PaymentMethodType = p.PaymentMethodType
                                 };

            return View(paymentMethods);
        }

        // GET: PaymentMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromPaymentMethod(paymentMethod));
        }

        // GET: PaymentMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMethodId,PaymentMethodType,Factor1,Factor2")] PaymentMethodDTO pDto)
        {
            if (ModelState.IsValid)
            {
                var paymentMethod = new PaymentMethod()
                {
                    PaymentMethodId = pDto.PaymentMethodId,
                    PaymentMethodType = pDto.PaymentMethodType
                };


                db.PaymentMethods.Add(paymentMethod);
                db.SaveChanges();
                return RedirectToAction("Index", "PaymentMethods");
            }
            else
            {
                return View("Create", pDto);
            }


        }

        // GET: PaymentMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromPaymentMethod(paymentMethod));
        }

        // POST: PaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMethodId,PaymentMethodType,Factor1,Factor2")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromPaymentMethod(paymentMethod));
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentMethod paymentMethod = db.PaymentMethods.Find(id);
            db.PaymentMethods.Remove(paymentMethod);
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
