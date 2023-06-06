using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Models
{
    public class ProductTypeFullRes
    {
        public string product_type_name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public List<string>? product_image_uuid { get; set; }
        public int brand_id { get; set; }
        public string brand_name { get; set; }
        public string brand_logo { get; set; }
        public int sub_category_id { get; set; }
        public string sub_category_name { get; set; }
        public List<int>? product_feedback_ids { get; set; }
    }
}