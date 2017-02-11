using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class MapController : Controller
    {
        // GET: /<controller>/
        public ViewResult Map()
        {
            return View();
        }
    }
}
