using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_glasses")]
    public class ProductGlass : BaseEntity
    {
        [Required]
        public string glass_name;   
    }
}

