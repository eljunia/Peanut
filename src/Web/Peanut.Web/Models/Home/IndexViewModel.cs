using System.Collections.Generic;

namespace Peanut.Web.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexSayingViewModel> Sayings { get; set; }
    }
}
