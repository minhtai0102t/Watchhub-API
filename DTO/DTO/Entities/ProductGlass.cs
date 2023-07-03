using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_glasses")]
    public class ProductGlass : BaseEntity
    {
        [Required]
        public string glass_name { get; set; }
        [ForeignKey("product_type_id")]
        public int? product_type_id { get; set; }   
        public ProductType productType { get; set; }

    }
}

