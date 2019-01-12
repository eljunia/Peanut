using Peanut.Data.Models;
using Peanut.Services.Mapping;

namespace Peanut.Services.Models.Sayings
{
    public class SayingSimpleViewModel : IMapFrom<Saying>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}