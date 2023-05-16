﻿using System;
namespace Ecom_API.DTO.Models;
using System.ComponentModel.DataAnnotations;

public class AuthenticateReq
{
    [Required]
    public string email { get; set; }

    [Required]
    public string password { get; set; }
}