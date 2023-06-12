using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        public string product_source { get; set; }
        public string product_guarantee { get; set; }
        public string product_dial_width { get; set; }
        public string product_dial_height { get; set; }
        public string product_dial_color { get; set; }
        public string product_waterproof { get; set; }
        public string product_features { get; set; }
        public string product_additional_information { get; set; }
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

