
namespace Ecom_API.DTO.Models
{
    public class GoogleUser
    {
        public string name { get; set; }
        public string picture { get; set; }
        public string user_id { get; set; }
        public string email { get; set; }
        public bool isGoogleAccount { get; set; } = true;
    }
}

