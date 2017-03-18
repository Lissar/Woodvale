using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models.Repositories;
using MVCLab2.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageRepository messageRepo;
        private UserManager<User> userManager;


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
        [Authorize(Roles = "User")]
        public ViewResult AddNewMessage()
        {
            return View(new Message());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMessage(Message message)
        {
            string body = message.Body;
            if (string.IsNullOrEmpty(body) || body.IndexOf(" ", System.StringComparison.Ordinal) < 1)
            {
                string prop = "Body";
                ModelState.AddModelError(prop, "Please enter at least two words");
            }

            string name = HttpContext.User.Identity.Name;
            message.User = await userManager.FindByNameAsync(name);
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
        [Authorize(Roles = "User")]
        public ViewResult ReplyToMessage(int id)
        {
            var replyVm = new ReplyViewModel();
            replyVm.MessageID = id;
            replyVm.MessageReply = new Reply();

            return View(replyVm);
        }

        [HttpPost]
        public async Task<IActionResult> ReplyToMessage(ReplyViewModel replyVm)
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
                string name = HttpContext.User.Identity.Name;
                message.User = await userManager.FindByNameAsync(name);
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
