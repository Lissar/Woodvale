using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Messages()
        {
            var repo = new MessageRepository();
            var messages = repo.GetMessages();
            return View(messages);
        }

        
    }
}
