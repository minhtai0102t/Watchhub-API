
namespace Ecom_API.DTO.Models;
public class ProductTypeCreateReq
{
    public string product_type_name { get; set; }
    public int quantity {get;set;}
    public int price {get;set;}
    public int brand_id { get; set; }
    public int sub_category_id { get; set; }
}