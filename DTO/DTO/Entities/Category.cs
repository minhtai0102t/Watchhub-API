using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string category_name { get; set; }
        public ICollection<SubCategory> subCategories {get;set;}
    }
}