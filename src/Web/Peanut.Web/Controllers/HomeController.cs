using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Peanut.Data.Common;
using Peanut.Data.Models;
using Peanut.Web.Models;
using Peanut.Web.Models.Home;

namespace Peanut.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Saying> sayingsRepository;

        public HomeController(IRepository<Saying> sayingsRepository)
        {
            this.sayingsRepository = sayingsRepository;
        }


        public IActionResult Index()
        {
            var sayings = this.sayingsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(
                x => new IndexSayingViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name,
                });

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
