using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("order_details")]
    public class OrderDetail : BaseEntity
    {
        [Required]
        public int quantity { get; set; }
         [Required]
        public int money_amount { get; set; }
        [Required]
        public List<int> product_ids { get; set; }
    }
}