using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class ThreadController : Controller
    {
        //
        // GET: /Thread/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewThreadDetail(int id)
        {
            // load thread from database
            var thread = new Thread() { ThreadId = id, ThreadTitle = "ASP.Net MVC 4", Posts = new List<Post>() };
            // assign ThreadId of New Post
            var newPost = new Post() { PostTitle = "", PostText = "", ThreadId = id };

            return View(new ThreadDetailViewModel() { Thread = thread, NewPost = newPost });
        }
    }
}
