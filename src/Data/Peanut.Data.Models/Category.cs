using Peanut.Data.Common;
using System.Collections.Generic;

namespace Peanut.Data.Models
{
    public class Category: BaseModel<int>
    {
        public Category() {
            this.Sayings = new HashSet<Saying>();
        }

        public string Name { get; set; }

        public virtual ICollection<Saying> Sayings { get; set; }
    }
}
