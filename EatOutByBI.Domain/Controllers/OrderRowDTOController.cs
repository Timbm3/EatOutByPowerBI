using EatOutByBI.Data;
using EatOutByBI.Data.DTO;
using EatOutByBI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EatOutByBI.Data.Classes;

namespace EatOutByBI.Domain.Controllers
{
    public class OrderRowDTOController : Controller
    {

        private EatOutContext db = new EatOutContext();
        private OrderRowDTO or = new OrderRowDTO();
        private OrderRowViewModel orW = new OrderRowViewModel();
        private IList<OrderRowDTO> orList = new List<OrderRowDTO>();
        //private OrderRowDTO AllDto()
        //{
        //    var model = new List<OrderRowDTO>()
        //    {

        //    };
        //    return model;
        //}


        // GET: OrderRowDTO
        public ActionResult Index(OrderRowDTO oDto)
        {
            //var list = from e in db.OrderRows
            //           select new OrderRowDTO()
            //           {
            //               OrderRowID = e.OrderRowID,
            //               ProductID = e.ProductID,
            //               ProduktNamn = e.Product.ProductName
            //           };

            //var list = or.Products.ToList();
            //var model = new List<OrderRowDTO>();
            //oDto.ProductID = or.ProductID;


            //model.Add(oDto);

            //ViewBag.ListProducts = db.Products.ToList();


            return View(orList.ToList());
        }

        //public ActionResult ShowProduct()
        //{
        //    return View(db.Products.ToList());
        //}


        //public ActionResult Remove(int id)
        //{



        //db.OrderRows.Remove(id);
        //db.SaveChanges();
        //return PartialView()
        //}


            // GET
        public ActionResult AddProduct()
        {
            
            var viewModel = new OrderRowDTO()
            {
                Products = db.Products.ToList()

            };

            return View(viewModel);
        }

        // POST
        [HttpPost]
        public ActionResult AddProduct(OrderRowDTO oRDto)
        {

            orList.Add(oRDto);
        }

    }
}