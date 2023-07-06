using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_alberts")]
    public class ProductAlbert : BaseEntity
    {
        [Required]
        public string albert_name { get; set; }
        [ForeignKey("product_type_id")]
        public IEnumerable<ProductType> productTypes { get; } = new List<ProductType>();

    }
}


