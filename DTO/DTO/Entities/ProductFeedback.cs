using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("product_feedbacks")]
    public class ProductFeedback : BaseEntity
    {
        [Required]
        [MaxLength]
        public string feedback_message { get; set; }
        public List<string> feedback_images { get; set; }
        public int rating { get; set; }
        [Required]
        public int user_id { get; set; }
        public User User { get; set; }
        [Required]
        public int product_type_id { get; set; }
        public ProductType ProductType { get; set; }
    }
}