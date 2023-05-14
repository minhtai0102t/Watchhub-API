using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("Users")]
    public class User : BaseEntity
	{
        [Required]
        [StringLength(500)]
        public string username { get; set; }
        [Required]
        [StringLength(250)]
        public string password { get; set; }
        [Required]
        [StringLength(500)]
        public string fullname { get; set; }
        [Required]
        [StringLength(200)]
        public string mail { get; set; }
        [Required]
        [StringLength(20)]
        public string role { get; set; }
    }
}

