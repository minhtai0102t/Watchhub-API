using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_cores")]
    public class ProductCore : BaseEntity
    {
        [Required]
        public string core_name { get; set; }
    }
}

