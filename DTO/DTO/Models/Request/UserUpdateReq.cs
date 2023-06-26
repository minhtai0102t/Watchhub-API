using System;
namespace Ecom_API.DTO.Models
{
    public class UserUpdateReq
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
        public List<UserAddress> userAddresses { get; set; }
        public class UserAddress
        {
            public string province { get; set; }
            public string district { get; set; }
            public string ward { get; set; }
            public string street { get; set; }
        }
    }
}

