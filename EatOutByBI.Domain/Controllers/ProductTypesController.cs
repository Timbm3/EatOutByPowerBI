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
    public class ProductTypesController : Controller
    {
        private EatOutContext db = new EatOutContext();

        private ProductTypeDTO ViewModelFromProductType(ProductType pType)
        {
            var viewModel = new ProductTypeDTO()
            {
                ProductTypeID = pType.ProductTypeID,
                ProductTypeName = pType.ProductTypeName,
                ProductTypeOrderRow = pType.ProductTypeOrderRow,
            };
            return viewModel;
        }

        // GET: ProductTypes
        [Authorize]
        public ActionResult Index()
        {
            var productType = from pT in db.ProductTypes
                              orderby pT.ProductTypeOrderRow
                              select new ProductTypeDTO()
                              {
                                  ProductTypeID = pT.ProductTypeID,
                                  ProductTypeName = pT.ProductTypeName,
                                  ProductTypeOrderRow = pT.ProductTypeOrderRow,
                              };
            //db.ProductTypes.ToList()
            return View(productType);
        }

        // GET: ProductTypes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductType(productType));
        }

        // GET: ProductTypes/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create([Bind(Include = "ProductTypeID,ProductTypeName,ProductTypeOrderRow,DateCreated,DateModified")] ProductTypeDTO pTypeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productType = new ProductType()
                    {
                        ProductTypeName = pTypeDto.ProductTypeName,
                        ProductTypeOrderRow = pTypeDto.ProductTypeOrderRow,
                        ProductTypeID = pTypeDto.ProductTypeID,
                    };
                    db.ProductTypes.Add(productType);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ProductTypes");
                }
                else
                {
                    return View("Create", pTypeDto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ProductTypes", "Create"));
            }
        }

        // GET: ProductTypes/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductType(productType));
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductTypeID,ProductTypeName,ProductTypeOrderRow,DateCreated,DateModified")] ProductType productType, ProductTypeDTO pTypeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productType.ProductTypeID = pTypeDto.ProductTypeID;
                    productType.ProductTypeName = pTypeDto.ProductTypeName;
                    productType.ProductTypeOrderRow = pTypeDto.ProductTypeOrderRow;

                    db.Entry(productType).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "ProductTypes");
                }
                else { return View("Edit", productType); }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ProductTypes", "Edit"));
            }
        }

        // GET: ProductTypes/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductType(productType));
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ProductType productType = db.ProductTypes.Find(id);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "ProductTypes", "Delete"));
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
