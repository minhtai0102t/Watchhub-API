using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom_API.DTO.Models;
public class UserRegisterReq
{
    [Required]
    [StringLength(500)]
    public string fullname { get; set; }
    [Required]
    [StringLength(200)]
    public string email { get; set; }
    [Required]
    [StringLength(100)]
    public string password { get; set; }
}

