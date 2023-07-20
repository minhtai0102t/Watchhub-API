using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("orders")]
    public class Order : BaseEntity
    {
        [Required]
        // Json [{"quantity: 5", "items: [{"asdsad", "dasdas"}]}]
        public string order_info { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public int total_amount { get; set; }
        [Required]
        public int payment_method_id { get; set; }
        [Required]
        public string order_status { get; set; }
        [Required]
        public string province { get; set; }
        [Required]
        public string district { get; set; }
        [Required]
        public string ward { get; set; }
        [Required]
        public string street { get; set; }
        public List<string>? product_image_uuid { get; set; }
        public List<int> product_type_ids { get; set; }
        [PhoneNumber(ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }
        public string cancel_reason { get; set; }
    }
}