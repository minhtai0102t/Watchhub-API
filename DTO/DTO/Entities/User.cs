using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [StringLength(1000)]
        public string? username { get; set; }
        [Required]
        [StringLength(250)]
        public string password { get; set; }
        [Required]
        [StringLength(1000)]
        public string fullname { get; set; }
        [Required]
        [StringLength(200)]
        public string email { get; set; }
        [StringLength(1000)]
        public string? avatar { get; set; }
        [StringLength(20)]
        public string? phone { get; set; }
        [StringLength(2000)]
        public bool is_admin { get; set; }
        public bool is_verified { get; set; }
        public List<int>? order_ids { get; set; }
        public string? addresses { get; set; }
        public ICollection<ProductFeedback> productFeedbacks { get; set; } = new List<ProductFeedback>();
    }
}

