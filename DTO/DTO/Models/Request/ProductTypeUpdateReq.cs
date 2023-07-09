
using System.ComponentModel.DataAnnotations;
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class ProductTypeUpdateReq
{
    [StringLength(1000)]
    public string product_type_name { get; set; }
    public int quantity { get; set; }
    public int price { get; set; }
    public List<string>? product_image_uuid { get; set; }
    public List<int>? product_feedback_ids { get; set; }
    public List<int> sub_category_ids { get; set; }
    public string product_source { get; set; }
    public string product_guarantee { get; set; }
    public string product_dial_width { get; set; }
    public string product_dial_height { get; set; }
    public string product_dial_color { get; set; }
    public string product_waterproof { get; set; }
    public string product_features { get; set; }
    public string product_additional_information { get; set; }
    public string gender { get; set; }
    public int sold_quantity { get; set; }
    public int brand_id { get; set; }
    public int? product_albert_id { get; set; }
    public int? product_core_id { get; set; }
    public int? product_glass_id { get; set; }
}