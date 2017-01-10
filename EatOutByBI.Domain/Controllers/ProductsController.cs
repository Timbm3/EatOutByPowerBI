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
                ProductTypeName = product.ProductGroup.ProductType.ProductTypeName
            };
            return viewModel;
        }


        // GET: Products
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.ProductGroup).Include(p => p.ProductGroup.ProductType);
            //return View(products.ToList());
            var product = from e in db.Products
                          select new ProductDTO()
                          {
                              ProductID = e.ProductID,
                              ProductName = e.ProductName,
                              UnitPrice = e.UnitPrice,


                              ProductGroupName = e.ProductGroup.ProductGroupName,
                              ProductTypeName = e.ProductGroup.ProductType.ProductTypeName,

                              //Amount = e.Amount,
                              //Unit = e.Unit
                          };

            return View(product);
        }

        // GET: Products/Details/5
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
        public ActionResult Create([Bind(Include = "ProductID,ProductName,OrderRowID,ProductTypeID,ProductGroupID,DateCreated,DateModified")] ProductDTO pDto)
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,OrderRowID,ProductTypeID,ProductGroupID,DateCreated,DateModified")] Product prd, ProductDTO pDto)
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
