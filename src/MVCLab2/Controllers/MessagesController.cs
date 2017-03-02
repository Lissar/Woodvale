using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models.Repositories;
using MVCLab2.Models;
using System;

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

        [HttpGet]
        public ViewResult AddNewMessage()
        {
            var newMessage = new Message();

            return View(newMessage);
        }

        [HttpPost]
        public IActionResult AddNewMessage(int id, string topic, string title, string body)
        {
            Member member = new Member { UserName = "member4", DisplayName = "Tandy", Email = "tandy@woodvale.com" };

            Message message = new Message { MessageID = id, Title = title, Body = body, Date = DateTime.Now, Topic = topic, User = member };
            messageRepo.Update(message);

            return RedirectToAction("Index", "Messages");
        }

        [HttpGet]
        public ViewResult ReplyToMessage(int id)
        {
            var messageReply = new ReplyViewModel();
            messageReply.MessageID = id;
            messageReply.MessageReply = new Models.Reply();


            return View(messageReply);
        }

        [HttpPost]
        public IActionResult ReplyToMessage(ReplyViewModel messageReply)
        {
            Message message = (from m in messageRepo.GetAllMessages()
                         where m.MessageID == messageReply.MessageID
                         select m).FirstOrDefault<Message>();

            message.MessageReplies.Add(messageReply.MessageReply);
            messageRepo.Update(message);

            return RedirectToAction("Index", "Messages");
        }
    }
}
