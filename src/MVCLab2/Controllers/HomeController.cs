using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models;
using MVCLab2.Models.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class HomeController : Controller
    {
        private IMemberRepository memberRepo;
        // GET: /<controller>/

        public HomeController(IMemberRepository repo)
        {
            memberRepo = repo;
        }

        public ViewResult Index()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
        }

        public ViewResult Members()
        {
            return View(memberRepo.GetAllMembers().ToList());
        }
    }
}
