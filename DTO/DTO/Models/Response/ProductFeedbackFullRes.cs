using Ecom_API.DTO.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO.Models
{
    public class ProductFeedbackFullRes
    {
        public string feedback_message { get; set; }
        public List<string> feedback_images { get; set; }
        public int rating { get; set; }
        public int user_id { get; set; }
        public UserMapper User { get; set; }
    }
    public class UserMapper
    {
        public string fullname { get; set; }
        public string? avatar { get; set; }
        public bool is_admin { get; set; }
        public string? addresses { get; set; }
    }
}
