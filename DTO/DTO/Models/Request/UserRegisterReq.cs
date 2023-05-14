using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom_API.DTO.Models;
public class UserRegisterReq
{
    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }
    [Required]
    public string fullname { get; set; }

    [Required]
    public string mail { get; set; }

    [Required]
    public string role { get; set; }
}

