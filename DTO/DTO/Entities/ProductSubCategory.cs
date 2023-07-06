using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("products_sub_categories")]
    public class ProductSubCategory
    {
        public int product_type_id { get; set; }
        public ProductType productType { get; set; }
        public int sub_category_id { get; set; }
        public SubCategory subCategory { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime created_date { get; set; } = DateTime.Now.ToUniversalTime();
        public int created_user { get; set; } = 1;
        [DataType(DataType.DateTime)]
        public DateTime updated_date { get; set; } = DateTime.Now.ToUniversalTime();
        public int updated_user { get; set; } = 1;
        public bool is_deleted { get; set; } = false;
    }
}

