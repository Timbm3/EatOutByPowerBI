using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Domain.viewModels;
using PagedList;
using System;
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


        [Authorize]
        //public ActionResult Index()
        //{
        //    //return View(_salesContext.SalesOrders.ToList());
        //    var salesOrders = from so in _salesContext.SalesOrders
        //                      orderby so.DateTime descending
        //                      select new SalesOrderViewModel()
        //                      {
        //                          SalesOrderId = so.SalesOrderId,
        //                          CustomerName = so.CustomerName,
        //                          DateTime = so.DateTime,
        //                          EmployeeName = so.Employee.EmployeeName,
        //                          SeatPlace = so.Seat.SeatPlace,
        //                      };

        //    return View(salesOrders);
        //}
        public ActionResult Index(string searchString, string employeeId, string date, string seat, string between, string currentFilter, int? page, string sortOrder, int? pagesize)
        {
            //, int pageSize = 30
            //int pageSize;
            #region Paged

            //ViewBag.PageParam = pageSize == 30 ? 60 : 30;
            //ViewBag.Page2Param = pageSize == 60 ? 30 : 60;



            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.EmployeeSortParam = sortOrder == "Employee" ? "employee_desc" : "Employee";
            ViewBag.SeatSortParam = sortOrder == "Seat" ? "seat_desc" : "Seat";


            //String.IsNullOrEmpty(sortOrder)

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            #endregion

            ViewBag.EmployeeId = new SelectList(_salesContext.Employees, "EmployeeID", "EmployeeName");
            ViewBag.SeatID = new SelectList(_salesContext.Seats, "SeatID", "SeatPlace");

            var salesOrders = from so in _salesContext.SalesOrders
                                  //orderby so.DateTime descending
                              select new SalesOrderViewModel()
                              {
                                  SalesOrderId = so.SalesOrderId,
                                  CustomerName = so.CustomerName,
                                  DateTime = so.DateTime,
                                  EmployeeName = so.Employee.EmployeeName,
                                  SeatPlace = so.Seat.SeatPlace,
                                  EmployeeID = so.EmployeeID,
                                  SeatID = so.SeatID

                              };

            #region SearchFilterIfs

            if (!String.IsNullOrEmpty(searchString))
            {
                salesOrders = salesOrders.Where(s => s.CustomerName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(date))
            {
                DateTime searchDate;
                if (DateTime.TryParse(date, out searchDate))
                {

                    if (String.IsNullOrEmpty(between))
                    {
                        var myDatePlus = searchDate.AddDays(1);
                        salesOrders = salesOrders
                            .Where(h => h.DateTime >= searchDate && h.DateTime < myDatePlus);
                    }
                    if (!String.IsNullOrEmpty(between))
                    {
                        DateTime searchDate2;
                        if (DateTime.TryParse(between, out searchDate2))
                        {
                            salesOrders = salesOrders
                        .Where(h => h.DateTime >= searchDate && h.DateTime < searchDate2);

                        }

                    }

                    //.Where(DbFunctions.TruncateTime(s.) == searchDate);
                    // do not use .Equals() which can not be converted to SQL
                }

            }



            if (!String.IsNullOrEmpty(employeeId))
            {
                int ei = Convert.ToInt32(employeeId);
                salesOrders = salesOrders.Where(s => s.EmployeeID == ei);
                //return View(salesOrders.ToList());
            }
            if (!String.IsNullOrEmpty(seat))
            {
                int si = Convert.ToInt32(seat);
                salesOrders = salesOrders.Where(s => s.SeatID == si);
                //return View(salesOrders.ToList());
            }

            #endregion

            else


                #region Switch
                switch (sortOrder)
                {
                    case "Name":
                        salesOrders = salesOrders.OrderBy(s => s.CustomerName);
                        break;
                    case "name_desc":
                        salesOrders = salesOrders.OrderByDescending(s => s.CustomerName);
                        break;

                    case "Employee":
                        salesOrders = salesOrders.OrderBy(s => s.EmployeeName);
                        break;
                    case "employee_desc":
                        salesOrders = salesOrders.OrderByDescending(s => s.EmployeeName);
                        break;

                    case "Seat":
                        salesOrders = salesOrders.OrderBy(s => s.SeatPlace);
                        break;
                    case "seat_desc":
                        salesOrders = salesOrders.OrderByDescending(s => s.SeatPlace);
                        break;




                    case "Date":
                        salesOrders = salesOrders.OrderBy(s => s.DateTime);
                        break;
                    default:
                        salesOrders = salesOrders.OrderByDescending(s => s.DateTime);
                        break;
                }

            #endregion

            #region pagesize
            int pageSize = pagesize ?? 5;






            //        List<SelectListItem> items = new List<SelectListItem>{
            //  new SelectListItem{ Text="5", Value="5" },
            //  new SelectListItem{ Text="10", Value="10" }
            //};


            //ViewBag.CurrentPageSize = pageSize;
            //ViewBag.PageSizeList = new SelectList(items, "Value", "Text", pagesize);


            #endregion

            //int pageSize = 3;

            int pageNumber = (page ?? 1);
            return View(salesOrders.ToPagedList(pageNumber, pageSize));

            //return View(salesOrders);

            //.ToList()
        }




        // GET: Sales/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
            salesOrderViewModel.ObjectState = ObjectState.Added;
            return View(salesOrderViewModel);
        }


        // GET: Sales/Edit/5
        [Authorize]
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
        [Authorize]
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

        [Authorize]
        public JsonResult GetSeats()
        {
            List<Seat> seats = new List<Seat>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            seats = _salesContext.Seats.OrderBy(a => a.SeatPlace).ToList();
            //}
            return new JsonResult { Data = seats, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize]
        public JsonResult GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //using (EatOutContext dc = new EatOutContext())
            //{
            employees = _salesContext.Employees.OrderBy(a => a.EmployeeName).ToList();
            //}
            return new JsonResult { Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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
