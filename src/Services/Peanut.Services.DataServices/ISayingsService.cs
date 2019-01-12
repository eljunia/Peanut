using System.Collections.Generic;
using System.Threading.Tasks;
using Peanut.Data.Models;
using Peanut.Services.Models.Home;
using Peanut.Services.Models.Sayings;

namespace Peanut.Services.DataServices
{
    public interface ISayingsService
    {
        IEnumerable<IndexSayingViewModel> GetRandomSayings(int count);

        int GetCount();

        Task<int> Create(int categoryId, string content);

        TViewModel GetSayingById<TViewModel>(int id);

        IEnumerable<SayingSimpleViewModel> GetAllByCategory(int categoryId);

        bool AddRatingToSaying(int sayingId, int rating);
    }
}
