using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom_API.DTO.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        [DataType(DataType.DateTime)]
        public DateTime created_date { get; set; } = DateTime.Now.ToUniversalTime();
        public int created_user { get; set; } = 1;
        [DataType(DataType.DateTime)]
        public DateTime updated_date { get; set; } = DateTime.Now.ToUniversalTime();
        public int updated_user { get; set; } = 1;
        public bool is_deleted { get; set; } = false;
    }

}

