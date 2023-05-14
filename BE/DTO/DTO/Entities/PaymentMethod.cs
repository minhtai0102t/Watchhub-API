using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("payment_methods")]
    public class PaymentMethod : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string payment_method_name {get;set;}
    }
}