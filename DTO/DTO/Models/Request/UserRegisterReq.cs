using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom_API.DTO.Models;
public class UserRegisterReq
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
        [Required]
        [StringLength(20)]
        public string phone { get; set; }
        [Required]
        [StringLength(2000)]
        public string address { get; set; }
}

