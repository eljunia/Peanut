using Peanut.Data.Common;

namespace Peanut.Data.Models
{
    public class Saying : BaseModel<int>
    {
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public double Rating { get; set; }
        public int RatingVotes { get; set; }
        public virtual Category Category { get; set; }
    }
}
