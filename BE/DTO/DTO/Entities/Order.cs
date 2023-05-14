using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("orders")]
    public class Order : BaseEntity
    {
        [Required]
        public int order_id {get;set;}
        [Required]
        public int total_money_amount { get; set; }
        [Required]
        public int order_detail_id { get; set; }
        [Required]
        public int user_id { get; set; }
    }
}