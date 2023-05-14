using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("order_status")]
    public class OrderStatus : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string order_status_name { get; set; }
        [Required]
        public int order_id { get; set; }
    }
}