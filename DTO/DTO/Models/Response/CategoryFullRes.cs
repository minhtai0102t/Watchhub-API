using Ecom_API.DTO.Models;

namespace Ecom_API.DTO.Entities
{
    public class CategoryFullRes : BaseEntity
    {
        public string category_name { get; set; }
        public ICollection<SubCategoryMapperShort> subCategories {get;set;}
    }
    public class SubCategoryMapperShort{
        public int id {get;set;}
        public string sub_category_name { get; set; }
    }
}