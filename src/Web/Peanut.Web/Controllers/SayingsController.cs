using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peanut.Services.DataServices;
//using Peanut.Services.MachineLearning;
using Peanut.Services.Models.Sayings;
using Peanut.Web.Model.Sayings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Peanut.Web.Controllers
{
    public class SayingsController : BaseController
    {
        private readonly ISayingsService sayingsService;
        private readonly ICategoriesService categoriesService;
//        private readonly ISayingsCategorizer sayingsCategorizer;

        public SayingsController(
            ISayingsService sayingsService,
            ICategoriesService categoriesService)
 //           ISayingsCategorizer sayingsCategorizer)
        {
            this.sayingsService = sayingsService;
            this.categoriesService = categoriesService;
 //           this.sayingsCategorizer = sayingsCategorizer;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameAndCount,
                });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSayingInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.sayingsService.Create(input.CategoryId, input.Content);
            return this.RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var saying = this.sayingsService.GetSayingById<SayingDetailsViewModel>(id);
            return this.View(saying);
        }

 /*       [HttpPost]
        public SuggestCategoryResult SuggestCategory(string saying)
        {
            var category = this.sayingsCategorizer.Categorize("MlModels/SayingsCategoryModel.zip", saying);
            var categoryId = this.categoriesService.GetCategoryId(category);
            return new SuggestCategoryResult { CategoryId = categoryId ?? 0, CategoryName = category };
        }

        [HttpPost]
        public object RateSaying(int sayingId, int rating)
        {
            var rateSaying = this.sayingsService.AddRatingToSaying(sayingId, rating);
            if (!rateSaying)
            {
                return Json($"An error occurred while processing your vote");
            }
            var successMessage = $"You successfully rated the saying with rating of {rating}";
            return Json(successMessage);
        }
    }

    public class SuggestCategoryResult
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }*/
    }
}