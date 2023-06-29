using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class OrderCreateReq
{
    public int user_id { get; set; }
    public List<OrderInfo> items { get; set; }
    public int total_amount { get; set; }
    public int payment_method_id { get; set; }
    public ORDER_STATUS order_status { get; set; }
    public class OrderInfo
    {
        public int id { get; set; }
        public int quantity { get; set; }
    }
    public string province { get; set; }
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }
    public List<string>? product_image_uuid { get; set; }
}
