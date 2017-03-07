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
            return View(new Message());
        }

        [HttpPost]
        public IActionResult AddNewMessage(Message message)
        {
            Member member = new Member { UserName = "member4", DisplayName = "Tandy", Email = "tandy@woodvale.com" };

            //Message message = new Message { MessageID = id, Title = title, Body = body, Date = DateTime.Now, Topic = topic, User = member };
            message.User = member;
            message.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                messageRepo.Update(message);

                return RedirectToAction("Index", "Messages");
            }
            else
            {
                return View(message);
            }
            
        }

        [HttpGet]
        public ViewResult ReplyToMessage(int id)
        {
            var replyVm = new ReplyViewModel();
            replyVm.MessageID = id;
            replyVm.MessageReply = new Reply();

            return View(replyVm);
        }

        [HttpPost]
        public IActionResult ReplyToMessage(ReplyViewModel replyVm)
        {

            if (replyVm.MessageReply.Body == "")
            {
               ModelState.AddModelError(nameof(replyVm.MessageReply.Body), "Please enter a reply");
           }

            if (ModelState.IsValid)
            {
                Message message = (from m in messageRepo.GetAllMessages()
                                   where m.MessageID == replyVm.MessageID
                                   select m).FirstOrDefault<Message>();

                message.MessageReplies.Add(replyVm.MessageReply);
                messageRepo.Update(message);

                return RedirectToAction("Index", "Messages");
            }
            else
            {
                return View(replyVm);
            }
        }
    }
}
