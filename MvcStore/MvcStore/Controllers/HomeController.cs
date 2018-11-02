using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIMLbot;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class HomeController : Controller
    {
       
        CopierStoreEntities storeDB = new CopierStoreEntities();

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Location()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        } 

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Community()
        {
            return View();
        }

        public ActionResult BkashView() {
            return View();
        }

 
        [ChildActionOnly]
        public ActionResult CustomerMessage()
        { 
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Payment()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Shipping()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Condition()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Faq()
        {
            return PartialView();
        }

        private List<Model> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Models
            .OrderByDescending(a => a.OrderDetails.Count())
            .Take(count)
            .ToList();
        }

    }
}
