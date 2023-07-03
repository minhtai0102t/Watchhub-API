using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [ForeignKey("product_type_id")]
        public int? product_type_id { get; set; }
        public ProductType productType { get; set; }
        public string product_code { get; set; }
    }
}

