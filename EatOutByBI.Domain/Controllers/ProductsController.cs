using EatOutByBI.Data;
using EatOutByBI.Data.Classes;
using EatOutByBI.Data.DTO;
using PagedList;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class ProductsController : Controller
    {
        private EatOutContext db = new EatOutContext();


        private ProductDTO ViewModelFromProducts(Product product)
        {
            var viewModel = new ProductDTO()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Amount = product.Amount,
                Unit = product.Unit,
                ProductGroups = db.ProductGroups.ToList(),
                ProductGroupName = product.ProductGroup.ProductGroupName,
                ProductTypeName = product.ProductGroup.ProductType.ProductTypeName,
                ProductGroupID = product.ProductGroupID
            };
            return viewModel;
        }


        // GET: Products
        [Authorize]
        #region OriginalIndex

        //public ActionResult Index()
        //{
        //    //var products = db.Products.Include(p => p.ProductGroup).Include(p => p.ProductGroup.ProductType);
        //    //return View(products.ToList());
        //    var product = from e in db.Products
        //                  select new ProductDTO()
        //                  {
        //                      ProductID = e.ProductID,
        //                      ProductName = e.ProductName,
        //                      UnitPrice = e.UnitPrice,


        //                      ProductGroupName = e.ProductGroup.ProductGroupName,
        //                      ProductTypeName = e.ProductGroup.ProductType.ProductTypeName,

        //                      //Amount = e.Amount,
        //                      //Unit = e.Unit
        //                  };

        //    return View(product);
        //}
        #endregion
        public ActionResult Index(string sortOrder, int? page)
        {
            //var products = db.Products.Include(p => p.ProductGroup).Include(p => p.ProductGroup.ProductType);
            //return View(products.ToList());

            ViewBag.CurrentSort = sortOrder;

            ViewBag.ProductNameSortParam = String.IsNullOrEmpty(sortOrder) ? "ProductName" : "";

            ViewBag.UnitPriceSortParam =
                sortOrder == "UnitPrice" ? "unitprice_desc" : "UnitPrice";

            ViewBag.ProductGroupSortParam =
                sortOrder == "ProductGroup" ? "productgroup_desc" : "ProductGroup";

            ViewBag.ProductTypeSortParam =
                sortOrder == "ProductType" ? "producttype_desc" : "ProductType";


            #region ViewModel           
            var product = from e in db.Products
                          select new ProductDTO()
                          {
                              ProductID = e.ProductID,
                              ProductName = e.ProductName,
                              UnitPrice = e.UnitPrice,


                              ProductGroupName = e.ProductGroup.ProductGroupName,
                              ProductTypeName = e.ProductGroup.ProductType.ProductTypeName,

                              ProductGroupID = e.ProductGroupID,
                              ProductTypeID = e.ProductGroup.ProductTypeID
                              //Amount = e.Amount,
                              //Unit = e.Unit
                          };
            #endregion


            #region Switch

            switch (sortOrder)
            {
                case "ProductName":
                    product = product.OrderByDescending(p => p.ProductName);
                    break;

                case "UnitPrice":
                    product = product.OrderBy(p => p.UnitPrice);
                    break;
                case "unitprice_desc":
                    product = product.OrderByDescending(p => p.UnitPrice);
                    break;

                case "ProductGroup":
                    product = product.OrderBy(p => p.ProductGroupName);
                    break;
                case "productgroup_desc":
                    product = product.OrderByDescending(p => p.ProductGroupName);
                    break;

                case "ProductType":
                    product = product.OrderBy(p => p.ProductTypeName);
                    break;
                case "producttype_desc":
                    product = product.OrderByDescending(p => p.ProductTypeName);
                    break;



                default:
                    product = product.OrderBy(p => p.ProductName);
                    break;
            }

            #endregion


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));

            //return View(product);
        }

        // GET: Products/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProducts(product));
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            //ViewBag.ProductGroupID = new SelectList(db.ProductGroups, "ProductGroupID", "ProductGroupName");
            //return View();

            var dtoModel = new ProductDTO()
            {
                ProductGroups = db.ProductGroups.ToList()
            };
            return View(dtoModel);

        }



        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,OrderRowID,UnitPrice,ProductTypeID,ProductGroupID,DateCreated,DateModified")] ProductDTO pDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product()
                    {
                        ProductName = pDto.ProductName,
                        ProductGroupID = pDto.ProductGroupID,
                        UnitPrice = pDto.UnitPrice
                    };

                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    pDto.ProductGroups = db.ProductGroups.ToList();
                    return View("Create", pDto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Products", "Create"));
            }



        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(ViewModelFromProducts(product));
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Products", "Edit"));
            }

        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,OrderRowID,UnitPrice,ProductTypeID,ProductGroupID,DateCreated,DateModified")] Product prd, ProductDTO pDto)
        {
            if (ModelState.IsValid)
            {
                prd.ProductID = pDto.ProductID;
                prd.ProductName = pDto.ProductName;
                prd.ProductGroupID = pDto.ProductGroupID;

                db.Entry(prd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            else
            {
                pDto.ProductGroups = db.ProductGroups.ToList();
                return View(prd);
            }



        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProducts(product));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Products", "Delete"));
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
