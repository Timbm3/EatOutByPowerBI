using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Domain.viewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class SalesController : Controller
    {
        private EatOutContext _salesContext = new EatOutContext();

        public SalesController()
        {
            _salesContext = new EatOutContext();
        }

        // GET: Sales
        public ActionResult Index()
        {
            //return View(_salesContext.SalesOrders.ToList());
            var salesOrders = from so in _salesContext.SalesOrders
                              orderby so.DateTime descending
                              select new SalesOrderViewModel()
                              {
                                  SalesOrderId = so.SalesOrderId,
                                  CustomerName = so.CustomerName,
                                  DateTime = so.DateTime,
                                  EmployeeName = so.Employee.EmployeeName,
                                  SeatPlace = so.Seat.SeatPlace,
                              };

            return View(salesOrders);


        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }


            SalesOrderViewModel salesOrderViewModel =
                viewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);

            salesOrderViewModel.MessageToClient = "I originated from the viewModel, rather than the Model.";
            salesOrderViewModel.SeatPlace = salesOrder.Seat.SeatPlace;
            salesOrderViewModel.EmployeeName = salesOrder.Employee.EmployeeName;

            //salesOrderViewModel.PaymentMethodType = salesOrder.PaymentMethod.PaymentMethodType;


            return View(salesOrderViewModel);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
            salesOrderViewModel.ObjectState = ObjectState.Added;
            return View(salesOrderViewModel);
        }


        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            SalesOrderViewModel salesOrderViewModel =
                viewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = string.Format
                ("The original value of Customer name is {0}.", salesOrderViewModel.CustomerName);
            //salesOrderViewModel.SeatPlace = salesOrder.Seat.SeatPlace;
            //salesOrderViewModel.EmployeeName = salesOrder.Employee.EmployeeName;
            //salesOrderViewModel.PaymentMethods = salesOrder.PaymentMethod.PaymentMethods;



            return View(salesOrderViewModel);
        }

        public JsonResult GetProducts()
        {
            List<Product> products = new List<Product>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            products = _salesContext.Products.OrderBy(a => a.ProductName).ToList();
            //}
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //public JsonResult OptionProducts()
        //{
        //    List<Product> products = new List<Product>();
        //    products = _salesContext.Products.ToList();
        //    return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
        public JsonResult GetSeats()
        {
            List<Seat> seats = new List<Seat>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            seats = _salesContext.Seats.OrderBy(a => a.SeatPlace).ToList();
            //}
            return new JsonResult { Data = seats, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            employees = _salesContext.Employees.OrderBy(a => a.EmployeeName).ToList();
            //}
            return new JsonResult { Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetPaymentMethods()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            paymentMethods = _salesContext.PaymentMethods.OrderBy(a => a.PaymentMethodType).ToList();
            //}
            return new JsonResult { Data = paymentMethods, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            SalesOrderViewModel salesOrderViewModel =
                viewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = string.Format
                ("You are about the permantly delete this sales order.");
            salesOrderViewModel.ObjectState = ObjectState.Deleted;


            return View(salesOrderViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _salesContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Save(SalesOrderViewModel salesOrderViewModel)
        {
            SalesOrder salesOrder = viewModels.Helpers.CreateSalesOrderFromSalesOrderViewModel(salesOrderViewModel);

            _salesContext.SalesOrders.Attach(salesOrder);

            if (salesOrder.ObjectState == ObjectState.Deleted)
            {
                foreach (SalesOrderItemViewModel salesOrderItemViewModel in salesOrderViewModel.SalesOrderItems)
                {
                    SalesOrderItem salesOrderItem = _salesContext.SalesOrderItems.Find(salesOrderItemViewModel.SalesOrderItemId);
                    if (salesOrderItem != null)
                    {
                        salesOrderItem.ObjectState = ObjectState.Deleted;
                    }
                }
            }
            else
            {
                foreach (int salesOrderItemId in salesOrderViewModel.SalesOrderItemsToDelete)
                {
                    SalesOrderItem salesOrderItem = _salesContext.SalesOrderItems.Find(salesOrderItemId);
                    if (salesOrderItem != null)
                    {
                        salesOrderItem.ObjectState = ObjectState.Deleted;
                    }
                }
            }




            _salesContext.ApplyStateChanges();
            _salesContext.SaveChanges();

            if (salesOrder.ObjectState == ObjectState.Deleted)
                return Json(new { newLocation = "/Sales/Index/" });

            string messageToClient = viewModels.Helpers.GetMessageToClient(salesOrderViewModel.ObjectState, salesOrder.CustomerName);
            salesOrderViewModel = viewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = messageToClient;

            return Json(new { newLocation = "/Sales/Index/" });
        }
    }
}
