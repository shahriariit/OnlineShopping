using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcStore.Models;


namespace MvcStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private CopierStoreEntities db = new CopierStoreEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var models = db.Models.Include(m => m.Brand).Include(m => m.Toner).Include(m => m.Supplier);
            return View(models.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Model model = db.Models.Find(id);
            return View(model);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

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
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Model model = db.Models.Find(id);
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", model.BrandId);
            ViewBag.TonerId = new SelectList(db.Toners, "TonerId", "Name", model.TonerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", model.SupplierId);
            return View(model);
        }

        //
        // POST: /StoreManager/Edit/5
        Object obj;

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
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Model model = db.Models.Find(id);
            return View(model);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Import()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult EntryView()
        { 
           return View();
        }

        public ActionResult Importexcel()
        {
            if (Request.Files["FileUpload1"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName);
                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["FileUpload1"].FileName);
                if (System.IO.File.Exists(path1))
                    System.IO.File.Delete(path1);

                string sqlConnectionString = @"Data Source=SHAHRIAR\SQLEXPRESS;Database=MvcStore.Models.CopierStoreEntities;Trusted_Connection=true;Persist Security Info=True";

                Request.Files["FileUpload1"].SaveAs(path1);


                string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";

                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", excelConnection);
                excelConnection.Open();
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();

                SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
                sqlBulk.DestinationTableName = "Models";
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();

                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult ImportTonerexcel()
        {
            if (Request.Files["FileUpload2"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload2"].FileName);
                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["FileUpload2"].FileName);
                if (System.IO.File.Exists(path1))
                    System.IO.File.Delete(path1);

                string sqlConnectionString = @"Data Source=SHAHRIAR\SQLEXPRESS;Database=MvcStore.Models.CopierStoreEntities;Trusted_Connection=true;Persist Security Info=True";

                Request.Files["FileUpload2"].SaveAs(path1);


                string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";

                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet2$]", excelConnection);
                excelConnection.Open();
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();

                SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
                sqlBulk.DestinationTableName = "Toners";
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();

                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [ChildActionOnly]
        public ActionResult AdminMenu()
        {
            return PartialView();
        }

        /*
          MvcStore.Models.CopierStoreEntities db=new MvcStore.Models.CopierStoreEntities();
    var dbdata = from c in db.Models select new {c.Title ,c.Price};
    var myChart = new Chart(width:1000, height: 800)
   .AddTitle("Product Sales")
   .AddSeries(chartType: "Pie",
      xValue: dbdata, xField: "Title",
      yValues: dbdata, yFields: "Price")
   .Write();
         */

        public ActionResult CustomerView()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}