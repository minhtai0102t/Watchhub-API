using System.ComponentModel.DataAnnotations;

namespace DTO.DTO.Models.Request
{
    public class ProductCreateReq
    {
        public string product_source { get; set; }
        public string product_guarantee { get; set; }
        public string product_dial_width { get; set; }
        public string product_dial_height { get; set; }
        public string product_dial_color { get; set; }
        public string product_waterproof { get; set; }
        public string product_features { get; set; }
        public string product_additional_information { get; set; }
        public int product_type_id { get; set; }
        public int product_albert_id { get; set; }
        public int product_core_id { get; set; }
        public int product_glass_id { get; set; }
    }
}
