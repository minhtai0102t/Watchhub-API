using System;
using Ecom_API.DTO.Entities;
namespace Ecom_API.DTO.Models;

public class AuthenticateRes : BaseEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Token { get; set; }
}

