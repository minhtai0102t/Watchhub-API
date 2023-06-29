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
    public enum ORDER_STATUS
    {
        AWAITING_CONFIRMATION,
        ON_HOLD,
        AWAITING_SHIPMENT,
        AWAITING_COLLECTION,
        IN_TRANSIT,
        DELIVERED,
        CANCELLED
    }
    public enum GENDER
    {
        MALE,
        FEMALE,
        COUPLE,
        UNISEX
    }
    public enum DIAL_COLOR
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        INDIGO,
        VIOLET,
        PURPLE,
        PINK,
        BROWN,
        GRAY,
        BLACK,
        WHITE,
        CYAN,
        MAGENTA,
        SILVER,
        GOLD
    }
    public enum SORT_OPTION
    {
        NAME,
        PRICE
    }
    //public static string VerificationLinkHosting = "https://watchhub.website/verify";
}
