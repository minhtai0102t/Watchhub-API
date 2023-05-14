using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_images")]
    public class ProductImage : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string product_image_url { get; set; }
    }
}