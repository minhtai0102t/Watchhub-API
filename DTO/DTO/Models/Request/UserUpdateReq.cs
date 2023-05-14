using System;
namespace Ecom_API.DTO.Models
{
	public class UserUpdateReq
	{
        public string username { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string mail { get; set; }
        public string role { get; set; }
    }
}

