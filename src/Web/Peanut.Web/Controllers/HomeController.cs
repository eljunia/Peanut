using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Peanut.Data.Common;
using Peanut.Data.Models;
using Peanut.Services.DataServices;
using Peanut.Services.Models.Home;
using Peanut.Web.Models;

namespace Peanut.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISayingsService sayingsService;

        public HomeController(ISayingsService sayingsService)
        {
            this.sayingsService = sayingsService;
        }

        public IActionResult Index()
        {
            var sayings = this.sayingsService.GetRandomSayings(20);

            var viewModel = new IndexViewModel
            {
                Sayings = sayings,
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"My application has {this.sayingsService.GetCount()} sayings.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
