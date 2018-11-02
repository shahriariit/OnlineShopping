using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class ModelController : Controller
    {
        private CopierStoreEntities db = new CopierStoreEntities();

        //
        // GET: /Model/

        public ActionResult Index()
        {
            var models = db.Models.Include(m => m.Brand).Include(m => m.Toner).Include(m => m.Supplier);
            return View(models.ToList());
        }

        //
        // GET: /Model/Details/5

        public ActionResult Details(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Model/Create

        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View();
        }

        //
        // POST: /Model/Create

        [HttpPost]
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                db.Models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.BrandId);
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name", model.TonerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", model.SupplierId);
            return View(model);
        }

        //
        // GET: /Model/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.BrandId);
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name", model.TonerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", model.SupplierId);
            return View(model);
        }

        //
        // POST: /Model/Edit/5

        [HttpPost]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.BrandId);
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name", model.TonerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", model.SupplierId);
            return View(model);
        }

        //
        // GET: /Model/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /Model/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}