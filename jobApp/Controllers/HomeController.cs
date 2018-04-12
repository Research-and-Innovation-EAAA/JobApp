using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jobApp.Models;
using JobApp.BLL;

namespace jobApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobDBRepository db;
        public HomeController(IJobDBRepository context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var all = db.KompetenceByAnnonceID(1);
            return View(all);
            //return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
