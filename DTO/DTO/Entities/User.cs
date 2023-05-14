using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(1000)]
        public string username { get; set; }
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
        [Required]
        [StringLength(20)]
        public string phone { get; set; }
        [Required]
        [StringLength(2000)]
        public string address { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        public List<int>? order_ids { get; set; }
    }
}

