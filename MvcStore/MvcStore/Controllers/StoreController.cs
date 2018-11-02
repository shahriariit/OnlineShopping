using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcStore.Models;
using PagedList;

namespace MvcStore.Controllers
{
    public class StoreController : Controller
    {
        CopierStoreEntities storeDB = new CopierStoreEntities();
        //
        // GET: /Store/


        public ActionResult Index()
        {

            var brands = storeDB.Brands.ToList();
            return View(brands); 
            
         
        }

       public ActionResult Browse(string brand) 
       {
           var brandModel = storeDB.Brands.Include("Models").Single(g => g.Name == brand);
           return View(brandModel);
       }

        public ActionResult Details(int id)
        {

            var model = storeDB.Models.Find(id);
            return View(model);

        }


        public ActionResult Test()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Others(string brand)
        {
            
            var model = storeDB.Models.Take(4).ToList();
            return PartialView(model);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult BrandMenu()
        {
            var genres = storeDB.Brands.ToList();

            return PartialView(genres);
        }

    }
}
