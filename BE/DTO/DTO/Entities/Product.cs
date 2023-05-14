using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Required]
        public int inventory { get; set; }
        [Required]
        [MaxLength]
        public string product_name { get; set; }
        [Required]
        [MaxLength]
        public string product_description { get; set; }
        [Required]
        public int product_type_id { get; set; }
        [Required]
        public List<int> product_image_ids { get; set; }
        [Required]
        public int brand_id { get; set; }
        [Required]
        public List<int> product_feedback_ids { get; set; }
    }
}

