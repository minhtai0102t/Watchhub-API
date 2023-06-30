using Ecom_API.DTO.Entities;

namespace Ecom_API.DTO.Models
{
    public class ProductTypeFullRes : BaseEntity
    {
        public int id { get; set; }
        public string? product_type_name { get; set; }
        public int? quantity { get; set; }
        public int? price { get; set; }
        public List<string>? product_image_uuid { get; set; }
        public int? brand_id { get; set; }
        public string? brand_name { get; set; }
        public string? brand_logo { get; set; }
        public int? sub_category_id { get; set; }
        public string? sub_category_name { get; set; }
        public List<int>? product_feedback_ids { get; set; }
        public ProductAlbert? alberts { get; set; }
        public ProductCore? cores { get; set; }
        public ProductGlass? glasses { get; set; }
        public string? product_source { get; set; }
        public string? product_guarantee { get; set; }
        public string? product_dial_width { get; set; }
        public string? product_dial_height { get; set; }
        public string? product_dial_color { get; set; }
        public string? product_waterproof { get; set; }
        public string? product_features { get; set; }
        public string? product_additional_information { get; set; }
        public string gender { get; set; }
        public string product_type_code { get; set; }
        public int? sold_quantity { get; set; }
    }
}