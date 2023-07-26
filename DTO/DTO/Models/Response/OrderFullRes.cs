using Ecom_API.DTO.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO.Models
{
    public class OrderFullRes : BaseEntity
    {
        [Required]
        // Json [{"quantity: 5", "items: [{"asdsad", "dasdas"}]}]
        public string order_info { get; set; }
        public int user_id { get; set; }
        public int total_amount { get; set; }
        public int payment_method_id { get; set; }
        public string order_status { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string street { get; set; }
        public List<string>? product_image_uuid { get; set; }
        public List<int> product_type_ids { get; set; }
        public string phone { get; set; }
        public string cancel_reason { get; set; }
        public bool isPaid { get; set; }
        public int? vnpay_id { get; set; }
        public VNPayMapper? vnpay { get; set; }
    }
    public class VNPayMapper
    {
        public string Amount { get; set; }
        public string BankCode { get; set; }
        public string BankTranNo { get; set; }
        public string CardType { get; set; }
        public string OrderInfo { get; set; }
        public string PayDate { get; set; }
        public string ResponseCode { get; set; }
        public string TmnCode { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionStatus { get; set; }
        public string TxnRef { get; set; }
        public string SecureHash { get; set; }
    }
}
