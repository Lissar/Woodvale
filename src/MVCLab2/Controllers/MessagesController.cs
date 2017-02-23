﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageRepository messageRepo;
        

        public MessagesController(IMessageRepository repo)
        {
            messageRepo = repo;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(messageRepo.GetAllMessages().ToList());
        }

        public ViewResult MessagesByTopic(string topic)
        {
            ViewBag.Topic = topic;
            return View("Index", messageRepo.GetAllMessages().
                Where(m => m.Topic == topic).ToList());
        }

        public ViewResult MessagesByMember(string member)
        {
            ViewBag.Member = member;
            return View("Index", messageRepo.GetAllMessages().
                Where(m => m.User.UserName == member).ToList());
        }
    }
}
