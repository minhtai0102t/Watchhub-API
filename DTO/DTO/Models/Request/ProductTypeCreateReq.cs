
namespace Ecom_API.DTO.Models;
public class ProductTypeCreateReq
{
    public string product_type_name { get; set; }
    public List<string> product_image_uuid { get; set; }
    public int quantity {get;set;}
    public int price {get;set;}
    public int brand_id { get; set; }
    public int sub_category_id { get; set; }
    public List<int> product_albert_ids { get; set; }
    public List<int> product_core_ids { get; set; }
    public List<int> product_glass_ids { get; set; }
}