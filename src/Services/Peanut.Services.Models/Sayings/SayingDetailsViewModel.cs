using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Data.Models;
using Peanut.Services.Mapping;

namespace Peanut.Services.Models.Sayings
{
    public class SayingDetailsViewModel : IMapFrom<Saying>
    {
        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}

