﻿using System;
namespace Ecom_API.DTO.Models
{
	public class UserUpdateReq
	{
        public string username { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
    }
}

