using System.ComponentModel.DataAnnotations;
using Peanut.Services.Models.Sayings;

namespace Peanut.Web.Model.Sayings
{
    public class CreateSayingInputModel
    {
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
