using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Entities
{
    [Table("vnpay_payment")]
    public class VNPay : BaseEntity
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
        public int UserID { get; set; }
        public User User { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}