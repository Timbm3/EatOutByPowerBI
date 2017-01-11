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
    public class ProductGroupsController : Controller
    {
        private EatOutContext db = new EatOutContext();


        private ProductGroupDTO ViewModelFromProductGroup(ProductGroup pGroup)
        {
            var viewModel = new ProductGroupDTO()
            {
                ProductGroupID = pGroup.ProductGroupID,
                ProductGroupName = pGroup.ProductGroupName,
                ProductGroupOrderRow = pGroup.ProductGroupOrderRow,
                ProductTypeID = pGroup.ProductTypeID,
                ProductTypeName = pGroup.ProductType.ProductTypeName,
                ProductTypes = db.ProductTypes.ToList()
            };
            return viewModel;
        }

        // GET: ProductGroups
        [Authorize]
        public ActionResult Index()
        {
            var productGroup = from pG in db.ProductGroups
                               orderby pG.ProductGroupOrderRow
                               select new ProductGroupDTO()
                               {
                                   ProductGroupID = pG.ProductGroupID,
                                   ProductGroupName = pG.ProductGroupName,
                                   ProductGroupOrderRow = pG.ProductGroupOrderRow,
                                   ProductTypeID = pG.ProductTypeID,
                                   ProductTypeName = pG.ProductType.ProductTypeName
                               };
            //db.ProductGroups.ToList()
            return View(productGroup);
        }

        // GET: ProductGroups/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = db.ProductGroups.Find(id);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductGroup(productGroup));
        }

        // GET: ProductGroups/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            var dtoModel = new ProductGroupDTO()
            {
                ProductTypes = db.ProductTypes.ToList()
            };

            return View(dtoModel);
        }

        // POST: ProductGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductGroupID,ProductGroupName,ProductGroupOrderRow,ProductTypeID")] ProductGroupDTO pGroupDto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var productGroup = new ProductGroup()
                    {
                        ProductGroupName = pGroupDto.ProductGroupName,
                        ProductGroupOrderRow = pGroupDto.ProductGroupOrderRow,
                        ProductTypeID = pGroupDto.ProductTypeID,
                    };
                    db.ProductGroups.Add(productGroup);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ProductGroups");
                }
                else
                {
                    pGroupDto.ProductTypes = db.ProductTypes.ToList();
                    return View("Create", pGroupDto);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ProductGroups", "Create"));
            }

        }

        // GET: ProductGroups/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = db.ProductGroups.Find(id);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductGroup(productGroup));
        }

        // POST: ProductGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductGroupID,ProductGroupName,ProductGroupOrderRow,DateCreated,DateModified")] ProductGroup productGroup, ProductGroupDTO pGroupDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productGroup.ProductGroupID = pGroupDto.ProductGroupID;
                    productGroup.ProductGroupName = pGroupDto.ProductGroupName;
                    productGroup.ProductGroupOrderRow = pGroupDto.ProductGroupOrderRow;
                    productGroup.ProductTypeID = pGroupDto.ProductTypeID;

                    db.Entry(productGroup).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "ProductGroups");
                }
                else
                {
                    pGroupDto.ProductTypes = db.ProductTypes.ToList();
                    return View("Edit", productGroup);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ProductGroups", "Edit"));
            }

        }

        // GET: ProductGroups/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = db.ProductGroups.Find(id);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return View(ViewModelFromProductGroup(productGroup));
        }

        // POST: ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ProductGroup productGroup = db.ProductGroups.Find(id);
                db.ProductGroups.Remove(productGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ProductGroups", "Delete"));
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
