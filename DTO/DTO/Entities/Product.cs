using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        public string? product_source;
        public string? product_guarantee; 
        public string? product_dial_width; 
        public string? product_dial_height; 
        public string? product_dial_color; 
        public string? product_waterproof; 
        public string? product_features; 
        public string? product_additional_information; 
        [Required]
        public int product_type_id { get; set; }
        [Required]
        public int product_albert_id { get; set; }
        [Required]
        public int product_core_id { get; set; }
        [Required]
        public int product_glass_id { get; set; }
    }
}

