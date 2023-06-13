using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        public int product_type_id { get; set; }
    }
}

