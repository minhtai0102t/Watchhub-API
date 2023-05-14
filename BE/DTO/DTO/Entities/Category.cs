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
        [Required]
        public int sub_category_id { get; set; }
    }
}