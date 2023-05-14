using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("payments")]
    public class Payment : BaseEntity
    {
        [Required]
        public bool isPaid { get; set; }
        [Required]
        public int order_id { get; set; }
        [Required]
        public int payment_method_id { get; set; }
    }
}