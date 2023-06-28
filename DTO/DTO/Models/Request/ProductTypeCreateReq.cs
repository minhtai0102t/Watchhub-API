
using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class ProductTypeCreateReq
{
    public string product_type_name { get; set; }
    public List<string> product_image_uuid { get; set; }
    public int quantity { get; set; }
    public int price { get; set; }
    public int brand_id { get; set; }
    public int sub_category_id { get; set; }
    public int product_albert_id { get; set; }
    public int product_core_id { get; set; }
    public int product_glass_id { get; set; }
    public string product_source { get; set; }
    public string product_guarantee { get; set; }
    public string product_dial_width { get; set; }
    public string product_dial_height { get; set; }
    public DIAL_COLOR product_dial_color { get; set; }
    public string product_waterproof { get; set; }
    public string product_features { get; set; }
    public string product_additional_information { get; set; }
    public GENDER gender { get; set; }
    public string product_type_code { get; set; }
}