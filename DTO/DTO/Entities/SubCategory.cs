using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("sub_categories")]
    public class SubCategory : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string sub_category_name { get; set; }
        [Required]
        public int category_id { get; set; }
    }
}