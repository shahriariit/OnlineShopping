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
    public class TonerController : Controller
    {
        private CopierStoreEntities db = new CopierStoreEntities();

        //
        // GET: /Toner/

        public ActionResult Index()
        {
            return View(db.Toners.ToList());
        }

        //
        // GET: /Toner/Details/5

        public ActionResult Details(int id = 0)
        {
            Toner toner = db.Toners.Find(id);
            if (toner == null)
            {
                return HttpNotFound();
            }
            return View(toner);
        }

        //
        // GET: /Toner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Toner/Create

        [HttpPost]
        public ActionResult Create(Toner toner)
        {
            if (ModelState.IsValid)
            {
                db.Toners.Add(toner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toner);
        }

        //
        // GET: /Toner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Toner toner = db.Toners.Find(id);
            if (toner == null)
            {
                return HttpNotFound();
            }
            return View(toner);
        }

        //
        // POST: /Toner/Edit/5

        [HttpPost]
        public ActionResult Edit(Toner toner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toner);
        }

        //
        // GET: /Toner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Toner toner = db.Toners.Find(id);
            if (toner == null)
            {
                return HttpNotFound();
            }
            return View(toner);
        }

        //
        // POST: /Toner/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Toner toner = db.Toners.Find(id);
            db.Toners.Remove(toner);
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