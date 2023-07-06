using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("brands")]
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string brand_name { get; set; }
        [Required]
        [StringLength(1000)]
        public string brand_logo { get; set; }
        public IEnumerable<ProductType> productTypes { get;} = new List<ProductType>();

    }
}