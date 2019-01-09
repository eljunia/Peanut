using System.Collections.Generic;
using Peanut.Data.Models;

namespace Peanut.Services.DataServices
{
    public interface ISayingsService
    {
        IEnumerable<Saying> GetRandomSayings(int count);

        int GetCount();
    }
}