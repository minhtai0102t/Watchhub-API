using System.ComponentModel;

namespace Ecom_API.Helpers;
public static class Constants
{
    public static string SMTP_SERVER = "smtp.gmail.com";
    public static int SMTP_PORT = 587;
    public static string Gmail = "tai.pham@concung.com.vn";
    public static string AppPassword = "wagxstegwfgmnpsd";
    public static string GmailDisplayName = "Watchhub";
    public static string VerificationLinkLocal = "https://localhost:8383/Users/verify";
    public static string VerificationLinkHosting = "https://zenttt.bsite.net/Users/verify";

    public enum ORDER_STATUS{
        [Description("Chưa thanh toán")]
        UNPAID,
        [Description("Chờ thanh toán")]
        ON_HOLD,
        [Description("Chờ vận chuyển")]
        AWAITING_SHIPMENT,
        [Description("Người gửi đang chuẩn bị hàng")]
        AWAITING_COLLECTION,
        [Description("Đang giao hàng")]
        IN_TRANSIT,
        [Description("Đã giao hàng")]
        DELIVERED,
        [Description("Hoàn tất đơn hàng")]
        COMPLETED,
        [Description("Đã huỷ")]
        CANCELLED
    }
    //public static string VerificationLinkHosting = "https://watchhub.website/verify";
}
