
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Ecom_API.Helpers
{
    public static class MomoUtil
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> CreatePaymentMomo()
        {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();

            string accessKey = "F8BBA842ECF85";
            string secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";

            QuickPayResquest request = new QuickPayResquest();
            request.orderInfo = "pay with MoMo";
            request.partnerCode = "MOMO";
            request.redirectUrl = "";
            request.ipnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            request.amount = 5000;
            request.orderId = myuuidAsString;
            request.requestId = myuuidAsString;
            request.extraData = "";
            request.partnerName = "MoMo Payment";
            request.storeId = "Test Store";
            request.orderGroupId = "";
            request.autoCapture = true;
            request.lang = "vi";

            var rawSignature = "accessKey=" + accessKey + "&amount=" + request.amount + "&extraData=" + request.extraData + "&orderId=" + request.orderId + "&orderInfo=" + request.orderInfo + "&partnerCode=" + request.partnerCode + "&paymentCode=" + request.paymentCode + "&requestId=" + request.requestId;
            request.signature = getSignature(rawSignature, secretKey);

            StringContent httpContent = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");
            var quickPayResponse = await client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);
            var contents = quickPayResponse.Content.ReadAsStringAsync().Result;
            return contents;
        }

        private static String getSignature(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
    public class QuickPayResquest
    {
        public string orderInfo { get; set; }
        public string partnerCode { get; set; }
        public string redirectUrl { get; set; }
        public string ipnUrl { get; set; }
        public long amount { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public string extraData { get; set; }
        public string partnerName { get; set; }
        public string storeId { get; set; }
        public string paymentCode { get; set; }
        public string orderGroupId { get; set; }
        public bool autoCapture { get; set; }
        public string lang { get; set; }
        public string signature { get; set; }
    }
}
