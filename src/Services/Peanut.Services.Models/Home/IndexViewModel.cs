using System.Collections.Generic;

namespace Peanut.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexSayingViewModel> Sayings { get; set; }
    }
}
