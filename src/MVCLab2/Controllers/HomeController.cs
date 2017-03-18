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
        public ViewResult Index()
        {
            var userVm = new UserViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userVm.UserName = HttpContext.User.Identity.Name;
                userVm.Authenticated = true;
            }
            return View(userVm);
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
            return View();
        }
    }
}
