using System.ComponentModel.DataAnnotations;

namespace DTO.DTO.Models
{
    public class ProductFeedbackCreateReq
    {
        public string feedback_message { get; set; }
        public List<string> feedback_images { get; set; }
        [Range(1, 5, ErrorMessage = "Rating action must be from 1 star to 5 stars")]
        public int rating { get; set; }
        public int user_id { get; set; }
        public int product_type_id { get; set; }
    }
}
