using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewPost(Post newPost)
        {
            return PartialView(newPost);
        }

        public ActionResult Add(Post newPost)
        {
            // add new post to database and redirect to thread detail page
            return RedirectToAction("ViewThreadDetail", "Thread", new { id = newPost.ThreadId });
        }

    }
}
