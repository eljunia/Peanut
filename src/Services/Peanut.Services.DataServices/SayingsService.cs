using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peanut.Data.Common;
using Peanut.Data.Models;
//using Peanut.Services.Mapping;
using Peanut.Services.Models.Home;
using Peanut.Services.Models.Sayings;
using Remotion.Linq.Utilities;

namespace Peanut.Services.DataServices
{
    public class SayingsService : ISayingsService
    {
        private readonly IRepository<Saying> sayingsRepository;
        private readonly IRepository<Category> categoriesRepository;

        public SayingsService(
            IRepository<Saying> sayingsRepository,
            IRepository<Category> categoriesRepository)
        {
            this.sayingsRepository = sayingsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IndexSayingViewModel> GetRandomJokes(int count)
        {
            var sayings = this.sayingsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .To<IndexSayingViewModel>().Take(count).ToList();

            return sayings;
        }

        public int GetCount()
        {
            return this.sayingsRepository.All().Count();
        }

        public async Task<int> Create(int categoryId, string content)
        {
            var saying = new Saying
            {
                CategoryId = categoryId,
                Content = content,
            };

            await this.sayingsRepository.AddAsync(saying);
            await this.sayingsRepository.SaveChangesAsync();

            return saying.Id;
        }

        public TViewModel GetJokeById<TViewModel>(int id)
        {
            var saying = this.sayingsRepository.All().Where(x => x.Id == id)
                .To<TViewModel>().FirstOrDefault();
            return saying;
        }

        public IEnumerable<SayingSimpleViewModel> GetAllByCategory(int categoryId)
            => this.sayingsRepository
                    .All()
                    .Where(j => j.CategoryId == categoryId)
                    .To<SayingSimpleViewModel>();

        public bool AddRatingToSaying(int sayingId, int rating)
        {
            var saying = this.sayingsRepository.All().FirstOrDefault(j => j.Id == sayingId);
            if (saying != null)
            {
                saying.Rating += rating;
                this.sayingsRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
