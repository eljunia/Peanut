using AutoMapper;
using Peanut.Data.Models;
using Peanut.Services.Mapping;

namespace Peanut.Services.Models.Home
{
    public class IndexSayingViewModel : IMapFrom<Saying>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string HtmlContent => this.Content.Replace("\n", "<br />\n");

        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            // configuration.CreateMap<Saying, IndexSayingsViewModel>().ForMember(x => x.CategoryName, x => x.MapFrom(j => j.Category.Name))
        }
    }
}