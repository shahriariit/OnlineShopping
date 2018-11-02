using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIMLbot;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class ChatBotController : Controller
    {
        //
        // GET: /ChatBot/

        public ActionResult Index()
        {
            ViewBag.Message = "Chat With Alice";
            return View();
        }

        [HttpPost]
        public ActionResult Index(String input) 
        {
            String filePath = Server.MapPath("~/aimlBot/aiml/");
            ViewBag.NP = filePath;
            ChatBot c = new ChatBot(filePath);
            Request r = new Request(input,c.myUser,c.myBot);
            Result res = c.myBot.Chat(r);
            return View("Bot: " + res.Output);
        }

    }
}
