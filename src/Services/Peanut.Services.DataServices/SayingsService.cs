using System;
using System.Collections.Generic;
using System.Linq;
using Peanut.Data.Common;
using Peanut.Data.Models;
using Peanut.Services.Models.Home;

namespace Peanut.Services.DataServices
{
    public class SayingsService: ISayingsService
    {
        private readonly IRepository<Saying> sayingsRepository;

        public SayingsService(IRepository<Saying> sayingsRepository)
        {
            this.sayingsRepository = sayingsRepository;
        }

        public IEnumerable<Saying> GetRandomSayings(int count)
        {
            var sayings = this.sayingsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Select(
                    x => new IndexSayingViewModel
                    {
                        Content = x.Content,
                        CategoryName = x.Category.Name,
                    }).Take(count).ToList();

            return sayings;
        }

        public int GetCount()
        {
            return this.sayingsRepository.All().Count();
        }
    }
}
