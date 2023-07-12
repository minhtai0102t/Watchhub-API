using Ecom_API.DTO.Entities;

namespace Ecom_API.DTO.Models
{
    public class ProductTypeFullRes : BaseEntity
    {
        public string product_type_name { get; set; }
        public int quantity { get; set; }
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
        public int sold_quantity { get; set; }
        public int brand_id { get; set; }
        public BrandMapper brand { get; set; }
        public int product_albert_id { get; set; }
        public AlbertMapper albert { get; set; }
        public int product_core_id { get; set; }
        public CoreMapper core { get; set; }
        public int product_glass_id { get; set; }
        public GlassMapper glass { get; set; }
        public ICollection<ProductSubCategoryMapper> productSubCategories { get; set; }
        public ICollection<ProductMapper> products { get; set; }
    }   
    public class ProductSubCategoryMapper
    {
        public int product_type_id { get; set; }
        public int sub_category_id { get; set; }
        public int category_id { get; set; }
        public string sub_category_name { get; set; }
    }
    public class BrandMapper
    {
        public string brand_name { get; set; }
        public string brand_logo { get; set; }
    }
    public class AlbertMapper
    {
        public string albert_name { get; set; }
    }
    public class CoreMapper
    {
        public string core_name { get; set; }
    }
    public class GlassMapper
    {
        public string glass_name { get; set; }
    }
    public class ProductMapper
    {
        public string product_code { get; set; }
    }
}