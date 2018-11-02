using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIMLbot;

namespace MvcStore.Models
{
    public class ChatBot
    {
        public Bot myBot {get; set;}
        public User myUser {get;set;}

        public ChatBot(string filepath)
        {
            myBot = new Bot();
            myBot.loadSettings("C:\\Users\\Setu\\Desktop\\MvcStore\\MvcStore\\aimlBot\\aiml");
            myUser = new User("Human", myBot);
            Initialize(filepath);
        }

        private void Initialize(string filepath)
        {
            AIMLbot.Utils.AIMLLoader loader = new AIMLbot.Utils.AIMLLoader(this.myBot);
            myBot.isAcceptingUserInput = false;
            //loader.loadAIML(filepath);
            myBot.loadAIMLFromFiles();
            myBot.isAcceptingUserInput = true;
        }

     
    }
}