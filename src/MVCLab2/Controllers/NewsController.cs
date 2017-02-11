using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            var news = new List<NewsList>();

            news.Add(new NewsList
            {
                Date = DateTime.Now,
                Title = "Lorem ipsum dolor sit amet",
                Story = "Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            });

            news.Add(new NewsList
            {
                Date = DateTime.Now,
                Title = "Sed ut perspiciatis unde omnis",
                Story = "Iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt."
            });

            ViewBag.News = news;
            return View();
        }

        public ViewResult Today()
        {
            return View();
        }

        public ViewResult Archive()
        {
            return View();
        }
    }
}
