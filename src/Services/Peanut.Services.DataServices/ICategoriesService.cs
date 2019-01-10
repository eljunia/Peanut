using System.Collections.Generic;
using System.Text;
using Peanut.Services.Models.Categories;

namespace Peanut.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        int? GetCategoryId(string name);
    }
}
