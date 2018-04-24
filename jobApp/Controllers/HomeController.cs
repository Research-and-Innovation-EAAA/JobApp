using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jobApp.Models;
using JobApp.BLL;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

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
            var reg = db.AllRegions();
            var all = db.KompetenceByAnnonceID(6);

            return View(reg);
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

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
