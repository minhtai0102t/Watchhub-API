using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_types")]
    public class ProductType : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string product_type_name { get; set; }
        [Required]
        public int quantity {get;set;}
        [Required]
        public int price {get;set;}
    }
}