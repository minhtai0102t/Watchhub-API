using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_types")]
    public class ProductType : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string product_type_name { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int price { get; set; }
        public List<string>? product_image_uuid { get; set; }
        public List<int>? product_feedback_ids { get; set; }
        public string product_source { get; set; }
        public string product_guarantee { get; set; }
        public string product_dial_width { get; set; }
        public string product_dial_height { get; set; }
        public string product_dial_color { get; set; }
        public string product_waterproof { get; set; }
        public string product_features { get; set; }
        public string product_additional_information { get; set; }
        public string gender { get; set; }
        public string product_type_code { get; set; }
        public int sold_quantity { get; set; } = 0;
        [Required]
        [ForeignKey("sub_category_id")]
        public int sub_category_id { get; set; }
        public SubCategory subCategory { get; set; }
        [Required]
        [ForeignKey("brand_id")]
        public int brand_id { get; set; }
        public Brand brand { get; set; }
        public ICollection<ProductAlbert> alberts { get; } = new List<ProductAlbert>();
        public ICollection<ProductCore> cores { get; } = new List<ProductCore>();
        public ICollection<ProductGlass> glasses { get; } = new List<ProductGlass>();
        public ICollection<Product> products { get; } = new List<Product>();
    }
}